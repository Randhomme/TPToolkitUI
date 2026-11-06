using TPToolkitLib.WorldObject.Definitions.AiEntityFactories;

namespace TPToolkitUI.ViewModels.WorldObject.AiEntityFactories
{
    public class GunAIViewModel : AiEntityDefinitionViewModel<GunAI>
    {
        public bool IsLobbingGun
        {
            get => Model.IsLobbingGun;
            set => SetAndValidateProperty(Model.IsLobbingGun, value, Model, (m, b) => m.IsLobbingGun = b);
        }
        public bool IsMineLayingGun
        {
            get => Model.IsMineLayingGun;
            set => SetAndValidateProperty(Model.IsMineLayingGun, value, Model, (m, b) => m.IsMineLayingGun = b);
        }
        public bool IsTorpedoLauncherGun
        {
            get => Model.IsTorpedoLauncherGun;
            set => SetAndValidateProperty(Model.IsTorpedoLauncherGun, value, Model, (m, b) => m.IsTorpedoLauncherGun = b);
        }
        public bool IsPointDefenseGun
        {
            get => Model.IsPointDefenseGun;
            set => SetAndValidateProperty(Model.IsPointDefenseGun, value, Model, (m, b) => m.IsPointDefenseGun = b);
        }

        public GunAIViewModel(GunAI model) : base(model)
        {
        }
    }
}
