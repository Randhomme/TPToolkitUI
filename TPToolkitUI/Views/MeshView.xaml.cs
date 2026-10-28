using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using WF = System.Windows.Forms;
using TPToolkitUI.Dialogs;
using TPToolkitUI.ViewModels;

namespace TPToolkitUI.Views
{
    /// <summary>
    /// Interaction logic for MeshView.xaml
    /// </summary>
    public partial class MeshView : UserControl
    {
        public MeshView()
        {
            InitializeComponent();
        }

        // X MDB to 1 3D file
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = (MainViewModel)DataContext;
            var owner = Window.GetWindow(this);
            var ofd = new OpenFileDialog()
            {
                Multiselect = true,
                DefaultExt = ".mdb",
                Filter = "Mesh (.mdb)|*.mdb",
                Title = "Select your mesh files",
                InitialDirectory = vm.Settings.LastMDBImportDirectory,
            };
            var sfd = new SaveFileDialog
            {
                Filter = "GL Transmission Format Binary |*.glb|Object file |*.obj",
                Title = "Save the meshes to a 3D file",
                InitialDirectory = vm.Settings.Last3DFileExportDirectory,
            };
            if (ofd.ShowDialog(owner) == true && sfd.ShowDialog(owner) == true)
            {
                if (sfd.FilterIndex == 1) // glb
                {
                    var pvm = new ProgressViewModel((p, l) =>
                    {
                        vm.XMDBTo1GLB(ofd.FileNames, sfd.FileName, vm.ExportLods, p, l);
                    });
                    new ProgressDialog(owner, pvm).Start(true, true);
                }
                else // obj
                {
                    var pvm = new ProgressViewModel((p, l) =>
                    {
                        vm.XMDBTo1OBJ(ofd.FileNames, sfd.FileName, vm.ExportLods, p, l);
                    });
                    new ProgressDialog(owner, pvm).Start(true, true);
                }
            }
        }

        // X MDB to X 3D file
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var vm = (MainViewModel)DataContext;
            var owner = Window.GetWindow(this);
            var ofd = new OpenFileDialog()
            {
                Multiselect = true,
                DefaultExt = ".mdb",
                Filter = "Mesh (.mdb)|*.mdb",
                Title = "Select your mesh files",
                InitialDirectory = vm.Settings.LastMDBImportDirectory,
            };
            var fbd = new WF.FolderBrowserDialog()
            {
                ShowNewFolderButton = false,
                SelectedPath = vm.Settings.Last3DFileExportDirectory,
                Description = "Select a folder to export your 3D files"
            };
            var mfpd = new ModelFormatPickerDialog(owner)
            {
                SelectedFileFormat = vm.Settings.Prefered3DFileFormat,
            };
            if (ofd.ShowDialog(owner) == true && fbd.ShowDialog() == WF.DialogResult.OK && mfpd.ShowDialog() == true)
            {
                switch (mfpd.SelectedFileFormat)
                {
                    case Enums.File3DFormat.glb:
                        var pvm1 = new ProgressViewModel((p, l) =>
                        {
                            vm.XMDBToXGLB(ofd.FileNames, fbd.SelectedPath, vm.ExportLods, p, l);
                        });
                        new ProgressDialog(owner, pvm1).Start(true, true);
                        break;
                    case Enums.File3DFormat.obj:
                        var pvm2 = new ProgressViewModel((p, l) =>
                        {
                            vm.XMDBToXOBJ(ofd.FileNames, fbd.SelectedPath, vm.ExportLods, p, l);
                        });
                        new ProgressDialog(owner, pvm2).Start(true, true);
                        break;
                    default:
                        MessageBox.Show("Invalid 3D file format selected", "3D file format", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
        }

        // X 3D file to X MDB
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var vm = (MainViewModel)DataContext;
            var owner = Window.GetWindow(this);
            var ofd = new OpenFileDialog()
            {
                Multiselect = true,
                Filter = "GL Transmission Format Binary |*.glb|Object file |*.obj",
                Title = "Select your 3D files",
                InitialDirectory = vm.Settings.Last3DFileImportDirectory,
            };
            var fbd = new WF.FolderBrowserDialog()
            {
                Description = "Select the directory to save your mdb files",
                ShowNewFolderButton = false,
                SelectedPath = vm.Settings.LastMDBExportDirectory,
            };
            if (ofd.ShowDialog(owner) == true && fbd.ShowDialog() == WF.DialogResult.OK)
            {
                if (ofd.FilterIndex == 1) // glb
                {
                    var pvm = new ProgressViewModel((p, l) =>
                    {
                        vm.XGLBToXMDB(ofd.FileNames, fbd.SelectedPath, p, l);
                    });
                    new ProgressDialog(owner, pvm).Start(true, true);
                }
                else // obj
                {
                    var pvm = new ProgressViewModel((p, l) =>
                    {
                        vm.XOBJToXMDB(ofd.FileNames, fbd.SelectedPath, p, l);
                    });
                    new ProgressDialog(owner, pvm).Start(true, true);
                }
            }
        }
    }
}
