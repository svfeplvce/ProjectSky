using ProjectSky.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectSky.Models
{
    public class CurrentTrainer : ViewModel
    {
        [JsonIgnore]
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        [JsonIgnore]
        private string _devID;
        public string DevID
        {
            get => _devID;
            set
            {
                if (_devID != value)
                {
                    _devID = value;
                    OnPropertyChanged();
                }
            }
        }
        [JsonIgnore]
        private Trainer.Value _data;
        public Trainer.Value Data
        {
            get => _data;
            set
            {
                if (_data != value)
                {
                    _data = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
