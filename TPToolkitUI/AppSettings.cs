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
        public string Last3DFileImportDirectory { get; set; } = string.Empty;
        public string Last3DFileExportDirectory { get; set; } = string.Empty;
        public File3DFormat Prefered3DFileFormat { get; set; } = File3DFormat.glb;
        public AppSettings Load()
        {
            try
            {
                using (var reader = new StreamReader(File.OpenRead(filename)))
                {
                    var xmls = new XmlSerializer(typeof(AppSettings));
                    return (AppSettings)xmls.Deserialize(reader);
                }
            }
            catch
            {
                Save();
                return this;
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
