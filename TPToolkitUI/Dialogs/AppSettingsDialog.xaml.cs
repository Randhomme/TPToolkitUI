using System.Windows;
using TPToolkitUI.ViewModels;

namespace TPToolkitUI.Dialogs
{
    /// <summary>
    /// Interaction logic for AppSettingsDialog.xaml
    /// </summary>
    public partial class AppSettingsDialog : DialogWindow
    {
        public AppSettingsDialog(Window owner, AppSettingsViewModel vm) : base(owner)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
