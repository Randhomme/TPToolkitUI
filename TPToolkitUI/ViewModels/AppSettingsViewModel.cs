using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF = System.Windows.Forms;

namespace TPToolkitUI.ViewModels
{
    public partial class AppSettingsViewModel : ObservableObject
    {
        private readonly AppSettings settings;

        [ObservableProperty]
        public partial string TPGameDirectory { get; set; }

        public AppSettingsViewModel(AppSettings settings)
        {
            this.settings = settings;
            TPGameDirectory = settings.TPGameDirectory;
        }

        [RelayCommand]
        private void OnSaveAppSettings()
        {
            settings.TPGameDirectory = TPGameDirectory;
        }
    }
}
