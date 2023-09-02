using ProjectSky.Core;
using ProjectSky.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace ProjectSky.ViewModels
{
    public class ConfigViewModel
    {

        public ICommand CloseCommand { get; }
        public ICommand MinimiseCommand { get; }
        public ICommand ChangeOutConfCommand { get; }
        public Config configVals { get; }
        public string UpdateConf { get; }

        public List<string> UpdateOptions { get; } = new List<string>() { "Automatically Update", "Don't Automatically Update" };
        Dictionary<string, bool> updateConfToCB = new Dictionary<string, bool>
            {
                { "Automatically Update", true },
                { "Don't Automatically Update", false }
            };

        public ConfigViewModel() {
            CloseCommand = new RelayCommand(o => { CloseWindow(o); }, o => true);
            MinimiseCommand = new RelayCommand(o => { MinimiseWindow(o); }, o => true);
            ChangeOutConfCommand = new RelayCommand(o => { ChangeUpdateConf(o); }, o => true);
        }

        public void UpdateConfChanged(object sender, EventArgs e)
        {
            System.Windows.Controls.ComboBox cb = sender as System.Windows.Controls.ComboBox;
            configVals.autoUpdate = updateConfToCB[cb.SelectedItem.ToString()];
        }

        private void ChangeUpdateConf(object A)
        {
            using (var f = new FolderBrowserDialog())
            {
                var result = f.ShowDialog();
                if (result == DialogResult.OK)
                {
                    configVals.outPath = f.SelectedPath;
                    (A as System.Windows.Controls.TextBox).Text = f.SelectedPath;
                }
            }
        }

        private void CloseWindow(object A)
        {
            if (A is Window window)
            {
                // first, update the json

                var configLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.json");
                var configJson = JsonSerializer.Serialize(configVals, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
                File.WriteAllText(configLocation, configJson);

                // then, close

                window.Close();
            }
        }

        private void MinimiseWindow(object A)
        {
            if (A is Window window)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

    }
}
