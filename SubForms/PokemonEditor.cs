using Sky.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sky.SubForms
{
    public partial class PokemonEditor : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private Assembly assembly = MainForm.assembly;
        private readonly string outPath = MainForm.outDir;
        private Species currentSpecies = new Species { };
        private PokeDevID.DevID pokeDevID;
        private List<Tuple<string, string, int>> items = new List<Tuple<string, string, int>> { };
        private List<string> abilityNames = new List<string> { };
        public List<string> speciesNames = new List<string> { };
        public List<string> moveNames = new List<string> { };
        public List<string> itemNames = new List<string> { };
        private List<string> alolaForms = new List<string> { "Rattata", "Raticate", "Raichu", "Sandshrew", "Sandslash", "Vulpix", "Ninetales", "Diglett", "Dugtrio", "Meowth", "Persian", "Geodude", "Graveler", "Golem", "Grimer", "Muk", "Exeggutor", "Marowak" }; 
        private List<string> galarForms = new List<string> { "Meowth", "Ponyta", "Rapidash", "Weezing", "Corsola", "Zigzagoon", "Linoone", "Darumaka", "Darmanitan", "Yamask", "Stunfisk", "Slowpoke", "Slowbro", "Slowking", "Articuno", "Zapdos", "Moltres" }; 
        private List<string> hisuiForms = new List<string> { "Lilligant", "Growlithe", "Arcanine", "Voltorb", "Electrode", "Typhlosion", "Samurott", "Decidueye", "Qwilfish", "Sneasel", "Zorua", "Zoroark", "Braviary", "Sliggoo", "Goodra", "Avalugg" }; 
        private List<string> paldeaForms = new List<string> { "Wooper" }; 
        private List<string> megaForms = new List<string> { "Venusaur", "Blastoise", "Alakazam", "Gengar", "Kangaskhan", "Pinsir", "Gyarados", "Aerodactyl", "Ampharos", "Scizor", "Heracross", "Houndoom", "Tyranitar", "Blaziken", "Gardevoir", "Gallade", "Mawile", "Aggron", "Medicham", "Manectric", "Banette", "Absol", "Latios", "Latias", "Garchomp", "Lucario", "Abomasnow", "Beedrill", "Pidgeot", "Slowbro", "Steelix", "Sceptile", "Swampert", "Sableye", "Sharpedo", "Camerupt", "Altaria", "Glalie", "Salamence", "Metagross", "Rayquaza", "Lopunny", "Audino", "Diancie" };
        private List<string> miscForms = new List<string> { "Dialga", "Palkia", "Giratina", "Kyogre", "Groudon" };
        private Dictionary<int, int> plibItems = new Dictionary<int, int> { };
        private Personal.PersonalArray personal;
        private Plib.PlibArray plib;
        private PokeData.DataArray pdata;
        public ItemDevID.DevID itemDevID;

        public Personal.PersonalArray _personal
        {
            get { return personal; }
            set { personal = value; }
        }
        public PokeData.DataArray _pdata
        {
            get { return pdata; }
            set { pdata = value; }
        }
        public Plib.PlibArray _plib
        {
            get { return plib; }
            set { plib = value; }
        }

        public PokemonEditor()
        {
            InitializeComponent();

            pictureBox1.BackgroundImage = Image.FromStream(assembly.GetManifestResourceStream("Sky.Assets.Images.sky_logo.png"));

            exitButton.Font = new Font(MainForm.pfc.Families[2], 12, FontStyle.Regular);

            LoadNecessaryFiles();
            FillSelectorPanel();
        }

        public void LoadNecessaryFiles()
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

            // jsons

            var personalFile = File.Exists(Path.Combine(outPath, "personal_array.json")) ? File.Open(Path.Combine(outPath, "personal_array.json"), FileMode.Open) : assembly.GetManifestResourceStream("Sky.Assets.JSON.personal_array.json");
            var plibFile = File.Exists(Path.Combine(outPath, "plib_item_conversion_array.json")) ? File.Open(Path.Combine(outPath, "plib_item_conversion_array.json"), FileMode.Open) : assembly.GetManifestResourceStream("Sky.Assets.JSON.plib_item_conversion_array.json");
            var pokeDataFile = File.Exists(Path.Combine(outPath, "pokedata_array.json")) ? File.Open(Path.Combine(outPath, "pokedata_array.json"), FileMode.Open) : assembly.GetManifestResourceStream("Sky.Assets.JSON.pokedata_array.json");
            var pokeDevIDFile = assembly.GetManifestResourceStream("Sky.Assets.JSON.devid_list.json");
            var itemDevIDFile = assembly.GetManifestResourceStream("Sky.Assets.JSON.item_list.json");
            using (var personalReader = new StreamReader(personalFile))
            using (var plibReader = new StreamReader(plibFile))
            using (var pdataReader = new StreamReader(pokeDataFile))
            using (var pokeDevIDReader = new StreamReader(pokeDevIDFile))
            using (var itemDevIDReader = new StreamReader(itemDevIDFile))
            {
                var personalJson = personalReader.ReadToEnd();
                var plibJson = plibReader.ReadToEnd();
                var pdataJson = pdataReader.ReadToEnd();
                var pokeDevIDJson = pokeDevIDReader.ReadToEnd();
                var itemDevIDJson = itemDevIDReader.ReadToEnd();
                
                personal = JsonSerializer.Deserialize<Personal.PersonalArray>(personalJson);
                plib = JsonSerializer.Deserialize<Plib.PlibArray>(plibJson);
                pdata = JsonSerializer.Deserialize<PokeData.DataArray>(pdataJson);
                pokeDevID = JsonSerializer.Deserialize<PokeDevID.DevID>(pokeDevIDJson);
                itemDevID = JsonSerializer.Deserialize<ItemDevID.DevID>(itemDevIDJson);

                // we have to init some stuff in here oopsie

                var currentItemID = 0;

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

                foreach (var x in plib.values)
                {
                    plibItems.Add(x.plibID, x.itemID);
                }
            }
        }

        private void FillSelectorPanel()
        {
            foreach (var entry in personal.entry)
            {
                string picName;

                if (speciesNames[entry.species.species] == "Mr. Mime" && entry.species.form == 0)
                {
                    picName = "mrmime";
                } else if (speciesNames[entry.species.species] == "Mr. Mime" && entry.species.form == 1)
                {
                    picName = "mrmimegalar";
                } else if (speciesNames[entry.species.species] == "Mr. Rime")
                {
                    picName = "mrrime";
                } else if (speciesNames[entry.species.species] == "Mime Jr.")
                {
                    picName = "mimejr";
                } else if (speciesNames[entry.species.species] == "Farfetch’d" && entry.species.form == 0)
                {
                    picName = "farfetchd";
                } else if (speciesNames[entry.species.species] == "Farfetch’d" && entry.species.form == 1)
                {
                    picName = "farfetchdgalar";
                } else if (speciesNames[entry.species.species] == "Sirfetch’d")
                {
                    picName = "sirfetchd";
                } else if (speciesNames[entry.species.species] == "Type: Null")
                {
                    picName = "typenull";
                } else if (speciesNames[entry.species.species] == "Tauros" && entry.species.form == 1)
                {
                    picName = "taurospaldea";
                } else if (speciesNames[entry.species.species] == "Slowbro" && entry.species.form == 1)
                {
                    picName = "slowbromega";
                }  else if (speciesNames[entry.species.species] == "Charizard" && entry.species.form == 1)
                {
                    picName = "charizardmegax";
                }  else if (speciesNames[entry.species.species] == "Charizard" && entry.species.form == 2)
                {
                    picName = "charizardmegay";
                }  else if (speciesNames[entry.species.species] == "Mewtwo" && entry.species.form == 1)
                {
                    picName = "mewtwomegax";
                }  else if (speciesNames[entry.species.species] == "Mewtwo" && entry.species.form == 2)
                {
                    picName = "mewtwomegay";
                } else if (speciesNames[entry.species.species] == "Slowbro" && entry.species.form == 2)
                {
                    picName = "slowbrogalar";
                } else if (speciesNames[entry.species.species] == "Slowbro" && entry.species.form == 1)
                {
                    picName = "slowbromega";
                } else if (speciesNames[entry.species.species] == "Tauros" && entry.species.form == 2)
                {
                    picName = "taurospaldeafire";
                } else if (speciesNames[entry.species.species] == "Tauros" && entry.species.form == 3)
                {
                    picName = "taurospaldeawater";
                } else if (alolaForms.Contains(speciesNames[entry.species.species]) && entry.species.form == 1 || speciesNames[entry.species.species] == "Meoowth" && entry.species.form == 1)
                {
                    picName = (speciesNames[entry.species.species].ToLower() + "alola");
                } else if (galarForms.Contains(speciesNames[entry.species.species]) && entry.species.form == 1 || speciesNames[entry.species.species] == "Meowth" && entry.species.form == 2)
                {
                    picName = (speciesNames[entry.species.species].ToLower() + "galar");
                } else if (paldeaForms.Contains(speciesNames[entry.species.species]) && entry.species.form == 1)
                {
                    picName = (speciesNames[entry.species.species].ToLower() + "paldea");
                } else if (hisuiForms.Contains(speciesNames[entry.species.species]) && entry.species.form == 1)
                {
                    picName = (speciesNames[entry.species.species].ToLower() + "hisui");
                }
                else if (megaForms.Contains(speciesNames[entry.species.species]) && entry.species.form == 1)
                {
                    picName = (speciesNames[entry.species.species].ToLower() + "mega");
                } else if (speciesNames[entry.species.species].ToLower() == "walking wake")
                {
                    picName = "suicune";
                } else if (speciesNames[entry.species.species].ToLower() == "iron leaves")
                {
                    picName = "virizion";
                }
                else
                {
                    picName = speciesNames[entry.species.species].Replace("♀", "f").Replace("♂", "m").Replace("-", "").Replace(" ", "").Replace("é", "e").ToLower();
                }

                if (entry.species.species > 0)
                {
                    Button button = new Button();
                    button.Height = 125;
                    button.Width = 78;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 50, 50);
                    button.Margin = new Padding(5, 5, 5, 5);
                    button.ForeColor = Color.White;
                    button.Image = Image.FromStream(assembly.GetManifestResourceStream($"Sky.Assets.Sprites.{picName}.png"));
                    button.TextAlign = ContentAlignment.BottomCenter;
                    button.ImageAlign = ContentAlignment.TopCenter;

                    if (entry.species.form >= 1)
                    {
                        if (alolaForms.Contains(speciesNames[entry.species.species]) || speciesNames[entry.species.species] == "Meowth" && entry.species.form == 1)
                        {
                            button.Text = ("Alolan " + speciesNames[entry.species.species]);
                        }
                        else if (galarForms.Contains(speciesNames[entry.species.species]) || speciesNames[entry.species.species] == "Meowth" && entry.species.form == 2 || speciesNames[entry.species.species] == "Slowbro" && entry.species.form == 2)
                        {
                            button.Text = ("Galarian " + speciesNames[entry.species.species]);
                        }
                        else if (paldeaForms.Contains(speciesNames[entry.species.species]))
                        {
                            button.Text = ("Paldean " + speciesNames[entry.species.species]);
                        }
                        else if (hisuiForms.Contains(speciesNames[entry.species.species]))
                        {
                            button.Text = ("Hisuian " + speciesNames[entry.species.species]);
                        }
                        else if ((megaForms.Contains(speciesNames[entry.species.species]) || speciesNames[entry.species.species] == "Slowbro" && entry.species.form == 1) && (speciesNames[entry.species.species] != "Charizard" || (speciesNames[entry.species.species] != "Mewtwo")))
                        {
                            button.Text = ("Mega " + speciesNames[entry.species.species]);
                        }
                        else if ((speciesNames[entry.species.species] == "Mewtwo" || speciesNames[entry.species.species] == "Charizard") && entry.species.form == 1)
                        {
                            button.Text = ("Mega " + speciesNames[entry.species.species] + " X");
                        }
                        else if ((speciesNames[entry.species.species] == "Mewtwo" || speciesNames[entry.species.species] == "Charizard") && entry.species.form == 2)
                        {
                            button.Text = ("Mega " + speciesNames[entry.species.species] + " Y");
                        }
                        else if (speciesNames[entry.species.species] == "Dialga" || speciesNames[entry.species.species] == "Palkia" || speciesNames[entry.species.species] == "Giratina")
                        {
                            button.Text = ("Origin " + speciesNames[entry.species.species]);
                        }
                        else if (speciesNames[entry.species.species] == "Kyogre" || speciesNames[entry.species.species] == "Groudon") {
                            button.Text = ("Primal " + speciesNames[entry.species.species]);
                        }
                        else
                        {
                            button.Text = speciesNames[entry.species.species];
                        }
                    } else
                    {
                        button.Text = speciesNames[entry.species.species];
                    }

                    button.Click += Species_Click;
                    selectorPanel.Controls.Add(button);
                }
            }
        }

        private void Species_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            var num = selectorPanel.Controls.IndexOf(button) + 1;
            var currentPdata = pdata.values.Exists(x => x.devid == pokeDevID.values.FirstOrDefault(x => x.id == speciesNames.IndexOf(button.Text.Replace("Alolan ", "").Replace("Galarian ", "").Replace("Paldean ", "").Replace("Mega ", "").Replace(" X", "").Replace(" Y", "").Replace("Hisuian ", "").Replace("Origin ", "").Replace("Primal ", ""))).devName) ? pdata.values.First(x => x.devid == pokeDevID.values.FirstOrDefault(x => x.id == speciesNames.IndexOf(button.Text.Replace("Alolan ", "").Replace("Galarian ", "").Replace("Paldean ", "").Replace("Mega ", "").Replace(" X", "").Replace(" Y", "").Replace("Hisuian ", "").Replace("Origin ", "").Replace("Primal ", ""))).devName) : null;
            currentSpecies = new Species { Name = button.Text, DevID = pokeDevID.values.First(x => x.id == speciesNames.IndexOf(button.Text.Replace("Alolan ", "").Replace("Galarian ", "").Replace("Paldean ", "").Replace("Mega ", "").Replace(" X", "").Replace(" Y", "").Replace("Hisuian ", "").Replace("Origin ", "").Replace("Primal ", ""))).devName, Index = num, EntryInfo = personal.entry[num], PokeDataInfo = currentPdata, isForm = (alolaForms.Contains(speciesNames[personal.entry[num].species.species]) || galarForms.Contains(speciesNames[personal.entry[num].species.species]) || hisuiForms.Contains(speciesNames[personal.entry[num].species.species]) || megaForms.Contains(speciesNames[personal.entry[num].species.species]) || paldeaForms.Contains(speciesNames[personal.entry[num].species.species]) || miscForms.Contains(speciesNames[personal.entry[num].species.species]) || button.Text == "Indeedee" || button.Text == "Oricorio" || button.Text == "Lycanroc" || button.Text.Contains("Charizard") || button.Text.Contains("Mewtwo") || button.Text == "Eevee") ? true : false};
            selectorPanel.Visible = false;
            searchBox.Visible = false;
            Form editor = new PokeEditor(currentSpecies, personal, plib, plibItems, pdata, this, items);
            editor.TopLevel = false;
            editor.FormClosed += Editor_FormClosed;
            contentPanel.Controls.Add(editor);
            editor.Show();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            foreach (var c in selectorPanel.Controls)
            {
                var button = c as Button;
                if (button.Text.ToLower().Contains(searchBox.Text.ToLower()))
                {
                    button.Enabled = true;
                }
                else button.Enabled = false;
            }
        }

        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            selectorPanel.Visible = true;
            searchBox.Visible = true;
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
