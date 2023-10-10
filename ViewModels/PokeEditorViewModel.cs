using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Expression.Shapes;
using HandyControl.Tools;
using HandyControl.Tools.Command;
using HandyControl.Tools.Extension;
using ProjectSky.Core;
using ProjectSky.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Printing;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml.Linq;
using ComboBox = HandyControl.Controls.ComboBox;
using MessageBox = System.Windows.MessageBox;

namespace ProjectSky.ViewModels
{

    public class PokeEditorViewModel : ViewModel, IDataErrorInfo
    {
        private INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }
        public int PokeIndex { get; set; }

        private Personal.PersonalArray _personalOrig;
        private Personal.PersonalArray _personalNew;
        private Plib.PlibArray _plibOrig; 
        public Plib.PlibArray _plibNew { get; set; }
        private PokeData.DataArray _pdataOrig;
        private PokeData.DataArray _pdataNew;

        private Core.RelayCommand _toggleCheckBoxCommand;
        public Core.RelayCommand ToggleCheckBoxCommand
        {
            get
            {
                if (_toggleCheckBoxCommand == null)
                {
                    _toggleCheckBoxCommand = new Core.RelayCommand(o => { ToggleCheckBox(o); }, o => true);
                }
                return _toggleCheckBoxCommand;
            }
        }

        private Core.RelayCommand _addMoveCommand;
        public Core.RelayCommand AddMoveCommand
        {
            get
            {
                if (_addMoveCommand == null)
                {
                    _addMoveCommand = new Core.RelayCommand(o => { AddMove(); }, o => true);
                }
                return _addMoveCommand;
            }
        }

        private Core.RelayCommand _removeMoveCommand;
        public Core.RelayCommand RemoveMoveCommand
        {
            get
            {
                if (_removeMoveCommand == null)
                {
                    _removeMoveCommand = new Core.RelayCommand(o => { RemoveMove(); }, o => true);
                }
                return _removeMoveCommand;
            }
        }

        private Core.RelayCommand _addEvoCommand;
        public Core.RelayCommand AddEvoCommand
        {
            get
            {
                if (_addEvoCommand == null)
                {
                    _addEvoCommand = new Core.RelayCommand(o => { AddEvo(); }, o => true);
                }
                return _addEvoCommand;
            }
        }

        private Core.RelayCommand _removeEvoCommand;
        public Core.RelayCommand RemoveEvoCommand
        {
            get
            {
                if (_removeEvoCommand == null)
                {
                    _removeEvoCommand = new Core.RelayCommand(o => { RemoveEvo(); }, o => true);
                }
                return _removeEvoCommand;
            }
        }

        public string PokeName { get; private set; }
        public int PokeForm { get; private set; }

