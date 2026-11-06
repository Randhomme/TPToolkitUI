using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using TPToolkitLib.Tools;
using TPToolkitLib.WorldObject;
using TPToolkitLib.WorldObject.Definitions.AiEntityFactories;
using TPToolkitUI.Enums;
using TPToolkitUI.Services;
using TPToolkitUI.ViewModels.WorldObject;
using TPToolkitUI.ViewModels.WorldObject.AiEntityFactories;

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
            shouldUpdateViewModelsFromUI = true;
        }
    }
}
