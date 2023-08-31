using ProjectSky.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSky.ViewModels
{
    public class PokeEditorViewModel : ViewModel
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

        public PokeEditorViewModel(INavigationService navService)
        {
            NavigationService = navService;
            NavigationService.NavigatedToViewModel += OnNavigatedToViewModel;
        }

        private void OnNavigatedToViewModel(object sender, Type viewModelType)
        {
            int parameter = (int)NavigationService.GetParameter<PokeEditorViewModel>();
            PokeIndex = parameter;
            FillFields();
        }

        private void FillFields()
        {
            
        }

    }
}
