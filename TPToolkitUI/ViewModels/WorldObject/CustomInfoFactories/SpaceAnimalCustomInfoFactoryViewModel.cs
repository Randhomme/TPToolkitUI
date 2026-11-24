using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitLib.WorldObject.Enums;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CustomInfoFactories
{
    public partial class SpaceAnimalCustomInfoFactoryViewModel : CustomInfoDefinitionViewModel<SpaceAnimalCustomInfoFactory>
    {
        [Float(MinValue = 0)]
        public string SelectedIndicatorPercentageOfRadius
        {
            get => Model.SelectedIndicatorPercentageOfRadius.ToString("F6");
            set => SetAndValidateProperty(Model.SelectedIndicatorPercentageOfRadius.ToString(), value, Model, (m, s) => m.SelectedIndicatorPercentageOfRadius = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string DistancetoStartSpherePicking
        {
            get => Model.DistancetoStartSpherePicking.ToString("F6");
            set => SetAndValidateProperty(Model.DistancetoStartSpherePicking.ToString(), value, Model, (m, s) => m.DistancetoStartSpherePicking = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string ShortestTimeBetweenSounds
        {
            get => Model.ShortestTimeBetweenSounds.ToString("F6");
            set => SetAndValidateProperty(Model.ShortestTimeBetweenSounds.ToString(), value, Model, (m, s) => m.ShortestTimeBetweenSounds = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string LongestTimeBetweenSounds
        {
            get => Model.LongestTimeBetweenSounds.ToString("F6");
            set => SetAndValidateProperty(Model.LongestTimeBetweenSounds.ToString(), value, Model, (m, s) => m.LongestTimeBetweenSounds = float.Parse(s));
        }

        [ObservableProperty]
        public partial bool HasSound_0 { get; set; }

        public string Sound_0
        {
            get => Model.Sound_0;
            set => SetAndValidateProperty(Model.Sound_0, value, Model, (m, s) => m.Sound_0 = s);
        }
        [ObservableProperty]
        public partial bool HasSound_1 { get; set; }

        public string Sound_1
        {
            get => Model.Sound_1;
            set => SetAndValidateProperty(Model.Sound_1, value, Model, (m, s) => m.Sound_1 = s);
        }
        [ObservableProperty]
        public partial bool HasSound_2 { get; set; }

        public string Sound_2
        {
            get => Model.Sound_2;
            set => SetAndValidateProperty(Model.Sound_2, value, Model, (m, s) => m.Sound_2 = s);
        }
        [ObservableProperty]
        public partial bool HasSound_3 { get; set; }

        public string Sound_3
        {
            get => Model.Sound_3;
            set => SetAndValidateProperty(Model.Sound_3, value, Model, (m, s) => m.Sound_3 = s);
        }
        [ObservableProperty]
        public partial bool HasSound_4 { get; set; }

        public string Sound_4
        {
            get => Model.Sound_4;
            set => SetAndValidateProperty(Model.Sound_4, value, Model, (m, s) => m.Sound_4 = s);
        }
        [ObservableProperty]
        public partial bool HasSound_5 { get; set; }

        public string Sound_5
        {
            get => Model.Sound_5;
            set => SetAndValidateProperty(Model.Sound_5, value, Model, (m, s) => m.Sound_5 = s);
        }
        [ObservableProperty]
        public partial bool HasSound_6 { get; set; }

        public string Sound_6
        {
            get => Model.Sound_6;
            set => SetAndValidateProperty(Model.Sound_6, value, Model, (m, s) => m.Sound_6 = s);
        }
        [ObservableProperty]
        public partial bool HasSound_7 { get; set; }

        public string Sound_7
        {
            get => Model.Sound_7;
            set => SetAndValidateProperty(Model.Sound_7, value, Model, (m, s) => m.Sound_7 = s);
        }
        [ObservableProperty]
        public partial bool HasSound_8 { get; set; }

        public string Sound_8
        {
            get => Model.Sound_8;
            set => SetAndValidateProperty(Model.Sound_8, value, Model, (m, s) => m.Sound_8 = s);
        }
        [ObservableProperty]
        public partial bool HasSound_9 { get; set; }

        public string Sound_9
        {
            get => Model.Sound_9;
            set => SetAndValidateProperty(Model.Sound_9, value, Model, (m, s) => m.Sound_9 = s);
        }

        public bool ReportSpotting
        {
            get => Model.ReportSpotting;
            set => SetAndValidateProperty(Model.ReportSpotting, value, Model, (m, b) => m.ReportSpotting = b);
        }

        [Float(MinValue = 0)]
        public string SoundDistance
        {
            get => Model.SoundDistance.ToString("F6");
            set => SetAndValidateProperty(Model.SoundDistance.ToString(), value, Model, (m, s) => m.SoundDistance = float.Parse(s));
        }

        public SpaceAnimalCustomInfoFactoryViewModel(SpaceAnimalCustomInfoFactory model) : base(model)
        {
            // This is the only spotter speech that works for space animals
            model.ReportType = GenericDialogSound.SPOTTER_WHALES;
        }

        partial void OnHasSound_0Changed(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(Sound_0))
                    Sound_0 = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                Sound_0 = string.Empty;
        }
        partial void OnHasSound_1Changed(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(Sound_1))
                    Sound_1 = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                Sound_1 = string.Empty;
        }
        partial void OnHasSound_2Changed(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(Sound_2))
                    Sound_2 = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                Sound_2 = string.Empty;
        }
        partial void OnHasSound_3Changed(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(Sound_3))
                    Sound_3 = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                Sound_3 = string.Empty;
        }
        partial void OnHasSound_4Changed(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(Sound_4))
                    Sound_4 = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                Sound_4 = string.Empty;
        }
        partial void OnHasSound_5Changed(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(Sound_5))
                    Sound_5 = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                Sound_5 = string.Empty;
        }
        partial void OnHasSound_6Changed(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(Sound_6))
                    Sound_6 = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                Sound_6 = string.Empty;
        }
        partial void OnHasSound_7Changed(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(Sound_7))
                    Sound_7 = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                Sound_7 = string.Empty;
        }
        partial void OnHasSound_8Changed(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(Sound_8))
                    Sound_8 = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                Sound_8 = string.Empty;
        }
        partial void OnHasSound_9Changed(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(Sound_9))
                    Sound_9 = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                Sound_9 = string.Empty;
        }
    }
}
