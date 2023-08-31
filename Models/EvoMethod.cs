using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSky.Models
{
    public class EvoMethod
    {
        public string Method { get; set; }
        public int MethodID { get; set; }
        public bool AdditionalArgs { get; set; }
        public bool UsesLevel { get; set; }
        public string ArgType { get; set; }
    }
}
