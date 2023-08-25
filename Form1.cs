using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using Sky.Core;
using Sky.SubForms;
using System.Reflection;
using System.Text.Json;
using System.Drawing.Text;
using static Sky.Core.TrainerDevID;
using CliWrap;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using System.Net;
using System.ComponentModel;
using CliWrap.Buffered;
using System.Diagnostics;

namespace Sky
{
    public partial class MainForm : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private Core.Trainer.TrainerArray trainerOrig;
        private Core.Trainer.TrainerArray trainerNew;
        private Personal.PersonalArray personalOrig;
        private Personal.PersonalArray personalNew;
        private PokeData.DataArray pdataOrig;
        private PokeData.DataArray pdataNew;
        private Plib.PlibArray plibOrig;
        private Plib.PlibArray plibNew;
        private List<string> update = new List<string> { };

        public readonly string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static Config config;
        public static string outDir;
        public static readonly Assembly assembly = Assembly.GetExecutingAssembly();
        public static PrivateFontCollection pfc = new PrivateFontCollection();

        public MainForm()
        {
            InitializeComponent();

            pictureBox1.BackgroundImage = Image.FromStream(assembly.GetManifestResourceStream("Sky.Assets.Images.sky_logo.png"));

            AddFontFromResource(pfc, "Sky.Assets.Fonts.Akira.ttf");
            AddFontFromResource(pfc, "Sky.Assets.Fonts.BankGothic.ttf");
            AddFontFromResource(pfc, "Sky.Assets.Fonts.DripIcons.ttf");
            AddFontFromResource(pfc, "Sky.Assets.Fonts.Montserrat.ttf");

            PokemonButton.Font = new Font(pfc.Families[1], 20, FontStyle.Regular);
            moveButton.Font = new Font(pfc.Families[1], 20, FontStyle.Regular);
            TrainerButton.Font = new Font(pfc.Families[1], 20, FontStyle.Regular);
            label1.Font = new Font(pfc.Families[0], 28, FontStyle.Regular);
            label2.Font = new Font(pfc.Families[3], 16, FontStyle.Regular);
            exitButton.Font = new Font(pfc.Families[2], 12, FontStyle.Regular);

            InitConfig();
            CheckUpdate();
            CheckBins();
        }

        private async void CheckUpdate()
        {
            var currentVersion = "1.1.5";
            
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "http://developer.github.com/v3/#user-agent-required");
                var result = await client.GetAsync("https://api.github.com/repos/svfeplvce/ProjectSky/releases/latest");
                var response = await result.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<Dictionary<string,object>>(response);
                var newVersion = content["name"].ToString();
                bool curIsNew = currentVersion == newVersion;

