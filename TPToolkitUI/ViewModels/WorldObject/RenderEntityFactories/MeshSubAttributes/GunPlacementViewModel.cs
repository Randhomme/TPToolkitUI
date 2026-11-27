using TPToolkitLib.WorldObject;
using TPToolkitLib.WorldObject.Definitions.RenderEntityFactories.RenderEntityFactoryClasses.MeshAttributes;
using TPToolkitLib.WorldObject.Enums;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories.MeshSubAttributes
{
    public class GunPlacementViewModel(GunPlacement model) : MeshSubAttributePropertiesBaseViewModel<GunPlacement>(model)
    {
        public WorldObjectType? Gun
        {
            get => Model.Gun;
            set => SetAndValidateProperty(Model.Gun, value, Model, (m, wot) => m.Gun = wot);
        }

        [Float(MinValue = -360, MaxValue = 360)]
        public string MaxRotation
        {
            get => Model.MaxRotation.ToString("F6");
            set => SetAndValidateProperty(Model.MaxRotation.ToString(), value, Model, (m, s) => m.MaxRotation = float.Parse(s));
        }

        public Bank Bank
        {
            get => Model.Bank;
            set => SetAndValidateProperty(Model.Bank, value, Model, (m, b) => m.Bank = b);
        }
    }
}
