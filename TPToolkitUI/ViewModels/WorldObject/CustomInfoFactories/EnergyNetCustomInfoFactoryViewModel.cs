using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CustomInfoFactories
{
    public class EnergyNetCustomInfoFactoryViewModel : BulletCustomInfoFactoryViewModel<EnergyNetCustomInfoFactory>
    {
        [Float(MinValue = 0)]
        public string Duration
        {
            get => Model.Duration.ToString("F6");
            set => SetAndValidateProperty(Model.Duration.ToString(), value, Model, (m, s) => m.Duration = float.Parse(s));
        }

        [Float]
        public string PercentageOfEnergyDissipated
        {
            get => Model.PercentageOfEnergyDissipated.ToString("F6");
            set => SetAndValidateProperty(Model.PercentageOfEnergyDissipated.ToString(), value, Model, (m, s) => m.PercentageOfEnergyDissipated = float.Parse(s));
        }

        public EnergyNetCustomInfoFactoryViewModel(EnergyNetCustomInfoFactory model) : base(model)
        {
        }
    }
}
