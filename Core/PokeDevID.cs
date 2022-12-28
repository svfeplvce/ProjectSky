using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Core
{
    public class PokeDevID
    {
        public class DevID
        {
            public List<Value> values { get; set; }
        }

        public class Value
        {
            public string devName { get; set; }
            public int id { get; set; }
            public int forms { get; set; }
        }
    }
}
