using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using TPToolkitLib.Tools;
using TPToolkitLib.WorldObject;
using TPToolkitLib.WorldObject.Definitions.AiEntityFactories;
using TPToolkitLib.WorldObject.Definitions.CollisionFactories;
using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitLib.WorldObject.Definitions.PhysicsFactories;
using TPToolkitUI.Enums;
using TPToolkitUI.Services;
using TPToolkitUI.ViewModels.WorldObject;
using TPToolkitUI.ViewModels.WorldObject.AiEntityFactories;
using TPToolkitUI.ViewModels.WorldObject.CollisionFactories;
using TPToolkitUI.ViewModels.WorldObject.CustomInfoFactories;
using TPToolkitUI.ViewModels.WorldObject.PhysicsFactories;
using TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories;

namespace TPToolkitUI.ViewModels
{
    public partial class WorldObjectViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;
        private readonly AppSettings settings;
        private string worldObjectTypeString = string.Empty;
        private bool shouldUpdateViewModelsFromUI = true;

        [ObservableProperty]
        public partial AiEntityFactory AiEntityFactory { get; set; }
        [ObservableProperty]
        public partial CollisionFactory CollisionFactory { get; set; }
        [ObservableProperty]
        public partial CustomInfoFactory CustomInfoFactory { get; set; }
        [ObservableProperty]
        public partial PhysicsFactory PhysicsFactory { get; set; }
        [ObservableProperty]
        public partial RenderEntityFactory RenderEntityFactory { get; set; }
        [ObservableProperty]
        public partial AiEntityDefinitionViewModel? AiEntityDefinitionViewModel { get; private set; }
        [ObservableProperty]
        public partial CollisionDefinitionViewModel? CollisionDefinitionViewModel { get; private set; }
        [ObservableProperty]
        public partial CustomInfoDefinitionViewModel? CustomInfoDefinitionViewModel { get; private set; }
        [ObservableProperty]
        public partial PhysicsDefinitionViewModel? PhysicsDefinitionViewModel { get; private set; }
        [ObservableProperty]
        public partial RenderEntityDefinitionViewModel? RenderEntityDefinitionViewModel { get; private set; }

        public WorldObjectViewModel(IDialogService dialogService, AppSettings settings)
        {
            this.dialogService = dialogService;
            this.settings = settings;
        }

        partial void OnAiEntityFactoryChanged(AiEntityFactory value)
        {
            if (shouldUpdateViewModelsFromUI)
            {
                AiEntityDefinitionViewModel = value switch
                {
                    AiEntityFactory.DragonAI => new DragonAIViewModel(new(worldObjectTypeString)),
                    AiEntityFactory.GunAI => new GunAIViewModel(new(worldObjectTypeString)),
                    AiEntityFactory.IslandAI => new IslandAIViewModel(new(worldObjectTypeString)),
                    AiEntityFactory.MineAI => new MineAIViewModel(new(worldObjectTypeString)),
                    AiEntityFactory.ShipAI => new ShipAIViewModel(new(worldObjectTypeString)),
                    AiEntityFactory.SpaceAnimalAI => new SpaceAnimalAIViewModel(new(worldObjectTypeString)),
                    AiEntityFactory.SpaceObjectAI => new SpaceObjectAIViewModel(new(worldObjectTypeString)),
                    AiEntityFactory.VolcanoAI => new VolcanoAIViewModel(new(worldObjectTypeString)),
                    _ => null
                };
            }
        }

        partial void OnCollisionFactoryChanged(CollisionFactory value)
        {
            if (shouldUpdateViewModelsFromUI)
            {
                CollisionDefinitionViewModel = value switch
                {
                    CollisionFactory.BoundingRenderEntity => new BoundingRenderEntityViewModel(new(worldObjectTypeString)),
                    CollisionFactory.BoundingSphere => new BoundingSphereViewModel(new(worldObjectTypeString)),
                    CollisionFactory.Point => new PointViewModel(new(worldObjectTypeString)),
                    _ => null,
                };
            }
        }

        partial void OnCustomInfoFactoryChanged(CustomInfoFactory value)
        {
            if (shouldUpdateViewModelsFromUI)
            {
                CustomInfoDefinitionViewModel = value switch
                {
                    CustomInfoFactory.AsteroidCustomInfoFactory => new AsteroidCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.BlackHoleCustomInfoFactory => new BlackHoleCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.BulletCustomInfoFactory => new BulletCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.CrewCustomInfoFactory => new CrewCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.DragonCustomInfoFactory => new DragonCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.EnergyNetCustomInfoFactory => new EnergyNetCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.EtheriumCurrentCustomInfoFactory => new EtheriumCurrentCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.GrapplingHarpoonCustomInfoFactory => new GrapplingHarpoonCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.GravChargeCustomInfoFactory => new GravChargeCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.GunCustomInfoFactory => new GunCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.IslandCustomInfoFactory => new IslandCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.MineCustomInfoFactory => new MineCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.NebulaCustomInfoFactory => new NebulaCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.NovaMortarCustomInfoFactory => new NovaMortarCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.ShipCustomInfoFactory => new ShipCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.ShipDebrisCustomInfoFactory => new ShipDebrisCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.SpaceAnimalCustomInfoFactory => new SpaceAnimalCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.StarMortarCustomInfoFactory => new StarMortarCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    CustomInfoFactory.TorpedoCustomInfoFactory => new TorpedoCustomInfoFactoryViewModel(new(worldObjectTypeString)),
                    _ => null,
                };
            }
        }

