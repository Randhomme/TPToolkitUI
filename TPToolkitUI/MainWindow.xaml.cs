using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Reflection;
using System.Windows;
using TPToolkitUI.ViewModels;

namespace TPToolkitUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel vm;
        public MainWindow()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            InitializeComponent();
            vm = (MainViewModel)DataContext;
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Title = $"{Title} v{version.Major}.{version.Minor}.{version.Build}";
        }

        #region Util methods

        

        #endregion

        #region Window events

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            vm.LoadSettings();
            vm.DisplayNewUpdateAsync();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            vm.SaveSettings();
        }

        #endregion
    }
}