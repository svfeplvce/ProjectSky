using ProjectSky.Core;
using ProjectSky.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static ProjectSky.Models.Personal;

namespace ProjectSky.ViewModels
{
    public class EvoViewModel : ViewModel
    {
        private ObservableCollection<EvoMethod> _evoMethods;
        private Dictionary<string, ObservableCollection<string>> _evoArgs;
        public ObservableCollection<string> Abilities { get; } = Application.Current.Properties["abilities"] as ObservableCollection<string>;
        public ObservableCollection<string> Moves { get; } = Application.Current.Properties["moves"] as ObservableCollection<string>;
        public ObservableCollection<string> SpeciesNames { get; } = Application.Current.Properties["species"] as ObservableCollection<string>;
        public ObservableCollection<string> Items { get; } = Application.Current.Properties["items"] as ObservableCollection<string>;

        public EvoViewModel()
        {
            _evoMethods = new ObservableCollection<EvoMethod> {
            new EvoMethod{ Method="None", MethodID=0, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up With High Friendship", MethodID=1, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up With High Friendship At Daytime", MethodID=2, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up With High Friendship At Nighttime", MethodID=3, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up", MethodID=4, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Trade", MethodID=5, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Trade With Held Item", MethodID=6, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Trade (Shelmet/Karrablast)", MethodID=7, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Use Item", MethodID=8, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Level Up While ATK > DEF", MethodID=9, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up While ATK = DEF", MethodID=10, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up While ATK < DEF", MethodID=11, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up With A Certain Personality Value", MethodID=12, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up With A Certain Personality Value 2", MethodID=13, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up (Ninjask)", MethodID=14, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up (Shedinja)", MethodID=15, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up With High Beauty", MethodID=16, AdditionalArgs=true, UsesLevel=false, ArgType="Stat" },
            new EvoMethod{ Method="Use Item While Pokemon is Male", MethodID=17, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Use Item While Pokemon is Female", MethodID=18, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Level Up With Held Item At Daytime", MethodID=19, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Level Up With Held Item At Nighttime", MethodID=20, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Level Up While Knowing Move", MethodID=21, AdditionalArgs=true, UsesLevel=false, ArgType="Move" },
            new EvoMethod{ Method="Level Up With Teammate", MethodID=22, AdditionalArgs=true, UsesLevel=false, ArgType="Species" },
            new EvoMethod{ Method="Level Up While Pokemon is Male", MethodID=23, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up While Pokemon is Female", MethodID=24, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up Near Electric Rock", MethodID=25, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up Near Mossy Rock", MethodID=26, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up Near Cold Rock", MethodID=27, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up While Console is Inverted", MethodID=28, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up With High Affection And A Move Of A Specific Type", MethodID=29, AdditionalArgs=true, UsesLevel=false, ArgType="Type" },
            new EvoMethod{ Method="Level Up While Knowing A Move Of A Specific Type", MethodID=30, AdditionalArgs=true, UsesLevel=false, ArgType="Type" },
            new EvoMethod{ Method="Level Up During Rainy Weather", MethodID=31, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up During Morning", MethodID=32, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up During Night", MethodID=33, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up While Pokemon is Female Form", MethodID=34, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="UNUSED", MethodID=35, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up In Specific Version", MethodID=36, AdditionalArgs=true, UsesLevel=false, ArgType="Misc" },
            new EvoMethod{ Method="Level Up In Specific Version During Daytime", MethodID=37, AdditionalArgs=true, UsesLevel=false, ArgType="Misc" },
            new EvoMethod{ Method="Level Up In Specific Version During Nighttime", MethodID=38, AdditionalArgs=true, UsesLevel=false, ArgType="Misc" },
            new EvoMethod{ Method="Level Up At A Summit", MethodID=39, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up At Dusk", MethodID=40, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up In Ultra Wormhole", MethodID=41, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Use Item In Ultra Wormhole", MethodID=42, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Get x Crits In Battle", MethodID=43, AdditionalArgs=true, UsesLevel=false, ArgType="Misc" },
            new EvoMethod{ Method="Lose HP In Battle", MethodID=44, AdditionalArgs=true, UsesLevel=false, ArgType="Misc" },
            new EvoMethod{ Method="Spin", MethodID=45, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up With Amped Nature", MethodID=46, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Level Up With LowKey Nature", MethodID=47, AdditionalArgs=false, UsesLevel=true, ArgType="None" },
            new EvoMethod{ Method="Tower Of Darkness", MethodID=48, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Tower Of Waters", MethodID=49, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up After Walking x Steps With In Lets Go Mode", MethodID=50, AdditionalArgs=true, UsesLevel=false, ArgType="Misc" },
            new EvoMethod{ Method="Level Up In Union Circle", MethodID=51, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up In Battle With A Certain Personality Value", MethodID=52, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up In Battle With A Certain Personality Value 2", MethodID=53, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up After Collecting 999 Gimmighoul Coins", MethodID=54, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up After Defeating 3 Leader Bisharp", MethodID=55, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up After Using A Move x Times", MethodID=56, AdditionalArgs=true, UsesLevel=false, ArgType="Misc" },
            new EvoMethod{ Method="Level Up While Knowing A Move With A Certain Personality Value", MethodID=57, AdditionalArgs=true, UsesLevel=false, ArgType="Move" },
            new EvoMethod{ Method="Level Up While Knowing A Move With A Certain Personality Value 2", MethodID=58, AdditionalArgs=true, UsesLevel=false, ArgType="Move" },
            new EvoMethod{ Method="Level Up After Taking x Recoil Damage While Pokemon is Male", MethodID=59, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Level Up After Taking x Recoil Damage While Pokemon is Female", MethodID=60, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Hisui", MethodID=61, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Use Item During Full Moon", MethodID=90, AdditionalArgs=true, UsesLevel=false, ArgType="Item" },
            new EvoMethod{ Method="Use Agile Style Moves", MethodID=91, AdditionalArgs=false, UsesLevel=false, ArgType="None" },
            new EvoMethod{ Method="Use Strong Style Moves", MethodID=92, AdditionalArgs=false, UsesLevel=false, ArgType="None" }
            };

            List<int> ints = Enumerable.Range(0, 1000).ToList();

            _evoArgs = new Dictionary<string, ObservableCollection<string>>
            {
                { "Item", Items },
                { "Move", Moves },
                { "Species", SpeciesNames },
                { "Type", new ObservableCollection<string> {  "Normal", "Fighting", "Flying", "Poison", "Ground", "Rock", "Bug", "Ghost", "Steel", "Fire", "Water", "Grass", "Electric", "Psychic", "Ice", "Dragon", "Dark", "Fairy" } },
                { "Misc", new ObservableCollection<string>(ints.ConvertAll(x => x.ToString())) }
            };
        }

        public ObservableCollection<EvoMethod> EvoMethods
        {
            get => _evoMethods;
            set
            {
                _evoMethods = value;
                OnPropertyChanged();
            }
        }

        public Dictionary<string, ObservableCollection<string>> EvoArgs
        {
            get => _evoArgs;
            set
            {
                _evoArgs = value;
                OnPropertyChanged();
            }
        }
    }
}
