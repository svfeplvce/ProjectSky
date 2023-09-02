using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSky.Models
{
    public class SelectorParamsToSend
    {
        public int PokeNum { get; set; }
        public string PokeName { get; set; }
        public Personal.PersonalArray Personal { get; set; }
        public Plib.PlibArray Plib { get; set; }
        public PokeData.DataArray PokeData { get; set; }
    }
}
