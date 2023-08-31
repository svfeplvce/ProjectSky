using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSky.Models
{
    public class PokeData
    {
        public class BringItem
        {
            public string itemID { get; set; }
            public int bringRate { get; set; }
        }

        public class Enabletable
        {
            public bool land { get; set; }
            public bool up_water { get; set; }
            public bool underwater { get; set; }
            public bool air1 { get; set; }
            public bool air2 { get; set; }
        }

        public class DataArray
        {
            public List<Value> values { get; set; }
        }

        public class Timetable
        {
            public bool morning { get; set; }
            public bool noon { get; set; }
            public bool evening { get; set; }
            public bool night { get; set; }
        }

        public class Value
        {
            public string devid { get; set; }
            public string sex { get; set; }
            public int formno { get; set; }
            public int minlevel { get; set; }
            public int maxlevel { get; set; }
            public int lotvalue { get; set; }
            public string biome1 { get; set; }
            public int lotvalue1 { get; set; }
            public string biome2 { get; set; }
            public int lotvalue2 { get; set; }
            public string biome3 { get; set; }
            public int lotvalue3 { get; set; }
            public string biome4 { get; set; }
            public int lotvalue4 { get; set; }
            public string area { get; set; }
            public string locationName { get; set; }
            public int minheight { get; set; }
            public int maxheight { get; set; }
            public Enabletable enabletable { get; set; }
            public Timetable timetable { get; set; }
            public string flagName { get; set; }
            public int bandrate { get; set; }
            public string bandtype { get; set; }
            public string bandpoke { get; set; }
            public string bandSex { get; set; }
            public int bandFormno { get; set; }
            public int outbreakLotvalue { get; set; }
            public string pokeVoiceClassification { get; set; }
            public Versiontable versiontable { get; set; }
            public BringItem bringItem { get; set; }
        }

        public class Versiontable
        {
            public bool A { get; set; }
            public bool B { get; set; }
        }
    }
}
