using CliWrap;
using CliWrap.Buffered;
using ProjectSky.Core;
using ProjectSky.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjectSky.ViewModels
{
    public class TrainerViewModel : ViewModel
    {
        public ObservableCollection<string> Abilities { get; } = Application.Current.Properties["abilities"] as ObservableCollection<string>;
        public MoveDevID.DevID Moves { get; } = Application.Current.Properties["movesWithDevID"] as MoveDevID.DevID;
        public ObservableCollection<string> SpeciesNames { get; } = Application.Current.Properties["species"] as ObservableCollection<string>;
        public ObservableCollection<string> Items { get; } = Application.Current.Properties["items"] as ObservableCollection<string>;
        public ObservableCollection<string> Balls { get; } = Application.Current.Properties["balls"] as ObservableCollection<string>;
        public Dictionary<string, string> TeraTypes { get; } = Application.Current.Properties["teratypes"] as Dictionary<string, string>;
        public Dictionary<string, string> BallItemID { get; } = new Dictionary<string, string> { };
        public Dictionary<string, string> AbilityTr { get; } = new Dictionary<string, string> { { "Automatic", "RANDOM_12" }, { "Ability 1", "SET_1" }, { "Ability 2", "SET_2" }, { "Hidden Ability", "SET_3" } };

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

        public RelayCommand ToggleRandomIVCommand { get; set; }
        public RelayCommand ToggleRandomMovesCommand { get; set; }
        public RelayCommand ToggleShinyCommand { get; set; }


        private TrainerDevID.DevID _trDevID;
        public TrainerDevID.DevID TrDevID
        {
            get => _trDevID;
            set
            {
                _trDevID = value;
                OnPropertyChanged();
            }
        }
        private ItemDevID.DevID _itmDevID;
        public ItemDevID.DevID ItmDevID
        {
            get => _itmDevID;
            set
            {
                _itmDevID = value;
                OnPropertyChanged();
            }
        }

        private PokeDevID.DevID _pkDevID;
        public PokeDevID.DevID PkDevID
        {
            get => _pkDevID;
            set
            {
                _pkDevID = value;
                OnPropertyChanged();
            }
        }

        public Trainer.TrainerArray _trainerOrig;
        public Trainer.TrainerArray _trainerNew;

        private Config configVals;

        private CurrentTrainer _selectedTrainer;
        public CurrentTrainer SelectedTrainer
        {
            get => _selectedTrainer;
            set
            {
                _selectedTrainer = value;
                OnPropertyChanged();
            }
        }

        private TrainerDevID.Trainer _selected;
        public TrainerDevID.Trainer Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                UpdateSelectedTrainer(_selected);
                OnPropertyChanged();
            }
        }

        public TrainerViewModel(INavigationService navService)
        {
            NavigationService = navService;
            NavigationService.NavigatedToViewModel += OnNavigatedToViewModel;
            var configLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.json");
            using (var r = new StreamReader(configLocation))
            {
                var conf = r.ReadToEnd();
                configVals = JsonSerializer.Deserialize<Config>(conf);
            }
            ToggleRandomIVCommand = new RelayCommand(o => {ToggleRandomIV(o); }, o => true);
            ToggleRandomMovesCommand = new RelayCommand(o => {ToggleRandomMoves(o); }, o => true);
            ToggleShinyCommand = new RelayCommand(o => {ToggleShiny(o); }, o => true);
        }

        private void OnNavigatedToViewModel(object sender, Type viewModelType)
        {
            if (viewModelType == typeof(TrainerViewModel))
            {
                Task.Run(async () => {
                    try
                    {
                        await LoadDataAsync();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                });
            }
        }

        public void ToggleRandomIV(object box)
        {
            var b = box as Tuple<CheckBox, string>;
            var checkBox = b.Item1;
            var poke = b.Item2;
            var grid = checkBox.Parent as Grid;
            if (checkBox.IsChecked == false)
            {
                if (poke == "1")
                {
                    SelectedTrainer.Data.poke1.talentType = "VALUE";
                }
                if (poke == "2")
                {
                    SelectedTrainer.Data.poke2.talentType = "VALUE";
                }
                if (poke == "3")
                {
                    SelectedTrainer.Data.poke3.talentType = "VALUE";
                }
                if (poke == "4")
                {
                    SelectedTrainer.Data.poke4.talentType = "VALUE";
                }
                if (poke == "5")
                {
                    SelectedTrainer.Data.poke5.talentType = "VALUE";
                }
                if (poke == "6")
                {
                    SelectedTrainer.Data.poke6.talentType = "VALUE";
                }
                for (var i = 15; i < grid.Children.Count; i++)
                {
                    var child = grid.Children[i];
                    child.IsEnabled = true;
                }
            } else
            {
                if (poke == "1")
                {
                    SelectedTrainer.Data.poke1.talentType = "RANDOM";
                }
                if (poke == "2")
                {
                    SelectedTrainer.Data.poke2.talentType = "RANDOM";
                }
                if (poke == "3")
                {
                    SelectedTrainer.Data.poke3.talentType = "RANDOM";
                }
                if (poke == "4")
                {
                    SelectedTrainer.Data.poke4.talentType = "RANDOM";
                }
                if (poke == "5")
                {
                    SelectedTrainer.Data.poke5.talentType = "RANDOM";
                }
                if (poke == "6")
                {
                    SelectedTrainer.Data.poke6.talentType = "RANDOM";
                }
                for (var i = 15; i < grid.Children.Count; i++)
                {
                    var child = grid.Children[i];
                    child.IsEnabled = false;
                }
            }
        }

        public void ToggleRandomMoves(object box)
        {
            var b = box as Tuple<CheckBox, string>;
            var checkBox = b.Item1;
            var poke = b.Item2;
            var grid = checkBox.Parent as Grid;
            if (checkBox.IsChecked == false)
            {
                if (poke == "1")
                {
                    SelectedTrainer.Data.poke1.wazaType = "MANUAL";
                }
                if (poke == "2")
                {
                    SelectedTrainer.Data.poke2.talentType = "MANUAL";
                }
                if (poke == "3")
                {
                    SelectedTrainer.Data.poke3.talentType = "MANUAL";
                }
                if (poke == "4")
                {
                    SelectedTrainer.Data.poke4.talentType = "MANUAL";
                }
                if (poke == "5")
                {
                    SelectedTrainer.Data.poke5.talentType = "MANUAL";
                }
                if (poke == "6")
                {
                    SelectedTrainer.Data.poke6.talentType = "MANUAL";
                }
                for (var i = 1; i < grid.Children.Count - 1; i++)
                {
                    var child = grid.Children[i];
                    child.IsEnabled = true;
                }
            }
            else
            {
                if (poke == "1")
                {
                    SelectedTrainer.Data.poke1.talentType = "DEFAULT";
                }
                if (poke == "2")
                {
                    SelectedTrainer.Data.poke2.talentType = "DEFAULT";
                }
                if (poke == "3")
                {
                    SelectedTrainer.Data.poke3.talentType = "DEFAULT";
                }
                if (poke == "4")
                {
                    SelectedTrainer.Data.poke4.talentType = "DEFAULT";
                }
                if (poke == "5")
                {
                    SelectedTrainer.Data.poke5.talentType = "DEFAULT";
                }
                if (poke == "6")
                {
                    SelectedTrainer.Data.poke6.talentType = "DEFAULT";
                }
                for (var i = 1; i < grid.Children.Count - 1; i++)
                {
                    var child = grid.Children[i];
                    child.IsEnabled = false;
                }
            }
        }

        public void ToggleShiny(object box)
        {
            var b = box as Tuple<CheckBox, string>;
            var checkBox = b.Item1;
            var poke = b.Item2;
            if (checkBox.IsChecked == false)
            {
                if (poke == "1")
                {
                    SelectedTrainer.Data.poke1.rareType = "NO_RARE";
                }
                if (poke == "2")
                {
                    SelectedTrainer.Data.poke2.rareType = "NO_RARE";
                }
                if (poke == "3")
                {
                    SelectedTrainer.Data.poke3.rareType = "NO_RARE";
                }
                if (poke == "4")
                {
                    SelectedTrainer.Data.poke4.rareType = "NO_RARE";
                }
                if (poke == "5")
                {
                    SelectedTrainer.Data.poke5.rareType = "NO_RARE";
                }
                if (poke == "6")
                {
                    SelectedTrainer.Data.poke6.rareType = "NO_RARE";
                }
            }
            else
            {
                if (poke == "1")
                {
                    SelectedTrainer.Data.poke1.rareType = "RARE";
                }
                if (poke == "2")
                {
                    SelectedTrainer.Data.poke2.rareType = "RARE";
                }
                if (poke == "3")
                {
                    SelectedTrainer.Data.poke3.rareType = "RARE";
                }
                if (poke == "4")
                {
                    SelectedTrainer.Data.poke4.rareType = "RARE";
                }
                if (poke == "5")
                {
                    SelectedTrainer.Data.poke5.rareType = "RARE";
                }
                if (poke == "6")
                {
                    SelectedTrainer.Data.poke6.rareType = "RARE";
                }
            }
        }

        private async Task LoadDataAsync()
        {
            var trainerFile = File.Exists(Path.Combine(configVals.outPath, "trdata_array.json")) ? File.Open(Path.Combine(configVals.outPath, "trdata_array.json"), FileMode.Open) : Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/trdata_array.json")).Stream;
            var trainerDevFile = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/trdev_id.json")).Stream;
            using (var trainerReader = new StreamReader(trainerFile))
            using (var trainerDevReader = new StreamReader(trainerDevFile))
            {
                var trainerJson = trainerReader.ReadToEnd();
                var trainerDevJson = trainerDevReader.ReadToEnd();

                _trainerOrig = JsonSerializer.Deserialize<Trainer.TrainerArray>(trainerJson);
                _trainerNew = JsonSerializer.Deserialize<Trainer.TrainerArray>(trainerJson);

                TrDevID = JsonSerializer.Deserialize<TrainerDevID.DevID>(trainerDevJson);
                PkDevID = (PokeDevID.DevID)Application.Current.Properties["pkdevid"];
                ItmDevID = (ItemDevID.DevID)Application.Current.Properties["itemdevid"];
            }

            SelectedTrainer = new CurrentTrainer { Name = TrDevID.trainers[0].name, Data = _trainerNew.values[0], DevID = TrDevID.trainers[0].dev_id };
            Selected = TrDevID.trainers[0];

            foreach (var x in Balls)
            {
                var devName = ItmDevID.items.First(y => y.name == x).devName;
                BallItemID[x] = devName.Split("ITEMID_")[1];
            }
        }

        private async void UpdateSelectedTrainer(TrainerDevID.Trainer trainer)
        {
            if (trainer == null) trainer = TrDevID.trainers[0];
            SelectedTrainer.Data = _trainerNew.values.FirstOrDefault(x => x.trid == trainer.dev_id);
            SelectedTrainer.DevID = trainer.dev_id;
            SelectedTrainer.Name = trainer.name;
            OnPropertyChanged(nameof(SelectedTrainer));
        }

        public void Exit()
        {
            try
            {
                var results = MessageBox.Show("Exit and save?\n\nTip: You can save by clicking on the dropdown menu in the top left corner of the window and clicking \"Save\".", "Caution", MessageBoxButton.YesNo);
                if (results == MessageBoxResult.Yes)
                {
                    Save();
                    NavigationService.NavigateTo<HomeViewModel>();
                }
                else return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async void Save()
        {
            try
            {
                var path = Path.Combine(configVals.outPath, "trdata_array.json");

                var json = JsonSerializer.Serialize(_trainerNew, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

                await File.WriteAllTextAsync(path, json);

                var flatcExe = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/Flatc/flatc.exe")).Stream;
                var fbs = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/Flatc/trdata_array.bfbs")).Stream;

                var tempExePath = Path.Combine(configVals.outPath, "flatc.exe");
                var fbsPath = Path.Combine(configVals.outPath, "trdata_array.bfbs");

                byte[] exebytes = new byte[(int)flatcExe.Length];
                byte[] tbytes = new byte[(int)fbs.Length];

                flatcExe.Read(exebytes, 0, exebytes.Length);
                fbs.Read(tbytes, 0, tbytes.Length);

                File.WriteAllBytesAsync(tempExePath, exebytes);
                File.WriteAllBytesAsync(fbsPath, tbytes);

                var cmd = Cli.Wrap(tempExePath).WithArguments("-o romfs/world/data/trainer/trdata/ -b trdata_array.bfbs trdata_array.json").WithWorkingDirectory(configVals.outPath);

                await cmd.ExecuteBufferedAsync();

                File.Delete(tempExePath);
                File.Delete(fbsPath);

                var zipDirs = Path.Combine(configVals.outPath, "romfs/");
                var zipPath = Path.Combine(configVals.outPath, "project_sky_pokemon_mod.zip");

                if (File.Exists(zipPath))
                {
                    File.Delete(zipPath);
                }

                ZipFile.CreateFromDirectory(zipDirs, zipPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("woops");
            }
        }

        public void Reset()
        {
            try
            {
                var results = MessageBox.Show("Are you sure you want to reset? All progress will be lost.", "CAUTION: RESET", MessageBoxButton.YesNo);
                if (results == MessageBoxResult.Yes)
                {
                    _trainerNew = _trainerOrig;
                }
                else return;
            } catch (Exception ex)
            {
                Console.WriteLine("woops");
            }
        }
    }
}
