using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TPToolkitUI.ViewModels
{
    public partial class AppSettingsViewModel : ObservableObject
    {
        private readonly AppSettings settings;
        private readonly string previousTPGameDirectory;

        [ObservableProperty]
        public partial string TPGameDirectory { get; set; }

        public bool HasTPGameDirectoryChanged { get => !string.Equals(TPGameDirectory, previousTPGameDirectory); }

        public AppSettingsViewModel(AppSettings settings)
        {
            this.settings = settings;
            previousTPGameDirectory = TPGameDirectory = settings.TPGameDirectory;
        }

        [RelayCommand]
        private void OnSaveAppSettings()
        {
            settings.TPGameDirectory = TPGameDirectory;
        }
    }
}
