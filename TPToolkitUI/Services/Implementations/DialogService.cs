using Microsoft.Win32;
using System.Security.Cryptography;
using System.Windows;
using TPToolkitUI.Dialogs;
using TPToolkitUI.Enums;
using TPToolkitUI.ViewModels;
using TPToolkitUI.ViewModels.MeshScene;
using WF = System.Windows.Forms;

namespace TPToolkitUI.Services.Implementations
{
    public class DialogService : IDialogService
    {
        private readonly Window owner;

        public DialogService()
        {
            this.owner = Application.Current.MainWindow;
        }

        public DialogService(Window owner)
        {
            this.owner = owner;
        }

        public void StartAsyncWorkWithProgress(Action<IProgress<string>, IProgress<string>> action, bool autoClose, bool notifyOnFinish)
        {
            var pvm = new ProgressViewModel(action);
            new ProgressDialog(owner, pvm).Start(autoClose, notifyOnFinish);
        }

        public string PromptMsbElementName(params IEnumerable<IMsbNamedElement>[] existingElementsCollection)
        {
            var vm = new MsbElementNamePickerViewModel(existingElementsCollection);
            var dialog = new MsbElementNamePicker(owner) { DataContext = vm };
            if (dialog.ShowDialog() == true)
                return vm.MsbElementName;
            else
                return string.Empty;
        }

        public string BrowseFileImport(string title, string filter, string defaultExt, string initialDirectory)
        {
            var ofd = new OpenFileDialog()
            {
                Multiselect = false,
                DefaultExt = defaultExt,
                Filter = filter,
                Title = title,
                InitialDirectory = initialDirectory,
            };
            if (ofd.ShowDialog() == true)
                return ofd.FileName;
            else
                return string.Empty;
        }

        public string[] BrowseFilesImport(string title, string filter, string defaultExt, string initialDirectory)
        {
            var ofd = new OpenFileDialog()
            {
                Multiselect = true,
                DefaultExt = defaultExt,
                Filter = filter,
                Title = title,
                InitialDirectory = initialDirectory,
            };
            ofd.ShowDialog();
            return ofd.FileNames;
        }

        public string BrowseFileExport(string title, string filter, string defaultExt, string initialDirectory)
        {
            var sfd = new SaveFileDialog
            {
                DefaultExt = defaultExt,
                Filter = filter,
                Title = title,
                InitialDirectory = initialDirectory,
            };
            if (sfd.ShowDialog() == true)
                return sfd.FileName;
            else
                return string.Empty;
        }

        public string BrowseDirectoryExport(string title, string initialDirectory)
        {
            var fbd = new WF.FolderBrowserDialog()
            {
                ShowNewFolderButton = true,
                SelectedPath = initialDirectory,
                Description = title,
            };
            if (fbd.ShowDialog() == WF.DialogResult.OK)
                return fbd.SelectedPath;
            else
                return string.Empty;
        }

        public File3DFormat? PromptFile3DFormat(File3DFormat defaultFormat)
        {
            var mfpd = new ModelFormatPickerDialog(owner)
            {
                SelectedFileFormat = defaultFormat,
            };
            if (mfpd.ShowDialog() == true)
                return mfpd.SelectedFileFormat;
            else
                return null;
        }

        public bool OpenAppSettings(AppSettings settings)
        {
            return new AppSettingsDialog(owner, new(settings)).ShowDialog() == true;
        }

        public void DisplayWarning(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
