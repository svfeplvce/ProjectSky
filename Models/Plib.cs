using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSky.Models
{
    public class Plib
    {
        public class PlibArray
        {
            public List<Value> values { get; set; }
        }

        public class Value
        {
            public int itemID { get; set; }
            public int plibID { get; set; }
        }
    }
}
