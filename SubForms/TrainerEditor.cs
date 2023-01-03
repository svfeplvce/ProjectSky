using Sky.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sky.SubForms
{
    public partial class TrainerEditor : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private Assembly assembly = MainForm.assembly;
        private readonly string outPath = MainForm.outDir;
        private Trainer.TrainerArray trainer;
        private CurrentTrainer currentTrainer = new CurrentTrainer { };
        public List<string> abilityNames = new List<string> { };
        public List<string> moveNames = new List<string> { };
        public List<string> itemNames = new List<string> { };
        public List<string> speciesNames = new List<string> { };

        public Trainer.TrainerArray _trainer
        {
            get { return trainer; }
            set { trainer = value; }
        }

        public CurrentTrainer _currentTrainer
        {
            get { return currentTrainer; }
            set { currentTrainer = value; }
        }

        public TrainerEditor()
        {
            InitializeComponent();
            LoadNecessaryFiles();
        }

        private void LoadNecessaryFiles()
        {
            // text files

            var abilityTextFile = assembly.GetManifestResourceStream("Sky.Assets.TextFiles.abilities.txt");
            var itemTextFile = assembly.GetManifestResourceStream("Sky.Assets.TextFiles.items.txt");
            var moveTextFile = assembly.GetManifestResourceStream("Sky.Assets.TextFiles.moves.txt");
            var speciesTextFile = assembly.GetManifestResourceStream("Sky.Assets.TextFiles.species.txt");
            using (var abilityReader = new StreamReader(abilityTextFile))
            using (var itemReader = new StreamReader(itemTextFile))
            using (var moveReader = new StreamReader(moveTextFile))
            using (var speciesReader = new StreamReader(speciesTextFile))
            {
                while (abilityReader.Peek() >= 0)
                {
                    abilityNames.Add(abilityReader.ReadLine());
                }
                while (moveReader.Peek() >= 0)
                {
                    moveNames.Add(moveReader.ReadLine());
                }
                while (speciesReader.Peek() >= 0)
                {
                    speciesNames.Add(speciesReader.ReadLine());
                }
                while (itemReader.Peek() >= 0)
                {
                    itemNames.Add(itemReader.ReadLine());
                }
            }

            // the 2 jsons

            var trainerFile = File.Exists(Path.Combine(outPath, "trdata_array.json")) ? File.Open(Path.Combine(outPath, "trdata_array.json"), FileMode.Open) : assembly.GetManifestResourceStream("Sky.Assets.JSON.trdata_array.json");
            var trainerDevIDFile = assembly.GetManifestResourceStream("Sky.Assets.JSON.trdev_id.json");
            var pokeDevIDFile = assembly.GetManifestResourceStream("Sky.Assets.JSON.devid_list.json");
            using (var trainerReader = new StreamReader(trainerFile))
            using (var trainerDevIDReader = new StreamReader(trainerDevIDFile))
            using (var pokeDevIDReader = new StreamReader(pokeDevIDFile))
            {
                var trainerJson = trainerReader.ReadToEnd();
                var trainerDevIDJson = trainerDevIDReader.ReadToEnd();
                var pokeDevIDJson = pokeDevIDReader.ReadToEnd();

                trainer = JsonSerializer.Deserialize<Trainer.TrainerArray>(trainerJson);
            }
        }

        // top panel shit

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
    }
}
