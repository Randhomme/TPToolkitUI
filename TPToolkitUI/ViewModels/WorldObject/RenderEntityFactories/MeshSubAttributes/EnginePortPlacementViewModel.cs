using TPToolkitLib.WorldObject.Definitions.RenderEntityFactories.RenderEntityFactoryClasses.MeshAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories.MeshSubAttributes
{
    public class EnginePortPlacementViewModel(EnginePortPlacement model) : MeshSubAttributePropertiesBaseViewModel<EnginePortPlacement>(model)
    {
        public string EffectName
        {
            get => Model.EffectName;
            set => SetAndValidateProperty(Model.EffectName, value, Model, (m, s) => m.EffectName = s);
        }
    }
}
