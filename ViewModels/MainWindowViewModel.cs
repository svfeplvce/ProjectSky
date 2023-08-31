using ProjectSky.Core;
using ProjectSky.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        public MainWindowViewModel(INavigationService navService)
        {
            NavigationService = navService;
            NavigationService.NavigateTo<HomeViewModel>();
            CloseCommand = new RelayCommand(o => { CloseWindow(); }, o => true);
            MinimiseCommand = new RelayCommand(o => { MinimiseWindow(); }, o => true);
            DropdownCommand = new RelayCommand(o => { OpenCtxDropdown(); }, o => true);
            SelectMenuItemCommand = new RelayCommand(o => { SelectMenuItem(o); }, o => true);
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

        private void SelectMenuItem(object menuItem)
        {
            if (menuItem is string selectedMenuItem)
            {
                switch (selectedMenuItem)
                {
                    case "Edit Config":
                        Window config = new Config();
                        config.Show();
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
