using System.Reflection;
using System.Net.Http;
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
using TPToolkitUI.ViewModels;

namespace TPToolkitUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
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

        #endregion

        #region Window events

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            MainViewModel vm = (MainViewModel)DataContext;
            vm.LoadSettings();
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

        #endregion
    }
}