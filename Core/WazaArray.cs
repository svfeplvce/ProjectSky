using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Core
{
    public class WazaArray
    {
        public class Inflict
        {
            public int value { get; set; }
            public int chance { get; set; }
            public int turn1 { get; set; }
            public int turn2 { get; set; }
            public int turn3 { get; set; }
        }

        public class Wazas
        {
            public List<Waza> waza { get; set; }
        }

        public class StatAmps
        {
            public int fstat1 { get; set; }
            public int fstat2 { get; set; }
            public int fstat3 { get; set; }
            public int fstat1_stage { get; set; }
            public int fstat2_state { get; set; }
            public int fstat3_stage { get; set; }
            public int fstat1_percent { get; set; }
            public int fstat2_percent { get; set; }
            public int fstat3_percent { get; set; }
        }

        public class Waza
        {
            public bool can_use_move { get; set; }
            public int category { get; set; }
            public int power { get; set; }
            public int accuracy { get; set; }
            public int pp { get; set; }
            public Inflict inflict { get; set; }
            public StatAmps stat_amps { get; set; }
            public bool flag_protect { get; set; }
            public string move_id { get; set; }
            public string affinity { get; set; }
            public bool? flag_makes_contact { get; set; }
            public bool? flag_mirror { get; set; }
            public bool? flag_metronome { get; set; }
            public int? type { get; set; }
            public int? crit_stage { get; set; }
            public int? effect_sequence { get; set; }
            public int? hit_max { get; set; }
            public int? hit_min { get; set; }
            public bool? flag_punch { get; set; }
            public int? quality { get; set; }
            public bool? flag_no_effectiveness { get; set; }
            public bool? unknown58 { get; set; }
            public bool? unknown59 { get; set; }
            public bool? unknown60 { get; set; }
            public int? raw_target { get; set; }
            public bool? flag_charge { get; set; }
            public bool? flag_no_sleep_talk { get; set; }
            public bool? flag_fail_instruct { get; set; }
            public bool? flag_snatch { get; set; }
            public bool? flag_dance { get; set; }
            public bool? flag_slicing { get; set; }
            public bool? flag_distance_triple { get; set; }
            public bool? flag_wind { get; set; }
            public int? priority { get; set; }
            public bool? flag_reflectable { get; set; }
            public bool? flag_ignore_substitute { get; set; }
            public bool? flag_animate_ally { get; set; }
            public bool? flag_no_assist { get; set; }
            public bool? flag_fail_copy_cat { get; set; }
            public bool? unknown57 { get; set; }
            public bool? flag_gravity { get; set; }
            public bool? flag_fail_sky_battle { get; set; }
            public int? flinch { get; set; }
            public int? recoil { get; set; }
            public bool? flag_bite { get; set; }
            public bool? flag_sound { get; set; }
        }
    }
}
