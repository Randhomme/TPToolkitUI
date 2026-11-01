using TPToolkitLib.MeshScene.Classes;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public class MsbMeshViewModel : MsbElementViewModel<MsbMesh>
    {
        public MsbMeshViewModel(MsbMesh model, IEnumerable<MsbNodeViewModel> nodes, IEnumerable<MsbMeshViewModel> meshes, IEnumerable<MsbBoneViewModel> bones, IEnumerable<MsbAnimationViewModel> animations, CompositeObservableCollection<MsbElementViewModel> parentCollection) : base(model, nodes, meshes, bones, animations, parentCollection)
        {
        }
    }
}
