using ProjectSky.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectSky.Views
{
    /// <summary>
    /// Interaction logic for Config.xaml
    /// </summary>
    public partial class Config : Window
    {

        bool loaded = false;
        
        public Config()
        {
            InitializeComponent();
            DataContext = new ConfigViewModel();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void configWindow_Loaded(object sender, RoutedEventArgs e)
        {
            loaded = true;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (loaded)
            {
                var confVM = (ConfigViewModel)DataContext;
                confVM.UpdateConfChanged(sender, e);
            }
        }
    }
}
