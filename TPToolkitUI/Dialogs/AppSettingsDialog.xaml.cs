using System.Windows;
using WF = System.Windows.Forms;
using TPToolkitUI.ViewModels;

namespace TPToolkitUI.Dialogs
{
    /// <summary>
    /// Interaction logic for AppSettingsDialog.xaml
    /// </summary>
    public partial class AppSettingsDialog : DialogWindow
    {
        private readonly AppSettingsViewModel vm;
        public AppSettingsDialog(Window owner, AppSettingsViewModel vm) : base(owner)
        {
            InitializeComponent();
            DataContext = this.vm = vm;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var fbd = new WF.FolderBrowserDialog()
            {
                Description = "Select your TPGame folder",
                ShowNewFolderButton = false,
                SelectedPath = vm.TPGameDirectory
            };
            if (fbd.ShowDialog() == WF.DialogResult.OK)
            {
                vm.TPGameDirectory = fbd.SelectedPath;
            }
        }
    }
}
