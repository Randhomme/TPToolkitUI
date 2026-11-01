using System.ComponentModel.DataAnnotations;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public class MsbBoneViewModel : CustomObservableValidator
    {
        private readonly IEnumerable<MsbNodeViewModel> nodes;
        private readonly IEnumerable<MsbMeshViewModel> meshes;
        private readonly IEnumerable<MsbBoneViewModel> bones;
        private readonly IEnumerable<MsbAnimationViewModel> animations;

        public MsbBone MsbBone { get; }
        [CustomValidation(typeof(MsbBoneViewModel), nameof(ValidateName))]
        public string Name
        {
            get => MsbBone.Name;
            set => SetAndValidateProperty(MsbBone.Name, value, MsbBone, (m, s) => m.Name = s);
        }

        public MsbBoneViewModel(MsbBone msbBone, IEnumerable<MsbNodeViewModel> nodes, IEnumerable<MsbMeshViewModel> meshes, IEnumerable<MsbBoneViewModel> bones, IEnumerable<MsbAnimationViewModel> animations)
        {
            MsbBone = msbBone;
            this.nodes = nodes;
            this.meshes = meshes;
            this.bones = bones;
            this.animations = animations;
        }

        private bool IsNameAlreadyUsed(string name)
        {
            foreach (var item in nodes)
                if (string.Equals(name, item.Name, StringComparison.OrdinalIgnoreCase))
                    return true;
            foreach (var item in meshes)
                if (string.Equals(name, item.Name, StringComparison.OrdinalIgnoreCase))
                    return true;
            foreach (var item in bones)
                if (string.Equals(name, item.Name, StringComparison.OrdinalIgnoreCase))
                    return true;
            foreach (var item in animations)
                if (string.Equals(name, item.Name, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        public static ValidationResult ValidateName(object value, ValidationContext context)
        {
            var instance = (MsbBoneViewModel)context.ObjectInstance;
            var typedValue = (string)value;
            if (string.IsNullOrEmpty(typedValue))
                return new("The name cannot be empty.");
            if (instance.IsNameAlreadyUsed(typedValue))
                return new($"The name {typedValue} is already used.");
            return ValidationResult.Success;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