        private readonly List<string> tmList = new() { "Take Down", "Charm", "Fake Tears", "Agility", "Mud Slap", "Scary Face", "Protect", "Fire Fang", "Thunder Fang", "Ice Fang", "Water Pulse", "Low Kick", "Acid Spray", "Acrobatics", "Struggle Bug", "Psybeam", "Confuse Ray", "Thief", "Disarming Voice", "Trailblaze", "Pounce", "Chilling Water", "Charge Beam", "Fire Spin", "Facade", "Poison Tail", "Aerial Ace", "Bulldoze", "Hex", "Snarl", "Metal Claw", "Swift", "Magical Leaf", "Icy Wind", "Mud Shot", "Rock Tomb", "Draining Kiss", "Flame Charge", "Low Sweep", "Air Cutter", "Stored Power", "Night Shade", "Fling", "Dragon Tail", "Venoshock", "Avalanche", "Endure", "Volt Switch", "Sunny Day", "Rain Dance", "Sandstorm", "Snowscape", "Smart Strike", "Psyshock", "Dig", "Bullet Seed", "False Swipe", "Brick Break", "Zen Headbutt", "U-Turn", "Shadow Claw", "Foul Play", "Psychic Fangs", "Bulk Up", "Air Slash", "Body Slam", "Fire Punch", "Thunder Punch", "Ice Punch", "Sleep Talk", "Seed Bomb", "Electro Ball", "Drain Punch", "Reflect", "Light Screen", "Rock Blast", "Waterfall", "Dragon Claw", "Dazzling Gleam", "Metronome", "Grass Knot", "Thunder Wave", "Poison Jab", "Stomping Tantrum", "Rest", "Rock Slide", "Taunt", "Swords Dance", "Body Press", "Spikes", "Toxic Spikes", "Imprison", "Flash Cannon", "Dark Pulse", "Leech Life", "Eerie Impulse", "Fly", "Skill Swap", "Iron Head", "Dragon Dance", "Power Gem", "Gunk Shot", "Substitute", "Iron Defense", "X-Scissor", "Drill Run", "Will-O-Wisp", "Crunch", "Trick", "Liquidation", "Giga Drain", "Aura Sphere", "Tailwind", "Shadow Ball", "Dragon Pulse", "Stealth Rock", "Hyper Voice", "Heat Wave", "Energy Ball", "Psychic", "Heavy Slam", "Encore", "Surf", "Ice Spinner", "Flamethrower", "Thunderbolt", "Play Rough", "Amnesia", "Calm Mind", "Helping Hand", "Pollen Puff", "Baton Pass", "Earth Power", "Reversal", "Ice Beam", "Electric Terrain", "Grassy Terrain", "Psychic Terrain", "Misty Terrain", "Nasty Plot", "Fire Blast", "Hydro Pump", "Blizzard", "Fire Pledge", "Water Pledge", "Grass Pledge", "Wild Charge", "Sludge Bomb", "Earthquake", "Stone Edge", "Phantom Force", "Giga Impact", "Blast Burn", "Hydro Cannon", "Frenzy Plant", "Outrage", "Overheat", "Focus Blast", "Leaf Storm", "Hurricane", "Trick Room", "Bug Buzz", "Hyper Beam", "Brave Bird", "Flare Blitz", "Thunder", "Close Combat", "Solar Beam", "Draco Meteor", "Steel Beam", "Tera Blast", "Roar", "Charge", "Haze", "Toxic", "Sand Tomb", "Spite", "Gravity", "Smack Down", "Gyro Ball", "Knock Off", "Bug Bite", "Super Fang", "Vacuum Wave", "Lunge", "High Horsepower", "Icicle Spear", "Scald", "Heat Crash", "Solar Blade", "Uproar", "Focus Punch", "Weather Ball", "Grassy Glide", "Burning Jealousy", "Flip Turn", "Dual Wingbeat", "Poltergeist", "Lash Out", "Scale Shot", "Misty Explosion" };

        private Species _currentSpecies;

        public Species CurrentSpecies {
            get { 
                if (!IsLoaded)
                {
                    return null;
                }
                else return _currentSpecies;
            }
            set
            {
                _currentSpecies = value;
                OnPropertyChanged();
            }
        }

        public PokeEditorViewModel(INavigationService navService)
        {
            NavigationService = navService;
            var configLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.json");
            using (var r = new StreamReader(configLocation))
            {
                var conf = r.ReadToEnd();
                configVals = JsonSerializer.Deserialize<Config>(conf);
            }
            NavigationService.NavigatedToViewModel += OnNavigatedToViewModel;
        }

