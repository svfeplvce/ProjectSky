using ProjectSky.Core;
using ProjectSky.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectSky.Models;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ProjectSky.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {

        private INavigationService _navigationService;
        public INavigationService NavigationService {
            get => _navigationService;
            set {
                _navigationService = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand CloseCommand { get; }
        public RelayCommand MinimiseCommand { get; }
        public RelayCommand DropdownCommand { get; }
        public RelayCommand GoBackCommand { get; }
        public RelayCommand SelectComboBoxItemCommand { get; }
        
        public ObservableCollection<string> ComboBoxItems { get; } = new ObservableCollection<string> { "Edit Config", "Minimise", "Close" };

        private bool _isDropdownOpen;
        public bool IsDropdownOpen
        {
            get { return _isDropdownOpen; }
            set
            {
                if (_isDropdownOpen != value)
                {
                    _isDropdownOpen = value;
                    OnPropertyChanged(nameof(IsDropdownOpen));
                }
            }
        }

        public ObservableCollection<string> Abilities { get; } = new ObservableCollection<string> { "—", "Stench", "Drizzle", "Speed Boost", "Battle Armor", "Sturdy", "Damp", "Limber", "Sand Veil", "Static", "Volt Absorb", "Water Absorb", "Oblivious", "Cloud Nine", "Compound Eyes", "Insomnia", "Color Change", "Immunity", "Flash Fire", "Shield Dust", "Own Tempo", "Suction Cups", "Intimidate", "Shadow Tag", "Rough Skin", "Wonder Guard", "Levitate", "Effect Spore", "Synchronize", "Clear Body", "Natural Cure", "Lightning Rod", "Serene Grace", "Swift Swim", "Chlorophyll", "Illuminate", "Trace", "Huge Power", "Poison Point", "Inner Focus", "Magma Armor", "Water Veil", "Magnet Pull", "Soundproof", "Rain Dish", "Sand Stream", "Pressure", "Thick Fat", "Early Bird", "Flame Body", "Run Away", "Keen Eye", "Hyper Cutter", "Pickup", "Truant", "Hustle", "Cute Charm", "Plus", "Minus", "Forecast", "Sticky Hold", "Shed Skin", "Guts", "Marvel Scale", "Liquid Ooze", "Overgrow", "Blaze", "Torrent", "Swarm", "Rock Head", "Drought", "Arena Trap", "Vital Spirit", "White Smoke", "Pure Power", "Shell Armor", "Air Lock", "Tangled Feet", "Motor Drive", "Rivalry", "Steadfast", "Snow Cloak", "Gluttony", "Anger Point", "Unburden", "Heatproof", "Simple", "Dry Skin", "Download", "Iron Fist", "Poison Heal", "Adaptability", "Skill Link", "Hydration", "Solar Power", "Quick Feet", "Normalize", "Sniper", "Magic Guard", "No Guard", "Stall", "Technician", "Leaf Guard", "Klutz", "Mold Breaker", "Super Luck", "Aftermath", "Anticipation", "Forewarn", "Unaware", "Tinted Lens", "Filter", "Slow Start", "Scrappy", "Storm Drain", "Ice Body", "Solid Rock", "Snow Warning", "Honey Gather", "Frisk", "Reckless", "Multitype", "Flower Gift", "Bad Dreams", "Pickpocket", "Sheer Force", "Contrary", "Unnerve", "Defiant", "Defeatist", "Cursed Body", "Healer", "Friend Guard", "Weak Armor", "Heavy Metal", "Light Metal", "Multiscale", "Toxic Boost", "Flare Boost", "Harvest", "Telepathy", "Moody", "Overcoat", "Poison Touch", "Regenerator", "Big Pecks", "Sand Rush", "Wonder Skin", "Analytic", "Illusion", "Imposter", "Infiltrator", "Mummy", "Moxie", "Justified", "Rattled", "Magic Bounce", "Sap Sipper", "Prankster", "Sand Force", "Iron Barbs", "Zen Mode", "Victory Star", "Turboblaze", "Teravolt", "Aroma Veil", "Flower Veil", "Cheek Pouch", "Protean", "Fur Coat", "Magician", "Bulletproof", "Competitive", "Strong Jaw", "Refrigerate", "Sweet Veil", "Stance Change", "Gale Wings", "Mega Launcher", "Grass Pelt", "Symbiosis", "Tough Claws", "Pixilate", "Gooey", "Aerilate", "Parental Bond", "Dark Aura", "Fairy Aura", "Aura Break", "Primordial Sea", "Desolate Land", "Delta Stream", "Stamina", "Wimp Out", "Emergency Exit", "Water Compaction", "Merciless", "Shields Down", "Stakeout", "Water Bubble", "Steelworker", "Berserk", "Slush Rush", "Long Reach", "Liquid Voice", "Triage", "Galvanize", "Surge Surfer", "Schooling", "Disguise", "Battle Bond", "Power Construct", "Corrosion", "Comatose", "Queenly Majesty", "Innards Out", "Dancer", "Battery", "Fluffy", "Dazzling", "Soul-Heart", "Tangling Hair", "Receiver", "Power of Alchemy", "Beast Boost", "RKS System", "Electric Surge", "Psychic Surge", "Misty Surge", "Grassy Surge", "Full Metal Body", "Shadow Shield", "Prism Armor", "Neuroforce", "Intrepid Sword", "Dauntless Shield", "Libero", "Ball Fetch", "Cotton Down", "Propeller Tail", "Mirror Armor", "Gulp Missile", "Stalwart", "Steam Engine", "Punk Rock", "Sand Spit", "Ice Scales", "Ripen", "Ice Face", "Power Spot", "Mimicry", "Screen Cleaner", "Steely Spirit", "Perish Body", "Wandering Spirit", "Gorilla Tactics", "Neutralizing Gas", "Pastel Veil", "Hunger Switch", "Quick Draw", "Unseen Fist", "Curious Medicine", "Transistor", "Dragon’s Maw", "Chilling Neigh", "Grim Neigh", "As One", "As One", "Lingering Aroma", "Seed Sower", "Thermal Exchange", "Anger Shell", "Purifying Salt", "Well-Baked Body", "Wind Rider", "Guard Dog", "Rocky Payload", "Wind Power", "Zero to Hero", "Commander", "Electromorphosis", "Protosynthesis", "Quark Drive", "Good as Gold", "Vessel of Ruin", "Sword of Ruin", "Tablets of Ruin", "Beads of Ruin", "Orichalcum Pulse", "Hadron Engine", "Opportunist", "Cud Chew", "Sharpness", "Supreme Overlord", "Costar", "Toxic Debris", "Armor Tail", "Earth Eater", "Mycelium Might", "Hospitality", "Mind’s Eye", "Embody Aspect", "Embody Aspect", "Embody Aspect", "Embody Aspect", "Toxic Chain", "Supersweet Syrup" };
        public ObservableCollection<string> Moves { get; } = new ObservableCollection<string> { "———", "Pound", "Karate Chop", "Double Slap", "Comet Punch", "Mega Punch", "Pay Day", "Fire Punch", "Ice Punch", "Thunder Punch", "Scratch", "Vise Grip", "Guillotine", "Razor Wind", "Swords Dance", "Cut", "Gust", "Wing Attack", "Whirlwind", "Fly", "Bind", "Slam", "Vine Whip", "Stomp", "Double Kick", "Mega Kick", "Jump Kick", "Rolling Kick", "Sand Attack", "Headbutt", "Horn Attack", "Fury Attack", "Horn Drill", "Tackle", "Body Slam", "Wrap", "Take Down", "Thrash", "Double-Edge", "Tail Whip", "Poison Sting", "Twineedle", "Pin Missile", "Leer", "Bite", "Growl", "Roar", "Sing", "Supersonic", "Sonic Boom", "Disable", "Acid", "Ember", "Flamethrower", "Mist", "Water Gun", "Hydro Pump", "Surf", "Ice Beam", "Blizzard", "Psybeam", "Bubble Beam", "Aurora Beam", "Hyper Beam", "Peck", "Drill Peck", "Submission", "Low Kick", "Counter", "Seismic Toss", "Strength", "Absorb", "Mega Drain", "Leech Seed", "Growth", "Razor Leaf", "Solar Beam", "Poison Powder", "Stun Spore", "Sleep Powder", "Petal Dance", "String Shot", "Dragon Rage", "Fire Spin", "Thunder Shock", "Thunderbolt", "Thunder Wave", "Thunder", "Rock Throw", "Earthquake", "Fissure", "Dig", "Toxic", "Confusion", "Psychic", "Hypnosis", "Meditate", "Agility", "Quick Attack", "Rage", "Teleport", "Night Shade", "Mimic", "Screech", "Double Team", "Recover", "Harden", "Minimize", "Smokescreen", "Confuse Ray", "Withdraw", "Defense Curl", "Barrier", "Light Screen", "Haze", "Reflect", "Focus Energy", "Bide", "Metronome", "Mirror Move", "Self-Destruct", "Egg Bomb", "Lick", "Smog", "Sludge", "Bone Club", "Fire Blast", "Waterfall", "Clamp", "Swift", "Skull Bash", "Spike Cannon", "Constrict", "Amnesia", "Kinesis", "Soft-Boiled", "High Jump Kick", "Glare", "Dream Eater", "Poison Gas", "Barrage", "Leech Life", "Lovely Kiss", "Sky Attack", "Transform", "Bubble", "Dizzy Punch", "Spore", "Flash", "Psywave", "Splash", "Acid Armor", "Crabhammer", "Explosion", "Fury Swipes", "Bonemerang", "Rest", "Rock Slide", "Hyper Fang", "Sharpen", "Conversion", "Tri Attack", "Super Fang", "Slash", "Substitute", "Struggle", "Sketch", "Triple Kick", "Thief", "Spider Web", "Mind Reader", "Nightmare", "Flame Wheel", "Snore", "Curse", "Flail", "Conversion 2", "Aeroblast", "Cotton Spore", "Reversal", "Spite", "Powder Snow", "Protect", "Mach Punch", "Scary Face", "Feint Attack", "Sweet Kiss", "Belly Drum", "Sludge Bomb", "Mud-Slap", "Octazooka", "Spikes", "Zap Cannon", "Foresight", "Destiny Bond", "Perish Song", "Icy Wind", "Detect", "Bone Rush", "Lock-On", "Outrage", "Sandstorm", "Giga Drain", "Endure", "Charm", "Rollout", "False Swipe", "Swagger", "Milk Drink", "Spark", "Fury Cutter", "Steel Wing", "Mean Look", "Attract", "Sleep Talk", "Heal Bell", "Return", "Present", "Frustration", "Safeguard", "Pain Split", "Sacred Fire", "Magnitude", "Dynamic Punch", "Megahorn", "Dragon Breath", "Baton Pass", "Encore", "Pursuit", "Rapid Spin", "Sweet Scent", "Iron Tail", "Metal Claw", "Vital Throw", "Morning Sun", "Synthesis", "Moonlight", "Hidden Power", "Cross Chop", "Twister", "Rain Dance", "Sunny Day", "Crunch", "Mirror Coat", "Psych Up", "Extreme Speed", "Ancient Power", "Shadow Ball", "Future Sight", "Rock Smash", "Whirlpool", "Beat Up", "Fake Out", "Uproar", "Stockpile", "Spit Up", "Swallow", "Heat Wave", "Hail", "Torment", "Flatter", "Will-O-Wisp", "Memento", "Facade", "Focus Punch", "Smelling Salts", "Follow Me", "Nature Power", "Charge", "Taunt", "Helping Hand", "Trick", "Role Play", "Wish", "Assist", "Ingrain", "Superpower", "Magic Coat", "Recycle", "Revenge", "Brick Break", "Yawn", "Knock Off", "Endeavor", "Eruption", "Skill Swap", "Imprison", "Refresh", "Grudge", "Snatch", "Secret Power", "Dive", "Arm Thrust", "Camouflage", "Tail Glow", "Luster Purge", "Mist Ball", "Feather Dance", "Teeter Dance", "Blaze Kick", "Mud Sport", "Ice Ball", "Needle Arm", "Slack Off", "Hyper Voice", "Poison Fang", "Crush Claw", "Blast Burn", "Hydro Cannon", "Meteor Mash", "Astonish", "Weather Ball", "Aromatherapy", "Fake Tears", "Air Cutter", "Overheat", "Odor Sleuth", "Rock Tomb", "Silver Wind", "Metal Sound", "Grass Whistle", "Tickle", "Cosmic Power", "Water Spout", "Signal Beam", "Shadow Punch", "Extrasensory", "Sky Uppercut", "Sand Tomb", "Sheer Cold", "Muddy Water", "Bullet Seed", "Aerial Ace", "Icicle Spear", "Iron Defense", "Block", "Howl", "Dragon Claw", "Frenzy Plant", "Bulk Up", "Bounce", "Mud Shot", "Poison Tail", "Covet", "Volt Tackle", "Magical Leaf", "Water Sport", "Calm Mind", "Leaf Blade", "Dragon Dance", "Rock Blast", "Shock Wave", "Water Pulse", "Doom Desire", "Psycho Boost", "Roost", "Gravity", "Miracle Eye", "Wake-Up Slap", "Hammer Arm", "Gyro Ball", "Healing Wish", "Brine", "Natural Gift", "Feint", "Pluck", "Tailwind", "Acupressure", "Metal Burst", "U-turn", "Close Combat", "Payback", "Assurance", "Embargo", "Fling", "Psycho Shift", "Trump Card", "Heal Block", "Wring Out", "Power Trick", "Gastro Acid", "Lucky Chant", "Me First", "Copycat", "Power Swap", "Guard Swap", "Punishment", "Last Resort", "Worry Seed", "Sucker Punch", "Toxic Spikes", "Heart Swap", "Aqua Ring", "Magnet Rise", "Flare Blitz", "Force Palm", "Aura Sphere", "Rock Polish", "Poison Jab", "Dark Pulse", "Night Slash", "Aqua Tail", "Seed Bomb", "Air Slash", "X-Scissor", "Bug Buzz", "Dragon Pulse", "Dragon Rush", "Power Gem", "Drain Punch", "Vacuum Wave", "Focus Blast", "Energy Ball", "Brave Bird", "Earth Power", "Switcheroo", "Giga Impact", "Nasty Plot", "Bullet Punch", "Avalanche", "Ice Shard", "Shadow Claw", "Thunder Fang", "Ice Fang", "Fire Fang", "Shadow Sneak", "Mud Bomb", "Psycho Cut", "Zen Headbutt", "Mirror Shot", "Flash Cannon", "Rock Climb", "Defog", "Trick Room", "Draco Meteor", "Discharge", "Lava Plume", "Leaf Storm", "Power Whip", "Rock Wrecker", "Cross Poison", "Gunk Shot", "Iron Head", "Magnet Bomb", "Stone Edge", "Captivate", "Stealth Rock", "Grass Knot", "Chatter", "Judgment", "Bug Bite", "Charge Beam", "Wood Hammer", "Aqua Jet", "Attack Order", "Defend Order", "Heal Order", "Head Smash", "Double Hit", "Roar of Time", "Spacial Rend", "Lunar Dance", "Crush Grip", "Magma Storm", "Dark Void", "Seed Flare", "Ominous Wind", "Shadow Force", "Hone Claws", "Wide Guard", "Guard Split", "Power Split", "Wonder Room", "Psyshock", "Venoshock", "Autotomize", "Rage Powder", "Telekinesis", "Magic Room", "Smack Down", "Storm Throw", "Flame Burst", "Sludge Wave", "Quiver Dance", "Heavy Slam", "Synchronoise", "Electro Ball", "Soak", "Flame Charge", "Coil", "Low Sweep", "Acid Spray", "Foul Play", "Simple Beam", "Entrainment", "After You", "Round", "Echoed Voice", "Chip Away", "Clear Smog", "Stored Power", "Quick Guard", "Ally Switch", "Scald", "Shell Smash", "Heal Pulse", "Hex", "Sky Drop", "Shift Gear", "Circle Throw", "Incinerate", "Quash", "Acrobatics", "Reflect Type", "Retaliate", "Final Gambit", "Bestow", "Inferno", "Water Pledge", "Fire Pledge", "Grass Pledge", "Volt Switch", "Struggle Bug", "Bulldoze", "Frost Breath", "Dragon Tail", "Work Up", "Electroweb", "Wild Charge", "Drill Run", "Dual Chop", "Heart Stamp", "Horn Leech", "Sacred Sword", "Razor Shell", "Heat Crash", "Leaf Tornado", "Steamroller", "Cotton Guard", "Night Daze", "Psystrike", "Tail Slap", "Hurricane", "Head Charge", "Gear Grind", "Searing Shot", "Techno Blast", "Relic Song", "Secret Sword", "Glaciate", "Bolt Strike", "Blue Flare", "Fiery Dance", "Freeze Shock", "Ice Burn", "Snarl", "Icicle Crash", "V-create", "Fusion Flare", "Fusion Bolt", "Flying Press", "Mat Block", "Belch", "Rototiller", "Sticky Web", "Fell Stinger", "Phantom Force", "Trick-or-Treat", "Noble Roar", "Ion Deluge", "Parabolic Charge", "Forest’s Curse", "Petal Blizzard", "Freeze-Dry", "Disarming Voice", "Parting Shot", "Topsy-Turvy", "Draining Kiss", "Crafty Shield", "Flower Shield", "Grassy Terrain", "Misty Terrain", "Electrify", "Play Rough", "Fairy Wind", "Moonblast", "Boomburst", "Fairy Lock", "King’s Shield", "Play Nice", "Confide", "Diamond Storm", "Steam Eruption", "Hyperspace Hole", "Water Shuriken", "Mystical Fire", "Spiky Shield", "Aromatic Mist", "Eerie Impulse", "Venom Drench", "Powder", "Geomancy", "Magnetic Flux", "Happy Hour", "Electric Terrain", "Dazzling Gleam", "Celebrate", "Hold Hands", "Baby-Doll Eyes", "Nuzzle", "Hold Back", "Infestation", "Power-Up Punch", "Oblivion Wing", "Thousand Arrows", "Thousand Waves", "Land’s Wrath", "Light of Ruin", "Origin Pulse", "Precipice Blades", "Dragon Ascent", "Hyperspace Fury", "Breakneck Blitz", "Breakneck Blitz", "All-Out Pummeling", "All-Out Pummeling", "Supersonic Skystrike", "Supersonic Skystrike", "Acid Downpour", "Acid Downpour", "Tectonic Rage", "Tectonic Rage", "Continental Crush", "Continental Crush", "Savage Spin-Out", "Savage Spin-Out", "Never-Ending Nightmare", "Never-Ending Nightmare", "Corkscrew Crash", "Corkscrew Crash", "Inferno Overdrive", "Inferno Overdrive", "Hydro Vortex", "Hydro Vortex", "Bloom Doom", "Bloom Doom", "Gigavolt Havoc", "Gigavolt Havoc", "Shattered Psyche", "Shattered Psyche", "Subzero Slammer", "Subzero Slammer", "Devastating Drake", "Devastating Drake", "Black Hole Eclipse", "Black Hole Eclipse", "Twinkle Tackle", "Twinkle Tackle", "Catastropika", "Shore Up", "First Impression", "Baneful Bunker", "Spirit Shackle", "Darkest Lariat", "Sparkling Aria", "Ice Hammer", "Floral Healing", "High Horsepower", "Strength Sap", "Solar Blade", "Leafage", "Spotlight", "Toxic Thread", "Laser Focus", "Gear Up", "Throat Chop", "Pollen Puff", "Anchor Shot", "Psychic Terrain", "Lunge", "Fire Lash", "Power Trip", "Burn Up", "Speed Swap", "Smart Strike", "Purify", "Revelation Dance", "Core Enforcer", "Trop Kick", "Instruct", "Beak Blast", "Clanging Scales", "Dragon Hammer", "Brutal Swing", "Aurora Veil", "Sinister Arrow Raid", "Malicious Moonsault", "Oceanic Operetta", "Guardian of Alola", "Soul-Stealing 7-Star Strike", "Stoked Sparksurfer", "Pulverizing Pancake", "Extreme Evoboost", "Genesis Supernova", "Shell Trap", "Fleur Cannon", "Psychic Fangs", "Stomping Tantrum", "Shadow Bone", "Accelerock", "Liquidation", "Prismatic Laser", "Spectral Thief", "Sunsteel Strike", "Moongeist Beam", "Tearful Look", "Zing Zap", "Nature’s Madness", "Multi-Attack", "10,000,000 Volt Thunderbolt", "Mind Blown", "Plasma Fists", "Photon Geyser", "Light That Burns the Sky", "Searing Sunraze Smash", "Menacing Moonraze Maelstrom", "Let’s Snuggle Forever", "Splintered Stormshards", "Clangorous Soulblaze", "Zippy Zap", "Splishy Splash", "Floaty Fall", "Pika Papow", "Bouncy Bubble", "Buzzy Buzz", "Sizzly Slide", "Glitzy Glow", "Baddy Bad", "Sappy Seed", "Freezy Frost", "Sparkly Swirl", "Veevee Volley", "Double Iron Bash", "Max Guard", "Dynamax Cannon", "Snipe Shot", "Jaw Lock", "Stuff Cheeks", "No Retreat", "Tar Shot", "Magic Powder", "Dragon Darts", "Teatime", "Octolock", "Bolt Beak", "Fishious Rend", "Court Change", "Max Flare", "Max Flutterby", "Max Lightning", "Max Strike", "Max Knuckle", "Max Phantasm", "Max Hailstorm", "Max Ooze", "Max Geyser", "Max Airstream", "Max Starfall", "Max Wyrmwind", "Max Mindstorm", "Max Rockfall", "Max Quake", "Max Darkness", "Max Overgrowth", "Max Steelspike", "Clangorous Soul", "Body Press", "Decorate", "Drum Beating", "Snap Trap", "Pyro Ball", "Behemoth Blade", "Behemoth Bash", "Aura Wheel", "Breaking Swipe", "Branch Poke", "Overdrive", "Apple Acid", "Grav Apple", "Spirit Break", "Strange Steam", "Life Dew", "Obstruct", "False Surrender", "Meteor Assault", "Eternabeam", "Steel Beam", "Expanding Force", "Steel Roller", "Scale Shot", "Meteor Beam", "Shell Side Arm", "Misty Explosion", "Grassy Glide", "Rising Voltage", "Terrain Pulse", "Skitter Smack", "Burning Jealousy", "Lash Out", "Poltergeist", "Corrosive Gas", "Coaching", "Flip Turn", "Triple Axel", "Dual Wingbeat", "Scorching Sands", "Jungle Healing", "Wicked Blow", "Surging Strikes", "Thunder Cage", "Dragon Energy", "Freezing Glare", "Fiery Wrath", "Thunderous Kick", "Glacial Lance", "Astral Barrage", "Eerie Spell", "Dire Claw", "Psyshield Bash", "Power Shift", "Stone Axe", "Springtide Storm", "Mystical Power", "Raging Fury", "Wave Crash", "Chloroblast", "Mountain Gale", "Victory Dance", "Headlong Rush", "Barb Barrage", "Esper Wing", "Bitter Malice", "Shelter", "Triple Arrows", "Infernal Parade", "Ceaseless Edge", "Bleakwind Storm", "Wildbolt Storm", "Sandsear Storm", "Lunar Blessing", "Take Heart", "Tera Blast", "Silk Trap", "Axe Kick", "Last Respects", "Lumina Crash", "Order Up", "Jet Punch", "Spicy Extract", "Spin Out", "Population Bomb", "Ice Spinner", "Glaive Rush", "Revival Blessing", "Salt Cure", "Triple Dive", "Mortal Spin", "Doodle", "Fillet Away", "Kowtow Cleave", "Flower Trick", "Torch Song", "Aqua Step", "Raging Bull", "Make It Rain", "Psyblade", "Hydro Steam", "Ruination", "Collision Course", "Electro Drift", "Shed Tail", "Chilly Reception", "Tidy Up", "Snowscape", "Pounce", "Trailblaze", "Chilling Water", "Hyper Drill", "Twin Beam", "Rage Fist", "Armor Cannon", "Bitter Blade", "Double Shock", "Gigaton Hammer", "Comeuppance", "Aqua Cutter", "Blazing Torque", "Wicked Torque", "Noxious Torque", "Combat Torque", "Magical Torque", "Blood Moon", "Matcha Gotcha", "Syrup Bomb", "Ivy Cudgel" };
        public ObservableCollection<string> SpeciesNames { get; } = new ObservableCollection<string> { "Egg", "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise", "Caterpie", "Metapod", "Butterfree", "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot", "Rattata", "Raticate", "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu", "Sandshrew", "Sandslash", "Nidoran♀", "Nidorina", "Nidoqueen", "Nidoran♂", "Nidorino", "Nidoking", "Clefairy", "Clefable", "Vulpix", "Ninetales", "Jigglypuff", "Wigglytuff", "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth", "Diglett", "Dugtrio", "Meowth", "Persian", "Psyduck", "Golduck", "Mankey", "Primeape", "Growlithe", "Arcanine", "Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam", "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell", "Victreebel", "Tentacool", "Tentacruel", "Geodude", "Graveler", "Golem", "Ponyta", "Rapidash", "Slowpoke", "Slowbro", "Magnemite", "Magneton", "Farfetch’d", "Doduo", "Dodrio", "Seel", "Dewgong", "Grimer", "Muk", "Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee", "Hypno", "Krabby", "Kingler", "Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Cubone", "Marowak", "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing", "Rhyhorn", "Rhydon", "Chansey", "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu", "Starmie", "Mr. Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros", "Magikarp", "Gyarados", "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon", "Porygon", "Omanyte", "Omastar", "Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno", "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew", "Chikorita", "Bayleef", "Meganium", "Cyndaquil", "Quilava", "Typhlosion", "Totodile", "Croconaw", "Feraligatr", "Sentret", "Furret", "Hoothoot", "Noctowl", "Ledyba", "Ledian", "Spinarak", "Ariados", "Crobat", "Chinchou", "Lanturn", "Pichu", "Cleffa", "Igglybuff", "Togepi", "Togetic", "Natu", "Xatu", "Mareep", "Flaaffy", "Ampharos", "Bellossom", "Marill", "Azumarill", "Sudowoodo", "Politoed", "Hoppip", "Skiploom", "Jumpluff", "Aipom", "Sunkern", "Sunflora", "Yanma", "Wooper", "Quagsire", "Espeon", "Umbreon", "Murkrow", "Slowking", "Misdreavus", "Unown", "Wobbuffet", "Girafarig", "Pineco", "Forretress", "Dunsparce", "Gligar", "Steelix", "Snubbull", "Granbull", "Qwilfish", "Scizor", "Shuckle", "Heracross", "Sneasel", "Teddiursa", "Ursaring", "Slugma", "Magcargo", "Swinub", "Piloswine", "Corsola", "Remoraid", "Octillery", "Delibird", "Mantine", "Skarmory", "Houndour", "Houndoom", "Kingdra", "Phanpy", "Donphan", "Porygon2", "Stantler", "Smeargle", "Tyrogue", "Hitmontop", "Smoochum", "Elekid", "Magby", "Miltank", "Blissey", "Raikou", "Entei", "Suicune", "Larvitar", "Pupitar", "Tyranitar", "Lugia", "Ho-Oh", "Celebi", "Treecko", "Grovyle", "Sceptile", "Torchic", "Combusken", "Blaziken", "Mudkip", "Marshtomp", "Swampert", "Poochyena", "Mightyena", "Zigzagoon", "Linoone", "Wurmple", "Silcoon", "Beautifly", "Cascoon", "Dustox", "Lotad", "Lombre", "Ludicolo", "Seedot", "Nuzleaf", "Shiftry", "Taillow", "Swellow", "Wingull", "Pelipper", "Ralts", "Kirlia", "Gardevoir", "Surskit", "Masquerain", "Shroomish", "Breloom", "Slakoth", "Vigoroth", "Slaking", "Nincada", "Ninjask", "Shedinja", "Whismur", "Loudred", "Exploud", "Makuhita", "Hariyama", "Azurill", "Nosepass", "Skitty", "Delcatty", "Sableye", "Mawile", "Aron", "Lairon", "Aggron", "Meditite", "Medicham", "Electrike", "Manectric", "Plusle", "Minun", "Volbeat", "Illumise", "Roselia", "Gulpin", "Swalot", "Carvanha", "Sharpedo", "Wailmer", "Wailord", "Numel", "Camerupt", "Torkoal", "Spoink", "Grumpig", "Spinda", "Trapinch", "Vibrava", "Flygon", "Cacnea", "Cacturne", "Swablu", "Altaria", "Zangoose", "Seviper", "Lunatone", "Solrock", "Barboach", "Whiscash", "Corphish", "Crawdaunt", "Baltoy", "Claydol", "Lileep", "Cradily", "Anorith", "Armaldo", "Feebas", "Milotic", "Castform", "Kecleon", "Shuppet", "Banette", "Duskull", "Dusclops", "Tropius", "Chimecho", "Absol", "Wynaut", "Snorunt", "Glalie", "Spheal", "Sealeo", "Walrein", "Clamperl", "Huntail", "Gorebyss", "Relicanth", "Luvdisc", "Bagon", "Shelgon", "Salamence", "Beldum", "Metang", "Metagross", "Regirock", "Regice", "Registeel", "Latias", "Latios", "Kyogre", "Groudon", "Rayquaza", "Jirachi", "Deoxys", "Turtwig", "Grotle", "Torterra", "Chimchar", "Monferno", "Infernape", "Piplup", "Prinplup", "Empoleon", "Starly", "Staravia", "Staraptor", "Bidoof", "Bibarel", "Kricketot", "Kricketune", "Shinx", "Luxio", "Luxray", "Budew", "Roserade", "Cranidos", "Rampardos", "Shieldon", "Bastiodon", "Burmy", "Wormadam", "Mothim", "Combee", "Vespiquen", "Pachirisu", "Buizel", "Floatzel", "Cherubi", "Cherrim", "Shellos", "Gastrodon", "Ambipom", "Drifloon", "Drifblim", "Buneary", "Lopunny", "Mismagius", "Honchkrow", "Glameow", "Purugly", "Chingling", "Stunky", "Skuntank", "Bronzor", "Bronzong", "Bonsly", "Mime Jr.", "Happiny", "Chatot", "Spiritomb", "Gible", "Gabite", "Garchomp", "Munchlax", "Riolu", "Lucario", "Hippopotas", "Hippowdon", "Skorupi", "Drapion", "Croagunk", "Toxicroak", "Carnivine", "Finneon", "Lumineon", "Mantyke", "Snover", "Abomasnow", "Weavile", "Magnezone", "Lickilicky", "Rhyperior", "Tangrowth", "Electivire", "Magmortar", "Togekiss", "Yanmega", "Leafeon", "Glaceon", "Gliscor", "Mamoswine", "Porygon-Z", "Gallade", "Probopass", "Dusknoir", "Froslass", "Rotom", "Uxie", "Mesprit", "Azelf", "Dialga", "Palkia", "Heatran", "Regigigas", "Giratina", "Cresselia", "Phione", "Manaphy", "Darkrai", "Shaymin", "Arceus", "Victini", "Snivy", "Servine", "Serperior", "Tepig", "Pignite", "Emboar", "Oshawott", "Dewott", "Samurott", "Patrat", "Watchog", "Lillipup", "Herdier", "Stoutland", "Purrloin", "Liepard", "Pansage", "Simisage", "Pansear", "Simisear", "Panpour", "Simipour", "Munna", "Musharna", "Pidove", "Tranquill", "Unfezant", "Blitzle", "Zebstrika", "Roggenrola", "Boldore", "Gigalith", "Woobat", "Swoobat", "Drilbur", "Excadrill", "Audino", "Timburr", "Gurdurr", "Conkeldurr", "Tympole", "Palpitoad", "Seismitoad", "Throh", "Sawk", "Sewaddle", "Swadloon", "Leavanny", "Venipede", "Whirlipede", "Scolipede", "Cottonee", "Whimsicott", "Petilil", "Lilligant", "Basculin", "Sandile", "Krokorok", "Krookodile", "Darumaka", "Darmanitan", "Maractus", "Dwebble", "Crustle", "Scraggy", "Scrafty", "Sigilyph", "Yamask", "Cofagrigus", "Tirtouga", "Carracosta", "Archen", "Archeops", "Trubbish", "Garbodor", "Zorua", "Zoroark", "Minccino", "Cinccino", "Gothita", "Gothorita", "Gothitelle", "Solosis", "Duosion", "Reuniclus", "Ducklett", "Swanna", "Vanillite", "Vanillish", "Vanilluxe", "Deerling", "Sawsbuck", "Emolga", "Karrablast", "Escavalier", "Foongus", "Amoonguss", "Frillish", "Jellicent", "Alomomola", "Joltik", "Galvantula", "Ferroseed", "Ferrothorn", "Klink", "Klang", "Klinklang", "Tynamo", "Eelektrik", "Eelektross", "Elgyem", "Beheeyem", "Litwick", "Lampent", "Chandelure", "Axew", "Fraxure", "Haxorus", "Cubchoo", "Beartic", "Cryogonal", "Shelmet", "Accelgor", "Stunfisk", "Mienfoo", "Mienshao", "Druddigon", "Golett", "Golurk", "Pawniard", "Bisharp", "Bouffalant", "Rufflet", "Braviary", "Vullaby", "Mandibuzz", "Heatmor", "Durant", "Deino", "Zweilous", "Hydreigon", "Larvesta", "Volcarona", "Cobalion", "Terrakion", "Virizion", "Tornadus", "Thundurus", "Reshiram", "Zekrom", "Landorus", "Kyurem", "Keldeo", "Meloetta", "Genesect", "Chespin", "Quilladin", "Chesnaught", "Fennekin", "Braixen", "Delphox", "Froakie", "Frogadier", "Greninja", "Bunnelby", "Diggersby", "Fletchling", "Fletchinder", "Talonflame", "Scatterbug", "Spewpa", "Vivillon", "Litleo", "Pyroar", "Flabébé", "Floette", "Florges", "Skiddo", "Gogoat", "Pancham", "Pangoro", "Furfrou", "Espurr", "Meowstic", "Honedge", "Doublade", "Aegislash", "Spritzee", "Aromatisse", "Swirlix", "Slurpuff", "Inkay", "Malamar", "Binacle", "Barbaracle", "Skrelp", "Dragalge", "Clauncher", "Clawitzer", "Helioptile", "Heliolisk", "Tyrunt", "Tyrantrum", "Amaura", "Aurorus", "Sylveon", "Hawlucha", "Dedenne", "Carbink", "Goomy", "Sliggoo", "Goodra", "Klefki", "Phantump", "Trevenant", "Pumpkaboo", "Gourgeist", "Bergmite", "Avalugg", "Noibat", "Noivern", "Xerneas", "Yveltal", "Zygarde", "Diancie", "Hoopa", "Volcanion", "Rowlet", "Dartrix", "Decidueye", "Litten", "Torracat", "Incineroar", "Popplio", "Brionne", "Primarina", "Pikipek", "Trumbeak", "Toucannon", "Yungoos", "Gumshoos", "Grubbin", "Charjabug", "Vikavolt", "Crabrawler", "Crabominable", "Oricorio", "Cutiefly", "Ribombee", "Rockruff", "Lycanroc", "Wishiwashi", "Mareanie", "Toxapex", "Mudbray", "Mudsdale", "Dewpider", "Araquanid", "Fomantis", "Lurantis", "Morelull", "Shiinotic", "Salandit", "Salazzle", "Stufful", "Bewear", "Bounsweet", "Steenee", "Tsareena", "Comfey", "Oranguru", "Passimian", "Wimpod", "Golisopod", "Sandygast", "Palossand", "Pyukumuku", "Type: Null", "Silvally", "Minior", "Komala", "Turtonator", "Togedemaru", "Mimikyu", "Bruxish", "Drampa", "Dhelmise", "Jangmo-o", "Hakamo-o", "Kommo-o", "Tapu Koko", "Tapu Lele", "Tapu Bulu", "Tapu Fini", "Cosmog", "Cosmoem", "Solgaleo", "Lunala", "Nihilego", "Buzzwole", "Pheromosa", "Xurkitree", "Celesteela", "Kartana", "Guzzlord", "Necrozma", "Magearna", "Marshadow", "Poipole", "Naganadel", "Stakataka", "Blacephalon", "Zeraora", "Meltan", "Melmetal", "Grookey", "Thwackey", "Rillaboom", "Scorbunny", "Raboot", "Cinderace", "Sobble", "Drizzile", "Inteleon", "Skwovet", "Greedent", "Rookidee", "Corvisquire", "Corviknight", "Blipbug", "Dottler", "Orbeetle", "Nickit", "Thievul", "Gossifleur", "Eldegoss", "Wooloo", "Dubwool", "Chewtle", "Drednaw", "Yamper", "Boltund", "Rolycoly", "Carkol", "Coalossal", "Applin", "Flapple", "Appletun", "Silicobra", "Sandaconda", "Cramorant", "Arrokuda", "Barraskewda", "Toxel", "Toxtricity", "Sizzlipede", "Centiskorch", "Clobbopus", "Grapploct", "Sinistea", "Polteageist", "Hatenna", "Hattrem", "Hatterene", "Impidimp", "Morgrem", "Grimmsnarl", "Obstagoon", "Perrserker", "Cursola", "Sirfetch’d", "Mr. Rime", "Runerigus", "Milcery", "Alcremie", "Falinks", "Pincurchin", "Snom", "Frosmoth", "Stonjourner", "Eiscue", "Indeedee", "Morpeko", "Cufant", "Copperajah", "Dracozolt", "Arctozolt", "Dracovish", "Arctovish", "Duraludon", "Dreepy", "Drakloak", "Dragapult", "Zacian", "Zamazenta", "Eternatus", "Kubfu", "Urshifu", "Zarude", "Regieleki", "Regidrago", "Glastrier", "Spectrier", "Calyrex", "Wyrdeer", "Kleavor", "Ursaluna", "Basculegion", "Sneasler", "Overqwil", "Enamorus", "Sprigatito", "Floragato", "Meowscarada", "Fuecoco", "Crocalor", "Skeledirge", "Quaxly", "Quaxwell", "Quaquaval", "Lechonk", "Oinkologne", "Dudunsparce", "Tarountula", "Spidops", "Nymble", "Lokix", "Rellor", "Rabsca", "Greavard", "Houndstone", "Flittle", "Espathra", "Farigiraf", "Wiglett", "Wugtrio", "Dondozo", "Veluza", "Finizen", "Palafin", "Smoliv", "Dolliv", "Arboliva", "Capsakid", "Scovillain", "Tadbulb", "Bellibolt", "Varoom", "Revavroom", "Orthworm", "Tandemaus", "Maushold", "Cetoddle", "Cetitan", "Frigibax", "Arctibax", "Baxcalibur", "Tatsugiri", "Cyclizar", "Pawmi", "Pawmo", "Pawmot", "Wattrel", "Kilowattrel", "Bombirdier", "Squawkabilly", "Flamigo", "Klawf", "Nacli", "Naclstack", "Garganacl", "Glimmet", "Glimmora", "Shroodle", "Grafaiai", "Fidough", "Dachsbun", "Maschiff", "Mabosstiff", "Bramblin", "Brambleghast", "Gimmighoul", "Gholdengo", "Great Tusk", "Brute Bonnet", "Walking Wake", "Sandy Shocks", "Scream Tail", "Flutter Mane", "Slither Wing", "Roaring Moon", "Iron Treads", "Iron Leaves", "Iron Moth", "Iron Hands", "Iron Jugulis", "Iron Thorns", "Iron Bundle", "Iron Valiant", "Ting-Lu", "Chien-Pao", "Wo-Chien", "Chi-Yu", "Koraidon", "Miraidon", "Tinkatink", "Tinkatuff", "Tinkaton", "Charcadet", "Armarouge", "Ceruledge", "Toedscool", "Toedscruel", "Kingambit", "Clodsire", "Annihilape", "Ogerpon", "Dipplin", "", "Okidogi", "Munkidori", "Fezandipiti", "", "", "", "", "", "", "", "Poltchageist", "Sinistcha" };
        public ObservableCollection<string> ItemsList { get; } = new ObservableCollection<string> { "None", "Master Ball", "Ultra Ball", "Great Ball", "Poké Ball", "Safari Ball", "Net Ball", "Dive Ball", "Nest Ball", "Repeat Ball", "Timer Ball", "Luxury Ball", "Premier Ball", "Dusk Ball", "Heal Ball", "Quick Ball", "Cherish Ball", "Potion", "Antidote", "Burn Heal", "Ice Heal", "Awakening", "Paralyze Heal", "Full Restore", "Max Potion", "Hyper Potion", "Super Potion", "Full Heal", "Revive", "Max Revive", "Fresh Water", "Soda Pop", "Lemonade", "Moomoo Milk", "Energy Powder", "Energy Root", "Heal Powder", "Revival Herb", "Ether", "Max Ether", "Elixir", "Max Elixir", "Lava Cookie", "Berry Juice", "Sacred Ash", "HP Up", "Protein", "Iron", "Carbos", "Calcium", "Rare Candy", "PP Up", "Zinc", "PP Max", "Old Gateau", "Guard Spec.", "Dire Hit", "X Attack", "X Defense", "X Speed", "X Accuracy", "X Sp. Atk", "X Sp. Def", "Poké Doll", "Fluffy Tail", "Blue Flute", "Yellow Flute", "Red Flute", "Black Flute", "White Flute", "Shoal Salt", "Shoal Shell", "Red Shard", "Blue Shard", "Yellow Shard", "Green Shard", "Super Repel", "Max Repel", "Escape Rope", "Repel", "Sun Stone", "Moon Stone", "Fire Stone", "Thunder Stone", "Water Stone", "Leaf Stone", "Tiny Mushroom", "Big Mushroom", "Pearl", "Big Pearl", "Stardust", "Star Piece", "Nugget", "Heart Scale", "Honey", "Growth Mulch", "Damp Mulch", "Stable Mulch", "Gooey Mulch", "Root Fossil", "Claw Fossil", "Helix Fossil", "Dome Fossil", "Old Amber", "Armor Fossil", "Skull Fossil", "Rare Bone", "Shiny Stone", "Dusk Stone", "Dawn Stone", "Oval Stone", "Odd Keystone", "Griseous Orb", "Tea", "???", "Autograph", "Douse Drive", "Shock Drive", "Burn Drive", "Chill Drive", "???", "Pokémon Box Link", "Medicine Pocket", "TM Case", "Candy Jar", "Power-Up Pocket", "Clothing Trunk", "Catching Pocket", "Battle Pocket", "???", "???", "???", "???", "???", "Sweet Heart", "Adamant Orb", "Lustrous Orb", "Greet Mail", "Favored Mail", "RSVP Mail", "Thanks Mail", "Inquiry Mail", "Like Mail", "Reply Mail", "Bridge Mail S", "Bridge Mail D", "Bridge Mail T", "Bridge Mail V", "Bridge Mail M", "Cheri Berry", "Chesto Berry", "Pecha Berry", "Rawst Berry", "Aspear Berry", "Leppa Berry", "Oran Berry", "Persim Berry", "Lum Berry", "Sitrus Berry", "Figy Berry", "Wiki Berry", "Mago Berry", "Aguav Berry", "Iapapa Berry", "Razz Berry", "Bluk Berry", "Nanab Berry", "Wepear Berry", "Pinap Berry", "Pomeg Berry", "Kelpsy Berry", "Qualot Berry", "Hondew Berry", "Grepa Berry", "Tamato Berry", "Cornn Berry", "Magost Berry", "Rabuta Berry", "Nomel Berry", "Spelon Berry", "Pamtre Berry", "Watmel Berry", "Durin Berry", "Belue Berry", "Occa Berry", "Passho Berry", "Wacan Berry", "Rindo Berry", "Yache Berry", "Chople Berry", "Kebia Berry", "Shuca Berry", "Coba Berry", "Payapa Berry", "Tanga Berry", "Charti Berry", "Kasib Berry", "Haban Berry", "Colbur Berry", "Babiri Berry", "Chilan Berry", "Liechi Berry", "Ganlon Berry", "Salac Berry", "Petaya Berry", "Apicot Berry", "Lansat Berry", "Starf Berry", "Enigma Berry", "Micle Berry", "Custap Berry", "Jaboca Berry", "Rowap Berry", "Bright Powder", "White Herb", "Macho Brace", "Exp. Share", "Quick Claw", "Soothe Bell", "Mental Herb", "Choice Band", "King’s Rock", "Silver Powder", "Amulet Coin", "Cleanse Tag", "Soul Dew", "Deep Sea Tooth", "Deep Sea Scale", "Smoke Ball", "Everstone", "Focus Band", "Lucky Egg", "Scope Lens", "Metal Coat", "Leftovers", "Dragon Scale", "Light Ball", "Soft Sand", "Hard Stone", "Miracle Seed", "Black Glasses", "Black Belt", "Magnet", "Mystic Water", "Sharp Beak", "Poison Barb", "Never-Melt Ice", "Spell Tag", "Twisted Spoon", "Charcoal", "Dragon Fang", "Silk Scarf", "Upgrade", "Shell Bell", "Sea Incense", "Lax Incense", "Lucky Punch", "Metal Powder", "Thick Club", "Leek", "Red Scarf", "Blue Scarf", "Pink Scarf", "Green Scarf", "Yellow Scarf", "Wide Lens", "Muscle Band", "Wise Glasses", "Expert Belt", "Light Clay", "Life Orb", "Power Herb", "Toxic Orb", "Flame Orb", "Quick Powder", "Focus Sash", "Zoom Lens", "Metronome", "Iron Ball", "Lagging Tail", "Destiny Knot", "Black Sludge", "Icy Rock", "Smooth Rock", "Heat Rock", "Damp Rock", "Grip Claw", "Choice Scarf", "Sticky Barb", "Power Bracer", "Power Belt", "Power Lens", "Power Band", "Power Anklet", "Power Weight", "Shed Shell", "Big Root", "Choice Specs", "Flame Plate", "Splash Plate", "Zap Plate", "Meadow Plate", "Icicle Plate", "Fist Plate", "Toxic Plate", "Earth Plate", "Sky Plate", "Mind Plate", "Insect Plate", "Stone Plate", "Spooky Plate", "Draco Plate", "Dread Plate", "Iron Plate", "Odd Incense", "Rock Incense", "Full Incense", "Wave Incense", "Rose Incense", "Luck Incense", "Pure Incense", "Protector", "Electirizer", "Magmarizer", "Dubious Disc", "Reaper Cloth", "Razor Claw", "Razor Fang", "TM001", "TM002", "TM003", "TM004", "TM005", "TM006", "TM007", "TM008", "TM009", "TM010", "TM011", "TM012", "TM013", "TM014", "TM015", "TM016", "TM017", "TM018", "TM019", "TM020", "TM021", "TM022", "TM023", "TM024", "TM025", "TM026", "TM027", "TM028", "TM029", "TM030", "TM031", "TM032", "TM033", "TM034", "TM035", "TM036", "TM037", "TM038", "TM039", "TM040", "TM041", "TM042", "TM043", "TM044", "TM045", "TM046", "TM047", "TM048", "TM049", "TM050", "TM051", "TM052", "TM053", "TM054", "TM055", "TM056", "TM057", "TM058", "TM059", "TM060", "TM061", "TM062", "TM063", "TM064", "TM065", "TM066", "TM067", "TM068", "TM069", "TM070", "TM071", "TM072", "TM073", "TM074", "TM075", "TM076", "TM077", "TM078", "TM079", "TM080", "TM081", "TM082", "TM083", "TM084", "TM085", "TM086", "TM087", "TM088", "TM089", "TM090", "TM091", "TM092", "HM01", "HM02", "HM03", "HM04", "HM05", "HM06", "???", "???", "Explorer Kit", "Loot Sack", "Rule Book", "Poké Radar", "Point Card", "Guidebook", "Sticker Case", "Fashion Case", "Sticker Bag", "Pal Pad", "Works Key", "Old Charm", "Galactic Key", "Red Chain", "Town Map", "Vs. Seeker", "Coin Case", "Old Rod", "Good Rod", "Super Rod", "Sprayduck", "Poffin Case", "Bike", "Suite Key", "Oak’s Letter", "Lunar Feather", "Member Card", "Azure Flute", "S.S. Ticket", "Contest Pass", "Magma Stone", "Parcel", "Coupon 1", "Coupon 2", "Coupon 3", "Storage Key", "Secret Medicine", "Vs. Recorder", "Gracidea", "Secret Key", "Apricorn Box", "Unown Report", "Berry Pots", "Dowsing Machine", "Blue Card", "Slowpoke Tail", "Clear Bell", "Card Key", "Basement Key", "Squirt Bottle", "Red Scale", "Lost Item", "Pass", "Machine Part", "Silver Feather", "Rainbow Feather", "Mystery Egg", "Red Apricorn", "Blue Apricorn", "Yellow Apricorn", "Green Apricorn", "Pink Apricorn", "White Apricorn", "Black Apricorn", "Fast Ball", "Level Ball", "Lure Ball", "Heavy Ball", "Love Ball", "Friend Ball", "Moon Ball", "Sport Ball", "Park Ball", "Photo Album", "GB Sounds", "Tidal Bell", "Rage Candy Bar", "Data Card 01", "Data Card 02", "Data Card 03", "Data Card 04", "Data Card 05", "Data Card 06", "Data Card 07", "Data Card 08", "Data Card 09", "Data Card 10", "Data Card 11", "Data Card 12", "Data Card 13", "Data Card 14", "Data Card 15", "Data Card 16", "Data Card 17", "Data Card 18", "Data Card 19", "Data Card 20", "Data Card 21", "Data Card 22", "Data Card 23", "Data Card 24", "Data Card 25", "Data Card 26", "Data Card 27", "Jade Orb", "Lock Capsule", "Red Orb", "Blue Orb", "Enigma Stone", "Prism Scale", "Eviolite", "Float Stone", "Rocky Helmet", "Air Balloon", "Red Card", "Ring Target", "Binding Band", "Absorb Bulb", "Cell Battery", "Eject Button", "Fire Gem", "Water Gem", "Electric Gem", "Grass Gem", "Ice Gem", "Fighting Gem", "Poison Gem", "Ground Gem", "Flying Gem", "Psychic Gem", "Bug Gem", "Rock Gem", "Ghost Gem", "Dragon Gem", "Dark Gem", "Steel Gem", "Normal Gem", "Health Feather", "Muscle Feather", "Resist Feather", "Genius Feather", "Clever Feather", "Swift Feather", "Pretty Feather", "Cover Fossil", "Plume Fossil", "Liberty Pass", "Pass Orb", "Dream Ball", "Poké Toy", "Prop Case", "Dragon Skull", "Balm Mushroom", "Big Nugget", "Pearl String", "Comet Shard", "Relic Copper", "Relic Silver", "Relic Gold", "Relic Vase", "Relic Band", "Relic Statue", "Relic Crown", "Casteliacone", "Dire Hit 2", "X Speed 2", "X Sp. Atk 2", "X Sp. Def 2", "X Defense 2", "X Attack 2", "X Accuracy 2", "X Speed 3", "X Sp. Atk 3", "X Sp. Def 3", "X Defense 3", "X Attack 3", "X Accuracy 3", "X Speed 6", "X Sp. Atk 6", "X Sp. Def 6", "X Defense 6", "X Attack 6", "X Accuracy 6", "Ability Urge", "Item Drop", "Item Urge", "Reset Urge", "Dire Hit 3", "Light Stone", "Dark Stone", "TM093", "TM094", "TM095", "Xtransceiver", "???", "Gram 1", "Gram 2", "Gram 3", "Xtransceiver", "Medal Box", "DNA Splicers", "DNA Splicers", "Permit", "Oval Charm", "Shiny Charm", "Plasma Card", "Grubby Hanky", "Colress Machine", "Dropped Item", "Dropped Item", "Reveal Glass", "Weakness Policy", "Assault Vest", "Holo Caster", "Prof’s Letter", "Roller Skates", "Pixie Plate", "Ability Capsule", "Whipped Dream", "Sachet", "Luminous Moss", "Snowball", "Safety Goggles", "Poké Flute", "Rich Mulch", "Surprise Mulch", "Boost Mulch", "Amaze Mulch", "Gengarite", "Gardevoirite", "Ampharosite", "Venusaurite", "Charizardite X", "Blastoisinite", "Mewtwonite X", "Mewtwonite Y", "Blazikenite", "Medichamite", "Houndoominite", "Aggronite", "Banettite", "Tyranitarite", "Scizorite", "Pinsirite", "Aerodactylite", "Lucarionite", "Abomasite", "Kangaskhanite", "Gyaradosite", "Absolite", "Charizardite Y", "Alakazite", "Heracronite", "Mawilite", "Manectite", "Garchompite", "Latiasite", "Latiosite", "Roseli Berry", "Kee Berry", "Maranga Berry", "Sprinklotad", "TM096", "TM097", "TM098", "TM099", "TM100", "Power Plant Pass", "Mega Ring", "Intriguing Stone", "Common Stone", "Discount Coupon", "Elevator Key", "TMV Pass", "Honor of Kalos", "Adventure Guide", "Strange Souvenir", "Lens Case", "Makeup Bag", "Travel Trunk", "Lumiose Galette", "Shalour Sable", "Jaw Fossil", "Sail Fossil", "Looker Ticket", "Bike", "Holo Caster", "Fairy Gem", "Mega Charm", "Mega Glove", "Mach Bike", "Acro Bike", "Wailmer Pail", "Devon Parts", "Soot Sack", "Basement Key", "Pokéblock Kit", "Letter", "Eon Ticket", "Scanner", "Go-Goggles", "Meteorite", "Key to Room 1", "Key to Room 2", "Key to Room 4", "Key to Room 6", "Storage Key", "Devon Scope", "S.S. Ticket", "HM07", "Devon Scuba Gear", "Contest Costume", "Contest Costume", "Magma Suit", "Aqua Suit", "Pair of Tickets", "Mega Bracelet", "Mega Pendant", "Mega Glasses", "Mega Anchor", "Mega Stickpin", "Mega Tiara", "Mega Anklet", "Meteorite", "Swampertite", "Sceptilite", "Sablenite", "Altarianite", "Galladite", "Audinite", "Metagrossite", "Sharpedonite", "Slowbronite", "Steelixite", "Pidgeotite", "Glalitite", "Diancite", "Prison Bottle", "Mega Cuff", "Cameruptite", "Lopunnite", "Salamencite", "Beedrillite", "Meteorite", "Meteorite", "Key Stone", "Meteorite Shard", "Eon Flute", "Normalium Z", "Firium Z", "Waterium Z", "Electrium Z", "Grassium Z", "Icium Z", "Fightinium Z", "Poisonium Z", "Groundium Z", "Flyinium Z", "Psychium Z", "Buginium Z", "Rockium Z", "Ghostium Z", "Dragonium Z", "Darkinium Z", "Steelium Z", "Fairium Z", "Pikanium Z", "Bottle Cap", "Gold Bottle Cap", "Z-Ring", "Decidium Z", "Incinium Z", "Primarium Z", "Tapunium Z", "Marshadium Z", "Aloraichium Z", "Snorlium Z", "Eevium Z", "Mewnium Z", "Normalium Z", "Firium Z", "Waterium Z", "Electrium Z", "Grassium Z", "Icium Z", "Fightinium Z", "Poisonium Z", "Groundium Z", "Flyinium Z", "Psychium Z", "Buginium Z", "Rockium Z", "Ghostium Z", "Dragonium Z", "Darkinium Z", "Steelium Z", "Fairium Z", "Pikanium Z", "Decidium Z", "Incinium Z", "Primarium Z", "Tapunium Z", "Marshadium Z", "Aloraichium Z", "Snorlium Z", "Eevium Z", "Mewnium Z", "Pikashunium Z", "Pikashunium Z", "???", "???", "???", "???", "Forage Bag", "Fishing Rod", "Professor’s Mask", "Festival Ticket", "Sparkling Stone", "Adrenaline Orb", "Zygarde Cube", "???", "Ice Stone", "Ride Pager", "Beast Ball", "Big Malasada", "Red Nectar", "Yellow Nectar", "Pink Nectar", "Purple Nectar", "Sun Flute", "Moon Flute", "???", "Enigmatic Card", "Silver Razz Berry", "Golden Razz Berry", "Silver Nanab Berry", "Golden Nanab Berry", "Silver Pinap Berry", "Golden Pinap Berry", "???", "???", "???", "???", "???", "Secret Key", "S.S. Ticket", "Silph Scope", "Parcel", "Card Key", "Gold Teeth", "Lift Key", "Terrain Extender", "Protective Pads", "Electric Seed", "Psychic Seed", "Misty Seed", "Grassy Seed", "Stretchy Spring", "Chalky Stone", "Marble", "Lone Earring", "Beach Glass", "Gold Leaf", "Silver Leaf", "Polished Mud Ball", "Tropical Shell", "Leaf Letter", "Leaf Letter", "Small Bouquet", "???", "???", "???", "Lure", "Super Lure", "Max Lure", "Pewter Crunchies", "Fighting Memory", "Flying Memory", "Poison Memory", "Ground Memory", "Rock Memory", "Bug Memory", "Ghost Memory", "Steel Memory", "Fire Memory", "Water Memory", "Grass Memory", "Electric Memory", "Psychic Memory", "Ice Memory", "Dragon Memory", "Dark Memory", "Fairy Memory", "Solganium Z", "Lunalium Z", "Ultranecrozium Z", "Mimikium Z", "Lycanium Z", "Kommonium Z", "Solganium Z", "Lunalium Z", "Ultranecrozium Z", "Mimikium Z", "Lycanium Z", "Kommonium Z", "Z-Power Ring", "Pink Petal", "Orange Petal", "Blue Petal", "Red Petal", "Green Petal", "Yellow Petal", "Purple Petal", "Rainbow Flower", "Surge Badge", "N-Solarizer", "N-Lunarizer", "N-Solarizer", "N-Lunarizer", "Ilima’s Normalium Z", "Left Poké Ball", "Roto Hatch", "Roto Bargain", "Roto Prize Money", "Roto Exp. Points", "Roto Friendship", "Roto Encounter", "Roto Stealth", "Roto HP Restore", "Roto PP Restore", "Roto Boost", "Roto Catch", "Health Candy", "Mighty Candy", "Tough Candy", "Smart Candy", "Courage Candy", "Quick Candy", "Health Candy L", "Mighty Candy L", "Tough Candy L", "Smart Candy L", "Courage Candy L", "Quick Candy L", "Health Candy XL", "Mighty Candy XL", "Tough Candy XL", "Smart Candy XL", "Courage Candy XL", "Quick Candy XL", "Bulbasaur Candy", "Charmander Candy", "Squirtle Candy", "Caterpie Candy", "Weedle Candy", "Pidgey Candy", "Rattata Candy", "Spearow Candy", "Ekans Candy", "Pikachu Candy", "Sandshrew Candy", "Nidoran♀ Candy", "Nidoran♂ Candy", "Clefairy Candy", "Vulpix Candy", "Jigglypuff Candy", "Zubat Candy", "Oddish Candy", "Paras Candy", "Venonat Candy", "Diglett Candy", "Meowth Candy", "Psyduck Candy", "Mankey Candy", "Growlithe Candy", "Poliwag Candy", "Abra Candy", "Machop Candy", "Bellsprout Candy", "Tentacool Candy", "Geodude Candy", "Ponyta Candy", "Slowpoke Candy", "Magnemite Candy", "Farfetch’d Candy", "Doduo Candy", "Seel Candy", "Grimer Candy", "Shellder Candy", "Gastly Candy", "Onix Candy", "Drowzee Candy", "Krabby Candy", "Voltorb Candy", "Exeggcute Candy", "Cubone Candy", "Hitmonlee Candy", "Hitmonchan Candy", "Lickitung Candy", "Koffing Candy", "Rhyhorn Candy", "Chansey Candy", "Tangela Candy", "Kangaskhan Candy", "Horsea Candy", "Goldeen Candy", "Staryu Candy", "Mr. Mime Candy", "Scyther Candy", "Jynx Candy", "Electabuzz Candy", "Pinsir Candy", "Tauros Candy", "Magikarp Candy", "Lapras Candy", "Ditto Candy", "Eevee Candy", "Porygon Candy", "Omanyte Candy", "Kabuto Candy", "Aerodactyl Candy", "Snorlax Candy", "Articuno Candy", "Zapdos Candy", "Moltres Candy", "Dratini Candy", "Mewtwo Candy", "Mew Candy", "Meltan Candy", "Magmar Candy", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "???", "Endorsement", "Pokémon Box Link", "Wishing Star", "Dynamax Band", "???", "???", "Fishing Rod", "Rotom Bike", "???", "???", "Sausages", "Bob’s Food Tin", "Bach’s Food Tin", "Tin of Beans", "Bread", "Pasta", "Mixed Mushrooms", "Smoke-Poke Tail", "Large Leek", "Fancy Apple", "Brittle Bones", "Pack of Potatoes", "Pungent Root", "Salad Mix", "Fried Food", "Boiled Egg", "Camping Gear", "???", "???", "Rusted Sword", "Rusted Shield", "Fossilized Bird", "Fossilized Fish", "Fossilized Drake", "Fossilized Dino", "Strawberry Sweet", "Love Sweet", "Berry Sweet", "Clover Sweet", "Flower Sweet", "Star Sweet", "Ribbon Sweet", "Sweet Apple", "Tart Apple", "Throat Spray", "Eject Pack", "Heavy-Duty Boots", "Blunder Policy", "Room Service", "Utility Umbrella", "Exp. Candy XS", "Exp. Candy S", "Exp. Candy M", "Exp. Candy L", "Exp. Candy XL", "Dynamax Candy", "TR00", "TR01", "TR02", "TR03", "TR04", "TR05", "TR06", "TR07", "TR08", "TR09", "TR10", "TR11", "TR12", "TR13", "TR14", "TR15", "TR16", "TR17", "TR18", "TR19", "TR20", "TR21", "TR22", "TR23", "TR24", "TR25", "TR26", "TR27", "TR28", "TR29", "TR30", "TR31", "TR32", "TR33", "TR34", "TR35", "TR36", "TR37", "TR38", "TR39", "TR40", "TR41", "TR42", "TR43", "TR44", "TR45", "TR46", "TR47", "TR48", "TR49", "TR50", "TR51", "TR52", "TR53", "TR54", "TR55", "TR56", "TR57", "TR58", "TR59", "TR60", "TR61", "TR62", "TR63", "TR64", "TR65", "TR66", "TR67", "TR68", "TR69", "TR70", "TR71", "TR72", "TR73", "TR74", "TR75", "TR76", "TR77", "TR78", "TR79", "TR80", "TR81", "TR82", "TR83", "TR84", "TR85", "TR86", "TR87", "TR88", "TR89", "TR90", "TR91", "TR92", "TR93", "TR94", "TR95", "TR96", "TR97", "TR98", "TR99", "TM00", "Lonely Mint", "Adamant Mint", "Naughty Mint", "Brave Mint", "Bold Mint", "Impish Mint", "Lax Mint", "Relaxed Mint", "Modest Mint", "Mild Mint", "Rash Mint", "Quiet Mint", "Calm Mint", "Gentle Mint", "Careful Mint", "Sassy Mint", "Timid Mint", "Hasty Mint", "Jolly Mint", "Naive Mint", "Serious Mint", "Wishing Piece", "Cracked Pot", "Chipped Pot", "Hi-tech Earbuds", "Fruit Bunch", "Moomoo Cheese", "Spice Mix", "Fresh Cream", "Packaged Curry", "Coconut Milk", "Instant Noodles", "Precooked Burger", "Gigantamix", "Wishing Chip", "Rotom Bike", "Catching Charm", "???", "Old Letter", "Band Autograph", "Sonia’s Book", "???", "???", "???", "???", "???", "???", "Rotom Catalog", "★And458", "★And15", "★And337", "★And603", "★And390", "★Sgr6879", "★Sgr6859", "★Sgr6913", "★Sgr7348", "★Sgr7121", "★Sgr6746", "★Sgr7194", "★Sgr7337", "★Sgr7343", "★Sgr6812", "★Sgr7116", "★Sgr7264", "★Sgr7597", "★Del7882", "★Del7906", "★Del7852", "★Psc596", "★Psc361", "★Psc510", "★Psc437", "★Psc8773", "★Lep1865", "★Lep1829", "★Boo5340", "★Boo5506", "★Boo5435", "★Boo5602", "★Boo5733", "★Boo5235", "★Boo5351", "★Hya3748", "★Hya3903", "★Hya3418", "★Hya3482", "★Hya3845", "★Eri1084", "★Eri472", "★Eri1666", "★Eri897", "★Eri1231", "★Eri874", "★Eri1298", "★Eri1325", "★Eri984", "★Eri1464", "★Eri1393", "★Eri850", "★Tau1409", "★Tau1457", "★Tau1165", "★Tau1791", "★Tau1910", "★Tau1346", "★Tau1373", "★Tau1412", "★CMa2491", "★CMa2693", "★CMa2294", "★CMa2827", "★CMa2282", "★CMa2618", "★CMa2657", "★CMa2646", "★UMa4905", "★UMa4301", "★UMa5191", "★UMa5054", "★UMa4295", "★UMa4660", "★UMa4554", "★UMa4069", "★UMa3569", "★UMa3323", "★UMa4033", "★UMa4377", "★UMa4375", "★UMa4518", "★UMa3594", "★Vir5056", "★Vir4825", "★Vir4932", "★Vir4540", "★Vir4689", "★Vir5338", "★Vir4910", "★Vir5315", "★Vir5359", "★Vir5409", "★Vir5107", "★Ari617", "★Ari553", "★Ari546", "★Ari951", "★Ori1713", "★Ori2061", "★Ori1790", "★Ori1903", "★Ori1948", "★Ori2004", "★Ori1852", "★Ori1879", "★Ori1899", "★Ori1543", "★Cas21", "★Cas168", "★Cas403", "★Cas153", "★Cas542", "★Cas219", "★Cas265", "★Cnc3572", "★Cnc3208", "★Cnc3461", "★Cnc3449", "★Cnc3429", "★Cnc3627", "★Cnc3268", "★Cnc3249", "★Com4968", "★Crv4757", "★Crv4623", "★Crv4662", "★Crv4786", "★Aur1708", "★Aur2088", "★Aur1605", "★Aur2095", "★Aur1577", "★Aur1641", "★Aur1612", "★Pav7790", "★Cet911", "★Cet681", "★Cet188", "★Cet539", "★Cet804", "★Cep8974", "★Cep8162", "★Cep8238", "★Cep8417", "★Cen5267", "★Cen5288", "★Cen551", "★Cen5459", "★Cen5460", "★CMi2943", "★CMi2845", "★Equ8131", "★Vul7405", "★UMi424", "★UMi5563", "★UMi5735", "★UMi6789", "★Crt4287", "★Lyr7001", "★Lyr7178", "★Lyr7106", "★Lyr7298", "★Ara6585", "★Sco6134", "★Sco6527", "★Sco6553", "★Sco5953", "★Sco5984", "★Sco6508", "★Sco6084", "★Sco5944", "★Sco6630", "★Sco6027", "★Sco6247", "★Sco6252", "★Sco5928", "★Sco6241", "★Sco6165", "★Tri544", "★Leo3982", "★Leo4534", "★Leo4357", "★Leo4057", "★Leo4359", "★Leo4031", "★Leo3852", "★Leo3905", "★Leo3773", "★Gru8425", "★Gru8636", "★Gru8353", "★Lib5685", "★Lib5531", "★Lib5787", "★Lib5603", "★Pup3165", "★Pup3185", "★Pup3045", "★Cyg7924", "★Cyg7417", "★Cyg7796", "★Cyg8301", "★Cyg7949", "★Cyg7528", "★Oct7228", "★Col1956", "★Col2040", "★Col2177", "★Gem2990", "★Gem2891", "★Gem2421", "★Gem2473", "★Gem2216", "★Gem2777", "★Gem2650", "★Gem2286", "★Gem2484", "★Gem2930", "★Peg8775", "★Peg8781", "★Peg39", "★Peg8308", "★Peg8650", "★Peg8634", "★Peg8684", "★Peg8450", "★Peg8880", "★Peg8905", "★Oph6556", "★Oph6378", "★Oph6603", "★Oph6149", "★Oph6056", "★Oph6075", "★Ser5854", "★Ser7141", "★Ser5879", "★Her6406", "★Her6148", "★Her6410", "★Her6526", "★Her6117", "★Her6008", "★Per936", "★Per1017", "★Per1131", "★Per1228", "★Per834", "★Per941", "★Phe99", "★Phe338", "★Vel3634", "★Vel3485", "★Vel3734", "★Aqr8232", "★Aqr8414", "★Aqr8709", "★Aqr8518", "★Aqr7950", "★Aqr8499", "★Aqr8610", "★Aqr8264", "★Cru4853", "★Cru4730", "★Cru4763", "★Cru4700", "★Cru4656", "★PsA8728", "★TrA6217", "★Cap7776", "★Cap7754", "★Cap8278", "★Cap8322", "★Cap7773", "★Sge7479", "★Car2326", "★Car3685", "★Car3307", "★Car3699", "★Dra5744", "★Dra5291", "★Dra6705", "★Dra6536", "★Dra7310", "★Dra6688", "★Dra4434", "★Dra6370", "★Dra7462", "★Dra6396", "★Dra6132", "★Dra6636", "★CVn4915", "★CVn4785", "★CVn4846", "★Aql7595", "★Aql7557", "★Aql7525", "★Aql7602", "★Aql7235", "Max Honey", "Max Mushrooms", "Galarica Twig", "Galarica Cuff", "Style Card", "Armor Pass", "Rotom Bike", "Rotom Bike", "Exp. Charm", "Armorite Ore", "Mark Charm", "Reins of Unity", "Reins of Unity", "Galarica Wreath", "Legendary Clue 1", "Legendary Clue 2", "Legendary Clue 3", "Legendary Clue?", "Crown Pass", "Wooden Crown", "Radiant Petal", "White Mane Hair", "Black Mane Hair", "Iceroot Carrot", "Shaderoot Carrot", "Dynite Ore", "Carrot Seeds", "Ability Patch", "Reins of Unity", "Time Balm", "Space Balm", "Mysterious Balm", "Linking Cord", "Hometown Muffin", "Apricorn", "Jubilife Muffin", "Aux Powerguard", "Dire Hit", "Choice Dumpling", "Twice-Spiced Radish", "Swap Snack", "Caster Fern", "Seed of Mastery", "Poké Ball", "???", "Eternal Ice", "Uxie’s Claw", "Azelf’s Fang", "Mesprit’s Plume", "Tumblestone", "Celestica Flute", "Remedy", "Fine Remedy", "Dazzling Honey", "Hearty Grains", "Plump Beans", "Springy Mushroom", "Crunchy Salt", "Wood", "King’s Leaf", "Marsh Balm", "Poké Ball", "Great Ball", "Ultra Ball", "Feather Ball", "Pokéshi Doll", "???", "Smoke Bomb", "Scatter Bang", "Sticky Glob", "Star Piece", "Mushroom Cake", "Bugwort", "Honey Cake", "Grain Cake", "Bean Cake", "Salt Cake", "Potion", "Super Potion", "Hyper Potion", "Max Potion", "Full Restore", "Remedy", "Fine Remedy", "Superb Remedy", "Old Gateau", "Jubilife Muffin", "Full Heal", "Revive", "Max Revive", "Max Ether", "Max Elixir", "Stealth Spray", "???", "Aux Power", "Aux Guard", "Dire Hit", "Aux Evasion", "Aux Powerguard", "Forest Balm", "Iron Chunk", "???", "Black Tumblestone", "Sky Tumblestone", "???", "Ball of Mud", "???", "Pop Pod", "Sootfoot Root", "Spoiled Apricorn", "Snowball", "Sticky Glob", "Black Augurite", "Peat Block", "Stealth Spray", "Medicinal Leek", "Vivichoke", "Pep-Up Plant", "???", "???", "Tempting Charm B", "Tempting Charm P", "Swordcap", "Iron Barktongue", "Doppel Bonnets", "Direshroom", "Sand Radish", "Tempting Charm T", "Tempting Charm Y", "Candy Truffle", "Cake-Lure Base", "Poké Ball", "Great Ball", "Ultra Ball", "Feather Ball", "???", "???", "Scatter Bang", "Smoke Bomb", "???", "???", "Pokéshi Doll", "Volcano Balm", "Mountain Balm", "Snow Balm", "Honey Cake", "Grain Cake", "Bean Cake", "Mushroom Cake", "Salt Cake", "Swap Snack", "Choice Dumpling", "Twice-Spiced Radish", "Survival Charm R", "Survival Charm B", "Survival Charm P", "Survival Charm T", "Survival Charm Y", "Torn Journal", "Warding Charm R", "Warding Charm B", "Warding Charm P", "Warding Charm T", "Warding Charm Y", "Wall Fragment", "Basculegion Food", "Old Journal", "Wing Ball", "Jet Ball", "Heavy Ball", "Leaden Ball", "Gigaton Ball", "Wing Ball", "Jet Ball", "Heavy Ball", "Hopo Berry", "Superb Remedy", "Aux Power", "Aux Guard", "Aux Evasion", "Grit Dust", "Grit Gravel", "Grit Pebble", "Grit Rock", "Secret Medicine", "Tempting Charm R", "Lost Satchel", "Lost Satchel", "Lost Satchel", "Lost Satchel", "Lost Satchel", "???", "Origin Ball", "???", "???", "???", "???", "Origin Ore", "Adamant Crystal", "Lustrous Globe", "Griseous Core", "Blank Plate", "???", "Crafting Kit", "Leaden Ball", "Gigaton Ball", "Strange Ball", "Pokédex", "Old Verse 1", "Old Verse 2", "Old Verse 3", "Old Verse 4", "???", "Old Verse 5", "Old Verse 6", "Old Verse 7", "Old Verse 8", "Old Verse 9", "Old Verse 10", "Old Verse 11", "Old Verse 12", "Old Verse 13", "Old Verse 14", "Old Verse 15", "Old Verse 16", "Old Verse 17", "Old Verse 18", "Old Verse 19", "Old Verse 20", "Mysterious Shard S", "Mysterious Shard L", "Digger Drill", "Kanto Slate", "Johto Slate", "Soul Slate", "Rainbow Slate", "Squall Slate", "Oceanic Slate", "Tectonic Slate", "Stratospheric Slate", "Genome Slate", "Discovery Slate", "Distortion Slate", "DS Sounds", "Legend Plate", "Rotom Phone", "Sandwich", "Koraidon’s Poké Ball", "Miraidon’s Poké Ball", "Tera Orb", "Scarlet Book", "Violet Book", "Kofu’s Wallet", "Tiny Bamboo Shoot", "Big Bamboo Shoot", "Scroll of Darkness", "Scroll of Waters", "Malicious Armor", "Normal Tera Shard", "Fire Tera Shard", "Water Tera Shard", "Electric Tera Shard", "Grass Tera Shard", "Ice Tera Shard", "Fighting Tera Shard", "Poison Tera Shard", "Ground Tera Shard", "Flying Tera Shard", "Psychic Tera Shard", "Bug Tera Shard", "Rock Tera Shard", "Ghost Tera Shard", "Dragon Tera Shard", "Dark Tera Shard", "Steel Tera Shard", "Fairy Tera Shard", "Booster Energy", "Ability Shield", "Clear Amulet", "Mirror Herb", "Punching Glove", "Covert Cloak", "Loaded Dice", "Baguette", "Mayonnaise", "Ketchup", "Mustard", "Butter", "Peanut Butter", "Chili Sauce", "Salt", "Pepper", "Yogurt", "Whipped Cream", "Cream Cheese", "Jam", "Marmalade", "Olive Oil", "Vinegar", "Sweet Herba Mystica", "Salty Herba Mystica", "Sour Herba Mystica", "Bitter Herba Mystica", "Spicy Herba Mystica", "Lettuce", "Tomato", "Cherry Tomatoes", "Cucumber", "Pickle", "Onion", "Red Onion", "Green Bell Pepper", "Red Bell Pepper", "Yellow Bell Pepper", "Avocado", "Bacon", "Ham", "Prosciutto", "Chorizo", "Herbed Sausage", "Hamburger", "Klawf Stick", "Smoked Fillet", "Fried Fillet", "Egg", "Potato Tortilla", "Tofu", "Rice", "Noodles", "Potato Salad", "Cheese", "Banana", "Strawberry", "Apple", "Kiwi", "Pineapple", "Jalapeño", "Horseradish", "Curry Powder", "Wasabi", "Watercress", "Basil", "Venonat Fang", "Diglett Dirt", "Meowth Fur", "Psyduck Down", "Mankey Fur", "Growlithe Fur", "Slowpoke Claw", "Magnemite Screw", "Grimer Toxin", "Shellder Pearl", "Gastly Gas", "Drowzee Fur", "Voltorb Sparks", "Scyther Claw", "Tauros Hair", "Magikarp Scales", "Ditto Goo", "Eevee Fur", "Dratini Scales", "Pichu Fur", "Igglybuff Fluff", "Mareep Wool", "Hoppip Leaf", "Sunkern Leaf", "Murkrow Bauble", "Misdreavus Tears", "Girafarig Fur", "Pineco Husk", "Dunsparce Scales", "Qwilfish Spines", "Heracross Claw", "Sneasel Claw", "Teddiursa Claw", "Delibird Parcel", "Houndour Fang", "Phanpy Nail", "Stantler Hair", "Larvitar Claw", "Wingull Feather", "Ralts Dust", "Surskit Syrup", "Shroomish Spores", "Slakoth Fur", "Makuhita Sweat", "Azurill Fur", "Sableye Gem", "Meditite Sweat", "Gulpin Mucus", "Numel Lava", "Torkoal Coal", "Spoink Pearl", "Cacnea Needle", "Swablu Fluff", "Zangoose Claw", "Seviper Fang", "Barboach Slime", "Shuppet Scrap", "Tropius Leaf", "Snorunt Fur", "Luvdisc Scales", "Bagon Scales", "Starly Feather", "Kricketot Shell", "Shinx Fang", "Combee Honey", "Pachirisu Fur", "Buizel Fur", "Shellos Mucus", "Drifloon Gas", "Stunky Fur", "Bronzor Fragment", "Bonsly Tears", "Happiny Dust", "Spiritomb Fragment", "Gible Scales", "Riolu Fur", "Hippopotas Sand", "Croagunk Poison", "Finneon Scales", "Snover Berries", "Rotom Sparks", "Petilil Leaf", "Basculin Fang", "Sandile Claw", "Zorua Fur", "Gothita Eyelash", "Deerling Hair", "Foongus Spores", "Alomomola Mucus", "Tynamo Slime", "Axew Scales", "Cubchoo Fur", "Cryogonal Ice", "Pawniard Blade", "Rufflet Feather", "Deino Scales", "Larvesta Fuzz", "Fletchling Feather", "Scatterbug Powder", "Litleo Tuft", "Flabébé Pollen", "Skiddo Leaf", "Skrelp Kelp", "Clauncher Claw", "Hawlucha Down", "Dedenne Fur", "Goomy Goo", "Klefki Key", "Bergmite Ice", "Noibat Fur", "Yungoos Fur", "Crabrawler Shell", "Oricorio Feather", "Rockruff Rock", "Mareanie Spike", "Mudbray Mud", "Fomantis Leaf", "Salandit Gas", "Bounsweet Sweat", "Oranguru Fur", "Passimian Fur", "Sandygast Sand", "Komala Claw", "Mimikyu Scrap", "Bruxish Tooth", "Chewtle Claw", "Skwovet Fur", "Arrokuda Scales", "Rookidee Feather", "Toxel Sparks", "Falinks Sweat", "Cufant Tarnish", "Rolycoly Coal", "Silicobra Sand", "Indeedee Fur", "Pincurchin Spines", "Snom Thread", "Impidimp Hair", "Applin Juice", "Sinistea Chip", "Hatenna Dust", "Stonjourner Stone", "Eiscue Down", "Dreepy Powder", "Lechonk Hair", "Tarountula Thread", "Nymble Claw", "Rellor Mud", "Greavard Wax", "Flittle Down", "Wiglett Sand", "Dondozo Whisker", "Veluza Fillet", "Finizen Mucus", "Smoliv Oil", "Capsakid Seed", "Tadbulb Mucus", "Varoom Fume", "Orthworm Tarnish", "Tandemaus Fur", "Cetoddle Grease", "Frigibax Scales", "Tatsugiri Scales", "Cyclizar Scales", "Pawmi Fur", "Wattrel Feather", "Bombirdier Feather", "Squawkabilly Feather", "Flamigo Down", "Klawf Claw", "Nacli Salt", "Glimmet Crystal", "Shroodle Ink", "Fidough Fur", "Maschiff Fang", "Bramblin Twig", "Gimmighoul Coin", "Tinkatink Hair", "Charcadet Soot", "Toedscool Flaps", "Wooper Slime", "TM100", "TM101", "TM102", "TM103", "TM104", "TM105", "TM106", "TM107", "TM108", "TM109", "TM110", "TM111", "TM112", "TM113", "TM114", "TM115", "TM116", "TM117", "TM118", "TM119", "TM120", "TM121", "TM122", "TM123", "TM124", "TM125", "TM126", "TM127", "TM128", "TM129", "TM130", "TM131", "TM132", "TM133", "TM134", "TM135", "TM136", "TM137", "TM138", "TM139", "TM140", "TM141", "TM142", "TM143", "TM144", "TM145", "TM146", "TM147", "TM148", "TM149", "TM150", "TM151", "TM152", "TM153", "TM154", "TM155", "TM156", "TM157", "TM158", "TM159", "TM160", "TM161", "TM162", "TM163", "TM164", "TM165", "TM166", "TM167", "TM168", "TM169", "TM170", "TM171", "TM172", "TM173", "TM174", "TM175", "TM176", "TM177", "TM178", "TM179", "TM180", "TM181", "TM182", "TM183", "TM184", "TM185", "TM186", "TM187", "TM188", "TM189", "TM190", "TM191", "TM192", "TM193", "TM194", "TM195", "TM196", "TM197", "TM198", "TM199", "TM200", "TM201", "TM202", "TM203", "TM204", "TM205", "TM206", "TM207", "TM208", "TM209", "TM210", "TM211", "TM212", "TM213", "TM214", "TM215", "TM216", "TM217", "TM218", "TM219", "TM220", "TM221", "TM222", "TM223", "TM224", "TM225", "TM226", "TM227", "TM228", "TM229", "Picnic Set", "Academy Bottle", "Academy Bottle", "Polka-Dot Bottle", "Striped Bottle", "Diamond Bottle", "Academy Cup", "Academy Cup", "Striped Cup", "Polka-Dot Cup", "Flower Pattern Cup", "Academy Tablecloth", "Academy Tablecloth", "Whimsical Tablecloth", "Leafy Tablecloth", "Spooky Tablecloth", "Academy Ball", "Academy Ball", "Marill Ball", "Yarn Ball", "Cyber Ball", "Gold Pick", "Silver Pick", "Red-Flag Pick", "Blue-Flag Pick", "Pika-Pika Pick", "Winking Pika Pick", "Vee-Vee Pick", "Smiling Vee Pick", "Blue Poké Ball Pick", "Auspicious Armor", "Leader’s Crest", "Pink Bottle", "Blue Bottle", "Yellow Bottle", "Steel Bottle (R)", "Steel Bottle (Y)", "Steel Bottle (B)", "Silver Bottle", "Barred Cup", "Diamond Pattern Cup", "Fire Pattern Cup", "Pink Cup", "Blue Cup", "Yellow Cup", "Pikachu Cup", "Eevee Cup", "Slowpoke Cup", "Silver Cup", "Exercise Ball", "Plaid Tablecloth (Y)", "Plaid Tablecloth (B)", "Plaid Tablecloth (R)", "B&W Grass Tablecloth", "Battle Tablecloth", "Monstrous Tablecloth", "Striped Tablecloth", "Diamond Tablecloth", "Polka-Dot Tablecloth", "Lilac Tablecloth", "Mint Tablecloth", "Peach Tablecloth", "Yellow Tablecloth", "Blue Tablecloth", "Pink Tablecloth", "Gold Bottle", "Bronze Bottle", "Gold Cup", "Bronze Cup", "Green Poké Ball Pick", "Red Poké Ball Pick", "Party Sparkler Pick", "Heroic Sword Pick", "Magical Star Pick", "Magical Heart Pick", "Parasol Pick", "Blue-Sky Flower Pick", "Sunset Flower Pick", "Sunrise Flower Pick", "Blue Dish", "Green Dish", "Orange Dish", "Red Dish", "White Dish", "Yellow Dish", "Fairy Feather", "Syrupy Apple", "Unremarkable Teacup", "Masterpiece Teacup", "Teal Mask", "Cornerstone Mask", "Wellspring Mask", "Hearthflame Mask", "Teal Style Card", "Crystal Cluster", "Health Mochi", "Muscle Mochi", "Resist Mochi", "Genius Mochi", "Clever Mochi", "Swift Mochi", "Simple Chairs", "Academy Chairs", "Academy Chairs", "Whimsical Chairs", "Leafy Chairs", "Spooky Chairs", "Plaid Chairs (Y)", "Plaid Chairs (B)", "Plaid Chairs (R)", "B&W Grass Chairs", "Battle Chairs", "Monstrous Chairs", "Striped Chairs", "Diamond Chairs", "Polka-Dot Chairs", "Lilac Chairs", "Mint Chairs", "Peach Chairs", "Yellow Chairs", "Blue Chairs", "Pink Chairs", "Ekans Fang", "Sandshrew Claw", "Cleffa Fur", "Vulpix Fur", "Poliwag Slime", "Bellsprout Vine", "Geodude Fragment", "Koffing Gas", "Munchlax Fang", "Sentret Fur", "Hoothoot Feather", "Spinarak Thread", "Aipom Hair", "Yanma Spike", "Gligar Fang", "Slugma Lava", "Swinub Hair", "Poochyena Fang", "Lotad Leaf", "Seedot Stem", "Nosepass Fragment", "Volbeat Fluid", "Illumise Fluid", "Corphish Shell", "Feebas Scales", "Duskull Fragment", "Chingling Fragment", "Timburr Sweat", "Sewaddle Leaf", "Ducklett Feather", "Litwick Soot", "Mienfoo Claw", "Vullaby Feather", "Carbink Jewel", "Phantump Twig", "Grubbin Thread", "Cutiefly Powder", "Jangmo-o Scales", "Cramorant Down", "Morpeko Snack", "Poltchageist Powder", "Fresh-Start Mochi", "Roto-Stick", "Glimmering Charm" };
        private Models.Config configVals { get; }

        public MainWindowViewModel(INavigationService navService)
        {
            NavigationService = navService;
            NavigationService.NavigateTo<HomeViewModel>();
            CloseCommand = new RelayCommand(o => { CloseWindow(); }, o => true);
            MinimiseCommand = new RelayCommand(o => { MinimiseWindow(); }, o => true);
            DropdownCommand = new RelayCommand(o => { OpenCtxDropdown(); }, o => true);
            GoBackCommand = new RelayCommand(o => { GoBack(); }, o => true);
            SelectComboBoxItemCommand = new RelayCommand(o => { SelectComboBoxItem(o); }, o => true);

            // init the config.json file if one does not exist
            var configLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.json");
            if (!File.Exists(configLocation))
            {
                configVals = new Models.Config();
                var configJson = JsonSerializer.Serialize(configVals, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
                File.WriteAllText(configLocation, configJson);
            } else
            {
                using (var r = new StreamReader(configLocation))
                {
                    var conf = r.ReadToEnd();
                    configVals = JsonSerializer.Deserialize<Models.Config>(conf);
                }
            }
            CheckUpdate();
            SetProperties();
            CheckBins();
        }

        private void SetProperties()
        {
            var pokeDevFile = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/devid_list.json")).Stream;
            var moveDevFile = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/move_list.json")).Stream;
            var itemDevFile = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/item_list.json")).Stream;
            using (var pokeDevReader = new StreamReader(pokeDevFile))
            using (var moveDevReader = new StreamReader(moveDevFile))
            using (var itemDevReader = new StreamReader(itemDevFile))
            {
                var pokeDevJson = pokeDevReader.ReadToEnd();
                var moveDevJson = moveDevReader.ReadToEnd();
                var itemDevJson = itemDevReader.ReadToEnd();

                var PkDevID = JsonSerializer.Deserialize<PokeDevID.DevID>(pokeDevJson);
                var MvDevID = JsonSerializer.Deserialize<MoveDevID.DevID>(moveDevJson);
                var ItmDevID = JsonSerializer.Deserialize<ItemDevID.DevID>(itemDevJson);
                Application.Current.Properties["pkdevid"] = PkDevID;
                Application.Current.Properties["movesWithDevID"] = MvDevID;
                Application.Current.Properties["itemdevid"] = ItmDevID;
            }
            Application.Current.Properties["config"] = configVals;
            Application.Current.Properties["abilities"] = Abilities;
            Application.Current.Properties["moves"] = Moves;
            Application.Current.Properties["species"] = SpeciesNames;
            Application.Current.Properties["items"] = ItemsList;
            Application.Current.Properties["balls"] = new ObservableCollection<string> { "None", "Master Ball", "Ultra Ball", "Great Ball", "Poké Ball", "Safari Ball", "Net Ball", "Dive Ball", "Nest Ball", "Repeat Ball", "Timer Ball", "Luxury Ball", "Premier Ball", "Dusk Ball", "Heal Ball", "Quick Ball", "Fast Ball", "Level Ball", "Lure Ball", "Heavy Ball", "Love Ball", "Friend Ball", "Moon Ball", "Sport Ball", "Dream Ball", "Beast Ball" };
            Application.Current.Properties["teratypes"] = new Dictionary<string, string> { { "Default", "DEFAULT" }, { "Normal", "NORMAL" }, { "Fighting", "KAKUTOU" }, { "Flying", "HIKOU" }, { "Poison", "DOKU" }, { "Ground", "JIMEN" }, { "Rock", "IWA" }, { "Bug", "MUSHI" }, { "Ghost", "GHOST" }, { "Steel", "HAGANE" }, { "Fire", "HONOO" }, { "Water", "MIZU" }, { "Grass", "KUSA" }, { "Electric", "DENKI" }, { "Psychic", "ESPER" }, { "Ice", "KOORI" }, { "Dragon", "DRAGON" }, { "Dark", "AKU" }, { "Fairy", "FAIRY" } };
        }

        private void CheckBins()
        {
            var newTrDataExists = File.Exists(Path.Combine(configVals.outPath, "trdata_array.json"));
            var newPersonalExists = File.Exists(Path.Combine(configVals.outPath, "personal_array.json"));
            var newPDataExists = File.Exists(Path.Combine(configVals.outPath, "pokedata_array.json"));
            var update = new List<string> { };

            if (newTrDataExists)
            {
                update.Add("trdata");
            }

            if (newPersonalExists)
            {
                update.Add("personal");
            }

            if (newPDataExists)
            {
                update.Add("pdata");
            }

            if (update.Count >= 1)
            {
                UpdateBins(update);
            }
        }

        private void UpdateBins(List<string> update)
        {
            var trdataOrigFile = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/trdata_array.json")).Stream;
            FileStream trdataNewFile = null;

            if (update.Contains("trdata"))
            {
                File.Copy(Path.Combine(configVals.outPath, "trdata_array.json"), Path.Combine(configVals.outPath, "trdata_array_2.json"));
                trdataNewFile = File.Open(Path.Combine(configVals.outPath, "trdata_array_2.json"), FileMode.Open);
            }

            var personalOrigFile = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/personal_array.json")).Stream;
            FileStream personalNewFile = null;

            if (update.Contains("personal"))
            {
                File.Copy(Path.Combine(configVals.outPath, "personal_array.json"), Path.Combine(configVals.outPath, "personal_array_2.json"));
                personalNewFile = File.Open(Path.Combine(configVals.outPath, "personal_array_2.json"), FileMode.Open);
            }

            var pdataOrigFile = Application.GetResourceStream(new Uri($"pack://application:,,,/Assets/JSON/pokedata_array.json")).Stream;
            FileStream pdataNewFile = null;

            if (update.Contains("pdata"))
            {
                File.Copy(Path.Combine(configVals.outPath, "pokedata_array.json"), Path.Combine(configVals.outPath, "pokedata_array_2.json"));
                pdataNewFile = File.Open(Path.Combine(configVals.outPath, "pokedata_array_2.json"), FileMode.Open);
            }

            using (var personalReader = new StreamReader(personalOrigFile))
            using (var pdataReader = new StreamReader(pdataOrigFile))
            using (var trdataReader = new StreamReader(trdataOrigFile))
            {

                foreach (var x in update)
                {
                    if (x == "trdata" && x == "weednose")
                    {
                        using (var trdataNewReader = new StreamReader(trdataNewFile))
                        {
                            var trdataOrigJson = trdataReader.ReadToEnd();
                            var trdataNewJson = trdataNewReader.ReadToEnd();

                            var trainerOrig = System.Text.Json.JsonSerializer.Deserialize<Trainer.TrainerArray>(trdataOrigJson);
                            var trainerNew = System.Text.Json.JsonSerializer.Deserialize<Trainer.TrainerArray>(trdataNewJson);
                            for (var i = 0; i < trainerOrig.values.Count; i++)
                            {
                                if (trainerNew.values[i] == null)
                                {
                                    trainerNew.values[i] = trainerOrig.values[i];
                                }
                            }
                            var path = Path.Combine(configVals.outPath, "trdata_array.json");

                            var json = JsonSerializer.Serialize(trainerNew, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

                            File.WriteAllText(path, json);
                        }
                        File.Delete(Path.Combine(configVals.outPath, "trdata_array_2.json"));
                    }
                    else if (x == "personal")
                    {
                        using (var personalNewReader = new StreamReader(personalNewFile))
                        {
                            var personalOrigJson = personalReader.ReadToEnd();
                            var personalNewJson = personalNewReader.ReadToEnd();

                            var personalOrig = System.Text.Json.JsonSerializer.Deserialize<Personal.PersonalArray>(personalOrigJson);
                            var personalNew = System.Text.Json.JsonSerializer.Deserialize<Personal.PersonalArray>(personalNewJson);

                            for (var i = 0; i < personalOrig.entry.Count; i++)
                            {
                                if (i < personalNew.entry.Count)
                                {
                                    PropertyInfo[] properties = typeof(Personal.Entry).GetProperties();

                                    foreach (var property in properties)
                                    {
                                        object targetValue = property.GetValue(personalNew.entry[i]);
                                        object sourceValue = property.GetValue(personalOrig.entry[i]);

                                        bool isTargetValueDefault = targetValue == null || (property.PropertyType.IsValueType && targetValue.Equals(Activator.CreateInstance(property.PropertyType)));


                                        if (isTargetValueDefault || property.ToString() == "kitakami_dex" || property.ToString() == "blueberry_dex")
                                        {
                                            property.SetValue(personalNew.entry[i], sourceValue);
                                        }
                                    }
                                }
                                else if (i >= personalNew.entry.Count)
                                {
                                    // Add a new item to personalNew if the index doesn't exist in personalNew
                                    personalNew.entry.Add(personalOrig.entry[i]);
                                }
                            }
                            var path = Path.Combine(configVals.outPath, "personal_array.json");

                            var json = System.Text.Json.JsonSerializer.Serialize(personalNew, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

                            File.WriteAllText(path, json);
                        }
                        File.Delete(Path.Combine(configVals.outPath, "personal_array_2.json"));
                    }
                    else if (x == "pdata")
                    {
                        using (var pdataNewReader = new StreamReader(pdataNewFile))
                        {
                            var pdataOrigJson = pdataReader.ReadToEnd();
                            var pdataNewJson = pdataNewReader.ReadToEnd();

                            var pdataOrig = System.Text.Json.JsonSerializer.Deserialize<PokeData.DataArray>(pdataOrigJson);
                            var pdataNew = System.Text.Json.JsonSerializer.Deserialize<PokeData.DataArray>(pdataNewJson);

                            for (var i = 0; i < pdataOrig.values.Count; i++)
                            {
                                if (pdataNew.values[i] == null)
                                {
                                    pdataNew.values[i] = pdataOrig.values[i];
                                }
                            }
                            var path = Path.Combine(configVals.outPath, "pokedata_array.json");

                            var json = System.Text.Json.JsonSerializer.Serialize(pdataNew, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

                            File.WriteAllText(path, json);
                        }
                        File.Delete(Path.Combine(configVals.outPath, "pokedata_array_2.json"));
                    }
                }
            }
        }

        private void CloseWindow()
        {
            Application.Current.Shutdown();
        }

        private void MinimiseWindow()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void OpenCtxDropdown()
        {
            IsDropdownOpen = !IsDropdownOpen;
        }

        private void GoBack()
        {
            var current = NavigationService.CurrentView;
            if (current.GetType() == typeof(SelectorViewModel))
            {
                var selector = (SelectorViewModel)current;
                selector.Exit();
                NavigationService.NavigateTo<HomeViewModel>();
            }
            if (current.GetType() == typeof(PokeEditorViewModel))
            {
                var editor = (PokeEditorViewModel)current;
                editor.Exit();
            }
            if (current.GetType() == typeof(MoveViewModel))
            {
                var editor = (MoveViewModel)current;
                editor.Exit();
            }
            if (current.GetType() == typeof(TrainerViewModel))
            {
                var editor = (TrainerViewModel)current;
                editor.Exit();
            }
        }

        private void SelectComboBoxItem(object ComboBoxItem)
        {
            var current = NavigationService.CurrentView;
            if (ComboBoxItem is string selectedComboBoxItem)
            {
                switch (selectedComboBoxItem)
                {
                    case "Edit Config":
                        Window config = new Views.Config();
                        config.Show();
                        break;

                    case "Save":
                        if (current.GetType() == typeof(PokeEditorViewModel))
                        {
                            var editor = (PokeEditorViewModel)current;
                            editor.Save();
                        }
                        if (current.GetType() == typeof(TrainerViewModel))
                        {
                            var editor = (TrainerViewModel)current;
                            editor.Save();
                        }
                        break;

                    case "Reset":
                        if (current.GetType() == typeof(PokeEditorViewModel))
                        {
                            var editor = (PokeEditorViewModel)current;
                            editor.Reset();
                        }
                        if (current.GetType() == typeof(TrainerViewModel))
                        {
                            var editor = (TrainerViewModel)current;
                            editor.Reset();
                        }
                        break;

                    case "Minimise":
                        Application.Current.MainWindow.WindowState = WindowState.Minimized;
                        break;

                    case "Close":
                        Application.Current.Shutdown();
                        break;
                }
                IsDropdownOpen = false;
            }
        }

        private async void CheckUpdate()
        {
            var currentVersion = "2.0.4";

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "http://developer.github.com/v3/#user-agent-required");
                    var result = await client.GetAsync("https://api.github.com/repos/svfeplvce/ProjectSky/releases/latest");
                    var response = await result.Content.ReadAsStringAsync();
                    var content = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
                    var newVersion = content["name"].ToString();
                    bool curIsNew = currentVersion == newVersion;

                    if (!curIsNew && !configVals.autoUpdate)
                    {
                        var box = MessageBox.Show($"New update found (version {newVersion}). Update?", "Update Found", MessageBoxButton.YesNo);
                        if (box == MessageBoxResult.Yes)
                        {
                            Process.Start("Updater.exe");
                            Application.Current.MainWindow.Close();
                        }
                    } else if (!curIsNew && configVals.autoUpdate)
                    {
                        Process.Start("Updater.exe");
                        Application.Current.MainWindow.Close();
                    }
                }
            }
            catch
            {
                return;
            }
        }
    }
}
