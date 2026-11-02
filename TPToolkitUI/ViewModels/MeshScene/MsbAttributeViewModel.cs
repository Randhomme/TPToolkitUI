using TPToolkitLib.MeshScene.Classes;
using TPToolkitLib.MeshScene.Enums;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public class MsbAttributeViewModel : CustomObservableValidator
    {
        public MsbAttribute Model { get; }

        public AttributeName AttributeName
        {
            get => Model.AttributeName;
            set => SetAndValidateProperty(Model.AttributeName, value, Model, (m, a) => m.AttributeName = a);
        }

        public string DescriptorName
        {
            get => Model.DescriptorName;
            set => SetAndValidateProperty(Model.DescriptorName, value, Model, (m, s) => m.DescriptorName = s);
        }

        public MsbAttributeViewModel(MsbAttribute model)
        {
            Model = model;
        }

        public override string ToString()
        {
            return DescriptorName;
        }
    }
}
