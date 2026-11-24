using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CustomInfoFactories
{
    public class StarMortarCustomInfoFactoryViewModel : BulletCustomInfoFactoryViewModel<StarMortarCustomInfoFactory>
    {
        public string Magnitude
        {
            get => Model.Magnitude.ToString("F6");
            set => SetAndValidateProperty(Model.Magnitude.ToString(), value, Model, (m, s) => m.Magnitude = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string Duration
        {
            get => Model.Duration.ToString("F6");
            set => SetAndValidateProperty(Model.Duration.ToString(), value, Model, (m, s) => m.Duration = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string MaxRadius
        {
            get => Model.MaxRadius.ToString("F6");
            set => SetAndValidateProperty(Model.MaxRadius.ToString(), value, Model, (m, s) => m.MaxRadius = float.Parse(s));
        }

        public StarMortarCustomInfoFactoryViewModel(StarMortarCustomInfoFactory model) : base(model)
        {
        }
    }
}
