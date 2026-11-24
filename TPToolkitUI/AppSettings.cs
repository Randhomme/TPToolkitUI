using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitLib.Tools;
using TPToolkitLib.TPSettings;
using TPToolkitLib.WorldObject;
using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitUI.Enums;

namespace TPToolkitUI
{
    public class AppSettings
    {
        public static ObservableCollection<WorldObjectType> Asteroids { get; } = [];
        public static ObservableCollection<WorldObjectType> Bullets { get; } = [];
        public static ObservableCollection<string> Effects { get; } = [];
        public static ObservableCollection<string> HudEntries { get; } = [];
        public static ObservableCollection<string> Meshes { get; } = [];
        public static ObservableCollection<string> SoundDialogues { get; } = [];
        public static ObservableCollection<string> SoundEffects { get; } = [];
        public static ObservableCollection<TPGameHeaderStrings> TPGameHeaderStrings { get; } = [];

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
                    LastWorldObjectImportDirectory = newSettings.LastWorldObjectImportDirectory;
                    LastWorldObjectExportDirectory = newSettings.LastWorldObjectExportDirectory;
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

        public static void RefreshCollections()
        {
            Asteroids.Clear();
            Bullets.Clear();
            Effects.Clear();
            HudEntries.Clear();
            Meshes.Clear();
            SoundDialogues.Clear();
            SoundEffects.Clear();
            TPGameHeaderStrings.Clear();
            foreach (var item in TPGameTool.WorldObjects)
            {
                if (item.CustomInfoDefinition is AsteroidCustomInfoFactory)
                    Asteroids.Add(item);
                else if (item.CustomInfoDefinition is BulletCustomInfoFactory)
                    Bullets.Add(item);
            }
            foreach (var item in TPGameTool.Effects)
            {
                Effects.Add(item);
            }
            foreach (var item in TPGameTool.HudEntries)
            {
                HudEntries.Add(item);
            }
            foreach (var item in TPGameTool.Meshes)
            {
                Meshes.Add(item);
            }
            foreach (var item in TPGameTool.SoundDialogues)
            {
                SoundDialogues.Add(item);
            }
            foreach (var item in TPGameTool.SoundEffects)
            {
                SoundEffects.Add(item);
            }
            foreach (var item in TPGameTool.TPGameHeaderStrings)
            {
                TPGameHeaderStrings.Add(item);
            }
        }
    }
}
