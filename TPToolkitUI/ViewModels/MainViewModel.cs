using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;

namespace TPToolkitUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public AppSettings Settings { get; private set; } = new();

        public void LoadSettings()
        {
            Settings = Settings.Load();
            if (string.IsNullOrEmpty(Settings.TPGameDirectory))
            {
                MessageBox.Show("You should set your TPGame directory in the app settings.");
            }
        }

        public void SaveSettings()
        {
            Settings.Save();
        }
    }
}
