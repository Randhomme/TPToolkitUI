using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using TPToolkitLib.Tools;
using TPToolkitUI.Enums;
using TPToolkitUI.Services;

namespace TPToolkitUI.ViewModels
{
    public partial class MeshViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;
        private readonly AppSettings settings;

        public bool ExportLods
        {
            get => settings.ExportLods;
            set => SetProperty(settings.ExportLods, value, settings, (s, b) => s.ExportLods = b);
        }

        public MeshViewModel(IDialogService dialogService, AppSettings settings)
        {
            this.dialogService = dialogService;
            this.settings = settings;
        }

        public void RefreshExportLodsSetting()
        {
            OnPropertyChanged(nameof(ExportLods));
        }

        [RelayCommand]
        private void OnXMDBTo13DFile()
        {
            var mdbFilePaths = dialogService.BrowseFilesImport("Select your mesh files", "Mesh (.mdb)|*.mdb", ".mdb", settings.LastMDBImportDirectory);
            if (mdbFilePaths.Length > 0)
            {
                var exportFilePath = dialogService.BrowseFileExport("Save the meshes to a 3D file", "GL Transmission Format Binary |*.glb|Object file |*.obj", ".glb", settings.Last3DFileExportDirectory);
                if (!string.IsNullOrWhiteSpace(exportFilePath))
                {
                    settings.LastMDBImportDirectory = Path.GetDirectoryName(mdbFilePaths[0]);
                    settings.Last3DFileExportDirectory = Path.GetDirectoryName(exportFilePath);
                    switch (Path.GetExtension(exportFilePath))
                    {
                        case ".glb":
                            settings.Prefered3DFileFormat = File3DFormat.glb;
                            dialogService.StartAsyncWorkWithProgress((p, l) => XMDBTo1GLB(mdbFilePaths, exportFilePath, ExportLods, p, l), true, true);
                            break;
                        case ".obj":
                            settings.Prefered3DFileFormat = File3DFormat.obj;
                            dialogService.StartAsyncWorkWithProgress((p, l) => XMDBTo1OBJ(mdbFilePaths, exportFilePath, ExportLods, p, l), true, true);
                            break;
                    }
                }
            }
        }

        [RelayCommand]
        private void OnXMDBToX3DFile()
        {
            var mdbFilePaths = dialogService.BrowseFilesImport("Select your mesh files", "Mesh (.mdb)|*.mdb", ".mdb", settings.LastMDBImportDirectory);
            if (mdbFilePaths.Length > 0)
            {
                var exportFilePath = dialogService.BrowseDirectoryExport("Select a folder to export your 3D files", settings.Last3DFileExportDirectory);
                if (!string.IsNullOrWhiteSpace(exportFilePath))
                {
                    settings.LastMDBImportDirectory = Path.GetDirectoryName(mdbFilePaths[0]);
                    settings.Last3DFileExportDirectory = exportFilePath;
                    var fileFormat = dialogService.PromptFile3DFormat(settings.Prefered3DFileFormat);
                    if (fileFormat != null)
                    {
                        settings.Prefered3DFileFormat = fileFormat ?? File3DFormat.glb;
                        switch (fileFormat)
                        {
                            case File3DFormat.glb:
                                dialogService.StartAsyncWorkWithProgress((p, l) => XMDBToXGLB(mdbFilePaths, exportFilePath, ExportLods, p, l), true, true);
                                break;
                            case File3DFormat.obj:
                                dialogService.StartAsyncWorkWithProgress((p, l) => XMDBToXOBJ(mdbFilePaths, exportFilePath, ExportLods, p, l), true, true);
                                break;
                        }
                    }
                }
            }
        }

