using TPToolkitLib.WorldObject.Definitions.AiEntityFactories;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.AiEntityFactories
{
    public class ShipAIViewModel : AiEntityDefinitionViewModel<ShipAI>
    {
        [Float(MinValue = 0)]
        public string DefaultSightRange
        {
            get => Model.DefaultSightRange.ToString("F6");
            set => SetAndValidateProperty(Model.DefaultSightRange.ToString(), value, Model, (m, s) => m.DefaultSightRange = float.Parse(value));
        }

        public ShipAIViewModel(ShipAI model) : base(model)
        {
        }
    }
}
