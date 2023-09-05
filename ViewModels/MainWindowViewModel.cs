using ProjectSky.Core;
using ProjectSky.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectSky.Models;

namespace ProjectSky.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {

        private INavigationService _navigationService;
        public INavigationService NavigationService {
            get => _navigationService;
            set {
                _navigationService = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand CloseCommand { get; }
        public RelayCommand MinimiseCommand { get; }
        public RelayCommand DropdownCommand { get; }
        public RelayCommand GoBackCommand { get; }
        public RelayCommand SelectMenuItemCommand { get; }
        
        public ObservableCollection<string> MenuItems { get; } = new ObservableCollection<string> { "Edit Config", "Minimise", "Close" };

        private bool _isDropdownOpen;
        public bool IsDropdownOpen
        {
            get { return _isDropdownOpen; }
            set
            {
                if (_isDropdownOpen != value)
                {
                    _isDropdownOpen = value;
                    OnPropertyChanged(nameof(IsDropdownOpen));
                }
            }
        }
        private Models.Config configVals { get; }

        public MainWindowViewModel(INavigationService navService)
        {
            NavigationService = navService;
            NavigationService.NavigateTo<HomeViewModel>();
            CloseCommand = new RelayCommand(o => { CloseWindow(); }, o => true);
            MinimiseCommand = new RelayCommand(o => { MinimiseWindow(); }, o => true);
            DropdownCommand = new RelayCommand(o => { OpenCtxDropdown(); }, o => true);
            GoBackCommand = new RelayCommand(o => { GoBack(); }, o => true);
            SelectMenuItemCommand = new RelayCommand(o => { SelectMenuItem(o); }, o => true);

            // init the config.json file if one does not exist
            var configLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.json");
            if (!File.Exists(configLocation))
            {
                configVals = new Models.Config();
                var configJson = JsonSerializer.Serialize(configVals, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
                File.WriteAllText(configLocation, configJson);
            } else
            {
                using (var r = new StreamReader(configLocation))
                {
                    var conf = r.ReadToEnd();
                    configVals = JsonSerializer.Deserialize<Models.Config>(conf);
                }
            }
            CheckBins();
        }

        private void CheckBins()
        {
            var newTrDataExists = File.Exists(Path.Combine(configVals.outPath, "trdata_array.json"));
            var newPersonalExists = File.Exists(Path.Combine(configVals.outPath, "personal_array.json"));
            var newPDataExists = File.Exists(Path.Combine(configVals.outPath, "pokedata_array.json"));
            var update = new List<string> { };

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
                UpdateBins(update);
            }
        }

        private void UpdateBins(List<string> update)
        {
            var trdataOrigFile = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/trdata_array.json")).Stream;
            FileStream trdataNewFile = null;

            if (update.Contains("trdata"))
            {
                File.Copy(Path.Combine(configVals.outPath, "trdata_array.json"), Path.Combine(configVals.outPath, "trdata_array_2.json"));
                trdataNewFile = File.Open(Path.Combine(configVals.outPath, "trdata_array_2.json"), FileMode.Open);
            }

            var personalOrigFile = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/personal_array.json")).Stream;
            FileStream personalNewFile = null;

            if (update.Contains("personal"))
            {
                File.Copy(Path.Combine(configVals.outPath, "personal_array.json"), Path.Combine(configVals.outPath, "personal_array_2.json"));
                personalNewFile = File.Open(Path.Combine(configVals.outPath, "personal_array_2.json"), FileMode.Open);
            }

            var pdataOrigFile = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/pokedata_array.json")).Stream;
            FileStream pdataNewFile = null;

            if (update.Contains("pdata"))
            {
                File.Copy(Path.Combine(configVals.outPath, "pokedata_array.json"), Path.Combine(configVals.outPath, "pokedata_array_2.json"));
                pdataNewFile = File.Open(Path.Combine(configVals.outPath, "pokedata_array_2.json"), FileMode.Open);
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

                            var trainerOrig = System.Text.Json.JsonSerializer.Deserialize<Trainer.TrainerArray>(trdataOrigJson);
                            var trainerNew = System.Text.Json.JsonSerializer.Deserialize<Trainer.TrainerArray>(trdataNewJson);

                            for (var i = 0; i < trainerOrig.values.Count; i++)
                            {
                                if (trainerNew.values[i] == null)
                                {
                                    trainerNew.values[i] = trainerOrig.values[i];

                                    var path = Path.Combine(configVals.outPath, "trdata_array.json");

                                    var json = JsonSerializer.Serialize(trainerNew, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

                                    File.WriteAllText(path, json);
                                }
                            }
                        }
                        File.Delete(Path.Combine(configVals.outPath, "trdata_array_2.json"));
                    }
                    else if (x == "personal")
                    {
                        using (var personalNewReader = new StreamReader(personalNewFile))
                        {
                            var personalOrigJson = personalReader.ReadToEnd();
                            var personalNewJson = personalNewReader.ReadToEnd();

                            var personalOrig = System.Text.Json.JsonSerializer.Deserialize<Personal.PersonalArray>(personalOrigJson);
                            var personalNew = System.Text.Json.JsonSerializer.Deserialize<Personal.PersonalArray>(personalNewJson);

                            for (var i = 0; i < personalOrig.entry.Count; i++)
                            {
                                if (personalNew.entry[i] == null || personalOrig.entry[i].species.species == 987 && personalNew.entry[i].type_1 == 12 || personalOrig.entry[i].species.species == 980 && personalNew.entry[i].type_1 == 12)
                                {
                                    personalNew.entry[i] = personalOrig.entry[i];

                                    var path = Path.Combine(configVals.outPath, "personal_array.json");

                                    var json = System.Text.Json.JsonSerializer.Serialize(personalNew, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

                                    File.WriteAllText(path, json);
                                }
                            }
                        }
                        File.Delete(Path.Combine(configVals.outPath, "personal_array_2.json"));
                    }
                    else if (x == "pdata")
                    {
                        using (var pdataNewReader = new StreamReader(pdataNewFile))
                        {
                            var pdataOrigJson = pdataReader.ReadToEnd();
                            var pdataNewJson = pdataNewReader.ReadToEnd();

                            var pdataOrig = System.Text.Json.JsonSerializer.Deserialize<PokeData.DataArray>(pdataOrigJson);
                            var pdataNew = System.Text.Json.JsonSerializer.Deserialize<PokeData.DataArray>(pdataNewJson);

                            for (var i = 0; i < pdataOrig.values.Count; i++)
                            {
                                if (pdataNew.values[i] == null)
                                {
                                    pdataNew.values[i] = pdataOrig.values[i];

                                    var path = Path.Combine(configVals.outPath, "pokedata_array.json");

                                    var json = System.Text.Json.JsonSerializer.Serialize(pdataNew, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

                                    File.WriteAllText(path, json);
                                }
                            }
                        }
                        File.Delete(Path.Combine(configVals.outPath, "pokedata_array_2.json"));
                    }
                }
            }
        }

        private void CloseWindow()
        {
            Application.Current.Shutdown();
        }

        private void MinimiseWindow()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void OpenCtxDropdown()
        {
            IsDropdownOpen = !IsDropdownOpen;
        }

        private void GoBack()
        {
            var current = NavigationService.CurrentView;
            if (current.GetType() == typeof(SelectorViewModel))
            {
                var selector = (SelectorViewModel)current;
                selector.Exit();
                NavigationService.NavigateTo<HomeViewModel>();
            }
            if (current.GetType() == typeof(PokeEditorViewModel))
            {
                var editor = (PokeEditorViewModel)current;
                editor.Exit();
            }
            if (current.GetType() == typeof(MoveViewModel))
            {
                var editor = (MoveViewModel)current;
            }
            if (current.GetType() == typeof(TrainerViewModel))
            {
                var editor = (TrainerViewModel)current;
            }
        }

        private void SelectMenuItem(object menuItem)
        {
            var current = NavigationService.CurrentView;
            if (menuItem is string selectedMenuItem)
            {
                switch (selectedMenuItem)
                {
                    case "Edit Config":
                        Window config = new Views.Config();
                        config.Show();
                        break;

                    case "Save":
                        if (current.GetType() == typeof(PokeEditorViewModel))
                        {
                            var editor = (PokeEditorViewModel)current;
                            editor.Save();
                        }
                        break;

                    case "Reset":
                        if (current.GetType() == typeof(PokeEditorViewModel))
                        {
                            var editor = (PokeEditorViewModel)current;
                            editor.Reset();
                        }
                        break;

                    case "Minimise":
                        Application.Current.MainWindow.WindowState = WindowState.Minimized;
                        break;

                    case "Close":
                        Application.Current.Shutdown();
                        break;
                }
                IsDropdownOpen = false;
            }
        }
    }
}
