using ProjectSky.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface INavigationService
{
    ViewModel CurrentView { get; }
    void NavigateTo<T>() where T : ViewModel;
    void NavigateTo<T>(object parameter) where T : ViewModel;
    object GetParameter<T>() where T : ViewModel;
    event EventHandler<Type> NavigatedToViewModel;
}

namespace ProjectSky.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, ViewModel> _viewModelFactory;
        private readonly Dictionary<Type, object> _parameters = new Dictionary<Type, object>();
        private ViewModel _currentView;

        public event EventHandler<Type> NavigatedToViewModel;

        public ViewModel CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, ViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModel
        {
            NavigateTo<TViewModel>(null);
        }

        public void NavigateTo<TViewModel>(object parameter) where TViewModel : ViewModel
        {
            ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
            _parameters[typeof(TViewModel)] = parameter;
            NavigatedToViewModel?.Invoke(this, typeof(TViewModel));
        }

        public object GetParameter<TViewModel>() where TViewModel : ViewModel
        {
            if (_parameters.TryGetValue(typeof(TViewModel), out object parameter)) return parameter;
            return null;
        }
    }
}