        [RelayCommand]
        private void OnX3DFileToXMDB()
        {
            var importFilePaths = dialogService.BrowseFilesImport("Select your 3D files", "GL Transmission Format Binary |*.glb|Object file |*.obj", ".glb", settings.Last3DFileImportDirectory);
            if (importFilePaths.Length > 0)
            {
                var exportFilePath = dialogService.BrowseDirectoryExport("Select the directory to save your mdb files", settings.LastMDBExportDirectory);
                if (!string.IsNullOrWhiteSpace(exportFilePath))
                {
                    settings.Last3DFileImportDirectory = Path.GetDirectoryName(importFilePaths[0]);
                    settings.LastMDBExportDirectory = exportFilePath;
                    switch (Path.GetExtension(importFilePaths[0]))
                    {
                        case ".glb":
                            dialogService.StartAsyncWorkWithProgress((p, l) => XGLBToXMDB(importFilePaths, exportFilePath, p, l), true, true);
                            break;
                        case ".obj":
                            dialogService.StartAsyncWorkWithProgress((p, l) => XOBJToXMDB(importFilePaths, exportFilePath, p, l), true, true);
                            break;
                    }
                }
            }
        }

        private void XMDBTo1GLB(string[] mdbFilePaths, string glbFilePath, bool exportLods, IProgress<string> progress, IProgress<string> logs)
        {
            progress.Report("Exporting mdb files into a glb file ...");
            try
            {
                MdbTool.XMdbTo1Glb(mdbFilePaths, glbFilePath, exportLods);
                progress.Report("The mdb files have been successfully exported to glb !");
            }
            catch (Exception ex)
            {
                progress.Report("Fail to export mdb files to glb");
                logs.Report(ex.Message);
            }
        }

        private void XMDBTo1OBJ(string[] mdbFilePaths, string objFilePath, bool exportLods, IProgress<string> progress, IProgress<string> logs)
        {
            progress.Report("Exporting mdb files into an obj file ...");
            try
            {
                MdbTool.XMdbTo1Obj(mdbFilePaths, objFilePath, exportLods);
                progress.Report("The mdb files have been successfully exported to obj !");
            }
            catch (Exception ex)
            {
                progress.Report("Fail to export mdb files to obj");
                logs.Report(ex.Message);
            }
        }

        private void XMDBToXGLB(string[] mdbFilePaths, string glbDirectory, bool exportLods, IProgress<string> progress, IProgress<string> logs)
        {
            progress.Report("Exporting mdb files into glb files ...");
            try
            {
                MdbTool.XMdbToXGlb(mdbFilePaths, glbDirectory, exportLods);
                progress.Report("The mdb files have been successfully exported to glb !");
            }
            catch (Exception ex)
            {
                progress.Report("Fail to export mdb files to glb");
                logs.Report(ex.Message);
            }
        }

        private void XMDBToXOBJ(string[] mdbFilePaths, string objDirectory, bool exportLods, IProgress<string> progress, IProgress<string> logs)
        {
            progress.Report("Exporting mdb files into obj files ...");
            try
            {
                MdbTool.XMdbToXObj(mdbFilePaths, objDirectory, exportLods);
                progress.Report("The mdb files have been successfully exported to obj !");
            }
            catch (Exception ex)
            {
                progress.Report("Fail to export mdb files to obj");
                logs.Report(ex.Message);
            }
        }

        private void XGLBToXMDB(string[] glbFilePaths, string mdbDirectory, IProgress<string> progress, IProgress<string> logs)
        {
            if (glbFilePaths.Length > 0) this.settings.Last3DFileImportDirectory = Path.GetDirectoryName(glbFilePaths[0]);
            this.settings.LastMDBExportDirectory = mdbDirectory;
            progress.Report("Exporting glb files into mdb files ...");
            try
            {
                MdbTool.XGlbToXMdb(glbFilePaths, mdbDirectory);
                progress.Report("The glb files have been successfully exported to mdb !");
            }
            catch (Exception ex)
            {
                progress.Report("Fail to export glb files to mdb");
                logs.Report(ex.Message);
            }
        }

        private void XOBJToXMDB(string[] objFilePaths, string mdbDirectory, IProgress<string> progress, IProgress<string> logs)
        {
            if (objFilePaths.Length > 0) this.settings.Last3DFileImportDirectory = Path.GetDirectoryName(objFilePaths[0]);
            this.settings.LastMDBExportDirectory = mdbDirectory;
            progress.Report("Exporting obj files into mdb files ...");
            try
            {
                MdbTool.XObjToXMdb(objFilePaths, mdbDirectory);
                progress.Report("The obj files have been successfully exported to mdb !");
            }
            catch (Exception ex)
            {
                progress.Report("Fail to export obj files to mdb");
                logs.Report(ex.Message);
            }
        }
    }
}
