using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WF = System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TPToolkitUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private AppSettings settings = new();

        public void LoadSettings()
        {
            settings = settings.Load();
            if (string.IsNullOrEmpty(settings.TPGameDirectory))
            {
                MessageBox.Show("You should set your TPGame directory in the app settings.");
            }
        }

        [RelayCommand]
        private void OnOpenAppSettings()
        {
            
        }
    }
}
