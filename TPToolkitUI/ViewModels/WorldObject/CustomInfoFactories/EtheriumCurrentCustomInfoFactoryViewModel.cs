using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CustomInfoFactories
{
    public class EtheriumCurrentCustomInfoFactoryViewModel : CustomInfoDefinitionViewModel<EtheriumCurrentCustomInfoFactory>
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

        public EtheriumCurrentCustomInfoFactoryViewModel(EtheriumCurrentCustomInfoFactory model) : base(model)
        {
        }
    }
}