        partial void OnPhysicsFactoryChanged(PhysicsFactory value)
        {
            if (shouldUpdateViewModelsFromUI)
            {
                PhysicsDefinitionViewModel = value switch
                {
                    PhysicsFactory.DragonPhysics => new DragonPhysicsViewModel(new(worldObjectTypeString)),
                    PhysicsFactory.MinePhysics => new MinePhysicsViewModel(new(worldObjectTypeString)),
                    PhysicsFactory.ProjectilePhysics => new ProjectilePhysicsViewModel(new(worldObjectTypeString)),
                    PhysicsFactory.ShipDemo => new ShipDemoViewModel(new(worldObjectTypeString)),
                    PhysicsFactory.SpaceObjectPhysics => new SpaceObjectPhysicsViewModel(new(worldObjectTypeString)),
                    PhysicsFactory.TorpedoPhysics => new TorpedoPhysicsViewModel(new(worldObjectTypeString)),
                    PhysicsFactory.WhalePhysics => new WhalePhysicsViewModel(new(worldObjectTypeString)),
                    _ => null,
                };
            }
        }

        partial void OnRenderEntityFactoryChanged(RenderEntityFactory value)
        {
            if (shouldUpdateViewModelsFromUI)
            {
                RenderEntityDefinitionViewModel = value switch
                {
                    RenderEntityFactory.RenderEntityFactory => new RenderEntityFactoryViewModel(new(worldObjectTypeString)),
                    _ => null,
                };
            }
        }

        [RelayCommand]
        private void OnImportWorldObject()
        {
            var worldObjectFilePath = dialogService.BrowseFileImport("Select you world object file", "World object (.wot)|*wot", ".wot", settings.LastWorldObjectImportDirectory);
            if (!string.IsNullOrWhiteSpace(worldObjectFilePath))
            {
                settings.LastWorldObjectImportDirectory = Path.GetDirectoryName(worldObjectFilePath);
                dialogService.StartAsyncWorkWithProgress((p, l) => ImportWorldObject(worldObjectFilePath, p, l), true, true);
            }
        }

        private void ImportWorldObject(string worldObjectFilePath, IProgress<string> progress, IProgress<string> logs)
        {
            progress.Report("Importing world object ...");
            try
            {
                var wot = WotTool.WorldObjectFromWot(worldObjectFilePath);
                worldObjectTypeString = wot.Type;
                SetViewModelsFromWorldObjectType(wot);
                progress.Report("World object successfully imported !");
            }
            catch (Exception ex)
            {
                logs.Report(ex.Message);
                progress.Report("Fail to import world object");
            }
        }

