using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CustomInfoFactories
{
    public partial class BlackHoleCustomInfoFactoryViewModel : CustomInfoDefinitionViewModel<BlackHoleCustomInfoFactory>
    {
        [Float]
        public string Magnitude
        {
            get => Model.Magnitude.ToString("F6");
            set => SetAndValidateProperty(Model.Magnitude.ToString(), value, Model, (m, s) => m.Magnitude = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string Radius
        {
            get => Model.Radius.ToString("F6");
            set => SetAndValidateProperty(Model.Radius.ToString(), value, Model, (m, s) => m.Radius = float.Parse(s));
        }

        public string VortexEffectName
        {
            get => Model.VortexEffectName;
            set => SetAndValidateProperty(Model.VortexEffectName, value, Model, (m, s) => m.VortexEffectName = s);
        }

        [Float(MinValue = 0)]
        public string AmbientSoundMaxDistance
        {
            get => Model.AmbientSoundMaxDistance.ToString("F6");
            set => SetAndValidateProperty(Model.AmbientSoundMaxDistance.ToString(), value, Model, (m, s) => m.AmbientSoundMaxDistance = float.Parse(s));
        }

        [ObservableProperty]
        public partial bool HasAmbientSoundName { get; set; }

        public string AmbientSoundName
        {
            get => Model.AmbientSoundName;
            set => SetAndValidateProperty(Model.AmbientSoundName, value, Model, (m, s) => m.AmbientSoundName = s);
        }

        public BlackHoleCustomInfoFactoryViewModel(BlackHoleCustomInfoFactory model) : base(model)
        {
        }

        partial void OnHasAmbientSoundNameChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(AmbientSoundName))
                    AmbientSoundName = AppSettings.SoundDialogues.FirstOrDefault();
            }
            else
                AmbientSoundName = string.Empty;
        }
    }
}