        private ObservableCollection<string> Moves = Application.Current.Properties["moves"] as ObservableCollection<string>;
        private ObservableCollection<string> SpeciesNames { get; } = Application.Current.Properties["species"] as ObservableCollection<string>;
        public ObservableCollection<string> Items { get;  } = Application.Current.Properties["items"] as ObservableCollection<string>;
        private ObservableCollection<Models.ComboBoxItemSky> _itemsComboBoxItems = new() { };
        public ObservableCollection<Models.ComboBoxItemSky> ItemsComboBoxItems
        {
            get => _itemsComboBoxItems;
            set
            {
                _itemsComboBoxItems = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<CheckBoxItemViewModel> _tmComboBoxItems = new() { };
        public ObservableCollection<CheckBoxItemViewModel> TMComboBoxItems
        {
            get => _tmComboBoxItems;
            set
            {
                _tmComboBoxItems = value;
                OnPropertyChanged();
            }
        }
        private Dictionary<int, int> PlibItems = new() { };
        private readonly List<string> alolaForms = new() { "Rattata", "Raticate", "Raichu", "Sandshrew", "Sandslash", "Vulpix", "Ninetales", "Diglett", "Dugtrio", "Meowth", "Persian", "Geodude", "Graveler", "Golem", "Grimer", "Muk", "Exeggutor", "Marowak" };
        private readonly List<string> galarForms = new() { "Meowth", "Ponyta", "Rapidash", "Weezing", "Corsola", "Zigzagoon", "Linoone", "Darumaka", "Darmanitan", "Yamask", "Stunfisk", "Slowpoke", "Slowbro", "Slowking", "Articuno", "Zapdos", "Moltres" };
        private readonly List<string> hisuiForms = new() { "Lilligant", "Growlithe", "Arcanine", "Voltorb", "Electrode", "Typhlosion", "Samurott", "Decidueye", "Qwilfish", "Sneasel", "Zorua", "Zoroark", "Braviary", "Sliggoo", "Goodra", "Avalugg" };
        private readonly List<string> paldeaForms = new() { "Wooper" };
        private readonly List<string> megaForms = new() { "Venusaur", "Blastoise", "Alakazam", "Gengar", "Kangaskhan", "Pinsir", "Gyarados", "Aerodactyl", "Ampharos", "Scizor", "Heracross", "Houndoom", "Tyranitar", "Blaziken", "Gardevoir", "Gallade", "Mawile", "Aggron", "Medicham", "Manectric", "Banette", "Absol", "Latios", "Latias", "Garchomp", "Lucario", "Abomasnow", "Beedrill", "Pidgeot", "Slowbro", "Steelix", "Sceptile", "Swampert", "Sableye", "Sharpedo", "Camerupt", "Altaria", "Glalie", "Salamence", "Metagross", "Rayquaza", "Lopunny", "Audino", "Diancie" };
        private readonly List<string> miscForms = new() { "Dialga", "Palkia", "Giratina", "Kyogre", "Groudon" };
        private PokeDevID.DevID PokeDevID;
        private ItemDevID.DevID ItemDevID;
        private Config configVals;
        private bool _isLoaded = false;
        
        public bool IsLoaded
        {
            get => _isLoaded;
            set
            {
                _isLoaded = value;
                OnPropertyChanged();
            }
        }

        private bool _hasPokeData;
        public bool HasPokeData
        {
            get => _hasPokeData;
            set
            {
                _hasPokeData = value;
                OnPropertyChanged();
            }
        }

        private string _heldItemDevName;
        public string HeldItemDevName
        {
            get => _heldItemDevName;
            set
            {
                _heldItemDevName = value;
                OnPropertyChanged();
            }
        }

        public string Error => "";

        public string this[string columnName] => "";

        private void OnNavigatedToViewModel(object sender, Type viewModelType)
        {
            if (viewModelType == typeof(PokeEditorViewModel))
            {
                IsLoaded = false;
                PlibItems.Clear();
                ItemsComboBoxItems.Clear();
                TMComboBoxItems.Clear();
                SelectorParamsToSend parameter = (SelectorParamsToSend)NavigationService.GetParameter<PokeEditorViewModel>();
                PokeIndex = parameter.PokeNum;
                PokeName = parameter.PokeName;
                PokeForm = parameter.FormNum;
                _personalOrig = parameter.Personal;
                _plibOrig = parameter.Plib;
                _pdataOrig = parameter.PokeData;
                _personalNew = _personalOrig;
                _plibNew = _plibOrig;
                _pdataNew = _pdataOrig;

                foreach (var x in _plibNew.values)
                {
                    PlibItems.Add(x.plibID, x.itemID);
                }


                Task.Run(async () => {
                    try
                    {
                        await LoadDataAsync();
                    } catch (Exception ex) 
                    {
                        Console.WriteLine(ex);
                    }
                    });
            }
        }

        private async Task LoadDataAsync()
        {
            var pokeDevIDFile = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/devid_list.json")).Stream;
            var itemDevIDFile = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/item_list.json")).Stream;
            using (var pokeDevIDReader = new StreamReader(pokeDevIDFile))
            using (var itemDevIDReader = new StreamReader(itemDevIDFile))
            {
                var pokeDevIDJson = pokeDevIDReader.ReadToEnd();
                var itemDevIDJson = itemDevIDReader.ReadToEnd();
                PokeDevID = JsonSerializer.Deserialize<PokeDevID.DevID>(pokeDevIDJson);
                ItemDevID = JsonSerializer.Deserialize<ItemDevID.DevID>(itemDevIDJson);
            }

            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                SetSpecies();
                FillItemList();
                FillTMList();
            });

            IsLoaded = true;

            OnPropertyChanged(nameof(CurrentSpecies));
        }