        private void SetViewModelsFromWorldObjectType(WorldObjectType worldObjectType)
        {
            shouldUpdateViewModelsFromUI = false;
            switch (worldObjectType.AiEntityDefinition)
            {
                case DragonAI dragonAI:
                    AiEntityDefinitionViewModel = new DragonAIViewModel(dragonAI);
                    AiEntityFactory = AiEntityFactory.DragonAI;
                    break;
                case GunAI gunAI:
                    AiEntityDefinitionViewModel = new GunAIViewModel(gunAI);
                    AiEntityFactory = AiEntityFactory.GunAI;
                    break;
                case IslandAI islandAI:
                    AiEntityDefinitionViewModel = new IslandAIViewModel(islandAI);
                    AiEntityFactory = AiEntityFactory.IslandAI;
                    break;
                case MineAI mineAI:
                    AiEntityDefinitionViewModel = new MineAIViewModel(mineAI);
                    AiEntityFactory = AiEntityFactory.MineAI;
                    break;
                case ShipAI shipAI:
                    AiEntityDefinitionViewModel = new ShipAIViewModel(shipAI);
                    AiEntityFactory = AiEntityFactory.ShipAI;
                    break;
                case SpaceAnimalAI spaceAnimalAI:
                    AiEntityDefinitionViewModel = new SpaceAnimalAIViewModel(spaceAnimalAI);
                    AiEntityFactory = AiEntityFactory.SpaceAnimalAI;
                    break;
                case SpaceObjectAI spaceObjectAI:
                    AiEntityDefinitionViewModel = new SpaceObjectAIViewModel(spaceObjectAI);
                    AiEntityFactory = AiEntityFactory.SpaceObjectAI;
                    break;
                case VolcanoAI volcanoAI:
                    AiEntityDefinitionViewModel = new VolcanoAIViewModel(volcanoAI);
                    AiEntityFactory = AiEntityFactory.VolcanoAI;
                    break;
                default:
                    AiEntityDefinitionViewModel = null;
                    AiEntityFactory = AiEntityFactory.None;
                    break;
            }
            switch (worldObjectType.CollisionDefinition)
            {
                case BoundingRenderEntity boundingRenderEntity:
                    CollisionDefinitionViewModel = new BoundingRenderEntityViewModel(boundingRenderEntity);
                    CollisionFactory = CollisionFactory.BoundingRenderEntity;
                    break;
                case BoundingSphere boundingSphere:
                    CollisionDefinitionViewModel = new BoundingSphereViewModel(boundingSphere);
                    CollisionFactory = CollisionFactory.BoundingSphere;
                    break;
                case Point point:
                    CollisionDefinitionViewModel = new PointViewModel(point);
                    CollisionFactory = CollisionFactory.Point;
                    break;
                default:
                    CollisionDefinitionViewModel = null;
                    CollisionFactory = CollisionFactory.None;
                    break;
            }
            switch (worldObjectType.CustomInfoDefinition)
            {
                case AsteroidCustomInfoFactory asteroidCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new AsteroidCustomInfoFactoryViewModel(asteroidCustomInfoFactory)
                    {
                        HasWorldObjectToCreateUponDeath0 = asteroidCustomInfoFactory.WorldObjectToCreateUponDeath0 != null,
                        HasWorldObjectToCreateUponDeath1 = asteroidCustomInfoFactory.WorldObjectToCreateUponDeath1 != null,
                        HasWorldObjectToCreateUponDeath2 = asteroidCustomInfoFactory.WorldObjectToCreateUponDeath2 != null,
                        HasWorldObjectToCreateUponDeath3 = asteroidCustomInfoFactory.WorldObjectToCreateUponDeath3 != null,
                        HasWorldObjectToCreateUponDeath4 = asteroidCustomInfoFactory.WorldObjectToCreateUponDeath4 != null,
                        HasWorldObjectToCreateUponDeath5 = asteroidCustomInfoFactory.WorldObjectToCreateUponDeath5 != null,
                        HasWorldObjectToCreateUponDeath6 = asteroidCustomInfoFactory.WorldObjectToCreateUponDeath6 != null,
                        HasWorldObjectToCreateUponDeath7 = asteroidCustomInfoFactory.WorldObjectToCreateUponDeath7 != null,
                        HasWorldObjectToCreateUponDeath8 = asteroidCustomInfoFactory.WorldObjectToCreateUponDeath8 != null,
                        HasWorldObjectToCreateUponDeath9 = asteroidCustomInfoFactory.WorldObjectToCreateUponDeath9 != null,
                    };
                    CustomInfoFactory = CustomInfoFactory.AsteroidCustomInfoFactory;
                    break;
                case BlackHoleCustomInfoFactory blackHoleCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new BlackHoleCustomInfoFactoryViewModel(blackHoleCustomInfoFactory)
                    {
                        HasAmbientSoundName = !string.IsNullOrWhiteSpace(blackHoleCustomInfoFactory.AmbientSoundName),
                    };
                    CustomInfoFactory = CustomInfoFactory.BlackHoleCustomInfoFactory;
                    break;
                case EnergyNetCustomInfoFactory energyNetCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new EnergyNetCustomInfoFactoryViewModel(energyNetCustomInfoFactory)
                    {
                        HasImpactSound0DragonScale = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound0DragonScale),
                        HasImpactSound1DragonScale = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound1DragonScale),
                        HasImpactSound2DragonScale = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound2DragonScale),
                        HasImpactSound3DragonScale = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound3DragonScale),
                        HasImpactSound4DragonScale = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound4DragonScale),
                        HasImpactSound0HullIron = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound0HullIron),
                        HasImpactSound1HullIron = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound1HullIron),
                        HasImpactSound2HullIron = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound2HullIron),
                        HasImpactSound3HullIron = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound3HullIron),
                        HasImpactSound4HullIron = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound4HullIron),
                        HasImpactSound0HullReInforcedWood = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound0HullReInforcedWood),
                        HasImpactSound1HullReInforcedWood = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound1HullReInforcedWood),
                        HasImpactSound2HullReInforcedWood = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound2HullReInforcedWood),
                        HasImpactSound3HullReInforcedWood = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound3HullReInforcedWood),
                        HasImpactSound4HullReInforcedWood = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound4HullReInforcedWood),
                        HasImpactSound0HullWood = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound0HullWood),
                        HasImpactSound1HullWood = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound1HullWood),
                        HasImpactSound2HullWood = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound2HullWood),
                        HasImpactSound3HullWood = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound3HullWood),
                        HasImpactSound4HullWood = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound4HullWood),
                        HasImpactSound0SailCloth = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound0SailCloth),
                        HasImpactSound1SailCloth = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound1SailCloth),
                        HasImpactSound2SailCloth = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound2SailCloth),
                        HasImpactSound3SailCloth = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound3SailCloth),
                        HasImpactSound4SailCloth = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound4SailCloth),
                        HasImpactSound0WallStone = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound0WallStone),
                        HasImpactSound1WallStone = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound1WallStone),
                        HasImpactSound2WallStone = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound2WallStone),
                        HasImpactSound3WallStone = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound3WallStone),
                        HasImpactSound4WallStone = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.ImpactSound4WallStone),
                        HasRicochetSoundDragonScale = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.RicochetSoundDragonScale),
                        HasRicochetSoundHullIron = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.RicochetSoundHullIron),
                        HasRicochetSoundHullReInforcedWood = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.RicochetSoundHullReInforcedWood),
                        HasRicochetSoundHullWood = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.RicochetSoundHullWood),
                        HasRicochetSoundSailCloth = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.RicochetSoundSailCloth),
                        HasRicochetSoundWallStone = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.RicochetSoundWallStone),
                        HasTravelSound = !string.IsNullOrWhiteSpace(energyNetCustomInfoFactory.TravelSound),
                    };
                    CustomInfoFactory = CustomInfoFactory.EnergyNetCustomInfoFactory;
                    break;
                case GrapplingHarpoonCustomInfoFactory grapplingHarpoonCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new GrapplingHarpoonCustomInfoFactoryViewModel(grapplingHarpoonCustomInfoFactory)
                    {
                        HasImpactSound0DragonScale = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound0DragonScale),
                        HasImpactSound1DragonScale = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound1DragonScale),
                        HasImpactSound2DragonScale = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound2DragonScale),
                        HasImpactSound3DragonScale = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound3DragonScale),
                        HasImpactSound4DragonScale = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound4DragonScale),
                        HasImpactSound0HullIron = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound0HullIron),
                        HasImpactSound1HullIron = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound1HullIron),
                        HasImpactSound2HullIron = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound2HullIron),
                        HasImpactSound3HullIron = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound3HullIron),
                        HasImpactSound4HullIron = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound4HullIron),
                        HasImpactSound0HullReInforcedWood = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound0HullReInforcedWood),
                        HasImpactSound1HullReInforcedWood = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound1HullReInforcedWood),
                        HasImpactSound2HullReInforcedWood = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound2HullReInforcedWood),
                        HasImpactSound3HullReInforcedWood = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound3HullReInforcedWood),
                        HasImpactSound4HullReInforcedWood = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound4HullReInforcedWood),
                        HasImpactSound0HullWood = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound0HullWood),
                        HasImpactSound1HullWood = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound1HullWood),
                        HasImpactSound2HullWood = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound2HullWood),
                        HasImpactSound3HullWood = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound3HullWood),
                        HasImpactSound4HullWood = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound4HullWood),
                        HasImpactSound0SailCloth = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound0SailCloth),
                        HasImpactSound1SailCloth = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound1SailCloth),
                        HasImpactSound2SailCloth = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound2SailCloth),
                        HasImpactSound3SailCloth = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound3SailCloth),
                        HasImpactSound4SailCloth = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound4SailCloth),
                        HasImpactSound0WallStone = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound0WallStone),
                        HasImpactSound1WallStone = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound1WallStone),
                        HasImpactSound2WallStone = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound2WallStone),
                        HasImpactSound3WallStone = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound3WallStone),
                        HasImpactSound4WallStone = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.ImpactSound4WallStone),
                        HasRicochetSoundDragonScale = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.RicochetSoundDragonScale),
                        HasRicochetSoundHullIron = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.RicochetSoundHullIron),
                        HasRicochetSoundHullReInforcedWood = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.RicochetSoundHullReInforcedWood),
                        HasRicochetSoundHullWood = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.RicochetSoundHullWood),
                        HasRicochetSoundSailCloth = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.RicochetSoundSailCloth),
                        HasRicochetSoundWallStone = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.RicochetSoundWallStone),
                        HasTravelSound = !string.IsNullOrWhiteSpace(grapplingHarpoonCustomInfoFactory.TravelSound),
                    };
                    CustomInfoFactory = CustomInfoFactory.GrapplingHarpoonCustomInfoFactory;
                    break;

                case GravChargeCustomInfoFactory gravChargeCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new GravChargeCustomInfoFactoryViewModel(gravChargeCustomInfoFactory)
                    {
                        HasImpactSound0DragonScale = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound0DragonScale),
                        HasImpactSound1DragonScale = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound1DragonScale),
                        HasImpactSound2DragonScale = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound2DragonScale),
                        HasImpactSound3DragonScale = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound3DragonScale),
                        HasImpactSound4DragonScale = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound4DragonScale),
                        HasImpactSound0HullIron = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound0HullIron),
                        HasImpactSound1HullIron = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound1HullIron),
                        HasImpactSound2HullIron = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound2HullIron),
                        HasImpactSound3HullIron = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound3HullIron),
                        HasImpactSound4HullIron = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound4HullIron),
                        HasImpactSound0HullReInforcedWood = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound0HullReInforcedWood),
                        HasImpactSound1HullReInforcedWood = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound1HullReInforcedWood),
                        HasImpactSound2HullReInforcedWood = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound2HullReInforcedWood),
                        HasImpactSound3HullReInforcedWood = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound3HullReInforcedWood),
                        HasImpactSound4HullReInforcedWood = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound4HullReInforcedWood),
                        HasImpactSound0HullWood = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound0HullWood),
                        HasImpactSound1HullWood = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound1HullWood),
                        HasImpactSound2HullWood = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound2HullWood),
                        HasImpactSound3HullWood = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound3HullWood),
                        HasImpactSound4HullWood = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound4HullWood),
                        HasImpactSound0SailCloth = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound0SailCloth),
                        HasImpactSound1SailCloth = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound1SailCloth),
                        HasImpactSound2SailCloth = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound2SailCloth),
                        HasImpactSound3SailCloth = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound3SailCloth),
                        HasImpactSound4SailCloth = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound4SailCloth),
                        HasImpactSound0WallStone = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound0WallStone),
                        HasImpactSound1WallStone = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound1WallStone),
                        HasImpactSound2WallStone = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound2WallStone),
                        HasImpactSound3WallStone = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound3WallStone),
                        HasImpactSound4WallStone = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.ImpactSound4WallStone),
                        HasRicochetSoundDragonScale = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.RicochetSoundDragonScale),
                        HasRicochetSoundHullIron = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.RicochetSoundHullIron),
                        HasRicochetSoundHullReInforcedWood = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.RicochetSoundHullReInforcedWood),
                        HasRicochetSoundHullWood = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.RicochetSoundHullWood),
                        HasRicochetSoundSailCloth = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.RicochetSoundSailCloth),
                        HasRicochetSoundWallStone = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.RicochetSoundWallStone),
                        HasTravelSound = !string.IsNullOrWhiteSpace(gravChargeCustomInfoFactory.TravelSound),
                    };
                    CustomInfoFactory = CustomInfoFactory.GravChargeCustomInfoFactory;
                    break;
                case MineCustomInfoFactory mineCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new MineCustomInfoFactoryViewModel(mineCustomInfoFactory)
                    {
                        HasImpactSound0DragonScale = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound0DragonScale),
                        HasImpactSound1DragonScale = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound1DragonScale),
                        HasImpactSound2DragonScale = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound2DragonScale),
                        HasImpactSound3DragonScale = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound3DragonScale),
                        HasImpactSound4DragonScale = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound4DragonScale),
                        HasImpactSound0HullIron = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound0HullIron),
                        HasImpactSound1HullIron = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound1HullIron),
                        HasImpactSound2HullIron = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound2HullIron),
                        HasImpactSound3HullIron = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound3HullIron),
                        HasImpactSound4HullIron = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound4HullIron),
                        HasImpactSound0HullReInforcedWood = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound0HullReInforcedWood),
                        HasImpactSound1HullReInforcedWood = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound1HullReInforcedWood),
                        HasImpactSound2HullReInforcedWood = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound2HullReInforcedWood),
                        HasImpactSound3HullReInforcedWood = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound3HullReInforcedWood),
                        HasImpactSound4HullReInforcedWood = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound4HullReInforcedWood),
                        HasImpactSound0HullWood = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound0HullWood),
                        HasImpactSound1HullWood = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound1HullWood),
                        HasImpactSound2HullWood = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound2HullWood),
                        HasImpactSound3HullWood = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound3HullWood),
                        HasImpactSound4HullWood = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound4HullWood),
                        HasImpactSound0SailCloth = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound0SailCloth),
                        HasImpactSound1SailCloth = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound1SailCloth),
                        HasImpactSound2SailCloth = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound2SailCloth),
                        HasImpactSound3SailCloth = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound3SailCloth),
                        HasImpactSound4SailCloth = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound4SailCloth),
                        HasImpactSound0WallStone = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound0WallStone),
                        HasImpactSound1WallStone = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound1WallStone),
                        HasImpactSound2WallStone = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound2WallStone),
                        HasImpactSound3WallStone = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound3WallStone),
                        HasImpactSound4WallStone = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.ImpactSound4WallStone),
                        HasRicochetSoundDragonScale = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.RicochetSoundDragonScale),
                        HasRicochetSoundHullIron = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.RicochetSoundHullIron),
                        HasRicochetSoundHullReInforcedWood = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.RicochetSoundHullReInforcedWood),
                        HasRicochetSoundHullWood = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.RicochetSoundHullWood),
                        HasRicochetSoundSailCloth = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.RicochetSoundSailCloth),
                        HasRicochetSoundWallStone = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.RicochetSoundWallStone),
                        HasTravelSound = !string.IsNullOrWhiteSpace(mineCustomInfoFactory.TravelSound),
                    };
                    CustomInfoFactory = CustomInfoFactory.MineCustomInfoFactory;
                    break;
                case NovaMortarCustomInfoFactory novaMortarCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new NovaMortarCustomInfoFactoryViewModel(novaMortarCustomInfoFactory)
                    {
                        HasImpactSound0DragonScale = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound0DragonScale),
                        HasImpactSound1DragonScale = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound1DragonScale),
                        HasImpactSound2DragonScale = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound2DragonScale),
                        HasImpactSound3DragonScale = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound3DragonScale),
                        HasImpactSound4DragonScale = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound4DragonScale),
                        HasImpactSound0HullIron = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound0HullIron),
                        HasImpactSound1HullIron = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound1HullIron),
                        HasImpactSound2HullIron = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound2HullIron),
                        HasImpactSound3HullIron = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound3HullIron),
                        HasImpactSound4HullIron = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound4HullIron),
                        HasImpactSound0HullReInforcedWood = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound0HullReInforcedWood),
                        HasImpactSound1HullReInforcedWood = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound1HullReInforcedWood),
                        HasImpactSound2HullReInforcedWood = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound2HullReInforcedWood),
                        HasImpactSound3HullReInforcedWood = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound3HullReInforcedWood),
                        HasImpactSound4HullReInforcedWood = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound4HullReInforcedWood),
                        HasImpactSound0HullWood = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound0HullWood),
                        HasImpactSound1HullWood = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound1HullWood),
                        HasImpactSound2HullWood = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound2HullWood),
                        HasImpactSound3HullWood = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound3HullWood),
                        HasImpactSound4HullWood = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound4HullWood),
                        HasImpactSound0SailCloth = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound0SailCloth),
                        HasImpactSound1SailCloth = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound1SailCloth),
                        HasImpactSound2SailCloth = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound2SailCloth),
                        HasImpactSound3SailCloth = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound3SailCloth),
                        HasImpactSound4SailCloth = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound4SailCloth),
                        HasImpactSound0WallStone = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound0WallStone),
                        HasImpactSound1WallStone = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound1WallStone),
                        HasImpactSound2WallStone = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound2WallStone),
                        HasImpactSound3WallStone = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound3WallStone),
                        HasImpactSound4WallStone = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.ImpactSound4WallStone),
                        HasRicochetSoundDragonScale = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.RicochetSoundDragonScale),
                        HasRicochetSoundHullIron = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.RicochetSoundHullIron),
                        HasRicochetSoundHullReInforcedWood = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.RicochetSoundHullReInforcedWood),
                        HasRicochetSoundHullWood = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.RicochetSoundHullWood),
                        HasRicochetSoundSailCloth = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.RicochetSoundSailCloth),
                        HasRicochetSoundWallStone = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.RicochetSoundWallStone),
                        HasTravelSound = !string.IsNullOrWhiteSpace(novaMortarCustomInfoFactory.TravelSound),
                    };
                    CustomInfoFactory = CustomInfoFactory.NovaMortarCustomInfoFactory;
                    break;
                case StarMortarCustomInfoFactory starMortarCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new StarMortarCustomInfoFactoryViewModel(starMortarCustomInfoFactory)
                    {
                        HasImpactSound0DragonScale = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound0DragonScale),
                        HasImpactSound1DragonScale = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound1DragonScale),
                        HasImpactSound2DragonScale = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound2DragonScale),
                        HasImpactSound3DragonScale = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound3DragonScale),
                        HasImpactSound4DragonScale = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound4DragonScale),
                        HasImpactSound0HullIron = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound0HullIron),
                        HasImpactSound1HullIron = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound1HullIron),
                        HasImpactSound2HullIron = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound2HullIron),
                        HasImpactSound3HullIron = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound3HullIron),
                        HasImpactSound4HullIron = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound4HullIron),
                        HasImpactSound0HullReInforcedWood = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound0HullReInforcedWood),
                        HasImpactSound1HullReInforcedWood = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound1HullReInforcedWood),
                        HasImpactSound2HullReInforcedWood = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound2HullReInforcedWood),
                        HasImpactSound3HullReInforcedWood = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound3HullReInforcedWood),
                        HasImpactSound4HullReInforcedWood = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound4HullReInforcedWood),
                        HasImpactSound0HullWood = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound0HullWood),
                        HasImpactSound1HullWood = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound1HullWood),
                        HasImpactSound2HullWood = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound2HullWood),
                        HasImpactSound3HullWood = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound3HullWood),
                        HasImpactSound4HullWood = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound4HullWood),
                        HasImpactSound0SailCloth = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound0SailCloth),
                        HasImpactSound1SailCloth = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound1SailCloth),
                        HasImpactSound2SailCloth = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound2SailCloth),
                        HasImpactSound3SailCloth = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound3SailCloth),
                        HasImpactSound4SailCloth = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound4SailCloth),
                        HasImpactSound0WallStone = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound0WallStone),
                        HasImpactSound1WallStone = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound1WallStone),
                        HasImpactSound2WallStone = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound2WallStone),
                        HasImpactSound3WallStone = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound3WallStone),
                        HasImpactSound4WallStone = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.ImpactSound4WallStone),
                        HasRicochetSoundDragonScale = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.RicochetSoundDragonScale),
                        HasRicochetSoundHullIron = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.RicochetSoundHullIron),
                        HasRicochetSoundHullReInforcedWood = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.RicochetSoundHullReInforcedWood),
                        HasRicochetSoundHullWood = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.RicochetSoundHullWood),
                        HasRicochetSoundSailCloth = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.RicochetSoundSailCloth),
                        HasRicochetSoundWallStone = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.RicochetSoundWallStone),
                        HasTravelSound = !string.IsNullOrWhiteSpace(starMortarCustomInfoFactory.TravelSound),
                    };
                    CustomInfoFactory = CustomInfoFactory.StarMortarCustomInfoFactory;
                    break;
                case TorpedoCustomInfoFactory torpedoCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new TorpedoCustomInfoFactoryViewModel(torpedoCustomInfoFactory)
                    {
                        HasImpactSound0DragonScale = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound0DragonScale),
                        HasImpactSound1DragonScale = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound1DragonScale),
                        HasImpactSound2DragonScale = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound2DragonScale),
                        HasImpactSound3DragonScale = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound3DragonScale),
                        HasImpactSound4DragonScale = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound4DragonScale),
                        HasImpactSound0HullIron = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound0HullIron),
                        HasImpactSound1HullIron = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound1HullIron),
                        HasImpactSound2HullIron = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound2HullIron),
                        HasImpactSound3HullIron = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound3HullIron),
                        HasImpactSound4HullIron = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound4HullIron),
                        HasImpactSound0HullReInforcedWood = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound0HullReInforcedWood),
                        HasImpactSound1HullReInforcedWood = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound1HullReInforcedWood),
                        HasImpactSound2HullReInforcedWood = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound2HullReInforcedWood),
                        HasImpactSound3HullReInforcedWood = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound3HullReInforcedWood),
                        HasImpactSound4HullReInforcedWood = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound4HullReInforcedWood),
                        HasImpactSound0HullWood = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound0HullWood),
                        HasImpactSound1HullWood = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound1HullWood),
                        HasImpactSound2HullWood = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound2HullWood),
                        HasImpactSound3HullWood = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound3HullWood),
                        HasImpactSound4HullWood = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound4HullWood),
                        HasImpactSound0SailCloth = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound0SailCloth),
                        HasImpactSound1SailCloth = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound1SailCloth),
                        HasImpactSound2SailCloth = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound2SailCloth),
                        HasImpactSound3SailCloth = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound3SailCloth),
                        HasImpactSound4SailCloth = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound4SailCloth),
                        HasImpactSound0WallStone = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound0WallStone),
                        HasImpactSound1WallStone = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound1WallStone),
                        HasImpactSound2WallStone = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound2WallStone),
                        HasImpactSound3WallStone = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound3WallStone),
                        HasImpactSound4WallStone = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.ImpactSound4WallStone),
                        HasRicochetSoundDragonScale = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.RicochetSoundDragonScale),
                        HasRicochetSoundHullIron = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.RicochetSoundHullIron),
                        HasRicochetSoundHullReInforcedWood = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.RicochetSoundHullReInforcedWood),
                        HasRicochetSoundHullWood = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.RicochetSoundHullWood),
                        HasRicochetSoundSailCloth = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.RicochetSoundSailCloth),
                        HasRicochetSoundWallStone = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.RicochetSoundWallStone),
                        HasTravelSound = !string.IsNullOrWhiteSpace(torpedoCustomInfoFactory.TravelSound),
                    };
                    CustomInfoFactory = CustomInfoFactory.TorpedoCustomInfoFactory;
                    break;
                case BulletCustomInfoFactory bulletCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new BulletCustomInfoFactoryViewModel(bulletCustomInfoFactory)
                    {
                        HasImpactSound0DragonScale = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound0DragonScale),
                        HasImpactSound1DragonScale = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound1DragonScale),
                        HasImpactSound2DragonScale = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound2DragonScale),
                        HasImpactSound3DragonScale = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound3DragonScale),
                        HasImpactSound4DragonScale = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound4DragonScale),
                        HasImpactSound0HullIron = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound0HullIron),
                        HasImpactSound1HullIron = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound1HullIron),
                        HasImpactSound2HullIron = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound2HullIron),
                        HasImpactSound3HullIron = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound3HullIron),
                        HasImpactSound4HullIron = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound4HullIron),
                        HasImpactSound0HullReInforcedWood = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound0HullReInforcedWood),
                        HasImpactSound1HullReInforcedWood = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound1HullReInforcedWood),
                        HasImpactSound2HullReInforcedWood = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound2HullReInforcedWood),
                        HasImpactSound3HullReInforcedWood = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound3HullReInforcedWood),
                        HasImpactSound4HullReInforcedWood = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound4HullReInforcedWood),
                        HasImpactSound0HullWood = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound0HullWood),
                        HasImpactSound1HullWood = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound1HullWood),
                        HasImpactSound2HullWood = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound2HullWood),
                        HasImpactSound3HullWood = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound3HullWood),
                        HasImpactSound4HullWood = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound4HullWood),
                        HasImpactSound0SailCloth = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound0SailCloth),
                        HasImpactSound1SailCloth = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound1SailCloth),
                        HasImpactSound2SailCloth = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound2SailCloth),
                        HasImpactSound3SailCloth = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound3SailCloth),
                        HasImpactSound4SailCloth = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound4SailCloth),
                        HasImpactSound0WallStone = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound0WallStone),
                        HasImpactSound1WallStone = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound1WallStone),
                        HasImpactSound2WallStone = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound2WallStone),
                        HasImpactSound3WallStone = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound3WallStone),
                        HasImpactSound4WallStone = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.ImpactSound4WallStone),
                        HasRicochetSoundDragonScale = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.RicochetSoundDragonScale),
                        HasRicochetSoundHullIron = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.RicochetSoundHullIron),
                        HasRicochetSoundHullReInforcedWood = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.RicochetSoundHullReInforcedWood),
                        HasRicochetSoundHullWood = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.RicochetSoundHullWood),
                        HasRicochetSoundSailCloth = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.RicochetSoundSailCloth),
                        HasRicochetSoundWallStone = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.RicochetSoundWallStone),
                        HasTravelSound = !string.IsNullOrWhiteSpace(bulletCustomInfoFactory.TravelSound),
                    };
                    CustomInfoFactory = CustomInfoFactory.BulletCustomInfoFactory;
                    break;
                case CrewCustomInfoFactory crewCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new CrewCustomInfoFactoryViewModel(crewCustomInfoFactory);
                    CustomInfoFactory = CustomInfoFactory.CrewCustomInfoFactory;
                    break;
                case DragonCustomInfoFactory dragonCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new DragonCustomInfoFactoryViewModel(dragonCustomInfoFactory)
                    {
                        HasSound_0 = !string.IsNullOrWhiteSpace(dragonCustomInfoFactory.Sound_0),
                        HasSound_1 = !string.IsNullOrWhiteSpace(dragonCustomInfoFactory.Sound_1),
                        HasSound_2 = !string.IsNullOrWhiteSpace(dragonCustomInfoFactory.Sound_2),
                        HasSound_3 = !string.IsNullOrWhiteSpace(dragonCustomInfoFactory.Sound_3),
                        HasSound_4 = !string.IsNullOrWhiteSpace(dragonCustomInfoFactory.Sound_4),
                        HasSound_5 = !string.IsNullOrWhiteSpace(dragonCustomInfoFactory.Sound_5),
                        HasSound_6 = !string.IsNullOrWhiteSpace(dragonCustomInfoFactory.Sound_6),
                        HasSound_7 = !string.IsNullOrWhiteSpace(dragonCustomInfoFactory.Sound_7),
                        HasSound_8 = !string.IsNullOrWhiteSpace(dragonCustomInfoFactory.Sound_8),
                        HasSound_9 = !string.IsNullOrWhiteSpace(dragonCustomInfoFactory.Sound_9),
                    };
                    CustomInfoFactory = CustomInfoFactory.DragonCustomInfoFactory;
                    break;
                case EtheriumCurrentCustomInfoFactory etheriumCurrentCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new EtheriumCurrentCustomInfoFactoryViewModel(etheriumCurrentCustomInfoFactory);
                    CustomInfoFactory = CustomInfoFactory.EtheriumCurrentCustomInfoFactory;
                    break;
                case GunCustomInfoFactory gunCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new GunCustomInfoFactoryViewModel(gunCustomInfoFactory)
                    {
                        HasBulletTypeName_Primary = gunCustomInfoFactory.BulletTypeName_Primary != null,
                        HasBulletTypeName_Secondary = gunCustomInfoFactory.BulletTypeName_Secondary != null,
                        HasSoundName = !string.IsNullOrWhiteSpace(gunCustomInfoFactory.SoundName),
                    };
                    CustomInfoFactory = CustomInfoFactory.GunCustomInfoFactory;
                    break;
                case IslandCustomInfoFactory islandCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new IslandCustomInfoFactoryViewModel(islandCustomInfoFactory);
                    CustomInfoFactory = CustomInfoFactory.IslandCustomInfoFactory;
                    break;
                case NebulaCustomInfoFactory nebulaCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new NebulaCustomInfoFactoryViewModel(nebulaCustomInfoFactory)
                    {
                        HasMeteorShowerSoundName = !string.IsNullOrWhiteSpace(nebulaCustomInfoFactory.MeteorShowerSoundName),
                        HasNebulaSoundName = !string.IsNullOrWhiteSpace(nebulaCustomInfoFactory.NebulaSoundName),
                        HasSolarStormSoundName = !string.IsNullOrWhiteSpace(nebulaCustomInfoFactory.SolarStormSoundName),
                    };
                    CustomInfoFactory = CustomInfoFactory.NebulaCustomInfoFactory;
                    break;
                case ShipCustomInfoFactory shipCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new ShipCustomInfoFactoryViewModel(shipCustomInfoFactory)
                    {
                        HasEngineSoundNameEmergency = !string.IsNullOrWhiteSpace(shipCustomInfoFactory.EngineSoundNameEmergency),
                        HasEngineSoundNameFull = !string.IsNullOrWhiteSpace(shipCustomInfoFactory.EngineSoundNameFull),
                        HasEngineSoundNameHalf = !string.IsNullOrWhiteSpace(shipCustomInfoFactory.EngineSoundNameHalf),
                    };
                    CustomInfoFactory = CustomInfoFactory.ShipCustomInfoFactory;
                    break;
                case ShipDebrisCustomInfoFactory shipDebrisCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new ShipDebrisCustomInfoFactoryViewModel(shipDebrisCustomInfoFactory);
                    CustomInfoFactory = CustomInfoFactory.ShipDebrisCustomInfoFactory;
                    break;
                case SpaceAnimalCustomInfoFactory spaceAnimalCustomInfoFactory:
                    CustomInfoDefinitionViewModel = new SpaceAnimalCustomInfoFactoryViewModel(spaceAnimalCustomInfoFactory)
                    {
                        HasSound_0 = !string.IsNullOrWhiteSpace(spaceAnimalCustomInfoFactory.Sound_0),
                        HasSound_1 = !string.IsNullOrWhiteSpace(spaceAnimalCustomInfoFactory.Sound_1),
                        HasSound_2 = !string.IsNullOrWhiteSpace(spaceAnimalCustomInfoFactory.Sound_2),
                        HasSound_3 = !string.IsNullOrWhiteSpace(spaceAnimalCustomInfoFactory.Sound_3),
                        HasSound_4 = !string.IsNullOrWhiteSpace(spaceAnimalCustomInfoFactory.Sound_4),
                        HasSound_5 = !string.IsNullOrWhiteSpace(spaceAnimalCustomInfoFactory.Sound_5),
                        HasSound_6 = !string.IsNullOrWhiteSpace(spaceAnimalCustomInfoFactory.Sound_6),
                        HasSound_7 = !string.IsNullOrWhiteSpace(spaceAnimalCustomInfoFactory.Sound_7),
                        HasSound_8 = !string.IsNullOrWhiteSpace(spaceAnimalCustomInfoFactory.Sound_8),
                        HasSound_9 = !string.IsNullOrWhiteSpace(spaceAnimalCustomInfoFactory.Sound_9),
                    };
                    CustomInfoFactory = CustomInfoFactory.SpaceAnimalCustomInfoFactory;
                    break;
                default:
                    CustomInfoDefinitionViewModel = null;
                    CustomInfoFactory = CustomInfoFactory.None;
                    break;
            }
            switch (worldObjectType.PhysicsDefinition)
            {
                case DragonPhysics dragonPhysics:
                    PhysicsDefinitionViewModel = new DragonPhysicsViewModel(dragonPhysics);
                    PhysicsFactory = PhysicsFactory.DragonPhysics;
                    break;
                case MinePhysics minePhysics:
                    PhysicsDefinitionViewModel = new MinePhysicsViewModel(minePhysics);
                    PhysicsFactory = PhysicsFactory.MinePhysics;
                    break;
                case ProjectilePhysics projectilePhysics:
                    PhysicsDefinitionViewModel = new ProjectilePhysicsViewModel(projectilePhysics);
                    PhysicsFactory = PhysicsFactory.ProjectilePhysics;
                    break;
                case ShipDemo shipDemo:
                    PhysicsDefinitionViewModel = new ShipDemoViewModel(shipDemo);
                    PhysicsFactory = PhysicsFactory.ShipDemo;
                    break;
                case SpaceObjectPhysics spaceObjectPhysics:
                    PhysicsDefinitionViewModel = new SpaceObjectPhysicsViewModel(spaceObjectPhysics);
                    PhysicsFactory = PhysicsFactory.SpaceObjectPhysics;
                    break;
                case TorpedoPhysics torpedoPhysics:
                    PhysicsDefinitionViewModel = new TorpedoPhysicsViewModel(torpedoPhysics);
                    PhysicsFactory = PhysicsFactory.TorpedoPhysics;
                    break;
                case WhalePhysics whalePhysics:
                    PhysicsDefinitionViewModel = new WhalePhysicsViewModel(whalePhysics);
                    PhysicsFactory = PhysicsFactory.WhalePhysics;
                    break;
                default:
                    PhysicsDefinitionViewModel = null;
                    PhysicsFactory = PhysicsFactory.None;
                    break;
            }
            switch (worldObjectType.RenderEntityDefinition)
            {
                case TPToolkitLib.WorldObject.Definitions.RenderEntityFactories.RenderEntityFactory renderEntityFactory:
                    RenderEntityDefinitionViewModel = new RenderEntityFactoryViewModel(renderEntityFactory);
                    RenderEntityFactory = RenderEntityFactory.RenderEntityFactory;
                    break;
                default:
                    RenderEntityDefinitionViewModel = null;
                    RenderEntityFactory = RenderEntityFactory.None;
                    break;
            }
            shouldUpdateViewModelsFromUI = true;
        }
    }
}
