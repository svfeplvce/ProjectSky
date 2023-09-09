using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSky.Models
{
    public class MoveDevID
    {
        public class Move
        {
            public string devName { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int type { get; set; }
            public object power { get; set; }
        }

        public class DevID
        {
            public ObservableCollection<Move> moves { get; set; }
        }
    }
}
