using TPToolkitLib.WorldObject.Definitions.RenderEntityFactories.RenderEntityFactoryClasses.MeshAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories.MeshSubAttributes
{
    public class MeshHitPointsViewModel(MeshHitPoints model) : MeshSubAttributePropertiesBaseViewModel<MeshHitPoints>(model)
    {
        public string AssociationName
        {
            get => Model.AssociationName;
            set => SetAndValidateProperty(Model.AssociationName, value, Model, (m, s) => m.AssociationName = s);
        }
    }
}
