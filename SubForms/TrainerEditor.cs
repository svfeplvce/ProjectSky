using CliWrap;
using CliWrap.Buffered;
using Siticone.Desktop.UI.WinForms;
using Sky.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sky.Core.MoveDevID;
using static Sky.Core.Personal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sky.SubForms
{
    public partial class TrainerEditor : Form
    {
        private bool mouseDown;
        private bool initialised = false;
        private Point lastLocation;
        private Assembly assembly = MainForm.assembly;
        private readonly string outPath = MainForm.outDir;
        private Trainer.TrainerArray trainer;
        private CurrentTrainer currentTrainer = new CurrentTrainer { };
        private TrainerDevID.DevID trainerDevID;
        private PokeDevID.DevID pokeDevID;
        private MoveDevID.DevID moveDevID;
        private ItemDevID.DevID itemDevID;
        public List<string> abilityNames = new List<string> { };
        public List<string> moveNames = new List<string> { };
        public List<string> itemNames = new List<string> { };
        public List<string> speciesNames = new List<string> { };
        public List<string> trainerNames = new List<string> { };
        private List<Tuple<string, string, int>> items = new List<Tuple<string, string, int>> { };
        private List<string> ballNames = new List<string> { "None", "Master Ball", "Ultra Ball", "Great Ball", "Poké Ball", "Safari Ball", "Net Ball", "Dive Ball", "Nest Ball", "Repeat Ball", "Timer Ball", "Luxury Ball", "Premier Ball", "Dusk Ball", "Heal Ball", "Quick Ball", "Fast Ball", "Level Ball", "Lure Ball", "Heavy Ball", "Love Ball", "Friend Ball", "Moon Ball", "Sport Ball", "Dream Ball", "Beast Ball" };
        private List<string> alolaForms = new List<string> { "Rattata", "Raticate", "Raichu", "Sandshrew", "Sandslash", "Vulpix", "Ninetales", "Diglett", "Dugtrio", "Meowth", "Persian", "Geodude", "Graveler", "Golem", "Grimer", "Muk", "Exeggutor", "Marowak" };
        private List<string> galarForms = new List<string> { "Meowth", "Ponyta", "Rapidash", "Weezing", "Corsola", "Zigzagoon", "Linoone", "Darumaka", "Darmanitan", "Yamask", "Stunfisk", "Slowpoke", "Slowbro", "Slowking", "Articuno", "Zapdos", "Moltres" };
        private List<string> hisuiForms = new List<string> { "Lilligant", "Growlithe", "Arcanine", "Voltorb", "Electrode", "Typhlosion", "Samurott", "Decidueye", "Qwilfish", "Sneasel", "Zorua", "Zoroark", "Braviary", "Sliggoo", "Goodra", "Avalugg" };
        private List<string> paldeaForms = new List<string> { "Wooper" };
        private List<string> megaForms = new List<string> { "Venusaur", "Blastoise", "Alakazam", "Gengar", "Kangaskhan", "Pinsir", "Gyarados", "Aerodactyl", "Ampharos", "Scizor", "Heracross", "Houndoom", "Tyranitar", "Blaziken", "Gardevoir", "Gallade", "Mawile", "Aggron", "Medicham", "Manectric", "Banette", "Absol", "Latios", "Latias", "Garchomp", "Lucario", "Abomasnow", "Beedrill", "Pidgeot", "Slowbro", "Steelix", "Sceptile", "Swampert", "Sableye", "Sharpedo", "Camerupt", "Altaria", "Glalie", "Salamence", "Metagross", "Rayquaza", "Lopunny", "Audino", "Diancie" };
        private List<string> miscForms = new List<string> { "Dialga", "Palkia", "Giratina", "Kyogre", "Groudon" };
        private Dictionary<string, string> speciesToDevID = new Dictionary<string, string>();
        private Dictionary<string, string> ballToDevID = new Dictionary<string, string>();
        private Dictionary<string, string> typeToGemName = new Dictionary<string, string>() { { "Normal", "NORMAL" }, { "Fighting", "KAKUTOU" }, { "Flying", "HIKOU" }, { "Poison", "DOKU" }, { "Ground", "JIMEN" }, { "Rock", "IWA" }, { "Bug", "MUSHI" }, { "Ghost", "GHOST" }, { "Steel", "HAGANE" }, { "Fire", "HONOO" }, { "Water", "MIZU" }, { "Grass", "KUSA" }, { "Electric", "DENKI" }, { "Psychic", "ESPER" }, { "Ice", "KOORI" }, { "Dragon", "DRAGON" }, { "Dark", "AKU" }, { "Fairy", "FAIRY" } };

        public TrainerEditor()
        {
            InitializeComponent();

            pictureBox1.BackgroundImage = Image.FromStream(assembly.GetManifestResourceStream("Sky.Assets.Images.sky_logo.png"));

            LoadNecessaryFiles();

            FillFields();
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

            var exists = File.Exists(Path.Combine(outPath, "trdata_array.json"));
            var trainerFile = File.Exists(Path.Combine(outPath, "trdata_array.json")) ? File.Open(Path.Combine(outPath, "trdata_array.json"), FileMode.Open) : assembly.GetManifestResourceStream("Sky.Assets.JSON.trdata_array.json");
            var trainerDevIDFile = assembly.GetManifestResourceStream("Sky.Assets.JSON.trdev_id.json");
            var pokeDevIDFile = assembly.GetManifestResourceStream("Sky.Assets.JSON.devid_list.json");
            var moveDevIDFile = assembly.GetManifestResourceStream("Sky.Assets.JSON.move_list.json");
            var itemDevIDFile = assembly.GetManifestResourceStream("Sky.Assets.JSON.item_list.json");
            using (var trainerReader = new StreamReader(trainerFile))
            using (var trainerDevIDReader = new StreamReader(trainerDevIDFile))
            using (var pokeDevIDReader = new StreamReader(pokeDevIDFile))
            using (var moveDevIDReader = new StreamReader(moveDevIDFile))
            using (var itemDevIDReader = new StreamReader(itemDevIDFile))
            {
                var trainerJson = trainerReader.ReadToEnd();
                var trainerDevIDJson = trainerDevIDReader.ReadToEnd();
                var pokeDevIDJson = pokeDevIDReader.ReadToEnd();
                var moveDevIDJson = moveDevIDReader.ReadToEnd();
                var itemDevIDJson = itemDevIDReader.ReadToEnd();

                trainer = JsonSerializer.Deserialize<Trainer.TrainerArray>(trainerJson);
                trainerDevID = JsonSerializer.Deserialize<TrainerDevID.DevID>(trainerDevIDJson);
                pokeDevID = JsonSerializer.Deserialize<PokeDevID.DevID>(pokeDevIDJson);
                moveDevID = JsonSerializer.Deserialize<MoveDevID.DevID>(moveDevIDJson);
                itemDevID = JsonSerializer.Deserialize<ItemDevID.DevID>(itemDevIDJson);

                currentTrainer = new CurrentTrainer { Data = trainer.values[0], DevID = trainer.values[0].trid, Index = 0, Name = trainerDevID.trainers.First(x => x.dev_id == trainer.values[0].trid).name };

                foreach (var x in trainerDevID.trainers)
                {
                    trainerNames.Add(x.name);
                }

                currentTrainerBox.DataSource = trainerNames;
                currentTrainerBox.SelectedIndex = 0;
            }

            foreach (var x in speciesNames)
            {
                if (speciesNames.IndexOf(x) > 0)
                {
                    speciesToDevID.Add(x, pokeDevID.values.FirstOrDefault(y => y.id == speciesNames.IndexOf(x)).devName);
                } else
                {
                    speciesToDevID.Add("None", "DEV_NULL");
                }
            }

            foreach (var x in ballNames)
            {
                if (x == "None")
                {
                    ballToDevID.Add("None", "NONE");
                }
                else
                {
                    var ballDevID = itemDevID.items.First(y => y.id == itemNames.IndexOf(x)).devName.Replace("ITEMID_", "");
                    ballToDevID.Add(x, ballDevID);
                }
            }

            foreach (var x in itemNames)
            {
                string name;
                string devName;
                var y = itemDevID.items.Exists(z => z.id == itemNames.IndexOf(x)) ? itemDevID.items.First(z => z.id == itemNames.IndexOf(x)).devName : "";
                if (x == "???")
                {
                    name = "NO NAME";
                    devName = "ITEMID_NONE";
                }
                else
                {
                    name = x;
                    devName = y;
                }
                items.Add(new Tuple<string, string, int>(name, devName, itemNames.IndexOf(x)));
            }
        }

        // now we code what we need to do

        private void FillFields()
        {

            // page 1

            var mon1 = currentTrainer.Data.poke1;

            setPicture(speciesToDevID.First(x => x.Value == currentTrainer.Data.poke1.devId).Key, currentTrainer.Data.poke1.formId, 0);

            speciesBox1.SelectedIndex = speciesNames.IndexOf(speciesToDevID.First(x => x.Value == currentTrainer.Data.poke1.devId).Key);
            formBox1.Value = mon1.formId;

            if (mon1.talentType == "RANDOM")
            {
                hpIV1.Enabled = false;
                atkIV1.Enabled = false;
                defIV1.Enabled = false;
                spaIV1.Enabled = false;
                spdIV1.Enabled = false;
                speIV1.Enabled = false;

                randomIV1.Checked = true;
            }
            else
            {
                // re-enabling just in case

                hpIV1.Enabled = true;
                atkIV1.Enabled = true;
                defIV1.Enabled = true;
                spaIV1.Enabled = true;
                spdIV1.Enabled = true;
                speIV1.Enabled = true;

                hpIV1.Value = mon1.talentValue.hp;
                atkIV1.Value = mon1.talentValue.atk;
                defIV1.Value = mon1.talentValue.def;
                spaIV1.Value = mon1.talentValue.spAtk;
                spdIV1.Value = mon1.talentValue.spDef;
                speIV1.Value = mon1.talentValue.agi;

                randomIV1.Checked = false;
            }

            hpEV1.Value = mon1.effortValue.hp;
            atkEV1.Value = mon1.effortValue.atk;
            defEV1.Value = mon1.effortValue.def;
            spaEV1.Value = mon1.effortValue.spAtk;
            spdEV1.Value = mon1.effortValue.spDef;
            speEV1.Value = mon1.effortValue.agi;

            if (mon1.wazaType == "MANUAL")
            {
                moveOne1.Enabled = true;
                ppUpOne1.Enabled = true;
                moveTwo1.Enabled = true;
                ppUpTwo1.Enabled = true;
                moveThree1.Enabled = true;
                ppUpThree1.Enabled = true;
                moveFour1.Enabled = true;
                ppUpFour1.Enabled = true;

                moveOne1.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon1.waza1.wazaId));
                ppUpOne1.Value = mon1.waza1.pointUp;
                moveTwo1.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon1.waza2.wazaId));
                ppUpTwo1.Value = mon1.waza2.pointUp;
                moveThree1.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon1.waza3.wazaId));
                ppUpThree1.Value = mon1.waza3.pointUp;
                moveFour1.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon1.waza4.wazaId));
                ppUpFour1.Value = mon1.waza4.pointUp;
            }
            else
            {
                moveOne1.SelectedIndex = 0;
                moveOne1.Enabled = false;
                ppUpOne1.Enabled = false;
                moveTwo1.SelectedIndex = 0;
                moveTwo1.Enabled = false;
                ppUpTwo1.Enabled = false;
                moveThree1.SelectedIndex = 0;
                moveThree1.Enabled = false;
                ppUpThree1.Enabled = false;
                moveFour1.SelectedIndex = 0;
                moveFour1.Enabled = false;
                ppUpFour1.Enabled = false;
            }

            ballBox1.SelectedIndex = ballBox1.Items.IndexOf(ballToDevID.First(x => x.Value == mon1.ballId).Key);
            itemBox1.SelectedIndex = mon1.item == null ? 0 : itemNames.IndexOf(itemNames[itemDevID.items.First(x => x.devName == mon1.item).id]);
            levelBox1.Value = mon1.level;

            if (mon1.gemType != "DEFAULT" && mon1.gemType != null)
            {
                teraTypeBox1.Enabled = true;
                teraTypeBox1.SelectedItem = typeToGemName.First(x => x.Value == mon1.gemType);
                defaultGemBox1.Checked = false;
            } else
            {
                teraTypeBox1.Enabled = false;
                defaultGemBox1.Checked = true;
            }

            shinyBox1.Checked = mon1.rareType == "NO_RARE" ? false : true;

            if (mon1.tokusei == "RANDOM_12") abilityBox1.SelectedIndex = 0;
            if (mon1.tokusei == "SET_1") abilityBox1.SelectedIndex = 1;
            if (mon1.tokusei == "SET_2") abilityBox1.SelectedIndex = 2;
            if (mon1.tokusei == "SET_3") abilityBox1.SelectedIndex = 3;

            // page 2

            var mon2 = currentTrainer.Data.poke2;

            if (mon2.devId != null)
            {
                setPicture(speciesToDevID.First(x => x.Value == currentTrainer.Data.poke2.devId).Key, currentTrainer.Data.poke2.formId, 1);
                speciesBox2.SelectedIndex = speciesNames.IndexOf(speciesToDevID.First(x => x.Value == currentTrainer.Data.poke2.devId).Key);
                formBox2.Value = mon2.formId;

                if (mon2.talentType == "RANDOM")
                {
                    hpIV2.Enabled = false;
                    atkIV2.Enabled = false;
                    defIV2.Enabled = false;
                    spaIV2.Enabled = false;
                    spdIV2.Enabled = false;
                    speIV2.Enabled = false;

                    randomIV2.Checked = true;
                }
                else
                {
                    // re-enabling just in case

                    hpIV2.Enabled = true;
                    atkIV2.Enabled = true;
                    defIV2.Enabled = true;
                    spaIV2.Enabled = true;
                    spdIV2.Enabled = true;
                    speIV2.Enabled = true;

                    hpIV2.Value = mon2.talentValue.hp;
                    atkIV2.Value = mon2.talentValue.atk;
                    defIV2.Value = mon2.talentValue.def;
                    spaIV2.Value = mon2.talentValue.spAtk;
                    spdIV2.Value = mon2.talentValue.spDef;
                    speIV2.Value = mon2.talentValue.agi;

                    randomIV2.Checked = false;
                }

                hpEV2.Value = mon2.effortValue.hp;
                atkEV2.Value = mon2.effortValue.atk;
                defEV2.Value = mon2.effortValue.def;
                spaEV2.Value = mon2.effortValue.spAtk;
                spdEV2.Value = mon2.effortValue.spDef;
                speEV2.Value = mon2.effortValue.agi;

                if (mon2.wazaType == "MANUAL")
                {
                    moveOne2.Enabled = true;
                    ppUpOne2.Enabled = true;
                    moveTwo2.Enabled = true;
                    ppUpTwo2.Enabled = true;
                    moveThree2.Enabled = true;
                    ppUpThree2.Enabled = true;
                    moveFour2.Enabled = true;
                    ppUpFour2.Enabled = true;

                    moveOne2.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon2.waza1.wazaId));
                    ppUpOne2.Value = mon2.waza1.pointUp;
                    moveTwo2.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon2.waza2.wazaId));
                    ppUpTwo2.Value = mon2.waza2.pointUp;
                    moveThree2.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon2.waza3.wazaId));
                    ppUpThree2.Value = mon2.waza3.pointUp;
                    moveFour2.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon2.waza4.wazaId));
                    ppUpFour2.Value = mon2.waza4.pointUp;
                }
                else
                {
                    moveOne2.SelectedIndex = 0;
                    moveOne2.Enabled = false;
                    ppUpOne2.Enabled = false;
                    moveTwo2.SelectedIndex = 0;
                    moveTwo2.Enabled = false;
                    ppUpTwo2.Enabled = false;
                    moveThree2.SelectedIndex = 0;
                    moveThree2.Enabled = false;
                    ppUpThree2.Enabled = false;
                    moveFour2.SelectedIndex = 0;
                    moveFour2.Enabled = false;
                    ppUpFour2.Enabled = false;
                }

                ballBox2.SelectedIndex = ballBox2.Items.IndexOf(ballToDevID.First(x => x.Value == mon2.ballId).Key);
                itemBox2.SelectedIndex = mon2.item == null ? 0 : itemNames.IndexOf(itemNames[itemDevID.items.First(x => x.devName == mon2.item).id]);
                levelBox2.Value = mon2.level;

                if (mon2.gemType != "DEFAULT" && mon2.gemType != null)
                {
                    teraTypeBox2.Enabled = true;
                    teraTypeBox2.SelectedItem = typeToGemName.First(x => x.Value == mon2.gemType);
                    defaultGemBox2.Checked = false;
                }
                else
                {
                    teraTypeBox2.Enabled = false;
                    defaultGemBox2.Checked = true;
                }

                shinyBox2.Checked = mon2.rareType == "NO_RARE" ? false : true;

                if (mon2.tokusei == "RANDOM_12") abilityBox2.SelectedIndex = 0;
                if (mon2.tokusei == "SET_1") abilityBox2.SelectedIndex = 1;
                if (mon2.tokusei == "SET_2") abilityBox2.SelectedIndex = 2;
                if (mon2.tokusei == "SET_3") abilityBox2.SelectedIndex = 3;
            }

            // page 3

            var mon3 = currentTrainer.Data.poke3;

            if (mon3.devId != null)
            {
                setPicture(speciesToDevID.First(x => x.Value == currentTrainer.Data.poke3.devId).Key, currentTrainer.Data.poke3.formId, 2);
                speciesBox3.SelectedIndex = speciesNames.IndexOf(speciesToDevID.First(x => x.Value == currentTrainer.Data.poke3.devId).Key);
                formBox3.Value = mon3.formId;

                if (mon3.talentType == "RANDOM")
                {
                    hpIV3.Enabled = false;
                    atkIV3.Enabled = false;
                    defIV3.Enabled = false;
                    spaIV3.Enabled = false;
                    spdIV3.Enabled = false;
                    speIV3.Enabled = false;

                    randomIV3.Checked = true;
                }
                else
                {
                    // re-enabling just in case

                    hpIV3.Enabled = true;
                    atkIV3.Enabled = true;
                    defIV3.Enabled = true;
                    spaIV3.Enabled = true;
                    spdIV3.Enabled = true;
                    speIV3.Enabled = true;

                    hpIV3.Value = mon3.talentValue.hp;
                    atkIV3.Value = mon3.talentValue.atk;
                    defIV3.Value = mon3.talentValue.def;
                    spaIV3.Value = mon3.talentValue.spAtk;
                    spdIV3.Value = mon3.talentValue.spDef;
                    speIV3.Value = mon3.talentValue.agi;

                    randomIV3.Checked = false;
                }

                hpEV3.Value = mon3.effortValue.hp;
                atkEV3.Value = mon3.effortValue.atk;
                defEV3.Value = mon3.effortValue.def;
                spaEV3.Value = mon3.effortValue.spAtk;
                spdEV3.Value = mon3.effortValue.spDef;
                speEV3.Value = mon3.effortValue.agi;

                if (mon3.wazaType == "MANUAL")
                {
                    moveOne3.Enabled = true;
                    ppUpOne3.Enabled = true;
                    moveTwo3.Enabled = true;
                    ppUpTwo3.Enabled = true;
                    moveThree3.Enabled = true;
                    ppUpThree3.Enabled = true;
                    moveFour3.Enabled = true;
                    ppUpFour3.Enabled = true;

                    moveOne3.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon3.waza1.wazaId));
                    ppUpOne3.Value = mon3.waza1.pointUp;
                    moveTwo3.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon3.waza2.wazaId));
                    ppUpTwo3.Value = mon3.waza2.pointUp;
                    moveThree3.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon3.waza3.wazaId));
                    ppUpThree3.Value = mon3.waza3.pointUp;
                    moveFour3.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon3.waza4.wazaId));
                    ppUpFour3.Value = mon3.waza4.pointUp;
                }
                else
                {
                    moveOne3.SelectedIndex = 0;
                    moveOne3.Enabled = false;
                    ppUpOne3.Enabled = false;
                    moveTwo3.SelectedIndex = 0;
                    moveTwo3.Enabled = false;
                    ppUpTwo3.Enabled = false;
                    moveThree3.SelectedIndex = 0;
                    moveThree3.Enabled = false;
                    ppUpThree3.Enabled = false;
                    moveFour3.SelectedIndex = 0;
                    moveFour3.Enabled = false;
                    ppUpFour3.Enabled = false;
                }

                ballBox3.SelectedIndex = ballBox3.Items.IndexOf(ballToDevID.First(x => x.Value == mon3.ballId).Key);
                itemBox3.SelectedIndex = mon3.item == null ? 0 : itemNames.IndexOf(itemNames[itemDevID.items.First(x => x.devName == mon3.item).id]);
                levelBox3.Value = mon3.level;

                if (mon3.gemType != "DEFAULT" && mon3.gemType != null)
                {
                    teraTypeBox3.Enabled = true;
                    teraTypeBox3.SelectedItem = typeToGemName.First(x => x.Value == mon3.gemType);
                    defaultGemBox3.Checked = false;
                }
                else
                {
                    teraTypeBox3.Enabled = false;
                    defaultGemBox3.Checked = true;
                }

                shinyBox3.Checked = mon3.rareType == "NO_RARE" ? false : true;

                if (mon3.tokusei == "RANDOM_12") abilityBox3.SelectedIndex = 0;
                if (mon3.tokusei == "SET_1") abilityBox3.SelectedIndex = 1;
                if (mon3.tokusei == "SET_2") abilityBox3.SelectedIndex = 2;
                if (mon3.tokusei == "SET_3") abilityBox3.SelectedIndex = 3;
            }

            // page 4

            var mon4 = currentTrainer.Data.poke4;

            if (mon4.devId != null)
            {
                setPicture(speciesToDevID.First(x => x.Value == currentTrainer.Data.poke4.devId).Key, currentTrainer.Data.poke4.formId, 3);
                speciesBox4.SelectedIndex = speciesNames.IndexOf(speciesToDevID.First(x => x.Value == currentTrainer.Data.poke4.devId).Key);
                formBox4.Value = mon1.formId;

                if (mon4.talentType == "RANDOM")
                {
                    hpIV4.Enabled = false;
                    atkIV4.Enabled = false;
                    defIV4.Enabled = false;
                    spaIV4.Enabled = false;
                    spdIV4.Enabled = false;
                    speIV4.Enabled = false;

                    randomIV4.Checked = true;
                }
                else
                {
                    // re-enabling just in case

                    hpIV4.Enabled = true;
                    atkIV4.Enabled = true;
                    defIV4.Enabled = true;
                    spaIV4.Enabled = true;
                    spdIV4.Enabled = true;
                    speIV4.Enabled = true;

                    hpIV4.Value = mon4.talentValue.hp;
                    atkIV4.Value = mon4.talentValue.atk;
                    defIV4.Value = mon4.talentValue.def;
                    spaIV4.Value = mon4.talentValue.spAtk;
                    spdIV4.Value = mon4.talentValue.spDef;
                    speIV4.Value = mon4.talentValue.agi;

                    randomIV4.Checked = false;
                }

                hpEV4.Value = mon4.effortValue.hp;
                atkEV4.Value = mon4.effortValue.atk;
                defEV4.Value = mon4.effortValue.def;
                spaEV4.Value = mon4.effortValue.spAtk;
                spdEV4.Value = mon4.effortValue.spDef;
                speEV4.Value = mon4.effortValue.agi;

                if (mon4.wazaType == "MANUAL")
                {
                    moveOne4.Enabled = true;
                    ppUpOne4.Enabled = true;
                    moveTwo4.Enabled = true;
                    ppUpTwo4.Enabled = true;
                    moveThree4.Enabled = true;
                    ppUpThree4.Enabled = true;
                    moveFour4.Enabled = true;
                    ppUpFour4.Enabled = true;

                    moveOne4.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon4.waza1.wazaId));
                    ppUpOne4.Value = mon4.waza1.pointUp;
                    moveTwo4.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon4.waza2.wazaId));
                    ppUpTwo4.Value = mon4.waza2.pointUp;
                    moveThree4.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon4.waza3.wazaId));
                    ppUpThree4.Value = mon4.waza3.pointUp;
                    moveFour4.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon4.waza4.wazaId));
                    ppUpFour4.Value = mon4.waza4.pointUp;
                }
                else
                {
                    moveOne4.SelectedIndex = 0;
                    moveOne4.Enabled = false;
                    ppUpOne4.Enabled = false;
                    moveTwo4.SelectedIndex = 0;
                    moveTwo4.Enabled = false;
                    ppUpTwo4.Enabled = false;
                    moveThree4.SelectedIndex = 0;
                    moveThree4.Enabled = false;
                    ppUpThree4.Enabled = false;
                    moveFour4.SelectedIndex = 0;
                    moveFour4.Enabled = false;
                    ppUpFour4.Enabled = false;
                }

                ballBox4.SelectedIndex = ballBox4.Items.IndexOf(ballToDevID.First(x => x.Value == mon4.ballId).Key);
                itemBox4.SelectedIndex = mon4.item == null ? 0 : itemNames.IndexOf(itemNames[itemDevID.items.First(x => x.devName == mon4.item).id]);
                levelBox4.Value = mon4.level;

                if (mon4.gemType != "DEFAULT" && mon4.gemType != null)
                {
                    teraTypeBox4.Enabled = true;
                    teraTypeBox4.SelectedItem = typeToGemName.First(x => x.Value == mon4.gemType);
                    defaultGemBox4.Checked = false;
                }
                else
                {
                    teraTypeBox4.Enabled = false;
                    defaultGemBox4.Checked = true;
                }

                shinyBox4.Checked = mon4.rareType == "NO_RARE" ? false : true;

                if (mon4.tokusei == "RANDOM_12") abilityBox4.SelectedIndex = 0;
                if (mon4.tokusei == "SET_1") abilityBox4.SelectedIndex = 1;
                if (mon4.tokusei == "SET_2") abilityBox4.SelectedIndex = 2;
                if (mon4.tokusei == "SET_3") abilityBox4.SelectedIndex = 3;
            }

            // page 5

            var mon5 = currentTrainer.Data.poke5;

            if (mon5.devId != null)
            {
                setPicture(speciesToDevID.First(x => x.Value == currentTrainer.Data.poke5.devId).Key, currentTrainer.Data.poke5.formId, 4);
                speciesBox5.SelectedIndex = speciesNames.IndexOf(speciesToDevID.First(x => x.Value == currentTrainer.Data.poke5.devId).Key);
                formBox5.Value = mon5.formId;

                if (mon5.talentType == "RANDOM")
                {
                    hpIV5.Enabled = false;
                    atkIV5.Enabled = false;
                    defIV5.Enabled = false;
                    spaIV5.Enabled = false;
                    spdIV5.Enabled = false;
                    speIV5.Enabled = false;

                    randomIV5.Checked = true;
                }
                else
                {
                    // re-enabling just in case

                    hpIV5.Enabled = true;
                    atkIV5.Enabled = true;
                    defIV5.Enabled = true;
                    spaIV5.Enabled = true;
                    spdIV5.Enabled = true;
                    speIV5.Enabled = true;

                    hpIV5.Value = mon5.talentValue.hp;
                    atkIV5.Value = mon5.talentValue.atk;
                    defIV5.Value = mon5.talentValue.def;
                    spaIV5.Value = mon5.talentValue.spAtk;
                    spdIV5.Value = mon5.talentValue.spDef;
                    speIV5.Value = mon5.talentValue.agi;

                    randomIV5.Checked = false;
                }

                hpEV5.Value = mon5.effortValue.hp;
                atkEV5.Value = mon5.effortValue.atk;
                defEV5.Value = mon5.effortValue.def;
                spaEV5.Value = mon5.effortValue.spAtk;
                spdEV5.Value = mon5.effortValue.spDef;
                speEV5.Value = mon5.effortValue.agi;

                if (mon5.wazaType == "MANUAL")
                {
                    moveOne5.Enabled = true;
                    ppUpOne5.Enabled = true;
                    moveTwo5.Enabled = true;
                    ppUpTwo5.Enabled = true;
                    moveThree5.Enabled = true;
                    ppUpThree5.Enabled = true;
                    moveFour5.Enabled = true;
                    ppUpFour5.Enabled = true;

                    moveOne5.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon5.waza1.wazaId));
                    ppUpOne5.Value = mon5.waza1.pointUp;
                    moveTwo5.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon5.waza2.wazaId));
                    ppUpTwo5.Value = mon5.waza2.pointUp;
                    moveThree5.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon5.waza3.wazaId));
                    ppUpThree5.Value = mon5.waza3.pointUp;
                    moveFour5.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon5.waza4.wazaId));
                    ppUpFour5.Value = mon5.waza4.pointUp;
                }
                else
                {
                    moveOne5.SelectedIndex = 0;
                    moveOne5.Enabled = false;
                    ppUpOne5.Enabled = false;
                    moveTwo5.SelectedIndex = 0;
                    moveTwo5.Enabled = false;
                    ppUpTwo5.Enabled = false;
                    moveThree5.SelectedIndex = 0;
                    moveThree5.Enabled = false;
                    ppUpThree5.Enabled = false;
                    moveFour5.SelectedIndex = 0;
                    moveFour5.Enabled = false;
                    ppUpFour5.Enabled = false;
                }

                ballBox5.SelectedIndex = ballBox5.Items.IndexOf(ballToDevID.First(x => x.Value == mon5.ballId).Key);
                itemBox5.SelectedIndex = mon5.item == null ? 0 : itemNames.IndexOf(itemNames[itemDevID.items.First(x => x.devName == mon5.item).id]);
                levelBox5.Value = mon5.level;

                if (mon5.gemType != "DEFAULT" && mon5.gemType != null)
                {
                    teraTypeBox5.Enabled = true;
                    teraTypeBox5.SelectedItem = typeToGemName.First(x => x.Value == mon5.gemType);
                    defaultGemBox5.Checked = false;
                }
                else
                {
                    teraTypeBox5.Enabled = false;
                    defaultGemBox5.Checked = true;
                }

                shinyBox5.Checked = mon5.rareType == "NO_RARE" ? false : true;

                if (mon5.tokusei == "RANDOM_12") abilityBox5.SelectedIndex = 0;
                if (mon5.tokusei == "SET_1") abilityBox5.SelectedIndex = 1;
                if (mon5.tokusei == "SET_2") abilityBox5.SelectedIndex = 2;
                if (mon5.tokusei == "SET_3") abilityBox5.SelectedIndex = 3;
            }

            // page 6

            var mon6 = currentTrainer.Data.poke6;

            if (mon6.devId != null)
            {
                setPicture(speciesToDevID.First(x => x.Value == currentTrainer.Data.poke6.devId).Key, currentTrainer.Data.poke6.formId, 5);
                speciesBox6.SelectedIndex = speciesNames.IndexOf(speciesToDevID.First(x => x.Value == currentTrainer.Data.poke6.devId).Key);
                formBox6.Value = mon6.formId;

                if (mon6.talentType == "RANDOM")
                {
                    hpIV6.Enabled = false;
                    atkIV6.Enabled = false;
                    defIV6.Enabled = false;
                    spaIV6.Enabled = false;
                    spdIV6.Enabled = false;
                    speIV6.Enabled = false;

                    randomIV6.Checked = true;
                }
                else
                {
                    // re-enabling just in case

                    hpIV6.Enabled = true;
                    atkIV6.Enabled = true;
                    defIV6.Enabled = true;
                    spaIV6.Enabled = true;
                    spdIV6.Enabled = true;
                    speIV6.Enabled = true;

                    hpIV6.Value = mon6.talentValue.hp;
                    atkIV6.Value = mon6.talentValue.atk;
                    defIV6.Value = mon6.talentValue.def;
                    spaIV6.Value = mon6.talentValue.spAtk;
                    spdIV6.Value = mon6.talentValue.spDef;
                    speIV6.Value = mon6.talentValue.agi;

                    randomIV6.Checked = false;
                }

                hpEV6.Value = mon6.effortValue.hp;
                atkEV6.Value = mon6.effortValue.atk;
                defEV6.Value = mon6.effortValue.def;
                spaEV6.Value = mon6.effortValue.spAtk;
                spdEV6.Value = mon6.effortValue.spDef;
                speEV6.Value = mon6.effortValue.agi;

                if (mon6.wazaType == "MANUAL")
                {
                    moveOne6.Enabled = true;
                    ppUpOne6.Enabled = true;
                    moveTwo6.Enabled = true;
                    ppUpTwo6.Enabled = true;
                    moveThree6.Enabled = true;
                    ppUpThree6.Enabled = true;
                    moveFour6.Enabled = true;
                    ppUpFour6.Enabled = true;

                    moveOne6.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon6.waza1.wazaId));
                    ppUpOne6.Value = mon6.waza1.pointUp;
                    moveTwo6.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon6.waza2.wazaId));
                    ppUpTwo6.Value = mon6.waza2.pointUp;
                    moveThree6.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon6.waza3.wazaId));
                    ppUpThree6.Value = mon6.waza3.pointUp;
                    moveFour6.SelectedIndex = moveDevID.moves.IndexOf(moveDevID.moves.First(x => x.devName == mon6.waza4.wazaId));
                    ppUpFour6.Value = mon6.waza4.pointUp;
                }
                else
                {
                    moveOne6.SelectedIndex = 0;
                    moveOne6.Enabled = false;
                    ppUpOne6.Enabled = false;
                    moveTwo6.SelectedIndex = 0;
                    moveTwo6.Enabled = false;
                    ppUpTwo6.Enabled = false;
                    moveThree6.SelectedIndex = 0;
                    moveThree6.Enabled = false;
                    ppUpThree6.Enabled = false;
                    moveFour6.SelectedIndex = 0;
                    moveFour6.Enabled = false;
                    ppUpFour6.Enabled = false;
                }

                ballBox6.SelectedIndex = ballBox6.Items.IndexOf(ballToDevID.First(x => x.Value == mon6.ballId).Key);
                itemBox6.SelectedIndex = mon6.item == null ? 0 : itemNames.IndexOf(itemNames[itemDevID.items.First(x => x.devName == mon6.item).id]);
                levelBox6.Value = mon6.level;

                if (mon6.gemType != "DEFAULT" && mon6.gemType != null)
                {
                    teraTypeBox6.Enabled = true;
                    teraTypeBox6.SelectedItem = typeToGemName.First(x => x.Value == mon6.gemType);
                    defaultGemBox6.Checked = false;
                }
                else
                {
                    teraTypeBox6.Enabled = false;
                    defaultGemBox6.Checked = true;
                }

                shinyBox6.Checked = mon6.rareType == "NO_RARE" ? false : true;

                if (mon6.tokusei == "RANDOM_12") abilityBox6.SelectedIndex = 0;
                if (mon6.tokusei == "SET_1") abilityBox6.SelectedIndex = 1;
                if (mon6.tokusei == "SET_2") abilityBox6.SelectedIndex = 2;
                if (mon6.tokusei == "SET_3") abilityBox6.SelectedIndex = 3;
            }

            // page 7

            checkedListBox1.SetItemChecked(0, currentTrainer.Data.isStrong);
            checkedListBox1.SetItemChecked(1, currentTrainer.Data.aiBasic);
            checkedListBox1.SetItemChecked(2, currentTrainer.Data.aiHigh);
            checkedListBox1.SetItemChecked(3, currentTrainer.Data.aiExpert);
            checkedListBox1.SetItemChecked(4, currentTrainer.Data.aiDouble);
            checkedListBox1.SetItemChecked(5, currentTrainer.Data.aiRaid);
            checkedListBox1.SetItemChecked(6, currentTrainer.Data.aiWeak);
            checkedListBox1.SetItemChecked(7, currentTrainer.Data.aiItem);
            checkedListBox1.SetItemChecked(8, currentTrainer.Data.aiChange);
            checkedListBox1.SetItemChecked(9, currentTrainer.Data.changeGem);
            moneyRateBox.Value = currentTrainer.Data.moneyRate;

            initialised = true;

        }

        private void speciesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initialised) {
                var currentPage = siticoneTabControl1.SelectedIndex;
                FlatComboBox species;
                if (currentPage == 0)
                {
                    species = speciesBox1;
                    currentTrainer.Data.poke1.devId = pokeDevID.values.First(x => x.id == species.SelectedIndex).devName;
                }
                else if (currentPage == 1)
                {
                    species = speciesBox2;
                    currentTrainer.Data.poke2.devId = pokeDevID.values.First(x => x.id == species.SelectedIndex).devName;
                }
                else if (currentPage == 2)
                {
                    species = speciesBox3;
                    currentTrainer.Data.poke3.devId = pokeDevID.values.First(x => x.id == species.SelectedIndex).devName;
                }
                else if (currentPage == 3)
                {
                    species = speciesBox4;
                    currentTrainer.Data.poke4.devId = pokeDevID.values.First(x => x.id == species.SelectedIndex).devName;
                }
                else if (currentPage == 4)
                {
                    species = speciesBox5;
                    currentTrainer.Data.poke5.devId = pokeDevID.values.First(x => x.id == species.SelectedIndex).devName;
                }
                else
                {
                    species = speciesBox6;
                    currentTrainer.Data.poke6.devId = pokeDevID.values.First(x => x.id == species.SelectedIndex).devName;
                }
                setPicture(speciesNames[species.SelectedIndex], 0, currentPage);
            }
        }

        private void formChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                var currentPage = siticoneTabControl1.SelectedIndex;
                var form = (int)(sender as SiticoneNumericUpDown).Value;
                if (currentPage == 0)
                {
                    currentTrainer.Data.poke1.formId = (int)formBox1.Value;
                    setPicture(speciesNames[speciesBox1.SelectedIndex], form, currentPage);
                }
                else if (currentPage == 1)
                {
                    currentTrainer.Data.poke2.formId = (int)formBox2.Value;
                    setPicture(speciesNames[speciesBox2.SelectedIndex], form, currentPage);
                }
                else if (currentPage == 2)
                {
                    currentTrainer.Data.poke3.formId = (int)formBox3.Value;
                    setPicture(speciesNames[speciesBox3.SelectedIndex], form, currentPage);
                }
                else if (currentPage == 3)
                {
                    currentTrainer.Data.poke4.formId = (int)formBox4.Value;
                    setPicture(speciesNames[speciesBox4.SelectedIndex], form, currentPage);
                }
                else if (currentPage == 4)
                {
                    currentTrainer.Data.poke5.formId = (int)formBox5.Value;
                    setPicture(speciesNames[speciesBox5.SelectedIndex], form, currentPage);
                }
                else
                {
                    currentTrainer.Data.poke6.formId = (int)formBox6.Value;
                    setPicture(speciesNames[speciesBox6.SelectedIndex], form, currentPage);
                }
            }
        }

        private void currentTrainerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                initialised = false;
                trainer.values[currentTrainer.Index] = currentTrainer.Data;
                currentTrainer = new CurrentTrainer { Data = trainer.values[currentTrainerBox.SelectedIndex], DevID = trainer.values[currentTrainerBox.SelectedIndex].trid, Name = trainerDevID.trainers.First(x => x.dev_id == trainer.values[currentTrainerBox.SelectedIndex].trid).name, Index = currentTrainerBox.SelectedIndex };
                FillFields();
            }
        }

        private void ivChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                var currentPage = siticoneTabControl1.SelectedIndex;
                if (currentPage == 0)
                {
                    currentTrainer.Data.poke1.talentValue.hp = (int)hpIV1.Value;
                    currentTrainer.Data.poke1.talentValue.atk = (int)atkIV1.Value;
                    currentTrainer.Data.poke1.talentValue.def = (int)defIV1.Value;
                    currentTrainer.Data.poke1.talentValue.spAtk = (int)spaIV1.Value;
                    currentTrainer.Data.poke1.talentValue.spDef = (int)spdIV1.Value;
                    currentTrainer.Data.poke1.talentValue.agi = (int)speIV1.Value;
                } else if (currentPage == 1)
                {
                    currentTrainer.Data.poke2.talentValue.hp = (int)hpIV2.Value;
                    currentTrainer.Data.poke2.talentValue.atk = (int)atkIV2.Value;
                    currentTrainer.Data.poke2.talentValue.def = (int)defIV2.Value;
                    currentTrainer.Data.poke2.talentValue.spAtk = (int)spaIV2.Value;
                    currentTrainer.Data.poke2.talentValue.spDef = (int)spdIV2.Value;
                    currentTrainer.Data.poke2.talentValue.agi = (int)speIV2.Value;
                } else if (currentPage == 2)
                {
                    currentTrainer.Data.poke3.talentValue.hp = (int)hpIV3.Value;
                    currentTrainer.Data.poke3.talentValue.atk = (int)atkIV3.Value;
                    currentTrainer.Data.poke3.talentValue.def = (int)defIV3.Value;
                    currentTrainer.Data.poke3.talentValue.spAtk = (int)spaIV3.Value;
                    currentTrainer.Data.poke3.talentValue.spDef = (int)spdIV3.Value;
                    currentTrainer.Data.poke3.talentValue.agi = (int)speIV3.Value;
                } else if (currentPage == 3)
                {
                    currentTrainer.Data.poke4.talentValue.hp = (int)hpIV4.Value;
                    currentTrainer.Data.poke4.talentValue.atk = (int)atkIV4.Value;
                    currentTrainer.Data.poke4.talentValue.def = (int)defIV4.Value;
                    currentTrainer.Data.poke4.talentValue.spAtk = (int)spaIV4.Value;
                    currentTrainer.Data.poke4.talentValue.spDef = (int)spdIV4.Value;
                    currentTrainer.Data.poke4.talentValue.agi = (int)speIV4.Value;
                } else if (currentPage == 4)
                {
                    currentTrainer.Data.poke5.talentValue.hp = (int)hpIV5.Value;
                    currentTrainer.Data.poke5.talentValue.atk = (int)atkIV5.Value;
                    currentTrainer.Data.poke5.talentValue.def = (int)defIV5.Value;
                    currentTrainer.Data.poke5.talentValue.spAtk = (int)spaIV5.Value;
                    currentTrainer.Data.poke5.talentValue.spDef = (int)spdIV5.Value;
                    currentTrainer.Data.poke5.talentValue.agi = (int)speIV5.Value;
                } else
                {
                    currentTrainer.Data.poke6.talentValue.hp = (int)hpIV6.Value;
                    currentTrainer.Data.poke6.talentValue.atk = (int)atkIV6.Value;
                    currentTrainer.Data.poke6.talentValue.def = (int)defIV6.Value;
                    currentTrainer.Data.poke6.talentValue.spAtk = (int)spaIV6.Value;
                    currentTrainer.Data.poke6.talentValue.spDef = (int)spdIV6.Value;
                    currentTrainer.Data.poke6.talentValue.agi = (int)speIV6.Value;
                }
            }
        }

        private void evChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                var currentPage = siticoneTabControl1.SelectedIndex;
                if (currentPage == 0)
                {
                    currentTrainer.Data.poke1.effortValue.hp = (int)hpEV1.Value;
                    currentTrainer.Data.poke1.effortValue.atk = (int)atkEV1.Value;
                    currentTrainer.Data.poke1.effortValue.def = (int)defEV1.Value;
                    currentTrainer.Data.poke1.effortValue.spAtk = (int)spaEV1.Value;
                    currentTrainer.Data.poke1.effortValue.spDef = (int)spdEV1.Value;
                    currentTrainer.Data.poke1.effortValue.agi = (int)speEV1.Value;
                }
                else if (currentPage == 1)
                {
                    currentTrainer.Data.poke2.effortValue.hp = (int)hpEV2.Value;
                    currentTrainer.Data.poke2.effortValue.atk = (int)atkEV2.Value;
                    currentTrainer.Data.poke2.effortValue.def = (int)defEV2.Value;
                    currentTrainer.Data.poke2.effortValue.spAtk = (int)spaEV2.Value;
                    currentTrainer.Data.poke2.effortValue.spDef = (int)spdEV2.Value;
                    currentTrainer.Data.poke2.effortValue.agi = (int)speEV2.Value;
                }
                else if (currentPage == 2)
                {
                    currentTrainer.Data.poke3.effortValue.hp = (int)hpEV3.Value;
                    currentTrainer.Data.poke3.effortValue.atk = (int)atkEV3.Value;
                    currentTrainer.Data.poke3.effortValue.def = (int)defEV3.Value;
                    currentTrainer.Data.poke3.effortValue.spAtk = (int)spaEV3.Value;
                    currentTrainer.Data.poke3.effortValue.spDef = (int)spdEV3.Value;
                    currentTrainer.Data.poke3.effortValue.agi = (int)speEV3.Value;
                }
                else if (currentPage == 3)
                {
                    currentTrainer.Data.poke4.effortValue.hp = (int)hpEV4.Value;
                    currentTrainer.Data.poke4.effortValue.atk = (int)atkEV4.Value;
                    currentTrainer.Data.poke4.effortValue.def = (int)defEV4.Value;
                    currentTrainer.Data.poke4.effortValue.spAtk = (int)spaEV4.Value;
                    currentTrainer.Data.poke4.effortValue.spDef = (int)spdEV4.Value;
                    currentTrainer.Data.poke4.effortValue.agi = (int)speEV4.Value;
                }
                else if (currentPage == 4)
                {
                    currentTrainer.Data.poke5.effortValue.hp = (int)hpEV5.Value;
                    currentTrainer.Data.poke5.effortValue.atk = (int)atkEV5.Value;
                    currentTrainer.Data.poke5.effortValue.def = (int)defEV5.Value;
                    currentTrainer.Data.poke5.effortValue.spAtk = (int)spaEV5.Value;
                    currentTrainer.Data.poke5.effortValue.spDef = (int)spdEV5.Value;
                    currentTrainer.Data.poke5.effortValue.agi = (int)speEV5.Value;
                }
                else
                {
                    currentTrainer.Data.poke6.effortValue.hp = (int)hpEV6.Value;
                    currentTrainer.Data.poke6.effortValue.atk = (int)atkEV6.Value;
                    currentTrainer.Data.poke6.effortValue.def = (int)defEV6.Value;
                    currentTrainer.Data.poke6.effortValue.spAtk = (int)spaEV6.Value;
                    currentTrainer.Data.poke6.effortValue.spDef = (int)spdEV6.Value;
                    currentTrainer.Data.poke6.effortValue.agi = (int)speEV6.Value;
                }
            }
        }

        private void moveChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                var currentPage = siticoneTabControl1.SelectedIndex;
                if (currentPage == 0)
                {
                    currentTrainer.Data.poke1.waza1.wazaId = moveDevID.moves.First(x => x.name == moveOne1.Items[moveOne1.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke1.waza2.wazaId = moveDevID.moves.First(x => x.name == moveTwo1.Items[moveTwo1.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke1.waza3.wazaId = moveDevID.moves.First(x => x.name == moveThree1.Items[moveThree1.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke1.waza4.wazaId = moveDevID.moves.First(x => x.name == moveFour1.Items[moveFour1.SelectedIndex].ToString()).devName;
                }
                else if (currentPage == 1)
                {
                    currentTrainer.Data.poke2.waza1.wazaId = moveDevID.moves.First(x => x.name == moveOne2.Items[moveOne2.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke2.waza2.wazaId = moveDevID.moves.First(x => x.name == moveTwo2.Items[moveTwo2.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke2.waza3.wazaId = moveDevID.moves.First(x => x.name == moveThree2.Items[moveThree2.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke2.waza4.wazaId = moveDevID.moves.First(x => x.name == moveFour2.Items[moveFour2.SelectedIndex].ToString()).devName;
                }
                else if (currentPage == 2)
                {
                    currentTrainer.Data.poke3.waza1.wazaId = moveDevID.moves.First(x => x.name == moveOne3.Items[moveOne3.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke3.waza2.wazaId = moveDevID.moves.First(x => x.name == moveTwo3.Items[moveTwo3.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke3.waza3.wazaId = moveDevID.moves.First(x => x.name == moveThree3.Items[moveThree3.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke3.waza4.wazaId = moveDevID.moves.First(x => x.name == moveFour3.Items[moveFour3.SelectedIndex].ToString()).devName;
                }
                else if (currentPage == 3)
                {
                    currentTrainer.Data.poke4.waza1.wazaId = moveDevID.moves.First(x => x.name == moveOne4.Items[moveOne4.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke4.waza2.wazaId = moveDevID.moves.First(x => x.name == moveTwo4.Items[moveTwo4.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke4.waza3.wazaId = moveDevID.moves.First(x => x.name == moveThree4.Items[moveThree4.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke4.waza4.wazaId = moveDevID.moves.First(x => x.name == moveFour4.Items[moveFour4.SelectedIndex].ToString()).devName;
                }
                else if (currentPage == 4)
                {
                    currentTrainer.Data.poke5.waza1.wazaId = moveDevID.moves.First(x => x.name == moveOne5.Items[moveOne5.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke5.waza2.wazaId = moveDevID.moves.First(x => x.name == moveTwo5.Items[moveTwo5.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke5.waza3.wazaId = moveDevID.moves.First(x => x.name == moveThree5.Items[moveThree5.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke5.waza4.wazaId = moveDevID.moves.First(x => x.name == moveFour5.Items[moveFour5.SelectedIndex].ToString()).devName;
                }
                else
                {
                    currentTrainer.Data.poke6.waza1.wazaId = moveDevID.moves.First(x => x.name == moveOne6.Items[moveOne6.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke6.waza2.wazaId = moveDevID.moves.First(x => x.name == moveTwo6.Items[moveTwo6.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke6.waza3.wazaId = moveDevID.moves.First(x => x.name == moveThree6.Items[moveThree6.SelectedIndex].ToString()).devName;
                    currentTrainer.Data.poke6.waza4.wazaId = moveDevID.moves.First(x => x.name == moveFour6.Items[moveFour6.SelectedIndex].ToString()).devName;
                }
            }
        }

        private void ppChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                var currentPage = siticoneTabControl1.SelectedIndex;
                if (currentPage == 0)
                {
                    currentTrainer.Data.poke1.waza1.pointUp = (int)ppUpOne1.Value;
                    currentTrainer.Data.poke1.waza2.pointUp = (int)ppUpTwo1.Value;
                    currentTrainer.Data.poke1.waza3.pointUp = (int)ppUpThree1.Value;
                    currentTrainer.Data.poke1.waza4.pointUp = (int)ppUpFour1.Value;
                }
                else if (currentPage == 1)
                {
                    currentTrainer.Data.poke2.waza1.pointUp = (int)ppUpOne2.Value;
                    currentTrainer.Data.poke2.waza2.pointUp = (int)ppUpTwo2.Value;
                    currentTrainer.Data.poke2.waza3.pointUp = (int)ppUpThree2.Value;
                    currentTrainer.Data.poke2.waza4.pointUp = (int)ppUpFour2.Value;
                }
                else if (currentPage == 2)
                {
                    currentTrainer.Data.poke3.waza1.pointUp = (int)ppUpOne3.Value;
                    currentTrainer.Data.poke3.waza2.pointUp = (int)ppUpTwo3.Value;
                    currentTrainer.Data.poke3.waza3.pointUp = (int)ppUpThree3.Value;
                    currentTrainer.Data.poke3.waza4.pointUp = (int)ppUpFour3.Value;
                }
                else if (currentPage == 3)
                {
                    currentTrainer.Data.poke4.waza1.pointUp = (int)ppUpOne4.Value;
                    currentTrainer.Data.poke4.waza2.pointUp = (int)ppUpTwo4.Value;
                    currentTrainer.Data.poke4.waza3.pointUp = (int)ppUpThree4.Value;
                    currentTrainer.Data.poke4.waza4.pointUp = (int)ppUpFour4.Value;
                }
                else if (currentPage == 4)
                {
                    currentTrainer.Data.poke5.waza1.pointUp = (int)ppUpOne5.Value;
                    currentTrainer.Data.poke5.waza2.pointUp = (int)ppUpTwo5.Value;
                    currentTrainer.Data.poke5.waza3.pointUp = (int)ppUpThree5.Value;
                    currentTrainer.Data.poke5.waza4.pointUp = (int)ppUpFour5.Value;
                }
                else
                {
                    currentTrainer.Data.poke6.waza1.pointUp = (int)ppUpOne6.Value;
                    currentTrainer.Data.poke6.waza2.pointUp = (int)ppUpTwo6.Value;
                    currentTrainer.Data.poke6.waza3.pointUp = (int)ppUpThree6.Value;
                    currentTrainer.Data.poke6.waza4.pointUp = (int)ppUpFour6.Value;
                }
            }
        }

        private void randomIV_CheckedChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                var currentPage = siticoneTabControl1.SelectedIndex;
                CheckBox box;
                if (currentPage == 0)
                {
                    box = randomIV1;

                    if (box.Checked)
                    {
                        currentTrainer.Data.poke1.talentType = "RANDOM";
                        currentTrainer.Data.poke1.talentValue.hp = 0;
                        currentTrainer.Data.poke1.talentValue.atk = 0;
                        currentTrainer.Data.poke1.talentValue.def = 0;
                        currentTrainer.Data.poke1.talentValue.spAtk = 0;
                        currentTrainer.Data.poke1.talentValue.spDef = 0;
                        currentTrainer.Data.poke1.talentValue.agi = 0;
                        hpIV1.Enabled = false;
                        atkIV1.Enabled = false;
                        defIV1.Enabled = false;
                        spaIV1.Enabled = false;
                        spdIV1.Enabled = false;
                        speIV1.Enabled = false;
                    } else
                    {
                        currentTrainer.Data.poke1.talentType = "VALUE";
                        hpIV1.Enabled = true;
                        atkIV1.Enabled = true;
                        defIV1.Enabled = true;
                        spaIV1.Enabled = true;
                        spdIV1.Enabled = true;
                        speIV1.Enabled = true;
                    }
                }
                else if (currentPage == 1)
                {
                    box = randomIV2;

                    if (box.Checked)
                    {
                        currentTrainer.Data.poke2.talentType = "RANDOM";
                        currentTrainer.Data.poke2.talentValue.hp = 0;
                        currentTrainer.Data.poke2.talentValue.atk = 0;
                        currentTrainer.Data.poke2.talentValue.def = 0;
                        currentTrainer.Data.poke2.talentValue.spAtk = 0;
                        currentTrainer.Data.poke2.talentValue.spDef = 0;
                        currentTrainer.Data.poke2.talentValue.agi = 0;
                        hpIV2.Enabled = false;
                        atkIV2.Enabled = false;
                        defIV2.Enabled = false;
                        spaIV2.Enabled = false;
                        spdIV2.Enabled = false;
                        speIV2.Enabled = false;
                    }
                    else
                    {
                        currentTrainer.Data.poke2.talentType = "VALUE";
                        hpIV2.Enabled = true;
                        atkIV2.Enabled = true;
                        defIV2.Enabled = true;
                        spaIV2.Enabled = true;
                        spdIV2.Enabled = true;
                        speIV2.Enabled = true;
                    }
                }
                else if (currentPage == 2)
                {
                    box = randomIV3;

                    if (box.Checked)
                    {
                        currentTrainer.Data.poke3.talentType = "RANDOM";
                        currentTrainer.Data.poke3.talentValue.hp = 0;
                        currentTrainer.Data.poke3.talentValue.atk = 0;
                        currentTrainer.Data.poke3.talentValue.def = 0;
                        currentTrainer.Data.poke3.talentValue.spAtk = 0;
                        currentTrainer.Data.poke3.talentValue.spDef = 0;
                        currentTrainer.Data.poke3.talentValue.agi = 0;
                        hpIV3.Enabled = false;
                        atkIV3.Enabled = false;
                        defIV3.Enabled = false;
                        spaIV3.Enabled = false;
                        spdIV3.Enabled = false;
                        speIV3.Enabled = false;
                    }
                    else
                    {
                        currentTrainer.Data.poke3.talentType = "VALUE";
                        hpIV3.Enabled = true;
                        atkIV3.Enabled = true;
                        defIV3.Enabled = true;
                        spaIV3.Enabled = true;
                        spdIV3.Enabled = true;
                        speIV3.Enabled = true;
                    }
                }
                else if (currentPage == 3)
                {
                    box = randomIV4;

                    if (box.Checked)
                    {
                        currentTrainer.Data.poke4.talentType = "RANDOM";
                        currentTrainer.Data.poke4.talentValue.hp = 0;
                        currentTrainer.Data.poke4.talentValue.atk = 0;
                        currentTrainer.Data.poke4.talentValue.def = 0;
                        currentTrainer.Data.poke4.talentValue.spAtk = 0;
                        currentTrainer.Data.poke4.talentValue.spDef = 0;
                        currentTrainer.Data.poke4.talentValue.agi = 0;
                        hpIV4.Enabled = false;
                        atkIV4.Enabled = false;
                        defIV4.Enabled = false;
                        spaIV4.Enabled = false;
                        spdIV4.Enabled = false;
                        speIV4.Enabled = false;
                    }
                    else
                    {
                        currentTrainer.Data.poke4.talentType = "VALUE";
                        hpIV4.Enabled = true;
                        atkIV4.Enabled = true;
                        defIV4.Enabled = true;
                        spaIV4.Enabled = true;
                        spdIV4.Enabled = true;
                        speIV4.Enabled = true;
                    }
                }
                else if (currentPage == 4)
                {
                    box = randomIV5;

                    if (box.Checked)
                    {
                        currentTrainer.Data.poke5.talentType = "RANDOM";
                        currentTrainer.Data.poke5.talentValue.hp = 0;
                        currentTrainer.Data.poke5.talentValue.atk = 0;
                        currentTrainer.Data.poke5.talentValue.def = 0;
                        currentTrainer.Data.poke5.talentValue.spAtk = 0;
                        currentTrainer.Data.poke5.talentValue.spDef = 0;
                        currentTrainer.Data.poke5.talentValue.agi = 0;
                        hpIV5.Enabled = false;
                        atkIV5.Enabled = false;
                        defIV5.Enabled = false;
                        spaIV5.Enabled = false;
                        spdIV5.Enabled = false;
                        speIV5.Enabled = false;
                    }
                    else
                    {
                        currentTrainer.Data.poke5.talentType = "VALUE";
                        hpIV5.Enabled = true;
                        atkIV5.Enabled = true;
                        defIV5.Enabled = true;
                        spaIV5.Enabled = true;
                        spdIV5.Enabled = true;
                        speIV5.Enabled = true;
                    }
                }
                else
                {
                    box = randomIV6;

                    if (box.Checked)
                    {
                        currentTrainer.Data.poke6.talentType = "RANDOM";
                        currentTrainer.Data.poke6.talentValue.hp = 0;
                        currentTrainer.Data.poke6.talentValue.atk = 0;
                        currentTrainer.Data.poke6.talentValue.def = 0;
                        currentTrainer.Data.poke6.talentValue.spAtk = 0;
                        currentTrainer.Data.poke6.talentValue.spDef = 0;
                        currentTrainer.Data.poke6.talentValue.agi = 0;
                        hpIV6.Enabled = false;
                        atkIV6.Enabled = false;
                        defIV6.Enabled = false;
                        spaIV6.Enabled = false;
                        spdIV6.Enabled = false;
                        speIV6.Enabled = false;
                    }
                    else
                    {
                        currentTrainer.Data.poke6.talentType = "VALUE";
                        hpIV6.Enabled = true;
                        atkIV6.Enabled = true;
                        defIV6.Enabled = true;
                        spaIV6.Enabled = true;
                        spdIV6.Enabled = true;
                        speIV6.Enabled = true;
                    }
                }
            }
        }

        private void manualButton_CheckedChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                var currentPage = siticoneTabControl1.SelectedIndex;
                CheckBox box;
                if (currentPage == 0)
                {
                    box = manualButton1;

                    if (box.Checked)
                    {
                        currentTrainer.Data.poke1.wazaType = "MANUAL";
                        moveOne1.Enabled = true;
                        ppUpOne1.Enabled = true;
                        moveTwo1.Enabled = true;
                        ppUpTwo1.Enabled = true;
                        moveThree1.Enabled = true;
                        ppUpThree1.Enabled = true;
                        moveFour1.Enabled = true;
                        ppUpFour1.Enabled = true;
                    }
                    else
                    {
                        currentTrainer.Data.poke1.wazaType = "DEFAULT";
                        moveOne1.SelectedIndex = 0;
                        moveOne1.Enabled = false;
                        moveTwo1.SelectedIndex = 0;
                        moveTwo1.Enabled = false;
                        moveThree1.SelectedIndex = 0;
                        moveThree1.Enabled = false;
                        moveFour1.SelectedIndex = 0;
                        moveFour1.Enabled = false;

                        ppUpOne1.Value = 0;
                        ppUpOne1.Enabled = false;
                        ppUpTwo1.Value = 0;
                        ppUpTwo1.Enabled = false;
                        ppUpThree1.Value = 0;
                        ppUpThree1.Enabled = false;
                        ppUpFour1.Value = 0;
                        ppUpFour1.Enabled = false;
                    }
                }
                else if (currentPage == 1)
                {
                    box = manualButton1;

                    if (box.Checked)
                    {
                        currentTrainer.Data.poke2.wazaType = "MANUAL";
                        moveOne2.Enabled = true;
                        ppUpOne2.Enabled = true;
                        moveTwo2.Enabled = true;
                        ppUpTwo2.Enabled = true;
                        moveThree2.Enabled = true;
                        ppUpThree2.Enabled = true;
                        moveFour2.Enabled = true;
                        ppUpFour2.Enabled = true;
                    }
                    else
                    {
                        currentTrainer.Data.poke2.wazaType = "DEFAULT";
                        moveOne2.SelectedIndex = 0;
                        moveOne2.Enabled = false;
                        moveTwo2.SelectedIndex = 0;
                        moveTwo2.Enabled = false;
                        moveThree2.SelectedIndex = 0;
                        moveThree2.Enabled = false;
                        moveFour2.SelectedIndex = 0;
                        moveFour2.Enabled = false;

                        ppUpOne2.Value = 0;
                        ppUpOne2.Enabled = false;
                        ppUpTwo2.Value = 0;
                        ppUpTwo2.Enabled = false;
                        ppUpThree2.Value = 0;
                        ppUpThree2.Enabled = false;
                        ppUpFour2.Value = 0;
                        ppUpFour2.Enabled = false;
                    }
                }
                else if (currentPage == 2)
                {
                    box = manualButton3;

                    if (box.Checked)
                    {
                        currentTrainer.Data.poke3.wazaType = "MANUAL";
                        moveOne3.Enabled = true;
                        ppUpOne3.Enabled = true;
                        moveTwo3.Enabled = true;
                        ppUpTwo3.Enabled = true;
                        moveThree3.Enabled = true;
                        ppUpThree3.Enabled = true;
                        moveFour3.Enabled = true;
                        ppUpFour3.Enabled = true;
                    }
                    else
                    {
                        currentTrainer.Data.poke3.wazaType = "DEFAULT";
                        moveOne3.SelectedIndex = 0;
                        moveOne3.Enabled = false;
                        moveTwo3.SelectedIndex = 0;
                        moveTwo3.Enabled = false;
                        moveThree3.SelectedIndex = 0;
                        moveThree3.Enabled = false;
                        moveFour3.SelectedIndex = 0;
                        moveFour3.Enabled = false;

                        ppUpOne3.Value = 0;
                        ppUpOne3.Enabled = false;
                        ppUpTwo3.Value = 0;
                        ppUpTwo3.Enabled = false;
                        ppUpThree3.Value = 0;
                        ppUpThree3.Enabled = false;
                        ppUpFour3.Value = 0;
                        ppUpFour3.Enabled = false;
                    }
                }
                else if (currentPage == 3)
                {
                    box = manualButton4;

                    if (box.Checked)
                    {
                        currentTrainer.Data.poke4.wazaType = "MANUAL";
                        moveOne4.Enabled = true;
                        ppUpOne4.Enabled = true;
                        moveTwo4.Enabled = true;
                        ppUpTwo4.Enabled = true;
                        moveThree4.Enabled = true;
                        ppUpThree4.Enabled = true;
                        moveFour4.Enabled = true;
                        ppUpFour4.Enabled = true;
                    }
                    else
                    {
                        currentTrainer.Data.poke4.wazaType = "DEFAULT";
                        moveOne4.SelectedIndex = 0;
                        moveOne4.Enabled = false;
                        moveTwo4.SelectedIndex = 0;
                        moveTwo4.Enabled = false;
                        moveThree4.SelectedIndex = 0;
                        moveThree4.Enabled = false;
                        moveFour4.SelectedIndex = 0;
                        moveFour4.Enabled = false;

                        ppUpOne4.Value = 0;
                        ppUpOne4.Enabled = false;
                        ppUpTwo4.Value = 0;
                        ppUpTwo4.Enabled = false;
                        ppUpThree4.Value = 0;
                        ppUpThree4.Enabled = false;
                        ppUpFour4.Value = 0;
                        ppUpFour4.Enabled = false;
                    }
                }
                else if (currentPage == 4)
                {
                    box = manualButton5;

                    if (box.Checked)
                    {
                        currentTrainer.Data.poke5.wazaType = "MANUAL";
                        moveOne5.Enabled = true;
                        ppUpOne5.Enabled = true;
                        moveTwo5.Enabled = true;
                        ppUpTwo5.Enabled = true;
                        moveThree5.Enabled = true;
                        ppUpThree5.Enabled = true;
                        moveFour5.Enabled = true;
                        ppUpFour5.Enabled = true;
                    }
                    else
                    {
                        currentTrainer.Data.poke5.wazaType = "DEFAULT";
                        moveOne5.SelectedIndex = 0;
                        moveOne5.Enabled = false;
                        moveTwo5.SelectedIndex = 0;
                        moveTwo5.Enabled = false;
                        moveThree5.SelectedIndex = 0;
                        moveThree5.Enabled = false;
                        moveFour5.SelectedIndex = 0;
                        moveFour5.Enabled = false;

                        ppUpOne5.Value = 0;
                        ppUpOne5.Enabled = false;
                        ppUpTwo5.Value = 0;
                        ppUpTwo5.Enabled = false;
                        ppUpThree5.Value = 0;
                        ppUpThree5.Enabled = false;
                        ppUpFour5.Value = 0;
                        ppUpFour5.Enabled = false;
                    }
                }
                else if (currentPage == 5)
                {
                    box = manualButton6;

                    if (box.Checked)
                    {
                        currentTrainer.Data.poke6.wazaType = "MANUAL";
                        moveOne6.Enabled = true;
                        ppUpOne6.Enabled = true;
                        moveTwo6.Enabled = true;
                        ppUpTwo6.Enabled = true;
                        moveThree6.Enabled = true;
                        ppUpThree6.Enabled = true;
                        moveFour6.Enabled = true;
                        ppUpFour6.Enabled = true;
                    }
                    else
                    {
                        currentTrainer.Data.poke6.wazaType = "DEFAULT";
                        moveOne6.SelectedIndex = 0;
                        moveOne6.Enabled = false;
                        moveTwo6.SelectedIndex = 0;
                        moveTwo6.Enabled = false;
                        moveThree6.SelectedIndex = 0;
                        moveThree6.Enabled = false;
                        moveFour6.SelectedIndex = 0;
                        moveFour6.Enabled = false;

                        ppUpOne6.Value = 0;
                        ppUpOne6.Enabled = false;
                        ppUpTwo6.Value = 0;
                        ppUpTwo6.Enabled = false;
                        ppUpThree6.Value = 0;
                        ppUpThree6.Enabled = false;
                        ppUpFour6.Value = 0;
                        ppUpFour6.Enabled = false;
                    }
                }
            }
        }

        private void defaultGemBox_CheckedChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                var currentPage = siticoneTabControl1.SelectedIndex;
                if (currentPage == 0)
                {
                    if (defaultGemBox1.Checked)
                    {
                        teraTypeBox1.SelectedIndex = 0;
                        teraTypeBox1.Enabled = false;
                        currentTrainer.Data.poke1.gemType = "DEFAULT";
                    } else
                    {
                        teraTypeBox1.Enabled = true;
                    }
                } else if (currentPage == 1)
                {
                    if (defaultGemBox2.Checked)
                    {
                        teraTypeBox2.SelectedIndex = 0;
                        teraTypeBox2.Enabled = false;
                        currentTrainer.Data.poke2.gemType = "DEFAULT";
                    }
                    else
                    {
                        teraTypeBox2.Enabled = true;
                    }
                } else if (currentPage == 2)
                {
                    if (defaultGemBox3.Checked)
                    {
                        teraTypeBox3.SelectedIndex = 0;
                        teraTypeBox3.Enabled = false;
                        currentTrainer.Data.poke3.gemType = "DEFAULT";
                    }
                    else
                    {
                        teraTypeBox3.Enabled = true;
                    }
                } else if (currentPage == 3)
                {
                    if (defaultGemBox4.Checked)
                    {
                        teraTypeBox4.SelectedIndex = 0;
                        teraTypeBox4.Enabled = false;
                        currentTrainer.Data.poke4.gemType = "DEFAULT";
                    }
                    else
                    {
                        teraTypeBox4.Enabled = true;
                    }
                } else if (currentPage == 4)
                {
                    if (defaultGemBox5.Checked)
                    {
                        teraTypeBox5.SelectedIndex = 0;
                        teraTypeBox5.Enabled = false;
                        currentTrainer.Data.poke5.gemType = "DEFAULT";
                    }
                    else
                    {
                        teraTypeBox5.Enabled = true;
                    }
                }
                {
                    if (defaultGemBox6.Checked)
                    {
                        teraTypeBox6.SelectedIndex = 0;
                        teraTypeBox6.Enabled = false;
                        currentTrainer.Data.poke6.gemType = "DEFAULT";
                    }
                    else
                    {
                        teraTypeBox6.Enabled = true;
                    }
                }
            }
        }

        private void teraTypeChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                var currentPage = siticoneTabControl1.SelectedIndex;
                if (currentPage == 0) currentTrainer.Data.poke1.gemType = typeToGemName.First(x => x.Key == teraTypeBox1.SelectedItem).Value;
                else if (currentPage == 0) currentTrainer.Data.poke2.gemType = typeToGemName.First(x => x.Key == teraTypeBox2.SelectedItem).Value;
                else if (currentPage == 0) currentTrainer.Data.poke3.gemType = typeToGemName.First(x => x.Key == teraTypeBox3.SelectedItem).Value;
                else if (currentPage == 0) currentTrainer.Data.poke4.gemType = typeToGemName.First(x => x.Key == teraTypeBox4.SelectedItem).Value;
                else if (currentPage == 0) currentTrainer.Data.poke5.gemType = typeToGemName.First(x => x.Key == teraTypeBox5.SelectedItem).Value;
                else currentTrainer.Data.poke6.gemType = typeToGemName.First(x => x.Key == teraTypeBox6.SelectedItem).Value;
            }
        }

        private void shinyBox_CheckedChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                var currentPage = siticoneTabControl1.SelectedIndex;
                if (currentPage == 0)
                {
                    if (shinyBox1.Checked) currentTrainer.Data.poke1.rareType = "RARE";
                    else currentTrainer.Data.poke1.rareType = "NO_RARE";
                } else if (currentPage == 1)
                {
                    if (shinyBox2.Checked) currentTrainer.Data.poke2.rareType = "RARE";
                    else currentTrainer.Data.poke2.rareType = "NO_RARE";
                }
                else if (currentPage == 2)
                {
                    if (shinyBox3.Checked) currentTrainer.Data.poke3.rareType = "RARE";
                    else currentTrainer.Data.poke3.rareType = "NO_RARE";
                }
                else if (currentPage == 3)
                {
                    if (shinyBox4.Checked) currentTrainer.Data.poke4.rareType = "RARE";
                    else currentTrainer.Data.poke4.rareType = "NO_RARE";
                }
                else if (currentPage == 4)
                {
                    if (shinyBox5.Checked) currentTrainer.Data.poke5.rareType = "RARE";
                    else currentTrainer.Data.poke5.rareType = "NO_RARE";
                }
                else
                {
                    if (shinyBox6.Checked) currentTrainer.Data.poke6.rareType = "RARE";
                    else currentTrainer.Data.poke6.rareType = "NO_RARE";
                }
            }
        }

        private void ballBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                var currentPage = siticoneTabControl1.SelectedIndex;
                if (currentPage == 0) currentTrainer.Data.poke1.ballId = ballToDevID.First(x => x.Key == ballBox1.Items[ballBox1.SelectedIndex].ToString()).Value;
                else if (currentPage == 1) currentTrainer.Data.poke2.ballId = ballToDevID.First(x => x.Key == ballBox2.Items[ballBox2.SelectedIndex].ToString()).Value;
                else if (currentPage == 2) currentTrainer.Data.poke3.ballId = ballToDevID.First(x => x.Key == ballBox3.Items[ballBox3.SelectedIndex].ToString()).Value;
                else if (currentPage == 3) currentTrainer.Data.poke4.ballId = ballToDevID.First(x => x.Key == ballBox4.Items[ballBox4.SelectedIndex].ToString()).Value;
                else if (currentPage == 4) currentTrainer.Data.poke5.ballId = ballToDevID.First(x => x.Key == ballBox5.Items[ballBox5.SelectedIndex].ToString()).Value;
                else currentTrainer.Data.poke6.ballId = ballToDevID.First(x => x.Key == ballBox6.Items[ballBox6.SelectedIndex].ToString()).Value;
            }
        }

        private void itemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                var currentPage = siticoneTabControl1.SelectedIndex;
                if (currentPage == 0) currentTrainer.Data.poke1.item = items.First(x => x.Item1 == itemBox1.SelectedItem.ToString().Replace("???", "NO NAME")).Item2;
                else if (currentPage == 1) currentTrainer.Data.poke2.item = items.First(x => x.Item1 == itemBox2.SelectedItem.ToString().Replace("???", "NO NAME")).Item2;
                else if (currentPage == 2) currentTrainer.Data.poke3.item = items.First(x => x.Item1 == itemBox3.SelectedItem.ToString().Replace("???", "NO NAME")).Item2;
                else if (currentPage == 3) currentTrainer.Data.poke4.item = items.First(x => x.Item1 == itemBox4.SelectedItem.ToString().Replace("???", "NO NAME")).Item2;
                else if (currentPage == 4) currentTrainer.Data.poke5.item = items.First(x => x.Item1 == itemBox5.SelectedItem.ToString().Replace("???", "NO NAME")).Item2;
                else currentTrainer.Data.poke6.item = items.First(x => x.Item1 == itemBox6.SelectedItem.ToString().Replace("???", "NO NAME")).Item2;
            }
        }

        private void levelChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                var currentPage = siticoneTabControl1.SelectedIndex;
                if (currentPage == 0) currentTrainer.Data.poke1.level = (int)levelBox1.Value;
                else if (currentPage == 1) currentTrainer.Data.poke2.level = (int)levelBox2.Value;
                else if (currentPage == 2) currentTrainer.Data.poke3.level = (int)levelBox3.Value;
                else if (currentPage == 3) currentTrainer.Data.poke4.level = (int)levelBox4.Value;
                else if (currentPage == 4) currentTrainer.Data.poke5.level = (int)levelBox5.Value;
                else currentTrainer.Data.poke6.level = (int)levelBox6.Value;
            }
        }

        private void abilityChanged(object sender, EventArgs e)
        {
            if (initialised)
            {
                var currentPage = siticoneTabControl1.SelectedIndex;
                if (currentPage == 0)
                {
                    if (abilityBox1.SelectedIndex == 0) currentTrainer.Data.poke1.tokusei = "RANDOM_12";
                    else if (abilityBox1.SelectedIndex == 1) currentTrainer.Data.poke1.tokusei = "SET_1";
                    else if (abilityBox1.SelectedIndex == 2) currentTrainer.Data.poke1.tokusei = "SET_2";
                    else currentTrainer.Data.poke1.tokusei = "SET_3";
                } else if (currentPage == 1)
                {
                    if (abilityBox2.SelectedIndex == 0) currentTrainer.Data.poke2.tokusei = "RANDOM_12";
                    else if (abilityBox2.SelectedIndex == 1) currentTrainer.Data.poke2.tokusei = "SET_1";
                    else if (abilityBox2.SelectedIndex == 2) currentTrainer.Data.poke2.tokusei = "SET_2";
                    else currentTrainer.Data.poke2.tokusei = "SET_3";
                } else if (currentPage == 2)
                {
                    if (abilityBox3.SelectedIndex == 0) currentTrainer.Data.poke3.tokusei = "RANDOM_12";
                    else if (abilityBox3.SelectedIndex == 1) currentTrainer.Data.poke3.tokusei = "SET_1";
                    else if (abilityBox3.SelectedIndex == 2) currentTrainer.Data.poke3.tokusei = "SET_2";
                    else currentTrainer.Data.poke3.tokusei = "SET_3";
                } else if (currentPage == 3)
                {
                    if (abilityBox4.SelectedIndex == 0) currentTrainer.Data.poke4.tokusei = "RANDOM_12";
                    else if (abilityBox4.SelectedIndex == 1) currentTrainer.Data.poke4.tokusei = "SET_1";
                    else if (abilityBox4.SelectedIndex == 2) currentTrainer.Data.poke4.tokusei = "SET_2";
                    else currentTrainer.Data.poke4.tokusei = "SET_3";
                } else if (currentPage == 4)
                {
                    if (abilityBox5.SelectedIndex == 0) currentTrainer.Data.poke5.tokusei = "RANDOM_12";
                    else if (abilityBox5.SelectedIndex == 1) currentTrainer.Data.poke5.tokusei = "SET_1";
                    else if (abilityBox5.SelectedIndex == 2) currentTrainer.Data.poke5.tokusei = "SET_2";
                    else currentTrainer.Data.poke5.tokusei = "SET_3";
                } else
                {
                    if (abilityBox6.SelectedIndex == 0) currentTrainer.Data.poke6.tokusei = "RANDOM_12";
                    else if (abilityBox6.SelectedIndex == 1) currentTrainer.Data.poke6.tokusei = "SET_1";
                    else if (abilityBox6.SelectedIndex == 2) currentTrainer.Data.poke6.tokusei = "SET_2";
                    else currentTrainer.Data.poke6.tokusei = "SET_3";
                }
            }
        }

        private void setPicture(string name, int form, int currentPage)
        {
            PictureBox sprite;
            if (currentPage == 0) sprite = spriteBox1;
            else if (currentPage == 1) sprite = spriteBox2;
            else if (currentPage == 2) sprite = spriteBox3;
            else if (currentPage == 3) sprite = spriteBox4;
            else if (currentPage == 4) sprite = spriteBox5;
            else sprite = spriteBox6;
            string picName;
            if (name == "Mr. Mime" && form == 0)
            {
                picName = "mrmime";
            }
            else if (name == "Mr. Mime" && form == 1)
            {
                picName = "mrmimegalar";
            }
            else if (name == "Mr. Rime")
            {
                picName = "mrrime";
            }
            else if (name == "Mime Jr.")
            {
                picName = "mimejr";
            }
            else if (name == "Farfetch’d" && form == 0)
            {
                picName = "farfetchd";
            }
            else if (name == "Farfetch’d" && form == 1)
            {
                picName = "farfetchdgalar";
            }
            else if (name == "Sirfetch’d")
            {
                picName = "sirfetchd";
            }
            else if (name == "Type: Null")
            {
                picName = "typenull";
            }
            else if (name == "Tauros" && form == 1)
            {
                picName = "taurospaldea";
            }
            else if (name == "Slowbro" && form == 1)
            {
                picName = "slowbromega";
            }
            else if (name == "Charizard" && form == 1)
            {
                picName = "charizardmegax";
            }
            else if (name == "Charizard" && form == 2)
            {
                picName = "charizardmegay";
            }
            else if (name == "Mewtwo" && form == 1)
            {
                picName = "mewtwomegax";
            }
            else if (name == "Mewtwo" && form == 2)
            {
                picName = "mewtwomegay";
            }
            else if (name == "Slowbro" && form == 2)
            {
                picName = "slowbrogalar";
            }
            else if (name == "Slowbro" && form == 1)
            {
                picName = "slowbromega";
            }
            else if (name == "Tauros" && form == 2)
            {
                picName = "taurospaldeafire";
            }
            else if (name == "Tauros" && form == 3)
            {
                picName = "taurospaldeawater";
            }
            else if (alolaForms.Contains(name) && form == 1 || name == "Meoowth" && form == 1)
            {
                picName = (name.ToLower() + "alola");
            }
            else if (galarForms.Contains(name) && form == 1 || name == "Meowth" && form == 2)
            {
                picName = (name.ToLower() + "galar");
            }
            else if (paldeaForms.Contains(name) && form == 1)
            {
                picName = (name.ToLower() + "paldea");
            }
            else if (hisuiForms.Contains(name) && form == 1)
            {
                picName = (name.ToLower() + "hisui");
            }
            else if (megaForms.Contains(name) && form == 1)
            {
                picName = (name.ToLower() + "mega");
            }
            else if (name.ToLower() == "walking wake")
            {
                picName = "suicune";
            }
            else if (name.ToLower() == "iron leaves")
            {
                picName = "virizion";
            }
            else
            {
                picName = name.Replace("♀", "f").Replace("♂", "m").Replace("-", "").Replace(" ", "").Replace("é", "e").ToLower();
            }

            sprite.BackgroundImage = Image.FromStream(assembly.GetManifestResourceStream($"Sky.Assets.Sprites.{picName}.png"));
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var option = e.Index;
            if (option == 0)
            {
                if (e.NewValue == CheckState.Checked) currentTrainer.Data.isStrong = true;
                else currentTrainer.Data.isStrong = false;
            } else if (option == 1)
            {
                if (e.NewValue == CheckState.Checked) currentTrainer.Data.aiBasic = true;
                else currentTrainer.Data.aiBasic = false;
            }
            else if (option == 2)
            {
                if (e.NewValue == CheckState.Checked) currentTrainer.Data.aiHigh = true;
                else currentTrainer.Data.aiHigh = false;
            }
            else if (option == 3)
            {
                if (e.NewValue == CheckState.Checked) currentTrainer.Data.aiExpert = true;
                else currentTrainer.Data.aiExpert = false;
            }
            else if (option == 4)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    currentTrainer.Data.aiDouble = true;
                    currentTrainer.Data.battleType = "_2vs2";
                }
                else
                {
                    currentTrainer.Data.aiDouble = false;
                    currentTrainer.Data.battleType = "_1vs1";
                }
            }
            else if (option == 5)
            {
                if (e.NewValue == CheckState.Checked) currentTrainer.Data.aiRaid = true;
                else currentTrainer.Data.aiRaid = false;
            }
            else if (option == 6)
            {
                if (e.NewValue == CheckState.Checked) currentTrainer.Data.aiWeak = true;
                else currentTrainer.Data.aiWeak = false;
            }
            else if (option == 7)
            {
                if (e.NewValue == CheckState.Checked) currentTrainer.Data.aiItem = true;
                else currentTrainer.Data.aiItem = false;
            }
            else if (option == 8)
            {
                if (e.NewValue == CheckState.Checked) currentTrainer.Data.aiChange = true;
                else currentTrainer.Data.aiChange = false;
            }
            else
            {
                if (e.NewValue == CheckState.Checked) currentTrainer.Data.changeGem = true;
                else currentTrainer.Data.changeGem = false;
            }
        }

        private void moneyRateBox_ValueChanged(object sender, EventArgs e)
        {
            currentTrainer.Data.moneyRate = (int)moneyRateBox.Value;
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

        // THIS GOES LAST DO NOT FUCKING PUT IT ANYWHERE ELSE FAT BITCH WHORE GOD DAMN I HATE YOU

        private async void TrainerEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // first we make sure the current trainer is saved

            trainer.values[currentTrainer.Index] = currentTrainer.Data;

            // now we make the bins :)

            var path = Path.Combine(MainForm.outDir, "trdata_array.json");

            var json = JsonSerializer.Serialize(trainer, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

            await File.WriteAllTextAsync(path, json);

            var flatcExe = MainForm.assembly.GetManifestResourceStream("Sky.Assets.Flatc.flatc.exe");
            var fbs = MainForm.assembly.GetManifestResourceStream("Sky.Assets.Flatc.trdata_array.bfbs");

            var tempExePath = Path.Combine(MainForm.outDir, "flatc.exe");
            var tempFbsPath = Path.Combine(MainForm.outDir, "trdata_array.bfbs");

            byte[] exebytes = new byte[(int)flatcExe.Length];
            byte[] fbsbytes = new byte[(int)fbs.Length];

            flatcExe.Read(exebytes, 0, exebytes.Length);
            fbs.Read(fbsbytes, 0, fbsbytes.Length);

            File.WriteAllBytesAsync(tempExePath, exebytes);
            File.WriteAllBytesAsync(tempFbsPath, fbsbytes);

            var cmd = Cli.Wrap(tempExePath).WithArguments("-o romfs/world/data/trainer/trdata/ -b trdata_array.bfbs trdata_array.json").WithWorkingDirectory(MainForm.outDir);

            await cmd.ExecuteBufferedAsync();

            File.Delete(tempExePath);
            File.Delete(tempFbsPath);

            var zipDirectories = Path.Combine(MainForm.outDir, "romfs/");
            var zipPath = Path.Combine(MainForm.outDir, "project_sky_pokemon_mod.zip");

            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

            ZipFile.CreateFromDirectory(zipDirectories, zipPath);
        }
    }
}
