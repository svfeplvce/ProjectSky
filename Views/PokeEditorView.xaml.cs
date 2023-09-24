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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectSky.Views
{
    /// <summary>
    /// Interaction logic for PokeEditorView.xaml
    /// </summary>
    public partial class PokeEditorView : UserControl
    {
        public PokeEditorView()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is HandyControl.Controls.ComboBox combobox && DataContext is PokeEditorViewModel vm)
            {
                if (e.AddedItems.Count > 0 && e.AddedItems[0] is string selectedArgType && vm.Items.Contains(selectedArgType))
                {
                    vm.EditPlib(vm.Items.IndexOf(selectedArgType), combobox);
                }
            }
        }
    }
}
