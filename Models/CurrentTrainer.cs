using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSky.Models
{
    public class CurrentTrainer
    {
        public string Name { get; set; }
        public string DevID { get; set; }
        public int Index { get; set; }
        public Trainer.Value Data { get; set; }
    }
}
