using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitLib.WorldObject.Definitions.RenderEntityFactories.RenderEntityFactoryClasses.MeshAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories.MeshSubAttributes
{
    public partial class DockPointViewModel(DockPoint model, IList<MsbAnimation> availableAnimations) : MeshSubAttributePropertiesBaseViewModel<DockPoint>(model)
    {
        [ObservableProperty]
        public partial bool HasAnimation { get; set; }

        public MsbAnimation? Animation
        {
            get => Model.Animation;
            set => SetAndValidateProperty(Model.Animation, value, Model, (m, a) => m.Animation = a);
        }

        public IList<MsbAnimation> AvailableAnimations { get; private set; } = availableAnimations;

        public void RefreshAvailableAnimations(IList<MsbAnimation> availableAnimations)
        {
            AvailableAnimations = availableAnimations;
            OnPropertyChanged(nameof(AvailableAnimations));
            Animation = AvailableAnimations.FirstOrDefault((a) => a.Name.Equals(Animation?.Name));
            if (Animation == null)
                HasAnimation = false;
        }
    }
}
