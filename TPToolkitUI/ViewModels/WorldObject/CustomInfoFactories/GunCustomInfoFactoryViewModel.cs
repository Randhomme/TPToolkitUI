using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.Enums;
using TPToolkitLib.TPSettings;
using TPToolkitLib.WorldObject;
using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitLib.WorldObject.Enums;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CustomInfoFactories
{
    public partial class GunCustomInfoFactoryViewModel : CustomInfoDefinitionViewModel<GunCustomInfoFactory>
    {
        [ObservableProperty]
        public partial bool HasBulletTypeName_Primary { get; set; }

        public WorldObjectType? BulletTypeName_Primary
        {
            get => Model.BulletTypeName_Primary;
            set => SetAndValidateProperty(Model.BulletTypeName_Primary, value, Model, (m, wot) => m.BulletTypeName_Primary = wot);
        }

        [ObservableProperty]
        public partial bool HasBulletTypeName_Secondary { get; set; }

        public WorldObjectType? BulletTypeName_Secondary
        {
            get => Model.BulletTypeName_Secondary;
            set => SetAndValidateProperty(Model.BulletTypeName_Secondary, value, Model, (m, wot) => m.BulletTypeName_Secondary = wot);
        }

        [ObservableProperty]
        public partial bool HasSoundName { get; set; }

        public string SoundName
        {
            get => Model.SoundName;
            set => SetAndValidateProperty(Model.SoundName, value, Model, (m, s) => m.SoundName = s);
        }

        public string MuzzleFlashEffect
        {
            get => Model.MuzzleFlashEffect;
            set => SetAndValidateProperty(Model.MuzzleFlashEffect, value, Model, (m, s) => m.MuzzleFlashEffect = s);
        }

        [Float(MinValue = 0)]
        public string MuzzleSpeed
        {
            get => Model.MuzzleSpeed.ToString("F6");
            set => SetAndValidateProperty(Model.MuzzleSpeed.ToString(), value, Model, (m, s) => m.MuzzleSpeed = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string DuringBurstReloadTime
        {
            get => Model.DuringBurstReloadTime.ToString("F6");
            set => SetAndValidateProperty(Model.DuringBurstReloadTime.ToString(), value, Model, (m, s) => m.DuringBurstReloadTime = float.Parse(s));
        }

        [Int(MinValue = 0)]
        public string BulletsPerBurst
        {
            get => Model.BulletsPerBurst.ToString();
            set => SetAndValidateProperty(Model.BulletsPerBurst.ToString(), value, Model, (m, s) => m.BulletsPerBurst = int.Parse(s));
        }

        [Float(MinValue = 0)]
        public string TimeBetweenBursts
        {
            get => Model.TimeBetweenBursts.ToString("F6");
            set => SetAndValidateProperty(Model.TimeBetweenBursts.ToString(), value, Model, (m, s) => m.TimeBetweenBursts = float.Parse(s));
        }

        public bool CalculateAccuracyDeviationDuringBurst
        {
            get => Model.CalculateAccuracyDeviationDuringBurst;
            set => SetAndValidateProperty(Model.CalculateAccuracyDeviationDuringBurst, value, Model, (m, b) => m.CalculateAccuracyDeviationDuringBurst = b);
        }

        public string WeaponBarIconTexture
        {
            get => Model.WeaponBarIconTexture;
            set => SetAndValidateProperty(Model.WeaponBarIconTexture, value, Model, (m, s) => m.WeaponBarIconTexture = s);
        }

        [Float(MinValue = 0)]
        public string VerticalRotationSpeed
        {
            get => Model.VerticalRotationSpeed.ToString("F6");
            set => SetAndValidateProperty(Model.VerticalRotationSpeed.ToString(), value, Model, (m, s) => m.VerticalRotationSpeed = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string HorizontalRotationSpeed
        {
            get => Model.HorizontalRotationSpeed.ToString("F6");
            set => SetAndValidateProperty(Model.HorizontalRotationSpeed.ToString(), value, Model, (m, s) => m.HorizontalRotationSpeed = float.Parse(s));
        }

        [Float(MinValue = (float)(-Math.PI / 4))]
        public string VerticalMinAngle
        {
            get => Model.VerticalMinAngle.ToString("F6");
            set => SetAndValidateProperty(Model.VerticalMinAngle.ToString(), value, Model, (m, s) => m.VerticalMinAngle = float.Parse(s));
        }

        [Float(MaxValue = (float)(Math.PI / 4))]
        public string VerticalMaxAngle
        {
            get => Model.VerticalMaxAngle.ToString("F6");
            set => SetAndValidateProperty(Model.VerticalMaxAngle.ToString(), value, Model, (m, s) => m.VerticalMaxAngle = float.Parse(s));
        }

        [Float(MaxValue = (float)(Math.PI / 4))]
        public string LobAngle
        {
            get => Model.LobAngle.ToString("F6");
            set => SetAndValidateProperty(Model.LobAngle.ToString(), value, Model, (m, s) => m.LobAngle = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string MaximumRange_Range
        {
            get => Model.MaximumRange_Range.ToString("F6");
            set => SetAndValidateProperty(Model.MaximumRange_Range.ToString(), value, Model, (m, s) => m.MaximumRange_Range = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string LongRange_Range
        {
            get => Model.LongRange_Range.ToString("F6");
            set => SetAndValidateProperty(Model.LongRange_Range.ToString(), value, Model, (m, s) => m.LongRange_Range = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string EffectiveRange_Range
        {
            get => Model.EffectiveRange_Range.ToString("F6");
            set => SetAndValidateProperty(Model.EffectiveRange_Range.ToString(), value, Model, (m, s) => m.EffectiveRange_Range = float.Parse(s));
        }

        public bool BulletAffectedByGravity
        {
            get => Model.BulletAffectedByGravity;
            set => SetAndValidateProperty(Model.BulletAffectedByGravity, value, Model, (m, b) => m.BulletAffectedByGravity = b);
        }

        [Float]
        public string MaximumRange_AccuracyDeviation
        {
            get => Model.MaximumRange_AccuracyDeviation.ToString("F6");
            set => SetAndValidateProperty(Model.MaximumRange_AccuracyDeviation.ToString(), value, Model, (m, s) => m.MaximumRange_AccuracyDeviation = float.Parse(s));
        }

        [Float]
        public string LongRange_AccuracyDeviation
        {
            get => Model.LongRange_AccuracyDeviation.ToString("F6");
            set => SetAndValidateProperty(Model.LongRange_AccuracyDeviation.ToString(), value, Model, (m, s) => m.LongRange_AccuracyDeviation = float.Parse(s));
        }

        [Float]
        public string EffectiveRange_AccuracyDeviation
        {
            get => Model.EffectiveRange_AccuracyDeviation.ToString("F6");
            set => SetAndValidateProperty(Model.EffectiveRange_AccuracyDeviation.ToString(), value, Model, (m, s) => m.EffectiveRange_AccuracyDeviation = float.Parse(s));
        }

        [Float]
        public string MaximumRange_RicochetFactor
        {
            get => Model.MaximumRange_RicochetFactor.ToString("F6");
            set => SetAndValidateProperty(Model.MaximumRange_RicochetFactor.ToString(), value, Model, (m, s) => m.MaximumRange_RicochetFactor = float.Parse(s));
        }

        [Float]
        public string LongRange_RicochetFactor
        {
            get => Model.LongRange_RicochetFactor.ToString("F6");
            set => SetAndValidateProperty(Model.LongRange_RicochetFactor.ToString(), value, Model, (m, s) => m.LongRange_RicochetFactor = float.Parse(s));
        }

        [Float]
        public string EffectiveRange_RicochetFactor
        {
            get => Model.EffectiveRange_RicochetFactor.ToString("F6");
            set => SetAndValidateProperty(Model.EffectiveRange_RicochetFactor.ToString(), value, Model, (m, s) => m.EffectiveRange_RicochetFactor = float.Parse(s));
        }

        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedGunNameStringIDGameHeader { get; set; }

        public IEnumerable<KeyValuePair<string, string>> AvailableGunNameStringIDS { get => SelectedGunNameStringIDGameHeader.Strings; }

        public string GunNameStringID
        {
            get => Model.GunNameStringID;
            set => SetAndValidateProperty(Model.GunNameStringID, value, Model, (m, s) => m.GunNameStringID = s);
        }

        public MountType MountType
        {
            get => Model.MountType;
            set => SetAndValidateProperty(Model.MountType, value, Model, (m, mt) => m.MountType = mt);
        }

        public Race ExclusionRace
        {
            get => Model.ExclusionRace;
            set => SetAndValidateProperty(Model.ExclusionRace, value, Model, (m, r) => m.ExclusionRace = r);
        }

        public bool CanBeFiredWhileCloaked
        {
            get => Model.CanBeFiredWhileCloaked;
            set => SetAndValidateProperty(Model.CanBeFiredWhileCloaked, value, Model, (m, b) => m.CanBeFiredWhileCloaked = b);
        }

        public GenericDialogSound FiringCrewAlert
        {
            get => Model.FiringCrewAlert;
            set => SetAndValidateProperty(Model.FiringCrewAlert, value, Model, (m, gds) => m.FiringCrewAlert = gds);
        }

        [Float(MinValue = 0)]
        public string SoundMaxDistance
        {
            get => Model.SoundMaxDistance.ToString("F6");
            set => SetAndValidateProperty(Model.SoundMaxDistance.ToString(), value, Model, (m, s) => m.SoundMaxDistance = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string SoundVolume
        {
            get => Model.SoundVolume.ToString("F6");
            set => SetAndValidateProperty(Model.SoundVolume.ToString(), value, Model, (m, s) => m.SoundVolume = float.Parse(s));
        }

        public GunCustomInfoFactoryViewModel(GunCustomInfoFactory model) : base(model)
        {
            SelectedGunNameStringIDGameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.GunNameStringID));
        }

        partial void OnHasBulletTypeName_PrimaryChanged(bool value)
        {
            if (value)
            {
                if (BulletTypeName_Primary == null)
                    BulletTypeName_Primary = AppSettings.Bullets.FirstOrDefault();
            }
            else
                BulletTypeName_Primary = null;
        }

        partial void OnHasBulletTypeName_SecondaryChanged(bool value)
        {
            if (value)
            {
                if (BulletTypeName_Secondary == null)
                    BulletTypeName_Secondary = AppSettings.Bullets.FirstOrDefault();
            }
            else
                BulletTypeName_Secondary = null;
        }

        partial void OnHasSoundNameChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(SoundName))
                    SoundName = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                SoundName = string.Empty;
        }

        partial void OnSelectedGunNameStringIDGameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableGunNameStringIDS));
                GunNameStringID = newValue.Strings.Keys.FirstOrDefault();
            }
        }
    }
}
