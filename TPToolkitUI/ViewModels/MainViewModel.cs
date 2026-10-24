using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WF = System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TPToolkitUI.Services;
using TPToolkitUI.Services.Implementations;

namespace TPToolkitUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;
        private AppSettings settings = new();

        public MainViewModel()
        {
            dialogService = new DialogService(Application.Current.MainWindow);
        }

        public void LoadSettings()
        {
            settings = settings.Load();
            if (string.IsNullOrEmpty(settings.TPGameDirectory))
            {
                MessageBox.Show("You should set your TPGame directory in the app settings.");
            }
        }

        public void SaveSettings()
        {
            settings.Save();
        }

        [RelayCommand]
        private void OnOpenAppSettings()
        {
            dialogService.ShowSettings(settings);
        }
    }
}
