using TPToolkitLib.WorldObject.Definitions.RenderEntityFactories.RenderEntityFactoryClasses.MeshAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories.MeshSubAttributes
{
    public class WakePlacementViewModel(WakePlacement model) : MeshSubAttributePropertiesBaseViewModel<WakePlacement>(model)
    {
        public string EffectName
        {
            get => Model.EffectName;
            set => SetAndValidateProperty(Model.EffectName, value, Model, (m, s) => m.EffectName = s);
        }
    }
}
