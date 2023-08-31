using ProjectSky.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public HomeViewModel(INavigationService navService)
        {
            NavigationService = navService;
            NavigateSelectCommand = new RelayCommand(o => { NavigationService.NavigateTo<SelectorViewModel>(); }, o => true);
        }

    }
}
