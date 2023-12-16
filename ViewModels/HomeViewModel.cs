using ProjectSky.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectSky.ViewModels
{
    public class HomeViewModel : ViewModel
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

        public RelayCommand NavigateSelectCommand { get; set; }
        public RelayCommand NavigateTrainerCommand { get; set; }
        public RelayCommand NavigateMoveCommand { get; set; }

        public HomeViewModel(INavigationService navService)
        {
            NavigationService = navService;
            NavigateSelectCommand = new RelayCommand(o => { NavigationService.NavigateTo<SelectorViewModel>(); }, o => true);
            NavigateTrainerCommand = new RelayCommand(o => { NavigationService.NavigateTo<TrainerViewModel>(); }, o => true);
            NavigateMoveCommand = new RelayCommand(o => { NotAdded(); }, o => true);
            //NavigateMoveCommand = new RelayCommand(o => { NavigationService.NavigateTo<MoveViewModel>(); }, o => true);
        }

        private void NotAdded()
        {
            MessageBox.Show("Move editor is coming soon. If you would like to contribute, please feel free to download the source code and mess with it yourself.\n\nFollow phantomAnarch on GameBanana for updates on when it's coming.");
        }
    }
}
