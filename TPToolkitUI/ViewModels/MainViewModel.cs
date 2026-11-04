using CommunityToolkit.Mvvm.ComponentModel;
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
        public bool HasTPGameDirectory { get => !string.IsNullOrEmpty(Settings.TPGameDirectory); }

        public MainViewModel()
        {
            dialogService = new DialogService();
            MeshViewModel = new(dialogService, Settings);
            MeshSceneViewModel = new(dialogService, Settings);
        }

        public void LoadSettings()
        {
            Settings.Load();
            MeshViewModel.RefreshExportLodsSetting();
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
    }
}
