using CommunityToolkit.Mvvm.ComponentModel;
using System.IO;
using TPToolkitLib.Tools;

namespace TPToolkitUI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public AppSettings Settings { get; private set; } = new();

        public bool HasTPGameDirectory { get => !string.IsNullOrEmpty(Settings.TPGameDirectory); }

        public bool ExportLods
        {
            get => Settings.ExportLods;
            set => SetProperty(Settings.ExportLods, value, (b) => Settings.ExportLods = b);
        }

        public void LoadSettings()
        {
            Settings = Settings.Load();
            OnPropertyChanged(nameof(ExportLods));
        }

        public void SaveSettings()
        {
            Settings.Save();
        }

        public void LoadTPGame(IProgress<string> progress, IProgress<string> progressLogs)
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

        public void XMDBTo1GLB(string[] mdbFilePaths, string glbFilePath, bool exportLods, IProgress<string> progress, IProgress<string> logs)
        {
            if (mdbFilePaths.Length > 0) Settings.LastMDBImportDirectory = Path.GetDirectoryName(mdbFilePaths[0]);
            Settings.Last3DFileExportDirectory = Path.GetDirectoryName(glbFilePath);
            Settings.Prefered3DFileFormat = Enums.File3DFormat.glb;
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

        public void XMDBToXGLB(string[] mdbFilePaths, string glbDirectory, bool exportLods, IProgress<string> progress, IProgress<string> logs)
        {
            if (mdbFilePaths.Length > 0) Settings.LastMDBImportDirectory = Path.GetDirectoryName(mdbFilePaths[0]);
            Settings.Last3DFileExportDirectory = glbDirectory;
            Settings.Prefered3DFileFormat = Enums.File3DFormat.glb;
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

        public void XMDBTo1OBJ(string[] mdbFilePaths, string objFilePath, bool exportLods, IProgress<string> progress, IProgress<string> logs)
        {
            if (mdbFilePaths.Length > 0) Settings.LastMDBImportDirectory = Path.GetDirectoryName(mdbFilePaths[0]);
            Settings.Last3DFileExportDirectory = Path.GetDirectoryName(objFilePath);
            Settings.Prefered3DFileFormat = Enums.File3DFormat.obj;
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

        public void XMDBToXOBJ(string[] mdbFilePaths, string objDirectory, bool exportLods, IProgress<string> progress, IProgress<string> logs)
        {
            if (mdbFilePaths.Length > 0) Settings.LastMDBImportDirectory = Path.GetDirectoryName(mdbFilePaths[0]);
            Settings.Last3DFileExportDirectory = objDirectory;
            Settings.Prefered3DFileFormat = Enums.File3DFormat.obj;
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

        public void XGLBToXMDB(string[] glbFilePaths, string mdbDirectory, IProgress<string> progress, IProgress<string> logs)
        {
            if (glbFilePaths.Length > 0) Settings.Last3DFileImportDirectory = Path.GetDirectoryName(glbFilePaths[0]);
            Settings.LastMDBExportDirectory = mdbDirectory;
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

        public void XOBJToXMDB(string[] objFilePaths, string mdbDirectory, IProgress<string> progress, IProgress<string> logs)
        {
            if (objFilePaths.Length > 0) Settings.Last3DFileImportDirectory = Path.GetDirectoryName(objFilePaths[0]);
            Settings.LastMDBExportDirectory = mdbDirectory;
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
