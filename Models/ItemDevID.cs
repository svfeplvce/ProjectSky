using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSky.Models
{
    public class ItemDevID
    {
        public class Item
        {
            public string devName { get; set; }
            public int id { get; set; }
        }

        public class DevID
        {
            public List<Item> items { get; set; }
        }

    }
}
