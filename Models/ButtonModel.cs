using ProjectSky.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectSky.Models
{
    public class ButtonModel
    {
        public StackPanel Content { get; }
        public RelayCommand Command { get; }

        public ButtonModel(StackPanel content, RelayCommand command)
        {
            Content = content;
            Command = command;
        }
    }
}
