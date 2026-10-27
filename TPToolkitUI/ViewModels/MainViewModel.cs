using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.Tools;

namespace TPToolkitUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public AppSettings Settings { get; private set; } = new();

        public bool HasTPGameDirectory { get => !string.IsNullOrEmpty(Settings.TPGameDirectory); }

        public void LoadSettings()
        {
            Settings = Settings.Load();
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
