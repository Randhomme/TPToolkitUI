using System.IO;
using System.Xml.Serialization;
using TPToolkitUI.Enums;

namespace TPToolkitUI
{
    public class AppSettings
    {
        private readonly string filename = "TPToolkitUI.xml";
        public string TPGameDirectory { get; set; } = string.Empty;
        public bool ExportLods { get; set; } = true;
        public string LastMDBImportDirectory { get; set; } = string.Empty;
        public string LastMDBExportDirectory { get; set; } = string.Empty;
        public string LastMSBImportDirectory { get; set; } = string.Empty;
        public string LastMSBExportDirectory { get; set; } = string.Empty;
        public string Last3DFileImportDirectory { get; set; } = string.Empty;
        public string Last3DFileExportDirectory { get; set; } = string.Empty;
        public string LastWorldObjectImportDirectory { get; set; } = string.Empty;
        public string LastWorldObjectExportDirectory { get; set; } = string.Empty;
        public File3DFormat Prefered3DFileFormat { get; set; } = File3DFormat.glb;
        public void Load()
        {
            try
            {
                using (var reader = new StreamReader(File.OpenRead(filename)))
                {
                    var xmls = new XmlSerializer(typeof(AppSettings));
                    var newSettings = (AppSettings)xmls.Deserialize(reader);
                    TPGameDirectory = newSettings.TPGameDirectory;
                    ExportLods = newSettings.ExportLods;
                    LastMDBImportDirectory = newSettings.LastMDBImportDirectory;
                    LastMDBExportDirectory = newSettings.LastMDBExportDirectory;
                    LastMSBImportDirectory = newSettings.LastMSBImportDirectory;
                    LastMSBExportDirectory = newSettings.LastMSBExportDirectory;
                    Last3DFileImportDirectory = newSettings.Last3DFileImportDirectory;
                    Last3DFileExportDirectory = newSettings.Last3DFileExportDirectory;
                    Prefered3DFileFormat = newSettings.Prefered3DFileFormat;
                }
            }
            catch
            {
                Save();
            }
        }

        public void Save()
        {
            try
            {
                using (var writer = new StreamWriter(File.Open(filename, FileMode.Create, FileAccess.ReadWrite)))
                {
                    var xmls = new XmlSerializer(typeof(AppSettings));
                    xmls.Serialize(writer, this);
                }
            }
            catch { }
        }
    }
}