                if (!curIsNew)
                {
                    var box = MessageBox.Show($"New update found (version {newVersion}). Update?", "Update Found", MessageBoxButtons.YesNo);
                    if (box == DialogResult.Yes)
                    {
                        var downloadUrl = $"https://github.com/svfeplvce/ProjectSky/releases/download/v{newVersion}/ProjectSky_{newVersion}.zip";
                        await DownloadUpdate(downloadUrl);
                        Process.Start("Updater.exe");
                        Close();
                    }
                }
            }
        }

        private async Task DownloadUpdate(string Url)
        {
            using (WebClient wc = new WebClient())
            {
                await wc.DownloadFileTaskAsync(
                    new Uri(Url),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "new.zip"));
            }
        }

        private void AddFontFromResource(PrivateFontCollection fonts, string fontResourceName)
        {
            var fontBytes = GetBytesOfFont(fontResourceName);
            var fontData = Marshal.AllocCoTaskMem(fontBytes.Length);
            Marshal.Copy(fontBytes, 0, fontData, fontBytes.Length);
            fonts.AddMemoryFont(fontData, fontBytes.Length);
        }

        private static byte[] GetBytesOfFont(string fontResourceName)
        {
            var stream = assembly.GetManifestResourceStream(fontResourceName);
            if (stream == null) throw new Exception("Oops!");
            var bytes = new byte[stream.Length];
            stream.Read(bytes, 0, (int)stream.Length);
            stream.Close();
            return bytes;
        }

        private void InitConfig()
        {
            var configDir = Path.Combine(exeDir, "config.json");
            if (File.Exists(configDir))
            {
                using (var r = new StreamReader(configDir))
                {
                    var conf = r.ReadToEnd();
                    config = System.Text.Json.JsonSerializer.Deserialize<Config>(conf);
                    outDir = config.outPath;
                }
            } else
            {
                MessageBox.Show("Select an output directory!");
                config = new Config();
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult res = fbd.ShowDialog();

                    if (res == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        config.outPath = fbd.SelectedPath;
                    }
                }
                outDir = config.outPath;
                var configJson = System.Text.Json.JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull });
                File.WriteAllText(configDir, configJson);
            }
        }

        private void CheckBins()
        {
            var newTrDataExists = File.Exists(Path.Combine(config.outPath, "trdata_array.json"));
            var newPersonalExists = File.Exists(Path.Combine(config.outPath, "personal_array.json"));
            var newPDataExists = File.Exists(Path.Combine(config.outPath, "pokedata_array.json"));

            if (newTrDataExists)
            {
                update.Add("trdata");
            }

            if (newPersonalExists)
            {
                update.Add("personal");
            }

            if (newPDataExists)
            {
                update.Add("pdata");
            }

            if (update.Count >= 1)
            {
                UpdateBins();
            }
        }

        private async void UpdateBins()
        {
            var trdataOrigFile = assembly.GetManifestResourceStream("Sky.Assets.JSON.trdata_array.json");
            FileStream trdataNewFile = null;

            if (update.Contains("trdata"))
            {
                File.Copy(Path.Combine(outDir, "trdata_array.json"), Path.Combine(outDir, "trdata_array_2.json"));
                trdataNewFile = File.Open(Path.Combine(config.outPath, "trdata_array_2.json"), FileMode.Open);
            }

            var personalOrigFile = assembly.GetManifestResourceStream("Sky.Assets.JSON.personal_array.json");
            FileStream personalNewFile = null;

            if (update.Contains("personal"))
            {
                File.Copy(Path.Combine(outDir, "personal_array.json"), Path.Combine(outDir, "personal_array_2.json"));
                personalNewFile = File.Open(Path.Combine(config.outPath, "personal_array_2.json"), FileMode.Open);
            }

            var pdataOrigFile = assembly.GetManifestResourceStream("Sky.Assets.JSON.pokedata_array.json");
            FileStream pdataNewFile = null;

            if (update.Contains("pdata"))
            {
                File.Copy(Path.Combine(outDir, "pokedata_array.json"), Path.Combine(outDir, "pokedata_array_2.json"));
                pdataNewFile = File.Open(Path.Combine(config.outPath, "pokedata_array_2.json"), FileMode.Open);
            }

            using (var personalReader = new StreamReader(personalOrigFile))
            using (var pdataReader = new StreamReader(pdataOrigFile))
            using (var trdataReader = new StreamReader(trdataOrigFile))
            {

                foreach (var x in update)
                {
                    if (x == "trdata")
                    {
                        using (var trdataNewReader = new StreamReader(trdataNewFile))
                        {
                            var trdataOrigJson = trdataReader.ReadToEnd();
                            var trdataNewJson = trdataNewReader.ReadToEnd();

                            trainerOrig = System.Text.Json.JsonSerializer.Deserialize<Core.Trainer.TrainerArray>(trdataOrigJson);
                            trainerNew = System.Text.Json.JsonSerializer.Deserialize<Core.Trainer.TrainerArray>(trdataNewJson);

                            for (var i = 0; i < trainerOrig.values.Count; i++)
                            {
                                if (trainerNew.values[i] == null)
                                {
                                    trainerNew.values[i] = trainerOrig.values[i];

                                    var path = Path.Combine(outDir, "trdata_array.json");

                                    var json = System.Text.Json.JsonSerializer.Serialize(trainerNew, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

                                    await File.WriteAllTextAsync(path, json);
                                }
                            }
                        }
                        File.Delete(Path.Combine(outDir, "trdata_array_2.json"));
                    }
                    else if (x == "personal")
                    {
                        using (var personalNewReader = new StreamReader(personalNewFile))
                        {
                            var personalOrigJson = personalReader.ReadToEnd();
                            var personalNewJson = personalNewReader.ReadToEnd();

                            personalOrig = System.Text.Json.JsonSerializer.Deserialize<Personal.PersonalArray>(personalOrigJson);
                            personalNew = System.Text.Json.JsonSerializer.Deserialize<Personal.PersonalArray>(personalNewJson);

                            for (var i = 0; i < personalOrig.entry.Count; i++)
                            {
                                if (personalNew.entry[i] == null || personalOrig.entry[i].species.species == 987 && personalNew.entry[i].type_1 == 12 || personalOrig.entry[i].species.species == 980 && personalNew.entry[i].type_1 == 12)
                                {
                                    personalNew.entry[i] = personalOrig.entry[i];

                                    var path = Path.Combine(outDir, "personal_array.json");

                                    var json = System.Text.Json.JsonSerializer.Serialize(personalNew, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

                                    await File.WriteAllTextAsync(path, json);
                                }
                            }
                        }
                        File.Delete(Path.Combine(outDir, "personal_array_2.json"));
                    }
                    else if (x == "pdata")
                    {
                        using (var pdataNewReader = new StreamReader(pdataNewFile))
                        {
                            var pdataOrigJson = pdataReader.ReadToEnd();
                            var pdataNewJson = pdataNewReader.ReadToEnd();

                            pdataOrig = System.Text.Json.JsonSerializer.Deserialize<PokeData.DataArray>(pdataOrigJson);
                            pdataNew = System.Text.Json.JsonSerializer.Deserialize<PokeData.DataArray>(pdataNewJson);

                            for (var i = 0; i < pdataOrig.values.Count; i++)
                            {
                                if (pdataNew.values[i] == null)
                                {
                                    pdataNew.values[i] = pdataOrig.values[i];

                                    var path = Path.Combine(outDir, "pokedata_array.json");

                                    var json = System.Text.Json.JsonSerializer.Serialize(pdataNew, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

                                    await File.WriteAllTextAsync(path, json);
                                }
                            }
                        }
                        File.Delete(Path.Combine(outDir, "pokedata_array_2.json"));
                    }
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized; 
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point((Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);
                Update();
            }
        }

        private void PokemonButton_Click(object sender, EventArgs e)
        {
            Form editor = new PokemonEditor();
            editor.FormClosed += Editor_FormClosed;
            editor.Show();
            Hide();
        }

        private void TrainerButton_Click(object sender, EventArgs e)
        {
            Form editor = new TrainerEditor();
            editor.FormClosed += Editor_FormClosed;
            editor.Show();
            Hide();
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            /*
            Form editor = new MoveEditor();
            editor.FormClosed += Editor_FormClosed;
            editor.Show();
            Hide();
            */
            MessageBox.Show("Move editor is coming soon...");
        }

        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }
    }
}