using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSky.Models
{
    public class Species
    {
        public string Name { get; set; }
        public string DevID { get; set; }
        public int Index { get; set; }
        public Personal.Entry EntryInfo { get; set; }
        public PokeData.Value PokeDataInfo { get; set; }
        public bool isForm { get; set; }
    }
}
