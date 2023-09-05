using ProjectSky.Core;
using ProjectSky.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectSky.ViewModels
{
    public class TrainerViewModel : ViewModel
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
                        Console.WriteLine(ex);
                    }
                });
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
            }

            SelectedTrainer = new CurrentTrainer { Data = _trainerNew.values[0], DevID = TrDevID.trainers[0].dev_id, Name = TrDevID.trainers[0].name };
        }
    }
}
