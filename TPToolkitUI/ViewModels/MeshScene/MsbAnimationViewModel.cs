using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.MeshScene.Classes;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public class MsbAnimationViewModel : ObservableObject
    {
        public MsbAnimation MsbAnimation { get; }
        public string Name
        {
            get => MsbAnimation.Name;
            set => SetProperty(MsbAnimation.Name, value, MsbAnimation, (m, s) => m.Name = s);
        }
        public MsbAnimationViewModel(MsbAnimation msbAnimation)
        {
            MsbAnimation = msbAnimation;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
