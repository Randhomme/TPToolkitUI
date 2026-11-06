using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TPToolkitLib.Tools;
using TPToolkitUI.Services;
using TPToolkitUI.Services.Implementations;

namespace TPToolkitUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;
        public AppSettings Settings { get; private set; } = new();
        public MeshViewModel MeshViewModel { get; }
        public MeshSceneViewModel MeshSceneViewModel { get; }
        public WorldObjectViewModel WorldObjectViewModel { get; }

        public MainViewModel()
        {
            dialogService = new DialogService();
            MeshViewModel = new(dialogService, Settings);
            MeshSceneViewModel = new(dialogService, Settings);
            WorldObjectViewModel = new(dialogService, Settings);
        }

        public void LoadSettings()
        {
            Settings.Load();
            MeshViewModel.RefreshExportLodsSetting();
            if (string.IsNullOrWhiteSpace(Settings.TPGameDirectory))
            {
                dialogService.DisplayWarning("TPGame directory", "You should set the TPGame directory in the app settings first.");
                OnEditAppSettings();
            }
            else
                dialogService.StartAsyncWorkWithProgress(LoadTPGame, true, false);
        }

        public void SaveSettings()
        {
            Settings.Save();
        }

        public void LoadTPGame(IProgress<string> progress, IProgress<string> progressLogs)
        {
            progress.Report("Loading TPGame folder ...");
            try
            {
                TPGameTool.LoadTPGameFolder(Settings.TPGameDirectory);
                progress.Report("TPGame folder loaded successfully !");
            }
            catch (Exception ex)
            {
                progressLogs.Report(ex.Message);
                progress.Report("Fail to load TPGame folder");
            }
        }

        [RelayCommand]
        public void OnEditAppSettings()
        {
            var tpGameDirectoryBefore = Settings.TPGameDirectory;
            if (dialogService.OpenAppSettings(Settings) && !string.Equals(tpGameDirectoryBefore, Settings.TPGameDirectory))
                dialogService.StartAsyncWorkWithProgress(LoadTPGame, true, true);
        }
    }
}
