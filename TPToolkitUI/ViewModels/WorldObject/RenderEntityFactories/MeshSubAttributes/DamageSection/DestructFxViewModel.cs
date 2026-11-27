using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.WorldObject.Definitions.RenderEntityFactories.RenderEntityFactoryClasses.MeshAttributes;
using TPToolkitUI.CustomAttributes;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories.MeshSubAttributes.DamageSection
{
    public partial class DestructFxViewModel(DestructFx model) : CustomObservableValidator
    {
        [ObservableProperty]
        public partial bool HasEffect { get; set; } = !model.Effect.Equals("none");

        public string Effect
        {
            get => Model.Effect;
            set => SetAndValidateProperty(Model.Effect, value, Model, (m, s) => m.Effect = s);
        }

        [Float(MinValue = 0)]
        public string Time
        {
            get => Model.Time.ToString("F6");
            set => SetAndValidateProperty(Model.Time.ToString(), value, Model, (m, s) => { m.Time = float.Parse(s); m.Value = m.Time + 0.2f; });
        }

        [Float]
        public string X
        {
            get => Model.X.ToString("F6");
            set => SetAndValidateProperty(Model.X.ToString(), value, Model, (m, s) => m.X = float.Parse(s));
        }

        [Float]
        public string Y
        {
            get => Model.Y.ToString("F6");
            set => SetAndValidateProperty(Model.Y.ToString(), value, Model, (m, s) => m.Y = float.Parse(s));
        }

        [Float]
        public string Z
        {
            get => Model.Z.ToString("F6");
            set => SetAndValidateProperty(Model.Z.ToString(), value, Model, (m, s) => m.Z = float.Parse(s));
        }

        public DestructFx Model { get; } = model;

        partial void OnHasEffectChanged(bool value)
        {
            if (value)
            {
                if (Effect.Equals("none"))
                    Effect = AppSettings.Effects.FirstOrDefault();
            }
            else
                Effect = "none";

        }

        public override string ToString()
        {
            return Effect;
        }
    }
}
