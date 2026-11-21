using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
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

        public async void DisplayNewUpdateAsync()
        {
            #if !DEBUG //Don't check for updates in debug mode
                var local = new Version(FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion);
                var latest = await GetLatestGitHubVersionAsync();
                if (latest != null && latest > local)
                {
                    if (dialogService.DisplayInformationWithConfirm("Update available", $"A new update is available (v{latest}).\nDo you want to check it out ?"))
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = "https://github.com/Randhomme/TPToolkitUI/releases/latest",
                            UseShellExecute = true
                        });
                    }
                }
            #endif
        }

        /// <summary>
        /// Check for a new release
        /// </summary>
        /// <returns></returns>
        private async Task<Version?> GetLatestGitHubVersionAsync()
        {
            try
            {
                var url = "https://github.com/Randhomme/TPToolkitUI/releases/latest";

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "request");

                var response = await client.GetAsync(url);
                var finalUrl = response.RequestMessage.RequestUri.ToString();
                var tag = finalUrl.Split('/').Last().TrimStart('v');
                return Version.TryParse(tag, out var version) ? version : null;
            }
            catch { return null; }
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
            {
                dialogService.StartAsyncWorkWithProgress(LoadTPGame, true, false);
                AppSettings.RefreshCollections();
            }
        }

        public void SaveSettings()
        {
            Settings.Save();
        }

        [RelayCommand]
        private void OnEditAppSettings()
        {
            var tpGameDirectoryBefore = Settings.TPGameDirectory;
            if (dialogService.OpenAppSettings(Settings) && !string.Equals(tpGameDirectoryBefore, Settings.TPGameDirectory))
            {
                dialogService.StartAsyncWorkWithProgress(ReloadTPGame, true, true);
                AppSettings.RefreshCollections();
            }
        }

        [RelayCommand]
        private void OnReloadTPGame()
        {
            dialogService.StartAsyncWorkWithProgress(ReloadTPGame, true, true);
            AppSettings.RefreshCollections();
        }

        private void LoadTPGame(IProgress<string> progress, IProgress<string> progressLogs)
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

        private void ReloadTPGame(IProgress<string> progress, IProgress<string> progressLogs)
        {
            progress.Report("Reloading TPGame folder ...");
            try
            {
                TPGameTool.ReloadTPGameFolder(Settings.TPGameDirectory);
                progress.Report("TPGame folder reloaded successfully !");
            }
            catch (Exception ex)
            {
                progressLogs.Report(ex.Message);
                progress.Report("Fail to reload TPGame folder");
            }
        }
    }
}
