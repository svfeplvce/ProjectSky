using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSky.Models
{
    public class Trainer
    {
        public class EffortValue
        {
            public int hp { get; set; }
            public int atk { get; set; }
            public int def { get; set; }
            public int spAtk { get; set; }
            public int spDef { get; set; }
            public int agi { get; set; }
        }

        public class Poke1
        {
            public string devId { get; set; }
            public int formId { get; set; }
            public string sex { get; set; }
            public string item { get; set; }
            public int level { get; set; }
            public string ballId { get; set; }
            public string wazaType { get; set; }
            public Waza1 waza1 { get; set; }
            public Waza2 waza2 { get; set; }
            public Waza3 waza3 { get; set; }
            public Waza4 waza4 { get; set; }
            public string gemType { get; set; }
            public string seikaku { get; set; }
            public string tokusei { get; set; }
            public string talentType { get; set; }
            public TalentValue talentValue { get; set; }
            public int talentVnum { get; set; }
            public EffortValue effortValue { get; set; }
            public string rareType { get; set; }
            public string scaleType { get; set; }
            public int scaleValue { get; set; }
        }

        public class Poke2
        {
            public string devId { get; set; }
            public int formId { get; set; }
            public string sex { get; set; }
            public string item { get; set; }
            public int level { get; set; }
            public string ballId { get; set; }
            public string wazaType { get; set; }
            public Waza1 waza1 { get; set; }
            public Waza2 waza2 { get; set; }
            public Waza3 waza3 { get; set; }
            public Waza4 waza4 { get; set; }
            public string gemType { get; set; }
            public string seikaku { get; set; }
            public string tokusei { get; set; }
            public string talentType { get; set; }
            public TalentValue talentValue { get; set; }
            public int talentVnum { get; set; }
            public EffortValue effortValue { get; set; }
            public string rareType { get; set; }
            public string scaleType { get; set; }
            public int scaleValue { get; set; }
        }

        public class Poke3
        {
            public string devId { get; set; }
            public int formId { get; set; }
            public string sex { get; set; }
            public string item { get; set; }
            public int level { get; set; }
            public string ballId { get; set; }
            public string wazaType { get; set; }
            public Waza1 waza1 { get; set; }
            public Waza2 waza2 { get; set; }
            public Waza3 waza3 { get; set; }
            public Waza4 waza4 { get; set; }
            public string gemType { get; set; }
            public string seikaku { get; set; }
            public string tokusei { get; set; }
            public string talentType { get; set; }
            public TalentValue talentValue { get; set; }
            public int talentVnum { get; set; }
            public EffortValue effortValue { get; set; }
            public string rareType { get; set; }
            public string scaleType { get; set; }
            public int scaleValue { get; set; }
        }

        public class Poke4
        {
            public string devId { get; set; }
            public int formId { get; set; }
            public string sex { get; set; }
            public string item { get; set; }
            public int level { get; set; }
            public string ballId { get; set; }
            public string wazaType { get; set; }
            public Waza1 waza1 { get; set; }
            public Waza2 waza2 { get; set; }
            public Waza3 waza3 { get; set; }
            public Waza4 waza4 { get; set; }
            public string gemType { get; set; }
            public string seikaku { get; set; }
            public string tokusei { get; set; }
            public string talentType { get; set; }
            public TalentValue talentValue { get; set; }
            public int talentVnum { get; set; }
            public EffortValue effortValue { get; set; }
            public string rareType { get; set; }
            public string scaleType { get; set; }
            public int scaleValue { get; set; }
        }

        public class Poke5
        {
            public string devId { get; set; }
            public int formId { get; set; }
            public string sex { get; set; }
            public string item { get; set; }
            public int level { get; set; }
            public string ballId { get; set; }
            public string wazaType { get; set; }
            public Waza1 waza1 { get; set; }
            public Waza2 waza2 { get; set; }
            public Waza3 waza3 { get; set; }
            public Waza4 waza4 { get; set; }
            public string gemType { get; set; }
            public string seikaku { get; set; }
            public string tokusei { get; set; }
            public string talentType { get; set; }
            public TalentValue talentValue { get; set; }
            public int talentVnum { get; set; }
            public EffortValue effortValue { get; set; }
            public string rareType { get; set; }
            public string scaleType { get; set; }
            public int scaleValue { get; set; }
        }

        public class Poke6
        {
            public string devId { get; set; }
            public int formId { get; set; }
            public string sex { get; set; }
            public string item { get; set; }
            public int level { get; set; }
            public string ballId { get; set; }
            public string wazaType { get; set; }
            public Waza1 waza1 { get; set; }
            public Waza2 waza2 { get; set; }
            public Waza3 waza3 { get; set; }
            public Waza4 waza4 { get; set; }
            public string gemType { get; set; }
            public string seikaku { get; set; }
            public string tokusei { get; set; }
            public string talentType { get; set; }
            public TalentValue talentValue { get; set; }
            public int talentVnum { get; set; }
            public EffortValue effortValue { get; set; }
            public string rareType { get; set; }
            public string scaleType { get; set; }
            public int scaleValue { get; set; }
        }

        public class TrainerArray
        {
            public List<Value> values { get; set; }
        }

        public class TalentValue
        {
            public int hp { get; set; }
            public int atk { get; set; }
            public int def { get; set; }
            public int spAtk { get; set; }
            public int spDef { get; set; }
            public int agi { get; set; }
        }

        public class Value
        {
            public string trid { get; set; }
            public string trNameLabel { get; set; }
            public string trainerType { get; set; }
            public bool isStrong { get; set; }
            public string battleType { get; set; }
            public string dataType { get; set; }
            public int moneyRate { get; set; }
            public bool changeGem { get; set; }
            public Poke1 poke1 { get; set; }
            public Poke2 poke2 { get; set; }
            public Poke3 poke3 { get; set; }
            public Poke4 poke4 { get; set; }
            public Poke5 poke5 { get; set; }
            public Poke6 poke6 { get; set; }
            public bool aiBasic { get; set; }
            public bool aiHigh { get; set; }
            public bool aiExpert { get; set; }
            public bool aiDouble { get; set; }
            public bool aiRaid { get; set; }
            public bool aiWeak { get; set; }
            public bool aiItem { get; set; }
            public bool aiChange { get; set; }
            public string popupLabelNormal1 { get; set; }
            public string popupLabelNormal2 { get; set; }
            public string popupLabelPinch1 { get; set; }
            public string popupLabelPinch2 { get; set; }
        }

        public class Waza1
        {
            public string wazaId { get; set; }
            public int pointUp { get; set; }
        }

        public class Waza2
        {
            public string wazaId { get; set; }
            public int pointUp { get; set; }
        }

        public class Waza3
        {
            public string wazaId { get; set; }
            public int pointUp { get; set; }
        }

        public class Waza4
        {
            public string wazaId { get; set; }
            public int pointUp { get; set; }
        }


    }
}