        private async Task SetSpecies()
        {
            var currentDevID = PokeDevID.values.FirstOrDefault(x => x.name == PokeName.Replace("Alolan ", "").Replace("Galarian ", "").Replace("Paldean ", "").Replace("Mega ", "").Replace(" X", "").Replace(" Y", "").Replace("Hisuian ", "").Replace("Origin ", "").Replace("Primal ", "").Replace(" Hearthflame", "").Replace(" Wellspring", "").Replace(" Cornerstone", "").Replace("Bloodmoon ", "")).devName;
            var currentPdata = _pdataNew.values.Exists(x => x.devid == currentDevID) ? _pdataNew.values.First(x => x.devid == currentDevID) : null;
            try
            {
                var devEntry = PokeDevID.values.First(y => y.devName == currentDevID);
                var pkEntry = _personalNew.entry.First(x => x.species.species == devEntry.id && x.species.form == PokeForm);
                CurrentSpecies = new Species { DevID = currentDevID, EntryInfo = pkEntry, PokeDataInfo = currentPdata, Index = PokeIndex, isForm = (alolaForms.Contains(SpeciesNames[_personalNew.entry[PokeIndex].species.species]) || galarForms.Contains(SpeciesNames[_personalNew.entry[PokeIndex].species.species]) || hisuiForms.Contains(SpeciesNames[_personalNew.entry[PokeIndex].species.species]) || megaForms.Contains(SpeciesNames[_personalNew.entry[PokeIndex].species.species]) || paldeaForms.Contains(SpeciesNames[_personalNew.entry[PokeIndex].species.species]) || miscForms.Contains(SpeciesNames[_personalNew.entry[PokeIndex].species.species]) || PokeName == "Indeedee" || PokeName == "Oricorio" || PokeName == "Lycanroc" || PokeName.Contains("Charizard") || PokeName.Contains("Mewtwo") || PokeName == "Eevee" || PokeName == "Pikachu" || PokeName == "Miraidon" || PokeName == "Koraidon" || PokeName == "Ogerpon" || PokeName == "Poltchageist" || PokeName == "Sinistcha") };
            } catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            if (currentPdata == null)
            {
                HasPokeData = false;
            }
            else
            {
                HasPokeData = true;
                HeldItemDevName = currentPdata.bringItem.itemID;
            }
        }

