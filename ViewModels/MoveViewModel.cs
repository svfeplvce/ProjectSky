using CliWrap;
using CliWrap.Buffered;
using ProjectSky.Core;
using ProjectSky.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectSky.ViewModels
{
    public class MoveViewModel : ViewModel
    {
        private MoveDevID.DevID _mvDevID;
        public MoveDevID.DevID MvDevID
        {
            get => _mvDevID;
            set
            {
                _mvDevID = value;
                OnPropertyChanged();
            }
        }

        public WazaArray.Wazas _moveOrig;
        public WazaArray.Wazas _moveNew;

        private Config configVals;

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

        private CurrentMove _selectedMove;
        public CurrentMove SelectedMove
        {
            get => _selectedMove;
            set
            {
                _selectedMove = value;
                OnPropertyChanged();
            }
        }

        private MoveDevID.Move _selected;
        public MoveDevID.Move Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                UpdateSelectedMove(_selected);
                OnPropertyChanged();
            }
        }

        private ObservableCollection<FlagBoxItemViewModel> _flagComboBoxItems = new ObservableCollection<FlagBoxItemViewModel>();
        public ObservableCollection<FlagBoxItemViewModel> FlagComboBoxItems
        {
            get => _flagComboBoxItems;
            set
            {
                _flagComboBoxItems = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ToggleCheckBoxCommand { get; set; }


        public MoveViewModel(INavigationService navService)
        {
            NavigationService = navService;
            NavigationService.NavigatedToViewModel += OnNavigatedToViewModel;
            var configLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.json");
            using (var r = new StreamReader(configLocation))
            {
                var conf = r.ReadToEnd();
                configVals = JsonSerializer.Deserialize<Config>(conf);
            }
            ToggleCheckBoxCommand = new RelayCommand(o => { ToggleCheckBox(o); }, o => true);
        }

        private void OnNavigatedToViewModel(object sender, Type viewModelType)
        {
            if (viewModelType == typeof(MoveViewModel))
            {
                Task.Run(async () => {
                    try
                    {
                        await LoadDataAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                });
            }
        }

        private async Task LoadDataAsync()
        {
            var moveFile = File.Exists(Path.Combine(configVals.outPath, "waza_array.json")) ? File.Open(Path.Combine(configVals.outPath, "waza_array.json"), FileMode.Open) : Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/waza_array.json")).Stream;
            var moveDevFile = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/move_list.json")).Stream;
            using (var moveReader = new StreamReader(moveFile))
            using (var moveDevReader = new StreamReader(moveDevFile))
            {
                var moveJson = moveReader.ReadToEnd();
                var moveDevJson = moveDevReader.ReadToEnd();

                _moveOrig = JsonSerializer.Deserialize<WazaArray.Wazas>(moveJson);
                _moveNew = JsonSerializer.Deserialize<WazaArray.Wazas>(moveJson);

                MvDevID = JsonSerializer.Deserialize<MoveDevID.DevID>(moveDevJson);
            }

            SelectedMove = new CurrentMove { Name = MvDevID.moves[1].name, Data = _moveNew.table[1], DevID = MvDevID.moves[1].devName };
            Selected = MvDevID.moves[1];
        }

        private async void UpdateSelectedMove(MoveDevID.Move waza)
        {
            if (waza == null) waza = MvDevID.moves[1];
            SelectedMove.Data = _moveNew.table.FirstOrDefault(x => x.move_id == waza.devName);
            SelectedMove.DevID = waza.devName;
            SelectedMove.Name = waza.name;
            OnPropertyChanged(nameof(SelectedMove));
            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                FillList();
            });
        }

        private async Task FillList()
        {
            FlagComboBoxItems.Clear();
            List<Tuple<string, string>> moveAttributes = new List<Tuple<string, string>> { Tuple.Create("can_use_move", "In the game?"), Tuple.Create("flag_protect", "Affected by protect?"), Tuple.Create("flag_mirror", "Can be mirrored?"), Tuple.Create("flag_makes_contact", "Makes contact?"), Tuple.Create("flag_metronome", "Selectable by metronome?"), Tuple.Create("flag_punch", "Is a punch move?"), Tuple.Create("flag_no_effectiveness", "No effectiveness?"), Tuple.Create("flag_charge", "Can be boosted by charge?"), Tuple.Create("flag_no_sleep_talk", "Can't be used by sleep talk?"), Tuple.Create("flag_fail_instruct", "Can make instruct fail?"), Tuple.Create("flag_snatch", "Affected by snatch?"), Tuple.Create("flag_dance", "Is a dance move?"), Tuple.Create("flag_slicing", "Is a slicing move?"), Tuple.Create("flag_distance_triple", "Can hit Bounce/Sky Attack?"), Tuple.Create("flag_wind", "Is a wind move?"), Tuple.Create("flag_reflectable", "Is reflectable?"), Tuple.Create("flag_ignore_substitute", "Ignores substitute?"), Tuple.Create("flag_animate_ally", "Swaps enemy Pokemon?"), Tuple.Create("flag_no_assist", "No assist?"), Tuple.Create("flag_fail_copy_cat", "Can make copy cat fail?"), Tuple.Create("flag_gravity", "Affected by gravity?"), Tuple.Create("flag_fail_sky_battle", "Can fail in sky battle?"), Tuple.Create("flag_bite", "Is a bite move?"), Tuple.Create("flag_sound", "Is a sound move?") };
            for (var x = 0; x < 24; x++)
            {
                if (SelectedMove.Name == "None")
                {
                    var ComboBoxItem = new FlagBoxItemViewModel();
                    ComboBoxItem.Value = moveAttributes[x].Item2;
                    ComboBoxItem.IsChecked = false;
                    ComboBoxItem.Flag = moveAttributes[x].Item1;
                    FlagComboBoxItems.Add(ComboBoxItem);
                }
                else
                {
                    var ComboBoxItem = new FlagBoxItemViewModel();
                    ComboBoxItem.Value = moveAttributes[x].Item2;
                    object propertyValue = SelectedMove.Data.GetType().GetProperty(moveAttributes[x].Item1)?.GetValue(SelectedMove.Data);
                    bool flag = propertyValue != null ? (bool)propertyValue : false;
                    if (flag)
                    {
                        ComboBoxItem.IsChecked = true;
                    }
                    else ComboBoxItem.IsChecked = false;
                    ComboBoxItem.Flag = moveAttributes[x].Item1;
                    FlagComboBoxItems.Add(ComboBoxItem);
                }
            }
        }

        public void ToggleCheckBox(object cb)
        {
            var checkBoxItem = cb as FlagBoxItemViewModel;
            var flag = SelectedMove.Data.GetType().GetProperty(checkBoxItem.Flag);
            if (checkBoxItem.IsChecked)
            {
                flag.SetValue(SelectedMove.Data, true);
            }
            else
            {
                flag.SetValue(SelectedMove.Data, false);
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
                var path = Path.Combine(configVals.outPath, "waza_array.json");

                var json = JsonSerializer.Serialize(_moveNew, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

                await File.WriteAllTextAsync(path, json);

                var flatcExe = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/Flatc/flatc.exe")).Stream;
                var fbs = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/Flatc/waza_array.bfbs")).Stream;

                var tempExePath = Path.Combine(configVals.outPath, "flatc.exe");
                var fbsPath = Path.Combine(configVals.outPath, "waza_array.fbs");

                byte[] exebytes = new byte[(int)flatcExe.Length];
                byte[] tbytes = new byte[(int)fbs.Length];

                flatcExe.Read(exebytes, 0, exebytes.Length);
                fbs.Read(tbytes, 0, tbytes.Length);

                File.WriteAllBytesAsync(tempExePath, exebytes);
                File.WriteAllBytesAsync(fbsPath, tbytes);

                var cmd = Cli.Wrap(tempExePath).WithArguments("-o romfs/world/data/trainer/trdata/ -b waza_array.fbs waza_array.json").WithWorkingDirectory(configVals.outPath);

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
                    _moveNew = _moveOrig;
                }
                else return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("woops");
            }
        }
    }
}
