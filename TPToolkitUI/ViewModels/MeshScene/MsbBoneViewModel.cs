using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.MeshScene.Classes;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public class MsbBoneViewModel : ObservableObject
    {
        public MsbBone MsbBone { get; }
        public string Name
        {
            get => MsbBone.Name;
            set => SetProperty(MsbBone.Name, value, MsbBone, (m, s) => m.Name = s);
        }
        public MsbBoneViewModel(MsbBone msbBone)
        {
            MsbBone = msbBone;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
