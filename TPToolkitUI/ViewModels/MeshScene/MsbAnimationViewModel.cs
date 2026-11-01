using TPToolkitLib.MeshScene.Classes;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public class MsbAnimationViewModel : MsbNamedElementViewModel<MsbAnimation>
    {
        public MsbAnimationViewModel(MsbAnimation model, IEnumerable<MsbNodeViewModel> nodes, IEnumerable<MsbMeshViewModel> meshes, IEnumerable<MsbBoneViewModel> bones, IEnumerable<MsbAnimationViewModel> animations) : base(model, nodes, meshes, bones, animations)
        {
        }
    }
}
