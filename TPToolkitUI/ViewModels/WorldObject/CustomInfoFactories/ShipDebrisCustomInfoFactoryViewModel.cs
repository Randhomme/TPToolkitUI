using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CustomInfoFactories
{
    public class ShipDebrisCustomInfoFactoryViewModel : CustomInfoDefinitionViewModel<ShipDebrisCustomInfoFactory>
    {
        [Float(MinValue = 0)]
        public string LifeTimeMin
        {
            get => Model.LifeTimeMin.ToString("F6");
            set => SetAndValidateProperty(Model.LifeTimeMin.ToString(), value, Model, (m, s) => m.LifeTimeMin = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string LifeTimeMax
        {
            get => Model.LifeTimeMax.ToString("F6");
            set => SetAndValidateProperty(Model.LifeTimeMax.ToString(), value, Model, (m, s) => m.LifeTimeMax = float.Parse(s));
        }
        public ShipDebrisCustomInfoFactoryViewModel(ShipDebrisCustomInfoFactory model) : base(model)
        {
        }
    }
}
