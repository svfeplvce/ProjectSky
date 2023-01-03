using CliWrap;
using CliWrap.Buffered;
using Siticone.Desktop.UI.WinForms;
using Sky.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sky.SubForms
{
    public partial class PokeEditor : Form
    {
        private Species _currentSpecies;
        private Personal.PersonalArray _personal;
        private PokeData.DataArray _pdata;
        private Plib.PlibArray _plib;
        private Dictionary<int, int> _plibItems;
        private PokemonEditor _form;
        private bool isForm;
        private bool isInitialised = false;
        private bool presentCheckChanged = false;
        private List<string> tmList = new List<string> { "Take Down", "Charm", "Fake Tears", "Agility", "Mud Slap", "Scary Face", "Protect", "Fire Fang", "Thunder Fang", "Ice Fang", "Water Pulse", "Low Kick", "Acid Spray", "Acrobatics", "Struggle Bug", "Psybeam", "Confuse Ray", "Thief", "Disarming Voice", "Trailblaze", "Pounce", "Chilling Water", "Charge Beam", "Fire Spin", "Facade", "Poison Tail", "Aerial Ace", "Bulldoze", "Hex", "Snarl", "Metal Claw", "Swift", "Magical Leaf", "Icy Wind", "Mud Shot", "Rock Tomb", "Draining Kiss", "Flame Charge", "Low Sweep", "Air Cutter", "Stored Power", "Night Shade", "Fling", "Dragon Tail", "Venoshock", "Avalanche", "Endure", "Volt Switch", "Sunny Day", "Rain Dance", "Sandstorm", "Snowscape", "Smart Strike", "Psyshock", "Dig", "Bullet Seed", "False Swipe", "Brick Break", "Zen Headbutt", "U-Turn", "Shadow Claw", "Foul Play", "Psychic Fangs", "Bulk Up", "Air Slash", "Body Slam", "Fire Punch", "Thunder Punch", "Ice Punch", "Sleep Talk", "Seed Bomb", "Electro Ball", "Drain Punch", "Reflect", "Light Screen", "Rock Blast", "Waterfall", "Dragon Claw", "Dazzling Gleam", "Metronome", "Grass Knot", "Thunder Wave", "Poison Jab", "Stomping Tantrum", "Rest", "Rock Slide", "Taunt", "Swords Dance", "Body Press", "Spikes", "Toxic Spikes", "Imprison", "Flash Cannon", "Dark Pulse", "Leech Life", "Eerie Impulse", "Fly", "Skill Swap", "Iron Head", "Dragon Dance", "Power Gem", "Gunk Shot", "Substitute", "Iron Defense", "X-Scissor", "Drill Run", "Will-O-Wisp", "Crunch", "Trick", "Liquidation", "Giga Drain", "Aura Sphere", "Tailwind", "Shadow Ball", "Dragon Pulse", "Stealth Rock", "Hyper Voice", "Heat Wave", "Energy Ball", "Psychic", "Heavy Slam", "Encore", "Surf", "Ice Spinner", "Flamethrower", "Thunderbolt", "Play Rough", "Amnesia", "Calm Mind", "Helping Hand", "Pollen Puff", "Baton Pass", "Earth Power", "Reversal", "Ice Beam", "Electric Terrain", "Grassy Terrain", "Psychic Terrain", "Misty Terrain", "Nasty Plot", "Fire Blast", "Hydro Pump", "Blizzard", "Fire Pledge", "Water Pledge", "Grass Pledge", "Wild Charge", "Sludge Bomb", "Earthquake", "Stone Edge", "Phantom Force", "Giga Impact", "Blast Burn", "Hydro Cannon", "Frenzy Plant", "Outrage", "Overheat", "Focus Blast", "Leaf Storm", "Hurricane", "Trick Room", "Bug Buzz", "Hyper Beam", "Brave Bird", "Flare Blitz", "Thunder", "Close Combat", "Solar Beam", "Draco Meteor", "Steel Beam", "Tera Blast" };
        private List<TMData> tms = new List<TMData> { };

        private List<EvoMethod> evoMethods = new List<EvoMethod> { 
            new EvoMethod{ Method="None", MethodID=0, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up With High Friendship", MethodID=1, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up With High Friendship At Daytime", MethodID=2, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up With High Friendship At Nighttime", MethodID=3, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up", MethodID=4, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Trade", MethodID=5, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Trade With Held Item", MethodID=6, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Trade (Shelmet/Karrablast)", MethodID=7, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Use Item", MethodID=8, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Level Up While ATK > DEF", MethodID=9, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up While ATK = DEF", MethodID=10, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up While ATK < DEF", MethodID=11, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up With A Certain Personality Value", MethodID=12, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up With A Certain Personality Value 2", MethodID=13, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up (Ninjask)", MethodID=14, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up (Shedinja)", MethodID=15, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up With High Beauty", MethodID=16, AdditionalArgs=true, UsesLevel=false, ArgType="Stat" },
            new EvoMethod{ Method="Use Item While Pokemon is Male", MethodID=17, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Use Item While Pokemon is Female", MethodID=18, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Level Up With Held Item At Daytime", MethodID=19, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Level Up With Held Item At Nighttime", MethodID=20, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Level Up While Knowing Move", MethodID=21, AdditionalArgs=true, UsesLevel=false, ArgType="Move" },
            new EvoMethod{ Method="Level Up With Teammate", MethodID=22, AdditionalArgs=true, UsesLevel=false, ArgType="Species" },
            new EvoMethod{ Method="Level Up While Pokemon is Male", MethodID=23, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up While Pokemon is Female", MethodID=24, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up Near Electric Rock", MethodID=25, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up Near Mossy Rock", MethodID=26, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up Near Cold Rock", MethodID=27, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up While Console is Inverted", MethodID=28, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up With High Affection And A Move Of A Specific Type", MethodID=29, AdditionalArgs=true, UsesLevel=false, ArgType="Type" },
            new EvoMethod{ Method="Level Up While Knowing A Move Of A Specific Type", MethodID=30, AdditionalArgs=true, UsesLevel=false, ArgType="Type" },
            new EvoMethod{ Method="Level Up During Rainy Weather", MethodID=31, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up During Morning", MethodID=32, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up During Night", MethodID=33, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up While Pokemon is Female Form", MethodID=34, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="UNUSED", MethodID=35, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up In Specific Version", MethodID=36, AdditionalArgs=true, UsesLevel=false, ArgType="Misc" },
            new EvoMethod{ Method="Level Up In Specific Version During Daytime", MethodID=37, AdditionalArgs=true, UsesLevel=false, ArgType="Misc" },
            new EvoMethod{ Method="Level Up In Specific Version During Nighttime", MethodID=38, AdditionalArgs=true, UsesLevel=false, ArgType="Misc" },
            new EvoMethod{ Method="Level Up At A Summit", MethodID=39, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up At Dusk", MethodID=40, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up In Ultra Wormhole", MethodID=41, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Use Item In Ultra Wormhole", MethodID=42, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Get x Crits In Battle", MethodID=43, AdditionalArgs=true, UsesLevel=false, ArgType="Misc" },
            new EvoMethod{ Method="Lose HP In Battle", MethodID=44, AdditionalArgs=true, UsesLevel=false, ArgType="Misc" },
            new EvoMethod{ Method="Spin", MethodID=45, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up With Amped Nature", MethodID=46, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up With LowKey Nature", MethodID=47, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Tower Of Darkness", MethodID=48, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Tower Of Waters", MethodID=49, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up After Walking x Steps With In Lets Go Mode", MethodID=50, AdditionalArgs=true, UsesLevel=false, ArgType="Misc" },
            new EvoMethod{ Method="Level Up In Union Circle", MethodID=51, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up In Battle With A Certain Personality Value", MethodID=52, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up In Battle With A Certain Personality Value 2", MethodID=53, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up After Collecting 999 Gimmighoul Coins", MethodID=54, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up After Defeating 3 Leader Bisharp", MethodID=55, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up After Using A Move x Times", MethodID=56, AdditionalArgs=true, UsesLevel=false, ArgType="Misc" },
            new EvoMethod{ Method="Level Up While Knowing A Move With A Certain Personality Value", MethodID=57, AdditionalArgs=true, UsesLevel=false, ArgType="Move" },
            new EvoMethod{ Method="Level Up While Knowing A Move With A Certain Personality Value 2", MethodID=58, AdditionalArgs=true, UsesLevel=false, ArgType="Move" },
            new EvoMethod{ Method="Level Up After Taking x Recoil Damage While Pokemon is Male", MethodID=59, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up After Taking x Recoil Damage While Pokemon is Female", MethodID=60, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Hisui", MethodID=61, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Use Item During Full Moon", MethodID=90, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Use Agile Style Moves", MethodID=91, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Use Strong Style Moves", MethodID=92, AdditionalArgs=false, UsesLevel=false, ArgType="None" }
        };

        private Dictionary<string, List<string>> evoArgs = new Dictionary<string, List<string>> {};

        public Species CurrentSpecies
        {
            get { return _currentSpecies; }
        }

        public PokeEditor(Species currentSpecies, Personal.PersonalArray personal, Plib.PlibArray plib, Dictionary<int, int> plibItems, PokeData.DataArray pdata, PokemonEditor form)
        {
            InitializeComponent();
            _currentSpecies = currentSpecies;
            if (_currentSpecies.Name.Contains("Alolan") || _currentSpecies.Name.Contains("Galarian") || _currentSpecies.Name.Contains("Hisuian") || _currentSpecies.Name.Contains("Mega") || _currentSpecies.Name.Contains("Paldean") || _currentSpecies.Name == "Indeedee") { isForm = true; } else { isForm = false; }
            _personal = personal;
            _pdata = pdata;
            _plib = plib;
            _plibItems = plibItems;
            _form = form;
            List<int> ints = Enumerable.Range(0, 1000).ToList();

            evoArgs.Add("Item", _form.itemNames);
            evoArgs.Add("Move", _form.moveNames);
            evoArgs.Add("Species", _form.speciesNames);
            evoArgs.Add("Type", new List<string> { "Normal", "Fighting", "Flying", "Poison", "Ground", "Rock", "Bug", "Ghost", "Steel", "Fire", "Water", "Grass", "Electric", "Psychic", "Ice", "Dragon", "Dark", "Fairy" });
            evoArgs.Add("Misc", ints.ConvertAll(x => x.ToString()));

            SetTMList();
            BuildMoveGrid();
            BuildEvoGrid();
            FillFields();
        }

        private void SetTMList()
        {
            foreach (var x in tmList)
            {
                foreach (var y in _form.moveNames)
                {
                    if (x == y)
                    {
                        var moveNum = _form.moveNames.IndexOf(x);
                        var tmNum = tmList.IndexOf(x) + 1;
                        tms.Add(new TMData { Name = x, MoveNumber = moveNum, TMNumber = tmNum });
                    }
                }
            }
        }

        private void BuildMoveGrid()
        {
            DataGridViewTextBoxColumn level = new DataGridViewTextBoxColumn()
            {
                Width = movesetGrid.Width / 2,
                HeaderText = "Level",
                MaxInputLength = 3
        };
            DataGridViewComboBoxColumn move = new DataGridViewComboBoxColumn()
            {
                Width = movesetGrid.Width / 2,
                HeaderText = "Move",
                DataSource = _form.moveNames,
                FlatStyle = FlatStyle.Flat
            };
            movesetGrid.Columns.Add(level);
            movesetGrid.Columns.Add(move);
        }

        private void BuildEvoGrid()
        {
            DataGridViewComboBoxColumn method = new DataGridViewComboBoxColumn()
            {
                Width = evoGrid.Width / 5,
                HeaderText = "Method",
                DataSource = evoMethods,
                FlatStyle = FlatStyle.Flat,
                DisplayMember = "Method"
            };
            DataGridViewComboBoxColumn arg = new DataGridViewComboBoxColumn()
            {
                Width = evoGrid.Width / 5,
                HeaderText = "Argument",
                FlatStyle = FlatStyle.Flat
            };
            DataGridViewTextBoxColumn level = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Level",
                Width = evoGrid.Width / 5
            };
            DataGridViewComboBoxColumn species = new DataGridViewComboBoxColumn()
            {
                Width = evoGrid.Width / 5,
                HeaderText = "Species",
                FlatStyle = FlatStyle.Flat,
                DataSource = _form.speciesNames
            };
            DataGridViewComboBoxColumn form = new DataGridViewComboBoxColumn()
            {
                Width = evoGrid.Width / 5,
                HeaderText = "Form",
                FlatStyle = FlatStyle.Flat
            };
            evoGrid.Columns.Add(method);
            evoGrid.Columns.Add(arg);
            evoGrid.Columns.Add(level);
            evoGrid.Columns.Add(species);
            evoGrid.Columns.Add(form);
        }

        private void FillFields()
        {
            pokemonName.Text = _currentSpecies.Name;
            pokemonName.Location = new Point(((baseStatsPage.Width / 2) - (pokemonName.Width / 2)), pokemonName.Location.Y);
            label4.Text = _currentSpecies.Name;
            label4.Location = new Point(((baseStatsPage.Width / 2) - (label4.Width / 2)), label4.Location.Y);
            label5.Text = _currentSpecies.Name;
            label5.Location = new Point(((baseStatsPage.Width / 2) - (label5.Width / 2)), label5.Location.Y);

            // base stats page

            presentCheck.CheckState = _currentSpecies.EntryInfo.is_present ? CheckState.Checked : CheckState.Unchecked;

            baseHP.Value = _currentSpecies.EntryInfo.base_stats.HP;
            baseATK.Value = _currentSpecies.EntryInfo.base_stats.ATK;
            baseDEF.Value = _currentSpecies.EntryInfo.base_stats.DEF;
            baseSPA.Value = _currentSpecies.EntryInfo.base_stats.SPA;
            baseSPD.Value = _currentSpecies.EntryInfo.base_stats.SPD;
            baseSPE.Value = _currentSpecies.EntryInfo.base_stats.SPE;

            var bst = ((int)baseHP.Value) + ((int)baseATK.Value) + ((int)baseDEF.Value) + ((int)baseSPA.Value) + ((int)baseSPD.Value) + ((int)baseSPE.Value);
            BSTtooltip.SetToolTip(panel3, $"Current BST is: {bst}");

            evHP.Value = _currentSpecies.EntryInfo.ev_yield.HP;
            evATK.Value = _currentSpecies.EntryInfo.ev_yield.ATK;
            evDEF.Value = _currentSpecies.EntryInfo.ev_yield.DEF;
            evSPA.Value = _currentSpecies.EntryInfo.ev_yield.SPA;
            evSPD.Value = _currentSpecies.EntryInfo.ev_yield.SPD;
            evSPE.Value = _currentSpecies.EntryInfo.ev_yield.SPE;

            typeBox1.SelectedIndex = _currentSpecies.EntryInfo.type_1;
            typeBox2.SelectedIndex = _currentSpecies.EntryInfo.type_2;

            abilityBox1.SelectedIndex = _currentSpecies.EntryInfo.ability_1;
            abilityBox2.SelectedIndex = _currentSpecies.EntryInfo.ability_2;
            abilityBox3.SelectedIndex = _currentSpecies.EntryInfo.ability_hidden;

            eggBox1.SelectedIndex = _currentSpecies.EntryInfo.egg_group_1;
            eggBox2.SelectedIndex = _currentSpecies.EntryInfo.egg_group_2;

            if (_pdata.values.Exists(x => x.devid == _currentSpecies.DevID))
            {
                heldItemBox.SelectedIndex = _form.items.IndexOf(_form.items.First(x => x.Item2 == _currentSpecies.PokeDataInfo.bringItem.itemID));
                heldItemRateBox.Value = _currentSpecies.PokeDataInfo.bringItem.bringRate;
            } else
            {
                heldItemBox.Visible = false;
                heldItemRateBox.Visible = false;
                heldLabel.Visible = false;
                percentLabel.Visible = false;
            }

            xpBox.SelectedIndex = _currentSpecies.EntryInfo.xp_growth;

            friendshipBox.Value = _currentSpecies.EntryInfo.base_friendship;

            catchRateBox.Value = _currentSpecies.EntryInfo.catch_rate;

            hatchBox.Value = _currentSpecies.EntryInfo.egg_hatch_steps;

            genderBox.SelectedIndex = _currentSpecies.EntryInfo.gender.group;

            if (genderBox.SelectedIndex > 0)
            {
                genderRatioBox.Visible = false;
                ratioLabel.Visible = false;
            } else
            {
                genderRatioBox.Value = _currentSpecies.EntryInfo.gender.ratio;
            }

            // moveset page

            foreach (var x in _currentSpecies.EntryInfo.tm_moves)
            {
                try
                {
                    tmBox.SetItemCheckState(tms.First(y => y.MoveNumber == x).TMNumber - 1, CheckState.Checked);
                } catch
                {
                    Console.WriteLine("not a tm!!!");
                }
            }

            movesetGrid.Rows.Add(_currentSpecies.EntryInfo.levelup_moves.Count);

            for (int i = 0; i < _currentSpecies.EntryInfo.levelup_moves.Count; i++)
            {
                movesetGrid.Rows[i].Cells[0].Value = _currentSpecies.EntryInfo.levelup_moves[i].level;
                movesetGrid.Rows[i].Cells[1].Value = _form.moveNames[_currentSpecies.EntryInfo.levelup_moves[i].move];
            }

            // evo page

            if (_currentSpecies.EntryInfo.evo_data.Count > 0)
            {
                evoGrid.Rows.Add(_currentSpecies.EntryInfo.evo_data.Count);

                for (int i = 0; i < _currentSpecies.EntryInfo.evo_data.Count; i++)
                {
                    evoGrid.Rows[i].Cells[0].Value = evoMethods.First(x => x.MethodID == _currentSpecies.EntryInfo.evo_data[i].condition).Method;
                    if (evoMethods.First(y => y.Method == evoGrid.Rows[i].Cells[0].Value).ArgType == "None")
                    {
                        evoGrid.Rows[i].Cells[1].ReadOnly = true;
                    }
                    else
                    {
                        evoGrid.Rows[i].Cells[1].ReadOnly = false;
                        (evoGrid.Rows[i].Cells[1] as DataGridViewComboBoxCell).DataSource = evoArgs.First(x => x.Key == evoMethods.First(y => y.Method == evoGrid.Rows[i].Cells[0].Value).ArgType).Value;
                    }
                    if (evoMethods.First(y => y.Method == evoGrid.Rows[i].Cells[0].Value).UsesLevel)
                    {
                        evoGrid.Rows[i].Cells[2].ReadOnly = false;
                        evoGrid.Rows[i].Cells[2].Value = _currentSpecies.EntryInfo.evo_data[i].level;
                    }
                    else
                    {
                        evoGrid.Rows[i].Cells[2].ReadOnly = true;
                    }
                    evoGrid.Rows[i].Cells[3].Value = _form.speciesNames[_currentSpecies.EntryInfo.evo_data[i].species];
                    if (_personal.entry.Where(x => x.species.species == _currentSpecies.EntryInfo.evo_data[i].species).Count() > 0)
                    {
                        evoGrid.Rows[i].Cells[4].ReadOnly = false;
                        (evoGrid.Rows[i].Cells[4] as DataGridViewComboBoxCell).DataSource = Enumerable.Range(0, _personal.entry.Where(x => x.species.species == _currentSpecies.EntryInfo.evo_data[i].species).Count() - 1).ToList();
                    }
                    else
                    {
                        evoGrid.Rows[i].Cells[4].ReadOnly = true;
                        evoGrid.Rows[i].Cells[4].Value = 0;
                    }
                }
            }

            isInitialised = true;
        }

        private void baseStat_ValueChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var editedValue = sender as SiticoneNumericUpDown;

                if (editedValue.Name == "baseHP")
                {
                    _currentSpecies.EntryInfo.base_stats.HP = ((int)editedValue.Value);
                } else if (editedValue.Name == "baseATK")
                {
                    _currentSpecies.EntryInfo.base_stats.ATK = ((int)editedValue.Value);
                } else if (editedValue.Name == "baseDEF")
                {
                    _currentSpecies.EntryInfo.base_stats.DEF = ((int)editedValue.Value);
                } else if (editedValue.Name == "baseSPA")
                {
                    _currentSpecies.EntryInfo.base_stats.SPA = ((int)editedValue.Value);
                } else if (editedValue.Name == "baseSPD")
                {
                    _currentSpecies.EntryInfo.base_stats.SPD = ((int)editedValue.Value);
                } else if (editedValue.Name == "baseSPE")
                {
                    _currentSpecies.EntryInfo.base_stats.SPE = ((int)editedValue.Value);
                }

                var bst = ((int)baseHP.Value) + ((int)baseATK.Value) + ((int)baseDEF.Value) + ((int)baseSPA.Value) + ((int)baseSPD.Value) + ((int)baseSPE.Value);
                BSTtooltip.SetToolTip(panel3, $"Current BST is: {bst}");
            }
        }

        private void ev_ValueChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var editedValue = sender as SiticoneNumericUpDown;

                if (editedValue.Name == "evHP")
                {
                    _currentSpecies.EntryInfo.ev_yield.HP = ((int)editedValue.Value);
                }
                else if (editedValue.Name == "evATK")
                {
                    _currentSpecies.EntryInfo.ev_yield.ATK = ((int)editedValue.Value);
                }
                else if (editedValue.Name == "evDEF")
                {
                    _currentSpecies.EntryInfo.ev_yield.DEF = ((int)editedValue.Value);
                }
                else if (editedValue.Name == "evSPA")
                {
                    _currentSpecies.EntryInfo.ev_yield.SPA = ((int)editedValue.Value);
                }
                else if (editedValue.Name == "evSPD")
                {
                    _currentSpecies.EntryInfo.ev_yield.SPD = ((int)editedValue.Value);
                }
                else if (editedValue.Name == "evSPE")
                {
                    _currentSpecies.EntryInfo.ev_yield.SPE = ((int)editedValue.Value);
                }
            }
        }

        private void presentCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                if (!presentCheckChanged)
                {
                    var check = sender as SiticoneCheckBox;
                    if (!check.Checked)
                    {
                        DialogResult res = MessageBox.Show("Unchecking this box can have unexpected consequences. Are you sure you want to continue?", "!! WARNING !!", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            presentCheckChanged = true;
                            _currentSpecies.EntryInfo.is_present = false;
                        } else
                        {
                            presentCheckChanged = true;
                            check.CheckState = CheckState.Unchecked;
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Checking this box can have unexpected consequences. Are you sure you want to continue?", "!! WARNING !!", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            presentCheckChanged = true;
                            _currentSpecies.EntryInfo.is_present = true;
                        } else
                        {
                            presentCheckChanged = true;
                            check.CheckState = CheckState.Checked;
                        }
                    }
                }
                presentCheckChanged = false;
            }
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var typeBox = sender as FlatComboBox;
                if (typeBox == typeBox1)
                {
                    _currentSpecies.EntryInfo.type_1 = typeBox.SelectedIndex;
                } else
                {
                    _currentSpecies.EntryInfo.type_2 = typeBox.SelectedIndex;
                }
            }
        }

        private void ability_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var abilityBox = sender as FlatComboBox;
                if (abilityBox == abilityBox1)
                {
                    _currentSpecies.EntryInfo.ability_1 = abilityBox.SelectedIndex;
                }
                else if (abilityBox == abilityBox2)
                {
                    _currentSpecies.EntryInfo.ability_2 = abilityBox.SelectedIndex;
                } else
                {
                    _currentSpecies.EntryInfo.ability_hidden = abilityBox.SelectedIndex;

                }
            }
        }

        private void egg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var eggBox = sender as FlatComboBox;
                if (eggBox == eggBox1)
                {
                    _currentSpecies.EntryInfo.egg_group_1 = eggBox.SelectedIndex;
                } else
                {
                    _currentSpecies.EntryInfo.egg_group_2 = eggBox.SelectedIndex;
                }
            }
        }

        private void xp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var xpGroupBox = sender as FlatComboBox;
                _currentSpecies.EntryInfo.xp_growth = xpGroupBox.SelectedIndex;
            }
        }

        private void heldItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var heldItemBox = sender as FlatComboBox;
                _currentSpecies.PokeDataInfo.bringItem.itemID = _form.items.First(x => x.Item3 == heldItemBox.SelectedIndex).Item2;
            }
        }

        private void heldItemRatio_ValueChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var ratioBox = sender as SiticoneNumericUpDown;
                _currentSpecies.PokeDataInfo.bringItem.bringRate = (int)ratioBox.Value;
            }
        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var genderBox = sender as FlatComboBox;
                _currentSpecies.EntryInfo.gender.group = genderBox.SelectedIndex;
                if (genderBox.SelectedIndex > 0)
                {
                    genderRatioBox.Visible = false;
                    _currentSpecies.EntryInfo.gender.ratio = 0;
                } else
                {
                    genderRatioBox.Visible = true;
                }
            }
        }

        private void genderRatio_ValueChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var ratioBox = sender as SiticoneNumericUpDown;
                _currentSpecies.EntryInfo.gender.ratio = (int)ratioBox.Value;
            }
        }

        private void miscStats_ValueChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var miscStatBox = sender as SiticoneNumericUpDown;
                if (miscStatBox == friendshipBox)
                {
                    _currentSpecies.EntryInfo.base_friendship = (int)miscStatBox.Value;
                } else if (miscStatBox == catchRateBox)
                {
                    _currentSpecies.EntryInfo.catch_rate = (int)miscStatBox.Value;
                }
                else if (miscStatBox == hatchBox)
                {
                    _currentSpecies.EntryInfo.egg_hatch_steps = (int)miscStatBox.Value;
                }
            }
        }

        private void tmBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isInitialised)
            {
                if (e.NewValue == CheckState.Unchecked)
                {
                    _currentSpecies.EntryInfo.tm_moves.Remove(e.Index);
                } else
                {
                    _currentSpecies.EntryInfo.tm_moves.Add(e.Index);
                }
            }
        }

        private void movesetGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isInitialised)
            {
                _currentSpecies.EntryInfo.levelup_moves.Clear();
                for (var i = 0; i < movesetGrid.RowCount; i++)
                {
                    if (movesetGrid.Rows[i].Cells[0].Value != null)
                    {
                        _currentSpecies.EntryInfo.levelup_moves.Add(new Personal.LevelupMove { level = int.Parse(movesetGrid.Rows[i].Cells[0].Value.ToString()) != 253 ? Math.Min(int.Parse(movesetGrid.Rows[i].Cells[0].Value.ToString()), 100) : 253, move = movesetGrid.Rows[i].Cells[1].Value == null ? 0 : _form.moveNames.IndexOf((string)movesetGrid.Rows[i].Cells[1].Value) });
                    }
                }
            }
        }

        private void evoGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (isInitialised)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewComboBoxCell cell = evoGrid.Rows[e.RowIndex].Cells[1] as DataGridViewComboBoxCell;
                    DataGridViewComboBoxCell cell2 = evoGrid.Rows[e.RowIndex].Cells[0] as DataGridViewComboBoxCell;
                    DataGridViewTextBoxCell cell3 = evoGrid.Rows[e.RowIndex].Cells[2] as DataGridViewTextBoxCell;
                    if (evoMethods.First(y => y.Method == cell2.Value).ArgType == "None")
                    {
                        cell.ReadOnly = true;
                    }
                    else
                    {
                        cell.ReadOnly = false;
                        cell.DataSource = evoArgs.First(x => x.Key == evoMethods.First(y => y.Method == cell2.Value).ArgType).Value;
                    }

                    if (evoMethods.First(y => y.Method == cell2.Value).UsesLevel)
                    {
                        cell3.ReadOnly = false;
                    } else
                    {
                        cell3.Value = 0;
                        cell3.ReadOnly = true;
                    }
                }
                if (evoGrid.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    if (_personal.entry.Where(x => x.species.species == _currentSpecies.EntryInfo.evo_data[e.RowIndex].species).Count() > 0)
                    {
                        evoGrid.Rows[e.RowIndex].Cells[4].ReadOnly = false;
                        (evoGrid.Rows[e.RowIndex].Cells[4] as DataGridViewComboBoxCell).DataSource = Enumerable.Range(0, _personal.entry.Where(x => x.species.species == _currentSpecies.EntryInfo.evo_data[e.RowIndex].species).Count() - 1).ToList().ConvertAll(x => x.ToString());
                    }
                    else
                    {
                        evoGrid.Rows[e.RowIndex].Cells[4].ReadOnly = true;
                        evoGrid.Rows[e.RowIndex].Cells[4].Value = 0;
                    }
                }

                // setting new values in currentspecies
                _currentSpecies.EntryInfo.evo_data.Clear();

                foreach (var x in evoGrid.Rows)
                {
                    var row = x as DataGridViewRow;
                    if (row.Index != evoGrid.Rows.Count - 1)
                    {
                        var method = row.Cells[0].Value == null ? 0 : evoMethods.First(y => y.Method == row.Cells[0].Value.ToString()).MethodID;
                        int arg;
                        if (row.Cells[1].Value != null)
                        {
                            if (evoMethods.First(y => y.MethodID == method).ArgType == "None")
                            {
                                arg = 0;
                            }
                            else if (evoMethods.First(y => y.MethodID == method).ArgType == "Item")
                            {
                                // we have to set plib stuff here in this case
                                var firstEmpty = _plib.values.First(y => y.itemID == 0);
                                if (firstEmpty != null)
                                {
                                    arg = firstEmpty.plibID;
                                    _plibItems[arg] = evoArgs["Item"].IndexOf(row.Cells[1].Value.ToString());
                                }
                                else
                                {
                                    MessageBox.Show($"No more space is available in plib for new evolution items. Please change the argument box in the {row.Index + 1} row to an evolution item that already exists.");
                                    arg = 0;
                                }
                            }
                            else
                            {
                                arg = evoArgs.First(y => y.Key == evoMethods.First(z => z.MethodID == method).ArgType).Value.IndexOf(row.Cells[1].Value.ToString());
                            }
                        }
                        else
                        {
                            arg = 0;
                        }
                        var level = (!evoMethods.First(y => y.MethodID == method).UsesLevel || row.Cells[2].Value == null) ? 0 : (int)row.Cells[2].Value;
                        var species = row.Cells[3].Value == null ? 0 : _form.speciesNames.IndexOf(row.Cells[3].Value.ToString());
                        var form = row.Cells[4].Value == null ? 0 : (int)row.Cells[4].Value;
                        _currentSpecies.EntryInfo.evo_data.Add(new Personal.EvoDatum { condition = method, parameter = arg, level = level, species = species, form = form });
                    }
                }
            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        // closing event (GOES LAST DUMB BITCH DONT FUCKING PUT ANYTHING HERE YOU FUCK!!!)

        private async void PokeEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // first we set the values in the base arrays

            var newPersonalData = _currentSpecies.EntryInfo;
            var newPokeData = _currentSpecies.PokeDataInfo;

            if (isForm)
            {
                var totalForms = _personal.entry.Where(x => x.species.species == _currentSpecies.EntryInfo.species.species).Count();

                for (var i = 0; i < totalForms; i++)
                {
                    _personal.entry[_currentSpecies.Index + i] = newPersonalData;
                }
            }
            else
            {
                _personal.entry[_currentSpecies.Index] = newPersonalData;
            }

            if (_pdata.values.Exists(x => x.devid == _currentSpecies.DevID))
            {
                _pdata.values[_pdata.values.IndexOf(_pdata.values.First(x => x.devid == _currentSpecies.DevID))] = newPokeData;
            }

            foreach (var x in _plibItems)
            {
                _plib.values.First(y => y.plibID == x.Key).itemID = x.Value;
            }

            _form._personal = _personal;
            _form._plib = _plib;
            _form._pdata = _pdata;

            var personalPath = Path.Combine(MainForm.outDir, "personal_array.json");
            var pdataPath = Path.Combine(MainForm.outDir, "pokedata_array.json");
            var plibPath = Path.Combine(MainForm.outDir, "plib_item_conversion_array.json");

            var personalJson = JsonSerializer.Serialize(_personal, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });
            var pdataJson = JsonSerializer.Serialize(_pdata, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });
            var plibJson = JsonSerializer.Serialize(_plib, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

            await File.WriteAllTextAsync(personalPath, personalJson);
            await File.WriteAllTextAsync(pdataPath, pdataJson);
            await File.WriteAllTextAsync(plibPath, plibJson);

            // create bins

            var flatcExe = MainForm.assembly.GetManifestResourceStream("Sky.Assets.Flatc.flatc.exe");
            var personalFBS = MainForm.assembly.GetManifestResourceStream("Sky.Assets.Flatc.personal_array.fbs");
            var plibBFBS = MainForm.assembly.GetManifestResourceStream("Sky.Assets.Flatc.plib_item_conversion_array.bfbs");
            var pdataBFBS = MainForm.assembly.GetManifestResourceStream("Sky.Assets.Flatc.pokedata_array.bfbs");

            var tempExePath = Path.Combine(MainForm.outDir, "flatc.exe");
            var personalFBSPath = Path.Combine(MainForm.outDir, "personal_array.fbs");
            var plibBFBSPath = Path.Combine(MainForm.outDir, "plib_item_conversion_array.bfbs");
            var pdataBFBSPath = Path.Combine(MainForm.outDir, "pokedata_array.bfbs");

            byte[] exebytes = new byte[(int)flatcExe.Length];
            byte[] pbytes = new byte[(int)personalFBS.Length];
            byte[] plbytes = new byte[(int)plibBFBS.Length];
            byte[] pdbytes = new byte[(int)pdataBFBS.Length];

            flatcExe.Read(exebytes, 0, exebytes.Length);
            personalFBS.Read(pbytes, 0, pbytes.Length);
            plibBFBS.Read(plbytes, 0, plbytes.Length);
            pdataBFBS.Read(pdbytes, 0, pdbytes.Length);

            File.WriteAllBytesAsync(tempExePath, exebytes);
            File.WriteAllBytesAsync(personalFBSPath, pbytes);
            File.WriteAllBytesAsync(plibBFBSPath, plbytes);
            File.WriteAllBytesAsync(pdataBFBSPath, pdbytes);

            var pcmd = Cli.Wrap(tempExePath).WithArguments("-o romfs/avalon/data/ -b personal_array.fbs personal_array.json").WithWorkingDirectory(MainForm.outDir);
            var plcmd = Cli.Wrap(tempExePath).WithArguments("-o romfs/world/data/battle/plib_item_conversion/ -b plib_item_conversion_array.bfbs plib_item_conversion_array.json").WithWorkingDirectory(MainForm.outDir);
            var pdcmd = Cli.Wrap(tempExePath).WithArguments("-o romfs/world/data/encount/pokedata/pokedata/ -b pokedata_array.bfbs pokedata_array.json").WithWorkingDirectory(MainForm.outDir);

            await pcmd.ExecuteBufferedAsync();
            await plcmd.ExecuteBufferedAsync();
            await pdcmd.ExecuteBufferedAsync();

            File.Delete(tempExePath);
            File.Delete(personalFBSPath);
            File.Delete(plibBFBSPath);
            File.Delete(pdataBFBSPath);

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
