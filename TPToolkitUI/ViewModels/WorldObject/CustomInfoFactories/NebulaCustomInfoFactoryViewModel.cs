using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CustomInfoFactories
{
    public partial class NebulaCustomInfoFactoryViewModel : CustomInfoDefinitionViewModel<NebulaCustomInfoFactory>
    {
        [Float(MinValue = 0)]
        public string MinimumLightningSpawnDistanceFromShips
        {
            get => Model.MinimumLightningSpawnDistanceFromShips.ToString("F6");
            set => SetAndValidateProperty(Model.MinimumLightningSpawnDistanceFromShips.ToString(), value, Model, (m, s) => m.MinimumLightningSpawnDistanceFromShips = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string MinimumLightningBoltLength
        {
            get => Model.MinimumLightningBoltLength.ToString("F6");
            set => SetAndValidateProperty(Model.MinimumLightningBoltLength.ToString(), value, Model, (m, s) => m.MinimumLightningBoltLength = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string MaximumLightningSpawnPointZAmplitude
        {
            get => Model.MaximumLightningSpawnPointZAmplitude.ToString("F6");
            set => SetAndValidateProperty(Model.MaximumLightningSpawnPointZAmplitude.ToString(), value, Model, (m, s) => m.MaximumLightningSpawnPointZAmplitude = float.Parse(s));
        }

        [Float(MinValue = 0, MaxValue = 100)]
        public string MeteorHitChanceModifier
        {
            get => Model.MeteorHitChanceModifier.ToString("F6");
            set => SetAndValidateProperty(Model.MeteorHitChanceModifier.ToString(), value, Model, (m, s) => m.MeteorHitChanceModifier = float.Parse(s));
        }

        public DamagePotentialViewModel LightningDamagePotentialViewModel { get; }
        public DamagePotentialViewModel WindDamagePotentialViewModel { get; }
        public DamagePotentialViewModel MeteorDamagePotentialViewModel { get; }

        [ObservableProperty]
        public partial bool HasNebulaSoundName { get; set; }

        public string NebulaSoundName
        {
            get => Model.NebulaSoundName;
            set => SetAndValidateProperty(Model.NebulaSoundName, value, Model, (m, s) => m.NebulaSoundName = s);
        }

        [ObservableProperty]
        public partial bool HasSolarStormSoundName { get; set; }

        public string SolarStormSoundName
        {
            get => Model.SolarStormSoundName;
            set => SetAndValidateProperty(Model.SolarStormSoundName, value, Model, (m, s) => m.SolarStormSoundName = s);
        }

        [ObservableProperty]
        public partial bool HasMeteorShowerSoundName { get; set; }

        public string MeteorShowerSoundName
        {
            get => Model.MeteorShowerSoundName;
            set => SetAndValidateProperty(Model.MeteorShowerSoundName, value, Model, (m, s) => m.MeteorShowerSoundName = s);
        }

        public NebulaCustomInfoFactoryViewModel(NebulaCustomInfoFactory model) : base(model)
        {
            LightningDamagePotentialViewModel = new(model.LightningDamagePotential);
            WindDamagePotentialViewModel = new(model.WindDamagePotential);
            MeteorDamagePotentialViewModel = new(model.MeteorDamagePotential);
        }

        partial void OnHasMeteorShowerSoundNameChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(MeteorShowerSoundName))
                    MeteorShowerSoundName = AppSettings.SoundDialogues.FirstOrDefault();
            }
            else
                MeteorShowerSoundName = string.Empty;
        }

        partial void OnHasNebulaSoundNameChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(NebulaSoundName))
                    NebulaSoundName = AppSettings.SoundDialogues.FirstOrDefault();
            }
            else
                NebulaSoundName = string.Empty;
        }

        partial void OnHasSolarStormSoundNameChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(SolarStormSoundName))
                    SolarStormSoundName = AppSettings.SoundDialogues.FirstOrDefault();
            }
            else
                SolarStormSoundName = string.Empty;
        }
    }
}
