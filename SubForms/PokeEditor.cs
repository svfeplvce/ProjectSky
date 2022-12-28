using Siticone.Desktop.UI.WinForms;
using Sky.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sky.SubForms
{
    public partial class PokeEditor : Form
    {
        private Species _currentSpecies;
        private Personal.PersonalArray _personal;
        private PokeData.DataArray _pdata;
        private Plib.PlibArray _plib;
        private Dictionary<int, int> _plibItems;
        private PokemonEditor _form;
        private bool isForm;
        private bool isInitialised;

        public Species CurrentSpecies
        {
            get { return _currentSpecies; }
        }

        public PokeEditor(Species currentSpecies, Personal.PersonalArray personal, Plib.PlibArray plib, Dictionary<int, int> plibItems, PokeData.DataArray pdata, PokemonEditor form)
        {
            InitializeComponent();
            _currentSpecies = currentSpecies;
            if (_currentSpecies.Name.Contains("Alolan") || _currentSpecies.Name.Contains("Galarian") || _currentSpecies.Name.Contains("Hisuian") || _currentSpecies.Name.Contains("Mega") || _currentSpecies.Name.Contains("Paldean") || _currentSpecies.Name == "Indeedee") { isForm = true; } else { isForm = false; }
            _personal = personal;
            _pdata = pdata;
            _plib = plib;
            _plibItems = plibItems;
            _form = form;

            FillFields();
        }

        private void FillFields()
        {
            pokemonName.Text = _currentSpecies.Name;
            pokemonName.Location = new Point(((baseStatsPage.Width / 2) - (pokemonName.Width / 2)), pokemonName.Location.Y);
            label4.Text = _currentSpecies.Name;
            label4.Location = new Point(((baseStatsPage.Width / 2) - (label4.Width / 2)), label4.Location.Y);
            label5.Text = _currentSpecies.Name;
            label5.Location = new Point(((baseStatsPage.Width / 2) - (label5.Width / 2)), label5.Location.Y);

            // base stats page

            presentCheck.CheckState = _currentSpecies.EntryInfo.is_present ? CheckState.Checked : CheckState.Unchecked;

            baseHP.Value = _currentSpecies.EntryInfo.base_stats.HP;
            baseATK.Value = _currentSpecies.EntryInfo.base_stats.ATK;
            baseDEF.Value = _currentSpecies.EntryInfo.base_stats.DEF;
            baseSPA.Value = _currentSpecies.EntryInfo.base_stats.SPA;
            baseSPD.Value = _currentSpecies.EntryInfo.base_stats.SPD;
            baseSPE.Value = _currentSpecies.EntryInfo.base_stats.SPE;

            var bst = ((int)baseHP.Value) + ((int)baseATK.Value) + ((int)baseDEF.Value) + ((int)baseSPA.Value) + ((int)baseSPD.Value) + ((int)baseSPE.Value);
            BSTtooltip.SetToolTip(panel3, $"Current BST is: {bst}");

            evHP.Value = _currentSpecies.EntryInfo.ev_yield.HP;
            evATK.Value = _currentSpecies.EntryInfo.ev_yield.ATK;
            evDEF.Value = _currentSpecies.EntryInfo.ev_yield.DEF;
            evSPA.Value = _currentSpecies.EntryInfo.ev_yield.SPA;
            evSPD.Value = _currentSpecies.EntryInfo.ev_yield.SPD;
            evSPE.Value = _currentSpecies.EntryInfo.ev_yield.SPE;

            typeBox1.SelectedIndex = _currentSpecies.EntryInfo.type_1;
            typeBox2.SelectedIndex = _currentSpecies.EntryInfo.type_2;

            abilityBox1.SelectedIndex = _currentSpecies.EntryInfo.ability_1;
            abilityBox2.SelectedIndex = _currentSpecies.EntryInfo.ability_2;
            abilityBox3.SelectedIndex = _currentSpecies.EntryInfo.ability_hidden;

            eggBox1.SelectedIndex = _currentSpecies.EntryInfo.egg_group_1;
            eggBox2.SelectedIndex = _currentSpecies.EntryInfo.egg_group_2;

            if (_pdata.values.Exists(x => x.devid == _currentSpecies.DevID))
            {
                heldItemBox.SelectedIndex = _form.items.IndexOf(_form.items.First(x => x.Item2 == _currentSpecies.PokeDataInfo.bringItem.itemID));
                heldItemRateBox.Value = _currentSpecies.PokeDataInfo.bringItem.bringRate;
            } else
            {
                heldItemBox.Visible = false;
                heldItemRateBox.Visible = false;
                heldLabel.Visible = false;
                percentLabel.Visible = false;
            }

            xpBox.SelectedIndex = _currentSpecies.EntryInfo.xp_growth;

            friendshipBox.Value = _currentSpecies.EntryInfo.base_friendship;

            catchRateBox.Value = _currentSpecies.EntryInfo.catch_rate;

            hatchBox.Value = _currentSpecies.EntryInfo.egg_hatch_steps;

            genderBox.SelectedIndex = _currentSpecies.EntryInfo.gender.group;

            if (genderBox.SelectedIndex > 0)
            {
                genderRatioBox.Visible = false;
                ratioLabel.Visible = false;
            } else
            {
                genderRatioBox.Value = _currentSpecies.EntryInfo.gender.ratio;
            }

            // moveset page



            // evo page



            isInitialised = true;
        }

        private void baseStat_ValueChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var editedValue = sender as SiticoneNumericUpDown;

                if (editedValue.Name == "baseHP")
                {
                    _currentSpecies.EntryInfo.base_stats.HP = ((int)editedValue.Value);
                } else if (editedValue.Name == "baseATK")
                {
                    _currentSpecies.EntryInfo.base_stats.ATK = ((int)editedValue.Value);
                } else if (editedValue.Name == "baseDEF")
                {
                    _currentSpecies.EntryInfo.base_stats.DEF = ((int)editedValue.Value);
                } else if (editedValue.Name == "baseSPA")
                {
                    _currentSpecies.EntryInfo.base_stats.SPA = ((int)editedValue.Value);
                } else if (editedValue.Name == "baseSPD")
                {
                    _currentSpecies.EntryInfo.base_stats.SPD = ((int)editedValue.Value);
                } else if (editedValue.Name == "baseSPE")
                {
                    _currentSpecies.EntryInfo.base_stats.SPE = ((int)editedValue.Value);
                }

                var bst = ((int)baseHP.Value) + ((int)baseATK.Value) + ((int)baseDEF.Value) + ((int)baseSPA.Value) + ((int)baseSPD.Value) + ((int)baseSPE.Value);
                BSTtooltip.SetToolTip(panel3, $"Current BST is: {bst}");
            }
        }

        private void ev_ValueChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var editedValue = sender as SiticoneNumericUpDown;

                if (editedValue.Name == "evHP")
                {
                    _currentSpecies.EntryInfo.ev_yield.HP = ((int)editedValue.Value);
                }
                else if (editedValue.Name == "evATK")
                {
                    _currentSpecies.EntryInfo.ev_yield.ATK = ((int)editedValue.Value);
                }
                else if (editedValue.Name == "evDEF")
                {
                    _currentSpecies.EntryInfo.ev_yield.DEF = ((int)editedValue.Value);
                }
                else if (editedValue.Name == "evSPA")
                {
                    _currentSpecies.EntryInfo.ev_yield.SPA = ((int)editedValue.Value);
                }
                else if (editedValue.Name == "evSPD")
                {
                    _currentSpecies.EntryInfo.ev_yield.SPD = ((int)editedValue.Value);
                }
                else if (editedValue.Name == "evSPE")
                {
                    _currentSpecies.EntryInfo.ev_yield.SPE = ((int)editedValue.Value);
                }
            }
        }

        private void presentCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var check = sender as SiticoneCheckBox;
                if (check.Checked)
                {
                    DialogResult res = MessageBox.Show("Unchecking this box can have unexpected consequences. Are you sure you want to continue?", "!! WARNING !!", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        check.CheckState = CheckState.Unchecked;
                        _currentSpecies.EntryInfo.is_present = false;
                    }
                }
                else
                {
                    DialogResult res = MessageBox.Show("Checking this box can have unexpected consequences. Are you sure you want to continue?", "!! WARNING !!", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        check.CheckState = CheckState.Checked;
                        _currentSpecies.EntryInfo.is_present = true;
                    }
                }
            }
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var typeBox = sender as FlatComboBox;
            }
        }

        private void ability_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var abilityBox = sender as FlatComboBox;
            }
        }

        private void egg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var eggBox = sender as FlatComboBox;
            }
        }

        private void xp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var xpGroupBox = sender as FlatComboBox;
            }
        }

        private void heldItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var heldItemBox = sender as FlatComboBox;
            }
        }

        private void heldItemRatio_ValueChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var ratioBox = sender as SiticoneNumericUpDown;
            }
        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var genderBox = sender as FlatComboBox;
            }
        }

        private void genderRatio_ValueChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var ratioBox = sender as SiticoneNumericUpDown;
            }
        }

        private void miscStats_ValueChanged(object sender, EventArgs e)
        {
            if (isInitialised)
            {
                var miscStatBox = sender as SiticoneNumericUpDown;
            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        // closing event (GOES LAST DUMB BITCH DONT FUCKING PUT ANYTHING HERE YOU FUCK!!!)

        private async void PokeEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // first we set the values in the base arrays

            var newPersonalData = _currentSpecies.EntryInfo;
            var newPokeData = _currentSpecies.PokeDataInfo;

            if (isForm)
            {
                var totalForms = _personal.entry.Where(x => x.species.species == _currentSpecies.EntryInfo.species.species).Count();

                for (var i = 0; i < totalForms; i++)
                {
                    _personal.entry[_currentSpecies.Index + i] = newPersonalData;
                }
            }
            else
            {
                _personal.entry[_currentSpecies.Index] = newPersonalData;
            }

            if (_pdata.values.Exists(x => x.devid == _currentSpecies.DevID))
            {
                _pdata.values[_pdata.values.IndexOf(_pdata.values.First(x => x.devid == _currentSpecies.DevID))] = newPokeData;
            }

            foreach (var x in _plibItems)
            {
                _plib.values.First(y => y.plibID == x.Key).itemID = x.Value;
            }

            _form._personal = _personal;
            _form._plib = _plib;
            _form._pdata = _pdata;

            var personalPath = Path.Combine(MainForm.outDir, "personal_array.json");
            var pdataPath = Path.Combine(MainForm.outDir, "pokedata_array.json");
            var plibPath = Path.Combine(MainForm.outDir, "plib_item_conversion_array.json");

            var personalJson = JsonSerializer.Serialize(_personal, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });
            var pdataJson = JsonSerializer.Serialize(_pdata, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });
            var plibJson = JsonSerializer.Serialize(_plib, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });

            await File.WriteAllTextAsync(personalPath, personalJson);
            await File.WriteAllTextAsync(pdataPath, pdataJson);
            await File.WriteAllTextAsync(plibPath, plibJson);
        }
    }
}
