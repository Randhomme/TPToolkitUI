using TPToolkitLib.WorldObject.Definitions.RenderEntityFactories.RenderEntityFactoryClasses.MeshAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories.MeshSubAttributes
{
    public class PlayEffectViewModel(PlayEffect model) : MeshSubAttributePropertiesBaseViewModel<PlayEffect>(model)
    {
        public string EffectName
        {
            get => Model.EffectName;
            set => SetAndValidateProperty(Model.EffectName, value, Model, (m, s) => m.EffectName = s);
        }
    }
}
