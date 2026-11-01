using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.MeshScene.Classes;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public class MsbMeshViewModel : ObservableObject
    {
        public MsbMesh MsbMesh { get; }
        public string Name
        {
            get => MsbMesh.Name;
            set => SetProperty(MsbMesh.Name, value, MsbMesh, (m, s) => m.Name = s);
        }
        public MsbMeshViewModel(MsbMesh msbMesh)
        {
            MsbMesh = msbMesh;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
