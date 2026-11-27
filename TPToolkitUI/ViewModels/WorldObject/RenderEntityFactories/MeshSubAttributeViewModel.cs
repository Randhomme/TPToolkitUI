using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitLib.WorldObject.Definitions.RenderEntityFactories.RenderEntityFactoryClasses;
using TPToolkitLib.WorldObject.Definitions.RenderEntityFactories.RenderEntityFactoryClasses.MeshAttributes;
using TPToolkitUI.Utils;
using TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories.MeshSubAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories
{
    public partial class MeshSubAttributeViewModel : CustomObservableValidator
    {
        private readonly bool shouldUpdatePropertiesViewModelFromUI = true;
        private readonly MsbScene meshScene;

        public MeshSubAttribute Model { get; }

        [ObservableProperty]
        public partial Enums.MeshSubAttribute MeshSubAttributeType { get; set; }

        [ObservableProperty]
        public partial MeshSubAttributePropertiesBaseViewModel? ModelPropertiesViewModel { get; private set; }

        public MeshSubAttributeViewModel(MeshSubAttribute model, MsbScene meshScene)
        {
            Model = model;
            shouldUpdatePropertiesViewModelFromUI = false;
            this.meshScene = meshScene;
            switch (Model)
            {
                case BoardingEffectPoint boardingEffectPoint:
                    ModelPropertiesViewModel = new BoardingEffectPointViewModel(boardingEffectPoint);
                    MeshSubAttributeType = Enums.MeshSubAttribute.BoardingEffectPoint;
                    break;
                case CloakingEffectPoint cloakingEffectPoint:
                    ModelPropertiesViewModel = new CloakingEffectPointViewModel(cloakingEffectPoint);
                    MeshSubAttributeType = Enums.MeshSubAttribute.CloakingEffectPoint;
                    break;
                case DamageSection damageSection:
                    ModelPropertiesViewModel = new DamageSectionViewModel(damageSection, meshScene)
                    {
                        HasDebrisMeshScene = damageSection.DebrisMsbScene != null,
                    };
                    MeshSubAttributeType = Enums.MeshSubAttribute.DamageSection;
                    break;
            }
            shouldUpdatePropertiesViewModelFromUI = true;
        }

        partial void OnMeshSubAttributeTypeChanged(Enums.MeshSubAttribute value)
        {
            if (shouldUpdatePropertiesViewModelFromUI)
            {
                ModelPropertiesViewModel = value switch
                {
                    Enums.MeshSubAttribute.BoardingEffectPoint => new BoardingEffectPointViewModel(new()),
                    Enums.MeshSubAttribute.CloakingEffectPoint => new CloakingEffectPointViewModel(new()),
                    Enums.MeshSubAttribute.DamageSection => new DamageSectionViewModel(new(), meshScene),
                    _ => null,
                };
            }
        }

        public override string ToString()
        {
            return MeshSubAttributeType.ToString();
        }
    }

    public abstract class MeshSubAttributePropertiesBaseViewModel : CustomObservableValidator
    {
    }

    public abstract class MeshSubAttributePropertiesBaseViewModel<T> : MeshSubAttributePropertiesBaseViewModel where T : MeshSubAttribute
    {
        public T Model { get; }
        public MeshSubAttributePropertiesBaseViewModel(T model)
        {
            Model = model;
        }
    }
}
