using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitLib.WorldObject.Enums;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CustomInfoFactories
{
    public partial class BulletCustomInfoFactoryViewModel : CustomInfoDefinitionViewModel<BulletCustomInfoFactory>
    {
        public string HitEffect
        {
            get => Model.HitEffect;
            set => SetAndValidateProperty(Model.HitEffect, value, Model, (m, s) => m.HitEffect = s);
        }

        public string BulletEffect
        {
            get => Model.BulletEffect;
            set => SetAndValidateProperty(Model.BulletEffect, value, Model, (m, s) => m.BulletEffect = s);
        }

        [Int]
        public string DamageHitPoints
        {
            get => Model.DamageHitPoints.ToString();
            set => SetAndValidateProperty(Model.DamageHitPoints.ToString(), value, Model, (m, s) => m.DamageHitPoints = int.Parse(s));
        }

        public DecalDamageSize DecalDamageSize
        {
            get => Model.DecalDamageSize;
            set => SetAndValidateProperty(Model.DecalDamageSize, value, Model, (m, d) => m.DecalDamageSize = d);
        }

        [Float(MinValue = 0)]
        public string ImpactSoundMaxDistance
        {
            get => Model.ImpactSoundMaxDistance.ToString("F6");
            set => SetAndValidateProperty(Model.ImpactSoundMaxDistance.ToString(), value, Model, (m, s) => m.ImpactSoundMaxDistance = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string ImpactSoundVolume
        {
            get => Model.ImpactSoundVolume.ToString("F6");
            set => SetAndValidateProperty(Model.ImpactSoundVolume.ToString(), value, Model, (m, s) => m.ImpactSoundVolume = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string TravelSoundMaxDistance
        {
            get => Model.TravelSoundMaxDistance.ToString("F6");
            set => SetAndValidateProperty(Model.TravelSoundMaxDistance.ToString(), value, Model, (m, s) => m.TravelSoundMaxDistance = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string TravelSoundVolume
        {
            get => Model.TravelSoundVolume.ToString("F6");
            set => SetAndValidateProperty(Model.TravelSoundVolume.ToString(), value, Model, (m, s) => m.TravelSoundVolume = float.Parse(s));
        }

        [ObservableProperty]
        public partial bool HasRicochetSoundHullWood { get; set; }

        public string RicochetSoundHullWood
        {
            get => Model.RicochetSoundHullWood;
            set => SetAndValidateProperty(Model.RicochetSoundHullWood, value, Model, (m, s) => m.RicochetSoundHullWood = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound0HullWood { get; set; }

        public string ImpactSound0HullWood
        {
            get => Model.ImpactSound0HullWood;
            set => SetAndValidateProperty(Model.ImpactSound0HullWood, value, Model, (m, s) => m.ImpactSound0HullWood = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound1HullWood { get; set; }

        public string ImpactSound1HullWood
        {
            get => Model.ImpactSound1HullWood;
            set => SetAndValidateProperty(Model.ImpactSound1HullWood, value, Model, (m, s) => m.ImpactSound1HullWood = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound2HullWood { get; set; }

        public string ImpactSound2HullWood
        {
            get => Model.ImpactSound2HullWood;
            set => SetAndValidateProperty(Model.ImpactSound2HullWood, value, Model, (m, s) => m.ImpactSound2HullWood = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound3HullWood { get; set; }

        public string ImpactSound3HullWood
        {
            get => Model.ImpactSound3HullWood;
            set => SetAndValidateProperty(Model.ImpactSound3HullWood, value, Model, (m, s) => m.ImpactSound3HullWood = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound4HullWood { get; set; }

        public string ImpactSound4HullWood
        {
            get => Model.ImpactSound4HullWood;
            set => SetAndValidateProperty(Model.ImpactSound4HullWood, value, Model, (m, s) => m.ImpactSound4HullWood = s);
        }

        [ObservableProperty]
        public partial bool HasRicochetSoundHullReInforcedWood { get; set; }

        public string RicochetSoundHullReInforcedWood
        {
            get => Model.RicochetSoundHullReInforcedWood;
            set => SetAndValidateProperty(Model.RicochetSoundHullReInforcedWood, value, Model, (m, s) => m.RicochetSoundHullReInforcedWood = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound0HullReInforcedWood { get; set; }

        public string ImpactSound0HullReInforcedWood
        {
            get => Model.ImpactSound0HullReInforcedWood;
            set => SetAndValidateProperty(Model.ImpactSound0HullReInforcedWood, value, Model, (m, s) => m.ImpactSound0HullReInforcedWood = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound1HullReInforcedWood { get; set; }

        public string ImpactSound1HullReInforcedWood
        {
            get => Model.ImpactSound1HullReInforcedWood;
            set => SetAndValidateProperty(Model.ImpactSound1HullReInforcedWood, value, Model, (m, s) => m.ImpactSound1HullReInforcedWood = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound2HullReInforcedWood { get; set; }

        public string ImpactSound2HullReInforcedWood
        {
            get => Model.ImpactSound2HullReInforcedWood;
            set => SetAndValidateProperty(Model.ImpactSound2HullReInforcedWood, value, Model, (m, s) => m.ImpactSound2HullReInforcedWood = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound3HullReInforcedWood { get; set; }

        public string ImpactSound3HullReInforcedWood
        {
            get => Model.ImpactSound3HullReInforcedWood;
            set => SetAndValidateProperty(Model.ImpactSound3HullReInforcedWood, value, Model, (m, s) => m.ImpactSound3HullReInforcedWood = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound4HullReInforcedWood { get; set; }

        public string ImpactSound4HullReInforcedWood
        {
            get => Model.ImpactSound4HullReInforcedWood;
            set => SetAndValidateProperty(Model.ImpactSound4HullReInforcedWood, value, Model, (m, s) => m.ImpactSound4HullReInforcedWood = s);
        }

        [ObservableProperty]
        public partial bool HasRicochetSoundHullIron { get; set; }

        public string RicochetSoundHullIron
        {
            get => Model.RicochetSoundHullIron;
            set => SetAndValidateProperty(Model.RicochetSoundHullIron, value, Model, (m, s) => m.RicochetSoundHullIron = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound0HullIron { get; set; }

        public string ImpactSound0HullIron
        {
            get => Model.ImpactSound0HullIron;
            set => SetAndValidateProperty(Model.ImpactSound0HullIron, value, Model, (m, s) => m.ImpactSound0HullIron = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound1HullIron { get; set; }

        public string ImpactSound1HullIron
        {
            get => Model.ImpactSound1HullIron;
            set => SetAndValidateProperty(Model.ImpactSound1HullIron, value, Model, (m, s) => m.ImpactSound1HullIron = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound2HullIron { get; set; }

        public string ImpactSound2HullIron
        {
            get => Model.ImpactSound2HullIron;
            set => SetAndValidateProperty(Model.ImpactSound2HullIron, value, Model, (m, s) => m.ImpactSound2HullIron = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound3HullIron { get; set; }

        public string ImpactSound3HullIron
        {
            get => Model.ImpactSound3HullIron;
            set => SetAndValidateProperty(Model.ImpactSound3HullIron, value, Model, (m, s) => m.ImpactSound3HullIron = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound4HullIron { get; set; }

        public string ImpactSound4HullIron
        {
            get => Model.ImpactSound4HullIron;
            set => SetAndValidateProperty(Model.ImpactSound4HullIron, value, Model, (m, s) => m.ImpactSound4HullIron = s);
        }

        [ObservableProperty]
        public partial bool HasRicochetSoundSailCloth { get; set; }

        public string RicochetSoundSailCloth
        {
            get => Model.RicochetSoundSailCloth;
            set => SetAndValidateProperty(Model.RicochetSoundSailCloth, value, Model, (m, s) => m.RicochetSoundSailCloth = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound0SailCloth { get; set; }

        public string ImpactSound0SailCloth
        {
            get => Model.ImpactSound0SailCloth;
            set => SetAndValidateProperty(Model.ImpactSound0SailCloth, value, Model, (m, s) => m.ImpactSound0SailCloth = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound1SailCloth { get; set; }

        public string ImpactSound1SailCloth
        {
            get => Model.ImpactSound1SailCloth;
            set => SetAndValidateProperty(Model.ImpactSound1SailCloth, value, Model, (m, s) => m.ImpactSound1SailCloth = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound2SailCloth { get; set; }

        public string ImpactSound2SailCloth
        {
            get => Model.ImpactSound2SailCloth;
            set => SetAndValidateProperty(Model.ImpactSound2SailCloth, value, Model, (m, s) => m.ImpactSound2SailCloth = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound3SailCloth { get; set; }

        public string ImpactSound3SailCloth
        {
            get => Model.ImpactSound3SailCloth;
            set => SetAndValidateProperty(Model.ImpactSound3SailCloth, value, Model, (m, s) => m.ImpactSound3SailCloth = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound4SailCloth { get; set; }

        public string ImpactSound4SailCloth
        {
            get => Model.ImpactSound4SailCloth;
            set => SetAndValidateProperty(Model.ImpactSound4SailCloth, value, Model, (m, s) => m.ImpactSound4SailCloth = s);
        }

        [ObservableProperty]
        public partial bool HasRicochetSoundWallStone { get; set; }

        public string RicochetSoundWallStone
        {
            get => Model.RicochetSoundWallStone;
            set => SetAndValidateProperty(Model.RicochetSoundWallStone, value, Model, (m, s) => m.RicochetSoundWallStone = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound0WallStone { get; set; }

        public string ImpactSound0WallStone
        {
            get => Model.ImpactSound0WallStone;
            set => SetAndValidateProperty(Model.ImpactSound0WallStone, value, Model, (m, s) => m.ImpactSound0WallStone = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound1WallStone { get; set; }

        public string ImpactSound1WallStone
        {
            get => Model.ImpactSound1WallStone;
            set => SetAndValidateProperty(Model.ImpactSound1WallStone, value, Model, (m, s) => m.ImpactSound1WallStone = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound2WallStone { get; set; }

        public string ImpactSound2WallStone
        {
            get => Model.ImpactSound2WallStone;
            set => SetAndValidateProperty(Model.ImpactSound2WallStone, value, Model, (m, s) => m.ImpactSound2WallStone = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound3WallStone { get; set; }

        public string ImpactSound3WallStone
        {
            get => Model.ImpactSound3WallStone;
            set => SetAndValidateProperty(Model.ImpactSound3WallStone, value, Model, (m, s) => m.ImpactSound3WallStone = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound4WallStone { get; set; }

        public string ImpactSound4WallStone
        {
            get => Model.ImpactSound4WallStone;
            set => SetAndValidateProperty(Model.ImpactSound4WallStone, value, Model, (m, s) => m.ImpactSound4WallStone = s);
        }

        [ObservableProperty]
        public partial bool HasRicochetSoundDragonScale { get; set; }

        public string RicochetSoundDragonScale
        {
            get => Model.RicochetSoundDragonScale;
            set => SetAndValidateProperty(Model.RicochetSoundDragonScale, value, Model, (m, s) => m.RicochetSoundDragonScale = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound0DragonScale { get; set; }

        public string ImpactSound0DragonScale
        {
            get => Model.ImpactSound0DragonScale;
            set => SetAndValidateProperty(Model.ImpactSound0DragonScale, value, Model, (m, s) => m.ImpactSound0DragonScale = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound1DragonScale { get; set; }

        public string ImpactSound1DragonScale
        {
            get => Model.ImpactSound1DragonScale;
            set => SetAndValidateProperty(Model.ImpactSound1DragonScale, value, Model, (m, s) => m.ImpactSound1DragonScale = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound2DragonScale { get; set; }

        public string ImpactSound2DragonScale
        {
            get => Model.ImpactSound2DragonScale;
            set => SetAndValidateProperty(Model.ImpactSound2DragonScale, value, Model, (m, s) => m.ImpactSound2DragonScale = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound3DragonScale { get; set; }

        public string ImpactSound3DragonScale
        {
            get => Model.ImpactSound3DragonScale;
            set => SetAndValidateProperty(Model.ImpactSound3DragonScale, value, Model, (m, s) => m.ImpactSound3DragonScale = s);
        }

        [ObservableProperty]
        public partial bool HasImpactSound4DragonScale { get; set; }

        public string ImpactSound4DragonScale
        {
            get => Model.ImpactSound4DragonScale;
            set => SetAndValidateProperty(Model.ImpactSound4DragonScale, value, Model, (m, s) => m.ImpactSound4DragonScale = s);
        }

        [ObservableProperty]
        public partial bool HasTravelSound { get; set; }

        public string TravelSound
        {
            get => Model.TravelSound;
            set => SetAndValidateProperty(Model.TravelSound, value, Model, (m, s) => m.TravelSound = s);
        }

        public bool HasLifetime
        {
            get => Model.HasLifetime;
            set => SetAndValidateProperty(Model.HasLifetime, value, Model, (m, b) => m.HasLifetime = b);
        }

        [Float(MinValue = 0)]
        public string Lifetime
        {
            get => Model.Lifetime.ToString("F6");
            set => SetAndValidateProperty(Model.Lifetime.ToString(), value, Model, (m, s) => m.Lifetime = float.Parse(s));
        }

        public DamagePotentialViewModel DamagePotentialViewModel { get; }

        public BulletCustomInfoFactoryViewModel(BulletCustomInfoFactory model) : base(model)
        {
            DamagePotentialViewModel = new(model.DamagePotential);
        }

        partial void OnHasRicochetSoundHullWoodChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(RicochetSoundHullWood))
                    RicochetSoundHullWood = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                RicochetSoundHullWood = string.Empty;
        }

        partial void OnHasImpactSound0HullWoodChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound0HullWood))
                    ImpactSound0HullWood = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound0HullWood = string.Empty;
        }

        partial void OnHasImpactSound1HullWoodChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound1HullWood))
                    ImpactSound1HullWood = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound1HullWood = string.Empty;
        }

        partial void OnHasImpactSound2HullWoodChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound2HullWood))
                    ImpactSound2HullWood = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound2HullWood = string.Empty;
        }

        partial void OnHasImpactSound3HullWoodChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound3HullWood))
                    ImpactSound3HullWood = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound3HullWood = string.Empty;
        }

        partial void OnHasImpactSound4HullWoodChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound4HullWood))
                    ImpactSound4HullWood = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound4HullWood = string.Empty;
        }

        partial void OnHasRicochetSoundHullReInforcedWoodChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(RicochetSoundHullReInforcedWood))
                    RicochetSoundHullReInforcedWood = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                RicochetSoundHullReInforcedWood = string.Empty;
        }

        partial void OnHasImpactSound0HullReInforcedWoodChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound0HullReInforcedWood))
                    ImpactSound0HullReInforcedWood = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound0HullReInforcedWood = string.Empty;
        }

        partial void OnHasImpactSound1HullReInforcedWoodChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound1HullReInforcedWood))
                    ImpactSound1HullReInforcedWood = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound1HullReInforcedWood = string.Empty;
        }

        partial void OnHasImpactSound2HullReInforcedWoodChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound2HullReInforcedWood))
                    ImpactSound2HullReInforcedWood = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound2HullReInforcedWood = string.Empty;
        }

        partial void OnHasImpactSound3HullReInforcedWoodChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound3HullReInforcedWood))
                    ImpactSound3HullReInforcedWood = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound3HullReInforcedWood = string.Empty;
        }

        partial void OnHasImpactSound4HullReInforcedWoodChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound4HullReInforcedWood))
                    ImpactSound4HullReInforcedWood = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound4HullReInforcedWood = string.Empty;
        }

        partial void OnHasRicochetSoundHullIronChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(RicochetSoundHullIron))
                    RicochetSoundHullIron = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                RicochetSoundHullIron = string.Empty;
        }

        partial void OnHasImpactSound0HullIronChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound0HullIron))
                    ImpactSound0HullIron = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound0HullIron = string.Empty;
        }

        partial void OnHasImpactSound1HullIronChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound1HullIron))
                    ImpactSound1HullIron = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound1HullIron = string.Empty;
        }

        partial void OnHasImpactSound2HullIronChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound2HullIron))
                    ImpactSound2HullIron = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound2HullIron = string.Empty;
        }

        partial void OnHasImpactSound3HullIronChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound3HullIron))
                    ImpactSound3HullIron = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound3HullIron = string.Empty;
        }

        partial void OnHasImpactSound4HullIronChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound4HullIron))
                    ImpactSound4HullIron = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound4HullIron = string.Empty;
        }

        partial void OnHasRicochetSoundSailClothChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(RicochetSoundSailCloth))
                    RicochetSoundSailCloth = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                RicochetSoundSailCloth = string.Empty;
        }

        partial void OnHasImpactSound0SailClothChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound0SailCloth))
                    ImpactSound0SailCloth = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound0SailCloth = string.Empty;
        }

        partial void OnHasImpactSound1SailClothChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound1SailCloth))
                    ImpactSound1SailCloth = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound1SailCloth = string.Empty;
        }

        partial void OnHasImpactSound2SailClothChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound2SailCloth))
                    ImpactSound2SailCloth = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound2SailCloth = string.Empty;
        }

        partial void OnHasImpactSound3SailClothChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound3SailCloth))
                    ImpactSound3SailCloth = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound3SailCloth = string.Empty;
        }

        partial void OnHasImpactSound4SailClothChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound4SailCloth))
                    ImpactSound4SailCloth = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound4SailCloth = string.Empty;
        }

        partial void OnHasRicochetSoundWallStoneChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(RicochetSoundWallStone))
                    RicochetSoundWallStone = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                RicochetSoundWallStone = string.Empty;
        }

        partial void OnHasImpactSound0WallStoneChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound0WallStone))
                    ImpactSound0WallStone = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound0WallStone = string.Empty;
        }

        partial void OnHasImpactSound1WallStoneChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound1WallStone))
                    ImpactSound1WallStone = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound1WallStone = string.Empty;
        }

        partial void OnHasImpactSound2WallStoneChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound2WallStone))
                    ImpactSound2WallStone = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound2WallStone = string.Empty;
        }

        partial void OnHasImpactSound3WallStoneChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound3WallStone))
                    ImpactSound3WallStone = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound3WallStone = string.Empty;
        }

        partial void OnHasImpactSound4WallStoneChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound4WallStone))
                    ImpactSound4WallStone = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound4WallStone = string.Empty;
        }

        partial void OnHasRicochetSoundDragonScaleChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(RicochetSoundDragonScale))
                    RicochetSoundDragonScale = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                RicochetSoundDragonScale = string.Empty;
        }

        partial void OnHasImpactSound0DragonScaleChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound0DragonScale))
                    ImpactSound0DragonScale = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound0DragonScale = string.Empty;
        }

        partial void OnHasImpactSound1DragonScaleChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound1DragonScale))
                    ImpactSound1DragonScale = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound1DragonScale = string.Empty;
        }

        partial void OnHasImpactSound2DragonScaleChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound2DragonScale))
                    ImpactSound2DragonScale = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound2DragonScale = string.Empty;
        }

        partial void OnHasImpactSound3DragonScaleChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound3DragonScale))
                    ImpactSound3DragonScale = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound3DragonScale = string.Empty;
        }

        partial void OnHasImpactSound4DragonScaleChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(ImpactSound4DragonScale))
                    ImpactSound4DragonScale = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                ImpactSound4DragonScale = string.Empty;
        }

        partial void OnHasTravelSoundChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(TravelSound))
                    TravelSound = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                TravelSound = string.Empty;
        }
    }

    public class BulletCustomInfoFactoryViewModel<T> : BulletCustomInfoFactoryViewModel where T : BulletCustomInfoFactory
    {
        public new T Model { get; }
        public BulletCustomInfoFactoryViewModel(T model) : base(model)
        {
            Model = model;
        }
    }
}
