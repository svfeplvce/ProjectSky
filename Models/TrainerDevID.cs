using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSky.Models
{
    public class TrainerDevID
    {
        public class DevID
        {
            public List<Trainer> trainers { get; set; }
        }

        public class Trainer
        {
            public string dev_id { get; set; }
            public string name { get; set; }
        }


    }
}
