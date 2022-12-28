using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Core
{
    public class Personal
    {
        public class BaseStats
        {
            public int HP { get; set; }
            public int ATK { get; set; }
            public int DEF { get; set; }
            public int SPA { get; set; }
            public int SPD { get; set; }
            public int SPE { get; set; }
        }

        public class Dex
        {
            public int index { get; set; }
            public int group { get; set; }
        }

        public class EggHatch
        {
            public int species { get; set; }
            public int form { get; set; }
            public int form_flags { get; set; }
            public int form_everstone { get; set; }
        }

        public class Entry
        {
            public Species species { get; set; }
            public bool is_present { get; set; }
            public int type_1 { get; set; }
            public int type_2 { get; set; }
            public int ability_1 { get; set; }
            public int ability_2 { get; set; }
            public int ability_hidden { get; set; }
            public int xp_growth { get; set; }
            public int catch_rate { get; set; }
            public Gender gender { get; set; }
            public int egg_group_1 { get; set; }
            public int egg_group_2 { get; set; }
            public EggHatch egg_hatch { get; set; }
            public int egg_hatch_steps { get; set; }
            public int base_friendship { get; set; }
            public int exp_addend { get; set; }
            public int evo_stage { get; set; }
            public bool unk_flag { get; set; }
            public EvYield ev_yield { get; set; }
            public BaseStats base_stats { get; set; }
            public List<EvoDatum> evo_data { get; set; }
            public List<int> tm_moves { get; set; }
            public List<int> egg_moves { get; set; }
            public List<object> reminder_moves { get; set; }
            public List<LevelupMove> levelup_moves { get; set; }
            public Dex dex { get; set; }
        }

        public class EvoDatum
        {
            public int level { get; set; }
            public int condition { get; set; }
            public int parameter { get; set; }
            public int reserved3 { get; set; }
            public int reserved4 { get; set; }
            public int reserved5 { get; set; }
            public int species { get; set; }
            public int form { get; set; }
        }

        public class EvYield
        {
            public int HP { get; set; }
            public int ATK { get; set; }
            public int DEF { get; set; }
            public int SPA { get; set; }
            public int SPD { get; set; }
            public int SPE { get; set; }
        }

        public class Gender
        {
            public int group { get; set; }
            public int ratio { get; set; }
        }

        public class LevelupMove
        {
            public int move { get; set; }
            public int level { get; set; }
        }

        public class PersonalArray
        {
            public List<Entry> entry { get; set; }
        }

        public class Species
        {
            public int species { get; set; }
            public int form { get; set; }
            public int model { get; set; }
            public int color { get; set; }
            public int body_type { get; set; }
            public int height { get; set; }
            public int weight { get; set; }
            public int reserved { get; set; }
            public int reserved1 { get; set; }
            public int reserved2 { get; set; }
        }


    }
}
