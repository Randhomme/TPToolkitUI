using TPToolkitLib.MeshScene.Classes;
using TPToolkitUI.CustomAttributes;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public class MsbBoneViewModel : MsbElementViewModel<MsbBone>
    {
        public string InfluenceMapName
        {
            get => Model.InfluenceMapName;
            set => SetAndValidateProperty(Model.InfluenceMapName, value, Model, (m, s) => m.InfluenceMapName = s);
        }

        [Float]
        public string RestLength
        {
            get => Model.RestLength.ToString("F6");
            set => SetAndValidateProperty(Model.RestLength.ToString(), value, Model, (m, s) => m.RestLength = float.Parse(s));
        }

        public MsbBoneViewModel(MsbBone model, IEnumerable<MsbNodeViewModel> nodes, IEnumerable<MsbMeshViewModel> meshes, IEnumerable<MsbBoneViewModel> bones, IEnumerable<MsbAnimationViewModel> animations, CompositeObservableCollection<MsbElementViewModel> parentCollection) : base(model, nodes, meshes, bones, animations, parentCollection)
        {
        }
    }
}
