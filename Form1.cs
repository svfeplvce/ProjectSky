using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using Sky.Core;
using Sky.SubForms;
using System.Reflection;
using System.Text.Json;

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

        public MainForm()
        {
            InitializeComponent();

            pictureBox1.BackgroundImage = Image.FromStream(assembly.GetManifestResourceStream("Sky.Assets.Images.sky_logo.png"));

            InitConfig();
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
            /*
            Form editor = new TrainerEditor();
            editor.FormClosed += Editor_FormClosed;
            editor.Show();
            Hide();
            */

            MessageBox.Show("Trainer editor is not finished yet... Coming soon.");
        }

        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }
    }
}