namespace Sky.SubForms
{
    partial class MoveEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveEditor));
            this.topPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.moveBox = new Sky.Core.FlatComboBox();
            this.siticonePanel1 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
            this.wazaFlags = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.siticonePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.topPanel.Controls.Add(this.pictureBox1);
            this.topPanel.Controls.Add(this.minimizeButton);
            this.topPanel.Controls.Add(this.exitButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(805, 30);
            this.topPanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 24);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // minimizeButton
            // 
            this.minimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minimizeButton.ForeColor = System.Drawing.SystemColors.Control;
            this.minimizeButton.Location = new System.Drawing.Point(745, 0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(30, 30);
            this.minimizeButton.TabIndex = 1;
            this.minimizeButton.Text = "_";
            this.minimizeButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("dripicons-v2", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exitButton.ForeColor = System.Drawing.SystemColors.Control;
            this.exitButton.Location = new System.Drawing.Point(775, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(30, 30);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "9";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // moveBox
            // 
            this.moveBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.moveBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.moveBox.ButtonColor = System.Drawing.Color.DarkGray;
            this.moveBox.ForeColor = System.Drawing.SystemColors.Control;
            this.moveBox.FormattingEnabled = true;
            this.moveBox.Items.AddRange(new object[] {
            "None",
            "Pound",
            "Mega Punch",
            "Pay Day",
            "Fire Punch",
            "Ice Punch",
            "Thunder Punch",
            "Scratch",
            "Vise Grip",
            "Guillotine",
            "Swords Dance",
            "Cut",
            "Gust",
            "Wing Attack",
            "Whirlwind",
            "Fly",
            "Bind",
            "Slam",
            "Vine Whip",
            "Stomp",
            "Double Kick",
            "Mega Kick",
            "Sand Attack",
            "Headbutt",
            "Horn Attack",
            "Fury Attack",
            "Horn Drill",
            "Tackle",
            "Body Slam",
            "Wrap",
            "Take Down",
            "Thrash",
            "Double-Edge",
            "Tail Whip",
            "Poison Sting",
            "Pin Missile",
            "Leer",
            "Bite",
            "Growl",
            "Roar",
            "Sing",
            "Supersonic",
            "Disable",
            "Acid",
            "Ember",
            "Flamethrower",
            "Mist",
            "Water Gun",
            "Hydro Pump",
            "Surf",
            "Ice Beam",
            "Blizzard",
            "Psybeam",
            "Bubble Beam",
            "Aurora Beam",
            "Hyper Beam",
            "Peck",
            "Drill Peck",
            "Low Kick",
            "Counter",
            "Seismic Toss",
            "Strength",
            "Absorb",
            "Mega Drain",
            "Leech Seed",
            "Growth",
            "Razor Leaf",
            "Solar Beam",
            "Poison Powder",
            "Stun Spore",
            "Sleep Powder",
            "Petal Dance",
            "String Shot",
            "Fire Spin",
            "Thunder Shock",
            "Thunderbolt",
            "Thunder Wave",
            "Thunder",
            "Rock Throw",
            "Earthquake",
            "Fissure",
            "Dig",
            "Toxic",
            "Confusion",
            "Psychic",
            "Hypnosis",
            "Agility",
            "Quick Attack",
            "Teleport",
            "Night Shade",
            "Mimic",
            "Screech",
            "Double Team",
            "Recover",
            "Harden",
            "Minimize",
            "Smokescreen",
            "Confuse Ray",
            "Withdraw",
            "Defense Curl",
            "Light Screen",
            "Haze",
            "Reflect",
            "Focus Energy",
            "Metronome",
            "Self-Destruct",
            "Lick",
            "Smog",
            "Sludge",
            "Fire Blast",
            "Waterfall",
            "Swift",
            "Amnesia",
            "Soft-Boiled",
            "High Jump Kick",
            "Glare",
            "Dream Eater",
            "Poison Gas",
            "Leech Life",
            "Sky Attack",
            "Transform",
            "Spore",
            "Splash",
            "Acid Armor",
            "Crabhammer",
            "Explosion",
            "Fury Swipes",
            "Rest",
            "Rock Slide",
            "Tri Attack",
            "Super Fang",
            "Slash",
            "Substitute",
            "Struggle",
            "Thief",
            "Flame Wheel",
            "Snore",
            "Curse",
            "Flail",
            "Cotton Spore",
            "Reversal",
            "Spite",
            "Powder Snow",
            "Protect",
            "Mach Punch",
            "Scary Face",
            "Sweet Kiss",
            "Belly Drum",
            "Sludge Bomb",
            "Mud-Slap",
            "Spikes",
            "Zap Cannon",
            "Destiny Bond",
            "Perish Song",
            "Icy Wind",
            "Detect",
            "Bone Rush",
            "Lock-On",
            "Outrage",
            "Sandstorm",
            "Giga Drain",
            "Endure",
            "Charm",
            "Rollout",
            "False Swipe",
            "Swagger",
            "Milk Drink",
            "Spark",
            "Fury Cutter",
            "Steel Wing",
            "Mean Look",
            "Attract",
            "Sleep Talk",
            "Heal Bell",
            "Present",
            "Safeguard",
            "Pain Split",
            "Dynamic Punch",
            "Megahorn",
            "Dragon Breath",
            "Baton Pass",
            "Encore",
            "Rapid Spin",
            "Sweet Scent",
            "Iron Tail",
            "Metal Claw",
            "Morning Sun",
            "Synthesis",
            "Moonlight",
            "Cross Chop",
            "Twister",
            "Rain Dance",
            "Sunny Day",
            "Crunch",
            "Mirror Coat",
            "Psych Up",
            "Extreme Speed",
            "Ancient Power",
            "Shadow Ball",
            "Future Sight",
            "Rock Smash",
            "Whirlpool",
            "Beat Up",
            "Fake Out",
            "Uproar",
            "Stockpile",
            "Spit Up",
            "Swallow",
            "Heat Wave",
            "Torment",
            "Flatter",
            "Will-O-Wisp",
            "Memento",
            "Facade",
            "Focus Punch",
            "Follow Me",
            "Charge",
            "Taunt",
            "Helping Hand",
            "Trick",
            "Role Play",
            "Wish",
            "Ingrain",
            "Superpower",
            "Recycle",
            "Brick Break",
            "Yawn",
            "Knock Off",
            "Endeavor",
            "Eruption",
            "Skill Swap",
            "Imprison",
            "Dive",
            "Arm Thrust",
            "Feather Dance",
            "Teeter Dance",
            "Blaze Kick",
            "Slack Off",
            "Hyper Voice",
            "Poison Fang",
            "Crush Claw",
            "Blast Burn",
            "Hydro Cannon",
            "Meteor Mash",
            "Astonish",
            "Weather Ball",
            "Fake Tears",
            "Air Cutter",
            "Overheat",
            "Rock Tomb",
            "Metal Sound",
            "Tickle",
            "Cosmic Power",
            "Water Spout",
            "Shadow Punch",
            "Extrasensory",
            "Sand Tomb",
            "Sheer Cold",
            "Muddy Water",
            "Bullet Seed",
            "Aerial Ace",
            "Icicle Spear",
            "Iron Defense",
            "Block",
            "Howl",
            "Dragon Claw",
            "Frenzy Plant",
            "Bulk Up",
            "Bounce",
            "Mud Shot",
            "Poison Tail",
            "Covet",
            "Volt Tackle",
            "Magical Leaf",
            "Calm Mind",
            "Leaf Blade",
            "Dragon Dance",
            "Rock Blast",
            "Shock Wave",
            "Water Pulse",
            "Roost",
            "Gravity",
            "Hammer Arm",
            "Gyro Ball",
            "Healing Wish",
            "Brine",
            "Feint",
            "Pluck",
            "Tailwind",
            "Acupressure",
            "Metal Burst",
            "U-turn",
            "Close Combat",
            "Payback",
            "Assurance",
            "Fling",
            "Power Trick",
            "Gastro Acid",
            "Copycat",
            "Power Swap",
            "Guard Swap",
            "Last Resort",
            "Worry Seed",
            "Sucker Punch",
            "Toxic Spikes",
            "Aqua Ring",
            "Magnet Rise",
            "Flare Blitz",
            "Force Palm",
            "Aura Sphere",
            "Rock Polish",
            "Poison Jab",
            "Dark Pulse",
            "Night Slash",
            "Aqua Tail",
            "Seed Bomb",
            "Air Slash",
            "X-Scissor",
            "Bug Buzz",
            "Dragon Pulse",
            "Dragon Rush",
            "Power Gem",
            "Drain Punch",
            "Vacuum Wave",
            "Focus Blast",
            "Energy Ball",
            "Brave Bird",
            "Earth Power",
            "Switcheroo",
            "Giga Impact",
            "Nasty Plot",
            "Bullet Punch",
            "Avalanche",
            "Ice Shard",
            "Shadow Claw",
            "Thunder Fang",
            "Ice Fang",
            "Fire Fang",
            "Shadow Sneak",
            "Psycho Cut",
            "Zen Headbutt",
            "Flash Cannon",
            "Defog",
            "Trick Room",
            "Draco Meteor",
            "Discharge",
            "Lava Plume",
            "Leaf Storm",
            "Power Whip",
            "Cross Poison",
            "Gunk Shot",
            "Iron Head",
            "Stone Edge",
            "Stealth Rock",
            "Grass Knot",
            "Judgment",
            "Bug Bite",
            "Charge Beam",
            "Wood Hammer",
            "Aqua Jet",
            "Attack Order",
            "Defend Order",
            "Head Smash",
            "Double Hit",
            "Roar of Time",
            "Spacial Rend",
            "Lunar Dance",
            "Magma Storm",
            "Shadow Force",
            "Hone Claws",
            "Wide Guard",
            "Guard Split",
            "Power Split",
            "Wonder Room",
            "Psyshock",
            "Venoshock",
            "Rage Powder",
            "Magic Room",
            "Smack Down",
            "Sludge Wave",
            "Quiver Dance",
            "Heavy Slam",
            "Electro Ball",
            "Soak",
            "Flame Charge",
            "Coil",
            "Low Sweep",
            "Acid Spray",
            "Foul Play",
            "Simple Beam",
            "Entrainment",
            "After You",
            "Round",
            "Echoed Voice",
            "Clear Smog",
            "Stored Power",
            "Quick Guard",
            "Ally Switch",
            "Scald",
            "Shell Smash",
            "Heal Pulse",
            "Hex",
            "Shift Gear",
            "Circle Throw",
            "Incinerate",
            "Quash",
            "Acrobatics",
            "Reflect Type",
            "Retaliate",
            "Final Gambit",
            "Inferno",
            "Water Pledge",
            "Fire Pledge",
            "Grass Pledge",
            "Volt Switch",
            "Struggle Bug",
            "Bulldoze",
            "Frost Breath",
            "Dragon Tail",
            "Work Up",
            "Electroweb",
            "Wild Charge",
            "Drill Run",
            "Horn Leech",
            "Sacred Sword",
            "Razor Shell",
            "Heat Crash",
            "Cotton Guard",
            "Night Daze",
            "Psystrike",
            "Tail Slap",
            "Hurricane",
            "Relic Song",
            "Fiery Dance",
            "Snarl",
            "Icicle Crash",
            "V-create",
            "Flying Press",
            "Belch",
            "Sticky Web",
            "Fell Stinger",
            "Phantom Force",
            "Noble Roar",
            "Parabolic Charge",
            "Petal Blizzard",
            "Freeze-Dry",
            "Disarming Voice",
            "Parting Shot",
            "Draining Kiss",
            "Grassy Terrain",
            "Misty Terrain",
            "Play Rough",
            "Fairy Wind",
            "Moonblast",
            "Boomburst",
            "Fairy Lock",
            "Play Nice",
            "Confide",
            "Diamond Storm",
            "Steam Eruption",
            "Hyperspace Hole",
            "Water Shuriken",
            "Mystical Fire",
            "Spiky Shield",
            "Aromatic Mist",
            "Eerie Impulse",
            "Magnetic Flux",
            "Happy Hour",
            "Electric Terrain",
            "Dazzling Gleam",
            "Celebrate",
            "Hold Hands",
            "Baby-Doll Eyes",
            "Nuzzle",
            "Hold Back",
            "Infestation",
            "Origin Pulse",
            "Precipice Blades",
            "Dragon Ascent",
            "Hyperspace Fury",
            "Shore Up",
            "First Impression",
            "Baneful Bunker",
            "Spirit Shackle",
            "Darkest Lariat",
            "Ice Hammer",
            "High Horsepower",
            "Strength Sap",
            "Solar Blade",
            "Leafage",
            "Throat Chop",
            "Pollen Puff",
            "Psychic Terrain",
            "Lunge",
            "Fire Lash",
            "Power Trip",
            "Burn Up",
            "Speed Swap",
            "Smart Strike",
            "Revelation Dance",
            "Trop Kick",
            "Instruct",
            "Brutal Swing",
            "Aurora Veil",
            "Fleur Cannon",
            "Psychic Fangs",
            "Stomping Tantrum",
            "Accelerock",
            "Liquidation",
            "Tearful Look",
            "Zing Zap",
            "Dynamax Cannon",
            "Snipe Shot",
            "Jaw Lock",
            "Stuff Cheeks",
            "No Retreat",
            "Tar Shot",
            "Magic Powder",
            "Dragon Darts",
            "Teatime",
            "Court Change",
            "Body Press",
            "Drum Beating",
            "Pyro Ball",
            "Behemoth Blade",
            "Behemoth Bash",
            "Breaking Swipe",
            "Branch Poke",
            "Overdrive",
            "Apple Acid",
            "Grav Apple",
            "Spirit Break",
            "Life Dew",
            "False Surrender",
            "Steel Beam",
            "Expanding Force",
            "Steel Roller",
            "Scale Shot",
            "Meteor Beam",
            "Shell Side Arm",
            "Misty Explosion",
            "Grassy Glide",
            "Rising Voltage",
            "Terrain Pulse",
            "Skitter Smack",
            "Burning Jealousy",
            "Lash Out",
            "Poltergeist",
            "Corrosive Gas",
            "Coaching",
            "Flip Turn",
            "Triple Axel",
            "Dual Wingbeat",
            "Scorching Sands",
            "Jungle Healing",
            "Wicked Blow",
            "Surging Strikes",
            "Thunder Cage",
            "Dragon Energy",
            "Freezing Glare",
            "Fiery Wrath",
            "Thunderous Kick",
            "Glacial Lance",
            "Astral Barrage",
            "Eerie Spell",
            "Dire Claw",
            "Psyshield Bash",
            "Power Shift",
            "Stone Axe",
            "Springtide Storm",
            "Mystical Power",
            "Raging Fury",
            "Wave Crash",
            "Chloroblast",
            "Mountain Gale",
            "Victory Dance",
            "Headlong Rush",
            "Barb Barrage",
            "Esper Wing",
            "Bitter Malice",
            "Shelter",
            "Triple Arrows",
            "Infernal Parade",
            "Ceaseless Edge",
            "Bleakwind Storm",
            "Wildbolt Storm",
            "Sandsear Storm",
            "Lunar Blessing",
            "Tera Blast",
            "Silk Trap",
            "Axe Kick",
            "Last Respects",
            "Lumina Crash",
            "Order Up",
            "Jet Punch",
            "Spicy Extract",
            "Spin Out",
            "Population Bomb",
            "Ice Spinner",
            "Glaive Rush",
            "Revival Blessing",
            "Salt Cure",
            "Triple Dive",
            "Mortal Spin",
            "Doodle",
            "Fillet Away",
            "Kowtow Cleave",
            "Flower Trick",
            "Torch Song",
            "Aqua Step",
            "Raging Bull",
            "Make It Rain",
            "Psyblade",
            "Hydro Steam",
            "Ruination",
            "Collision Course",
            "Electro Drift",
            "Shed Tail",
            "Chilly Reception",
            "Tidy Up",
            "Snowscape",
            "Pounce",
            "Trailblaze",
            "Chilling Water",
            "Hyper Drill",
            "Twin Beam",
            "Rage Fist",
            "Armor Cannon",
            "Bitter Blade",
            "Double Shock",
            "Gigaton Hammer",
            "Comeuppance",
            "Aqua Cutter"});
            this.moveBox.Location = new System.Drawing.Point(654, 36);
            this.moveBox.Name = "moveBox";
            this.moveBox.Size = new System.Drawing.Size(139, 23);
            this.moveBox.TabIndex = 3;
            // 
            // siticonePanel1
            // 
            this.siticonePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.siticonePanel1.BorderRadius = 10;
            this.siticonePanel1.Controls.Add(this.label2);
            this.siticonePanel1.Controls.Add(this.label1);
            this.siticonePanel1.Controls.Add(this.wazaFlags);
            this.siticonePanel1.ForeColor = System.Drawing.SystemColors.Control;
            this.siticonePanel1.Location = new System.Drawing.Point(12, 65);
            this.siticonePanel1.Name = "siticonePanel1";
            this.siticonePanel1.Size = new System.Drawing.Size(781, 428);
            this.siticonePanel1.TabIndex = 4;
            // 
            // wazaFlags
            // 
            this.wazaFlags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.wazaFlags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wazaFlags.ForeColor = System.Drawing.SystemColors.Window;
            this.wazaFlags.FormattingEnabled = true;
            this.wazaFlags.Items.AddRange(new object[] {
            "Is in the game?",
            "Affected by protect?",
            "Can be mirrored?",
            "Makes contact?",
            "Selectable by metronome?",
            "Is a punch move?",
            "No effectiveness?",
            "Can be boosted by charge?",
            "Can\'t be used by sleep talk?",
            "Can make instruct fail?",
            "Affected by snatch?",
            "Is a dance move?",
            "Is a slicing move?",
            "Can hit Bounce/Sky Attack?",
            "Is a wind move?",
            "Is reflectable?",
            "Ignores substitute?",
            "Swaps enemy Pokemon?",
            "No assist?",
            "Can make copy cat fail?",
            "Affected by gravity?",
            "Can fail in sky battle?",
            "Is a bite move?",
            "Is a sound move?"});
            this.wazaFlags.Location = new System.Drawing.Point(10, 39);
            this.wazaFlags.Name = "wazaFlags";
            this.wazaFlags.Size = new System.Drawing.Size(200, 378);
            this.wazaFlags.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Revamped", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(68, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Flags";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Revamped", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(469, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stats";
            // 
            // MoveEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(805, 505);
            this.Controls.Add(this.siticonePanel1);
            this.Controls.Add(this.moveBox);
            this.Controls.Add(this.topPanel);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MoveEditor";
            this.Text = "PROJECT SKY";
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.siticonePanel1.ResumeLayout(false);
            this.siticonePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel topPanel;
        private PictureBox pictureBox1;
        private Button minimizeButton;
        private Button exitButton;
        private Core.FlatComboBox moveBox;
        private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel1;
        private Label label1;
        private CheckedListBox wazaFlags;
        private Label label2;
    }
}