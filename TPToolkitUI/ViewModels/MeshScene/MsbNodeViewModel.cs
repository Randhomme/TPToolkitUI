using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.MeshScene.Classes;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public class MsbNodeViewModel : ObservableObject
    {
        public MsbNode MsbNode { get; }
        public string Name
        {
            get => MsbNode.Name;
            set => SetProperty(MsbNode.Name, value, MsbNode, (m, s) => m.Name = s);
        }
        public MsbNodeViewModel(MsbNode msbNode)
        {
            MsbNode = msbNode;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
