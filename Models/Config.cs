using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSky.Models
{
    public class Config
    {
        public string outPath { get; set; } = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "out\\");
        public bool autoUpdate { get; set; } = true;
    }
}
