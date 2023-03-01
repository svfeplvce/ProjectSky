using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Core
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
            public List<Move> moves { get; set; }
        }
    }
}