        private async Task FillItemList()
        {
            if (HasPokeData)
            {
                var batchSize = 100;
                var delay = 100;

                await Task.Run(() =>
                {
                    for (var i = 0; i < Items.Count; i += batchSize)
                    {
                        var batch = new List<Models.ComboBoxItemSky>();

                        for (var j = i; j < Math.Min(i + batchSize, Items.Count); j++)
                        {
                            string name;
                            string devName;
                            var ComboBoxItem = new Models.ComboBoxItemSky();
                            var y = ItemDevID.items.Exists(z => z.id == j) ? ItemDevID.items.First(z => z.id == j).devName : "";
                            if (Items[j] == "???")
                            {
                                name = "NO NAME";
                                devName = "ITEMID_NONE";
                            }
                            else
                            {
                                name = Items[j];
                                devName = y;
                            }
                            ComboBoxItem.DisplayName = name;
                            ComboBoxItem.DevName = devName;
                            batch.Add(ComboBoxItem);
                        }

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            ItemsComboBoxItems.AddRange(batch);
                        });

                        Thread.Sleep(delay);
                    }
                });
            }
        }

        private async Task FillTMList()
        {
            for (var x = 0; x < tmList.Count; x++)
            {
                var ComboBoxItem = new CheckBoxItemViewModel();
                ComboBoxItem.Value = tmList[x];
                if (_currentSpecies.EntryInfo.tm_moves.Contains(Moves.IndexOf(tmList[x])))
                {
                    ComboBoxItem.IsChecked = true;
                }
                else ComboBoxItem.IsChecked = false;
                ComboBoxItem.Index = Moves.IndexOf(tmList[x]);
                TMComboBoxItems.Add(ComboBoxItem);
            }
        }
        
        private void AddMove()
        {
            CurrentSpecies.EntryInfo.levelup_moves.Add(new Personal.LevelupMove { level = 1, move = 1 });
        }

        private void RemoveMove()
        {
            if (CurrentSpecies.EntryInfo.levelup_moves.Count != 1)
            {
                CurrentSpecies.EntryInfo.levelup_moves.RemoveAt(CurrentSpecies.EntryInfo.levelup_moves.Count - 1);
            }
        }
        
        private void AddEvo()
        {
            CurrentSpecies.EntryInfo.evo_data.Add(new Personal.EvoDatum { level = 1, condition = 4, form = 0, species = 1, parameter = 0 });
        }

        private void RemoveEvo()
        {
            if (CurrentSpecies.EntryInfo.evo_data.Count != 0)
            {
                CurrentSpecies.EntryInfo.evo_data.RemoveAt(CurrentSpecies.EntryInfo.evo_data.Count - 1);
            }
        }

        public void EditPlib(int item, HandyControl.Controls.ComboBox cb)
        {
            var _evoMethods = new ObservableCollection<EvoMethod> {
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

            var editedEntry = _plibNew.values.FirstOrDefault(x => x.itemID == 0);
            var parentSP = cb.Parent as StackPanel;
            if (editedEntry != null)
            {
                var checkIfInPlib = _plibNew.values.Where(x => x.itemID == item).Count() > 0;
                if (!checkIfInPlib)
                {
                    editedEntry.itemID = item;
                }
            }
            else MessageBox.Show("No more entries available in Plib. Please set the item to something else.");
        }

        private void ToggleCheckBox(object cb)
        {
            var checkBoxItem = cb as CheckBoxItemViewModel;
            if (checkBoxItem.IsChecked)
            {
                CurrentSpecies.EntryInfo.tm_moves.Add(checkBoxItem.Index);
            }
            else
            {
                CurrentSpecies.EntryInfo.tm_moves.Remove(checkBoxItem.Index);
            }
        }

        public void Exit()
        {
            try
            {
                var results = MessageBox.Show("Exit and save?\n\nTip: You can save by clicking on the dropdown menu in the top left corner of the window and clicking \"Save\".", "Caution", MessageBoxButton.YesNo);
                if (results == MessageBoxResult.Yes)
                {
                    Save();
                    NavigationService.NavigateTo<SelectorViewModel>();
                }
                else
                {
                    var results2 = MessageBox.Show("Exit without saving?", "Caution", MessageBoxButton.YesNo);
                    if (results2 == MessageBoxResult.Yes)
                    {
                        NavigationService.NavigateTo<SelectorViewModel>();
                    }
                    else return;
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public async void Save()
        {
            try
            {
                if (HasPokeData)
                {
                    CurrentSpecies.PokeDataInfo.bringItem.itemID = HeldItemDevName;
                }

                foreach (var x in CurrentSpecies.EntryInfo.evo_data)
                {
                    if (x.parameter == -1)
                    {
                        x.parameter = 0;
                    }
                }

                var devName = PokeDevID.values.First(y => y.devName == CurrentSpecies.DevID).id;
                var personalEntry = _personalNew.entry.FirstOrDefault(x => x.species.species == devName && x.species.form == PokeForm);

                personalEntry = CurrentSpecies.EntryInfo;

                if (HasPokeData)
                {
                    var entry = _pdataNew.values.First(x => x.devid == CurrentSpecies.DevID);
                    entry = CurrentSpecies.PokeDataInfo;
                }

                var personalPath = Path.Combine(configVals.outPath, "personal_array.json");
                var pdataPath = Path.Combine(configVals.outPath, "pokedata_array.json");
                var plibPath = Path.Combine(configVals.outPath, "plib_item_conversion_array.json");

                var personalJson = JsonSerializer.Serialize(_personalNew, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });
                var pdataJson = JsonSerializer.Serialize(_pdataNew, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });
                var plibJson = JsonSerializer.Serialize(_plibNew, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

                await File.WriteAllTextAsync(personalPath, personalJson);
                await File.WriteAllTextAsync(pdataPath, pdataJson);
                await File.WriteAllTextAsync(plibPath, plibJson);

                MessageBox.Show("Saved!\n\nTo create the zip file that can be used in Trinity Mod Loader, just click the back button on the selector screen! You can also continue to edit Pokemon until you are ready.", "Save Success");
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Reset()
        {
            try
            {
                var results = MessageBox.Show("Are you sure you want to reset? All progress will be lost.", "CAUTION: RESET", MessageBoxButton.YesNo);
                if (results == MessageBoxResult.Yes)
                {
                    _personalNew = _personalOrig;
                    _plibNew = _plibOrig;
                    _pdataNew = _pdataOrig;
                }
                else return;
            } catch (Exception ex)
            {
                Console.WriteLine("woops");
            }
        }
    }
}
