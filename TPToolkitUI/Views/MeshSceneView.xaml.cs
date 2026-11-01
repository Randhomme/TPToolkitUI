using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace TPToolkitUI.Views
{
    /// <summary>
    /// Interaction logic for MeshSceneView.xaml
    /// </summary>
    public partial class MeshSceneView : UserControl
    {
        public MeshSceneView()
        {
            InitializeComponent();
        }

        // Import mesh scene
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = (MeshSceneViewModel)DataContext;
            var owner = Window.GetWindow(this);
            var ofd = new OpenFileDialog()
            {
                Title = "Select your mesh scene file",
                Multiselect = false,
                Filter = "Mesh scene (.msb)|*.msb",
                InitialDirectory = vm.Settings.LastMSBImportDirectory,
            };
            if (ofd.ShowDialog(owner) == true)
            {
                var pvm = new ProgressViewModel((p, l) =>
                {
                    vm.ImportMeshScene(ofd.FileNames, p, l);
                });
                new ProgressDialog(owner, pvm).Start(true, true);
                vm.UpdateCollections();
            }
        }

        // Export mesh scene
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var vm = (MeshSceneViewModel)DataContext;
            var owner = Window.GetWindow(this);
            var ofd = new SaveFileDialog()
            {
                Title = "Save your mesh scene file",
                Filter = "Mesh scene (.msb)|*.msb",
                InitialDirectory = vm.Settings.LastMSBExportDirectory,
            };
            if (ofd.ShowDialog(owner) == true)
            {
                var pvm = new ProgressViewModel((p, l) =>
                {
                    vm.ExportMeshScene(ofd.FileName, p, l);
                });
                new ProgressDialog(owner, pvm).Start(true, true);
                vm.UpdateCollections();
            }
        }

        // Clear mesh scene
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var vm = (MeshSceneViewModel)DataContext;
            if (MessageBox.Show("This will clear everything in the current mesh scene.\nDo you want to continue ?", "Clear mesh scene ?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                vm.ClearMeshScene();
            }
        }
    }
}
