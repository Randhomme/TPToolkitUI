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
                case DockPoint dockPoint:
                    ModelPropertiesViewModel = new DockPointViewModel(dockPoint, meshScene.MsbAnimations);
                    MeshSubAttributeType = Enums.MeshSubAttribute.DockPoint;
                    break;
                case EnginePortPlacement enginePortPlacement:
                    ModelPropertiesViewModel = new EnginePortPlacementViewModel(enginePortPlacement);
                    MeshSubAttributeType = Enums.MeshSubAttribute.EnginePortPlacement;
                    break;
                case FlagAttachmentPoint flagAttachmentPoint:
                    ModelPropertiesViewModel = new FlagAttachmentPointViewModel(flagAttachmentPoint);
                    MeshSubAttributeType = Enums.MeshSubAttribute.FlagAttachmentPoint;
                    break;
                case FullyCloakedEffectPoint fullyCloakedEffectPoint:
                    ModelPropertiesViewModel = new FullyCloakedEffectPointViewModel(fullyCloakedEffectPoint);
                    MeshSubAttributeType = Enums.MeshSubAttribute.FullyCloakedEffectPoint;
                    break;
                case GunMuzzlePlacement gunMuzzlePlacement:
                    ModelPropertiesViewModel = new GunMuzzlePlacementViewModel(gunMuzzlePlacement);
                    MeshSubAttributeType = Enums.MeshSubAttribute.GunMuzzlePlacement;
                    break;
                case GunPlacement gunPlacement:
                    ModelPropertiesViewModel = new GunPlacementViewModel(gunPlacement);
                    MeshSubAttributeType = Enums.MeshSubAttribute.GunPlacement;
                    break;
                case GunVerticalPivotPlacement gunVerticalPivotPlacement:
                    ModelPropertiesViewModel = new GunVerticalPivotPlacementViewModel(gunVerticalPivotPlacement);
                    MeshSubAttributeType = Enums.MeshSubAttribute.GunVerticalPivotPlacement;
                    break;
                case MeshHitPoints meshHitPoints:
                    ModelPropertiesViewModel = new MeshHitPointsViewModel(meshHitPoints);
                    MeshSubAttributeType = Enums.MeshSubAttribute.MeshHitPoints;
                    break;
                case PlayEffect playEffect:
                    ModelPropertiesViewModel = new PlayEffectViewModel(playEffect);
                    MeshSubAttributeType = Enums.MeshSubAttribute.PlayEffect;
                    break;
                case TorpedoHomingPoint torpedoHomingPoint:
                    ModelPropertiesViewModel = new TorpedoHomingPointViewModel(torpedoHomingPoint);
                    MeshSubAttributeType = Enums.MeshSubAttribute.TorpedoHomingPoint;
                    break;
                case ToweePoint toweePoint:
                    ModelPropertiesViewModel = new ToweePointViewModel(toweePoint);
                    MeshSubAttributeType = Enums.MeshSubAttribute.ToweePoint;
                    break;
                case TowerPoint towerPoint:
                    ModelPropertiesViewModel = new TowerPointViewModel(towerPoint);
                    MeshSubAttributeType = Enums.MeshSubAttribute.TowerPoint;
                    break;
                case VolcanoSmoke volcanoSmoke:
                    ModelPropertiesViewModel = new VolcanoSmokeViewModel(volcanoSmoke);
                    MeshSubAttributeType = Enums.MeshSubAttribute.VolcanoSmoke;
                    break;
                case WakePlacement wakePlacement:
                    ModelPropertiesViewModel = new WakePlacementViewModel(wakePlacement);
                    MeshSubAttributeType = Enums.MeshSubAttribute.WakePlacement;
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
                    Enums.MeshSubAttribute.DockPoint => new DockPointViewModel(new(), meshScene.MsbAnimations),
                    Enums.MeshSubAttribute.EnginePortPlacement => new EnginePortPlacementViewModel(new()),
                    Enums.MeshSubAttribute.FlagAttachmentPoint => new FlagAttachmentPointViewModel(new()),
                    Enums.MeshSubAttribute.FullyCloakedEffectPoint => new FullyCloakedEffectPointViewModel(new()),
                    Enums.MeshSubAttribute.GunMuzzlePlacement => new GunMuzzlePlacementViewModel(new()),
                    Enums.MeshSubAttribute.GunPlacement => new GunPlacementViewModel(new()),
                    Enums.MeshSubAttribute.GunVerticalPivotPlacement => new GunVerticalPivotPlacementViewModel(new()),
                    Enums.MeshSubAttribute.MeshHitPoints => new MeshHitPointsViewModel(new()),
                    Enums.MeshSubAttribute.PlayEffect => new PlayEffectViewModel(new()),
                    Enums.MeshSubAttribute.TorpedoHomingPoint => new TorpedoHomingPointViewModel(new()),
                    Enums.MeshSubAttribute.ToweePoint => new ToweePointViewModel(new()),
                    Enums.MeshSubAttribute.TowerPoint => new TowerPointViewModel(new()),
                    Enums.MeshSubAttribute.VolcanoSmoke => new VolcanoSmokeViewModel(new()),
                    Enums.MeshSubAttribute.WakePlacement => new WakePlacementViewModel(new()),
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
