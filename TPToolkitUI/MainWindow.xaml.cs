using System.Globalization;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TPToolkitUI.Dialogs;
using TPToolkitUI.ViewModels;

namespace TPToolkitUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel vm = new();
        public MainWindow()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            DataContext = vm;
            InitializeComponent();
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Title = $"{Title} v{version.Major}.{version.Minor}.{version.Build}";
        }

        #region Util methods

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

        /// <summary>
        /// Open AppSettingsDialog and start loading TPGame if needed
        /// </summary>
        private void OpenAppSettingsDialog()
        {
            var appSettingsVm = new AppSettingsViewModel(vm.Settings);
            if (new AppSettingsDialog(this, appSettingsVm).ShowDialog() == true && appSettingsVm.HasTPGameDirectoryChanged)
            {
                new ProgressDialog(this, new(vm.LoadTPGame)).Start(true, true);
            }
        }

        #endregion

        #region Menu events

        private void AppSettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenAppSettingsDialog();
        }

        #endregion

        #region Window events

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            vm.LoadSettings();
            if (vm.HasTPGameDirectory)
            {
                new ProgressDialog(this, new(vm.LoadTPGame)).Start(true, false);
            }
            else
            {
                MessageBox.Show("Set the TPGame directory in the app settings first.");
                OpenAppSettingsDialog();
            }
            #if !DEBUG //Don't check for updates in debug mode
                var local = new Version(FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion);
                var latest = await GetLatestGitHubVersionAsync();
                if (latest != null && latest > local)
                {
                    if (MessageBox.Show(
                        $"A new update is available (v{latest}).\n" +
                        "Do you want to check it out ?",
                        "Update available",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Information
                    ) == MessageBoxResult.Yes)
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

        private void Window_Closed(object sender, EventArgs e)
        {
            vm.SaveSettings();
        }

        #endregion
    }
}