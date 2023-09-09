using ProjectSky.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSky.Models
{
    public class CurrentMove : ViewModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private WazaArray.Waza _data;
        public WazaArray.Waza Data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged();
            }
        }

        private string _devID;
        public string DevID
        {
            get => _devID;
            set
            {
                _devID = value;
                OnPropertyChanged();
            }
        }

    }
}
