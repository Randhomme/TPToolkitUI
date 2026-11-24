using TPToolkitLib.Enums;
using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CustomInfoFactories
{
    public class IslandCustomInfoFactoryViewModel : CustomInfoDefinitionViewModel<IslandCustomInfoFactory>
    {
        [Float]
        public string OcclusionPolygonPoint00X
        {
            get => Model.OcclusionPolygonPoint00.X.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint00.X.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint00 = new(float.Parse(s), m.OcclusionPolygonPoint00.Y, m.OcclusionPolygonPoint00.Z));
        }

        [Float]
        public string OcclusionPolygonPoint00Y
        {
            get => Model.OcclusionPolygonPoint00.Y.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint00.Y.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint00 = new(m.OcclusionPolygonPoint00.X, float.Parse(s), m.OcclusionPolygonPoint00.Z));
        }

        [Float]
        public string OcclusionPolygonPoint00Z
        {
            get => Model.OcclusionPolygonPoint00.Z.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint00.Z.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint00 = new(m.OcclusionPolygonPoint00.X, m.OcclusionPolygonPoint00.Y, float.Parse(s)));
        }

        [Float]
        public string OcclusionPolygonPoint01X
        {
            get => Model.OcclusionPolygonPoint01.X.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint01.X.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint01 = new(float.Parse(s), m.OcclusionPolygonPoint01.Y, m.OcclusionPolygonPoint01.Z));
        }

        [Float]
        public string OcclusionPolygonPoint01Y
        {
            get => Model.OcclusionPolygonPoint01.Y.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint01.Y.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint01 = new(m.OcclusionPolygonPoint01.X, float.Parse(s), m.OcclusionPolygonPoint01.Z));
        }

        [Float]
        public string OcclusionPolygonPoint01Z
        {
            get => Model.OcclusionPolygonPoint01.Z.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint01.Z.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint01 = new(m.OcclusionPolygonPoint01.X, m.OcclusionPolygonPoint01.Y, float.Parse(s)));
        }

        [Float]
        public string OcclusionPolygonPoint02X
        {
            get => Model.OcclusionPolygonPoint02.X.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint02.X.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint02 = new(float.Parse(s), m.OcclusionPolygonPoint02.Y, m.OcclusionPolygonPoint02.Z));
        }

        [Float]
        public string OcclusionPolygonPoint02Y
        {
            get => Model.OcclusionPolygonPoint02.Y.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint02.Y.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint02 = new(m.OcclusionPolygonPoint02.X, float.Parse(s), m.OcclusionPolygonPoint02.Z));
        }

        [Float]
        public string OcclusionPolygonPoint02Z
        {
            get => Model.OcclusionPolygonPoint02.Z.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint02.Z.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint02 = new(m.OcclusionPolygonPoint02.X, m.OcclusionPolygonPoint02.Y, float.Parse(s)));
        }

        [Float]
        public string OcclusionPolygonPoint03X
        {
            get => Model.OcclusionPolygonPoint03.X.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint03.X.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint03 = new(float.Parse(s), m.OcclusionPolygonPoint03.Y, m.OcclusionPolygonPoint03.Z));
        }

        [Float]
        public string OcclusionPolygonPoint03Y
        {
            get => Model.OcclusionPolygonPoint03.Y.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint03.Y.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint03 = new(m.OcclusionPolygonPoint03.X, float.Parse(s), m.OcclusionPolygonPoint03.Z));
        }

        [Float]
        public string OcclusionPolygonPoint03Z
        {
            get => Model.OcclusionPolygonPoint03.Z.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint03.Z.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint03 = new(m.OcclusionPolygonPoint03.X, m.OcclusionPolygonPoint03.Y, float.Parse(s)));
        }

        [Float]
        public string OcclusionPolygonPoint04X
        {
            get => Model.OcclusionPolygonPoint04.X.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint04.X.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint04 = new(float.Parse(s), m.OcclusionPolygonPoint04.Y, m.OcclusionPolygonPoint04.Z));
        }

        [Float]
        public string OcclusionPolygonPoint04Y
        {
            get => Model.OcclusionPolygonPoint04.Y.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint04.Y.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint04 = new(m.OcclusionPolygonPoint04.X, float.Parse(s), m.OcclusionPolygonPoint04.Z));
        }

        [Float]
        public string OcclusionPolygonPoint04Z
        {
            get => Model.OcclusionPolygonPoint04.Z.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint04.Z.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint04 = new(m.OcclusionPolygonPoint04.X, m.OcclusionPolygonPoint04.Y, float.Parse(s)));
        }

        [Float]
        public string OcclusionPolygonPoint05X
        {
            get => Model.OcclusionPolygonPoint05.X.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint05.X.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint05 = new(float.Parse(s), m.OcclusionPolygonPoint05.Y, m.OcclusionPolygonPoint05.Z));
        }

        [Float]
        public string OcclusionPolygonPoint05Y
        {
            get => Model.OcclusionPolygonPoint05.Y.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint05.Y.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint05 = new(m.OcclusionPolygonPoint05.X, float.Parse(s), m.OcclusionPolygonPoint05.Z));
        }

        [Float]
        public string OcclusionPolygonPoint05Z
        {
            get => Model.OcclusionPolygonPoint05.Z.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint05.Z.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint05 = new(m.OcclusionPolygonPoint05.X, m.OcclusionPolygonPoint05.Y, float.Parse(s)));
        }

        [Float]
        public string OcclusionPolygonPoint06X
        {
            get => Model.OcclusionPolygonPoint06.X.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint06.X.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint06 = new(float.Parse(s), m.OcclusionPolygonPoint06.Y, m.OcclusionPolygonPoint06.Z));
        }

        [Float]
        public string OcclusionPolygonPoint06Y
        {
            get => Model.OcclusionPolygonPoint06.Y.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint06.Y.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint06 = new(m.OcclusionPolygonPoint06.X, float.Parse(s), m.OcclusionPolygonPoint06.Z));
        }

        [Float]
        public string OcclusionPolygonPoint06Z
        {
            get => Model.OcclusionPolygonPoint06.Z.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint06.Z.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint06 = new(m.OcclusionPolygonPoint06.X, m.OcclusionPolygonPoint06.Y, float.Parse(s)));
        }

        [Float]
        public string OcclusionPolygonPoint07X
        {
            get => Model.OcclusionPolygonPoint07.X.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint07.X.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint07 = new(float.Parse(s), m.OcclusionPolygonPoint07.Y, m.OcclusionPolygonPoint07.Z));
        }

        [Float]
        public string OcclusionPolygonPoint07Y
        {
            get => Model.OcclusionPolygonPoint07.Y.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint07.Y.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint07 = new(m.OcclusionPolygonPoint07.X, float.Parse(s), m.OcclusionPolygonPoint07.Z));
        }

        [Float]
        public string OcclusionPolygonPoint07Z
        {
            get => Model.OcclusionPolygonPoint07.Z.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint07.Z.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint07 = new(m.OcclusionPolygonPoint07.X, m.OcclusionPolygonPoint07.Y, float.Parse(s)));
        }

        [Float]
        public string OcclusionPolygonPoint08X
        {
            get => Model.OcclusionPolygonPoint08.X.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint08.X.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint08 = new(float.Parse(s), m.OcclusionPolygonPoint08.Y, m.OcclusionPolygonPoint08.Z));
        }

        [Float]
        public string OcclusionPolygonPoint08Y
        {
            get => Model.OcclusionPolygonPoint08.Y.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint08.Y.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint08 = new(m.OcclusionPolygonPoint08.X, float.Parse(s), m.OcclusionPolygonPoint08.Z));
        }

        [Float]
        public string OcclusionPolygonPoint08Z
        {
            get => Model.OcclusionPolygonPoint08.Z.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint08.Z.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint08 = new(m.OcclusionPolygonPoint08.X, m.OcclusionPolygonPoint08.Y, float.Parse(s)));
        }

        [Float]
        public string OcclusionPolygonPoint09X
        {
            get => Model.OcclusionPolygonPoint09.X.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint09.X.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint09 = new(float.Parse(s), m.OcclusionPolygonPoint09.Y, m.OcclusionPolygonPoint09.Z));
        }

        [Float]
        public string OcclusionPolygonPoint09Y
        {
            get => Model.OcclusionPolygonPoint09.Y.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint09.Y.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint09 = new(m.OcclusionPolygonPoint09.X, float.Parse(s), m.OcclusionPolygonPoint09.Z));
        }

        [Float]
        public string OcclusionPolygonPoint09Z
        {
            get => Model.OcclusionPolygonPoint09.Z.ToString("F6");
            set => SetAndValidateProperty(Model.OcclusionPolygonPoint09.Z.ToString(), value, Model, (m, s) => m.OcclusionPolygonPoint09 = new(m.OcclusionPolygonPoint09.X, m.OcclusionPolygonPoint09.Y, float.Parse(s)));
        }

        [Int(MinValue = 0, MaxValue = 9)]
        public int OcclusionPolygonPointCount
        {
            get => Model.OcclusionPolygonPointCount;
            set => SetAndValidateProperty(Model.OcclusionPolygonPointCount, value, Model, (m, i) => m.OcclusionPolygonPointCount = i);
        }

        public Race Race
        {
            get => Model.Race;
            set => SetAndValidateProperty(Model.Race, value, Model, (m, r) => m.Race = r);
        }

        public bool HasAmbientSound
        {
            get => Model.HasAmbientSound;
            set
            {
                SetAndValidateProperty(Model.HasAmbientSound, value, Model, (m, b) => m.HasAmbientSound = b);
                if (value)
                {
                    if (string.IsNullOrWhiteSpace(AmbientSoundName))
                        AmbientSoundName = AppSettings.SoundDialogues.FirstOrDefault();
                }
                else
                    AmbientSoundName = string.Empty;
            }
        }

        [Float(MinValue = 0)]
        public string AmbientSoundMaxDistance
        {
            get => Model.AmbientSoundMaxDistance.ToString("F6");
            set => SetAndValidateProperty(Model.AmbientSoundMaxDistance.ToString(), value, Model, (m, s) => m.AmbientSoundMaxDistance = float.Parse(s));
        }

        public string AmbientSoundName
        {
            get => Model.AmbientSoundName;
            set => SetAndValidateProperty(Model.AmbientSoundName, value, Model, (m, s) => m.AmbientSoundName = s);
        }

        [Int]
        public string CoreDamageSectionMaxHitPoints
        {
            get => Model.CoreDamageSectionMaxHitPoints.ToString();
            set => SetAndValidateProperty(Model.CoreDamageSectionMaxHitPoints.ToString(), value, Model, (m, s) => m.CoreDamageSectionMaxHitPoints = int.Parse(s));
        }

        public bool AnnounceSighting
        {
            get => Model.AnnounceSighting;
            set => SetAndValidateProperty(Model.AnnounceSighting, value, Model, (m, b) => m.AnnounceSighting = b);
        }

        public IslandCustomInfoFactoryViewModel(IslandCustomInfoFactory model) : base(model)
        {
        }
    }
}
