using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using Sky.Core;
using Sky.SubForms;
using System.Reflection;
using System.Text.Json;
using System.Drawing.Text;

namespace Sky
{
    public partial class MainForm : Form
    {
        private bool mouseDown;
        private Point lastLocation;

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
                    config = JsonSerializer.Deserialize<Config>(conf);
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
                var configJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull });
                File.WriteAllText(configDir, configJson);
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

            MessageBox.Show("Move editor is not finished yet... Coming soon.");
        }

        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }
    }
}