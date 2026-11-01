using System.ComponentModel.DataAnnotations;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public class MsbAnimationViewModel : CustomObservableValidator
    {
        private readonly IEnumerable<MsbNodeViewModel> nodes;
        private readonly IEnumerable<MsbMeshViewModel> meshes;
        private readonly IEnumerable<MsbBoneViewModel> bones;
        private readonly IEnumerable<MsbAnimationViewModel> animations;

        public MsbAnimation MsbAnimation { get; }
        [CustomValidation(typeof(MsbAnimationViewModel), nameof(ValidateName))]
        public string Name
        {
            get => MsbAnimation.Name;
            set => SetAndValidateProperty(MsbAnimation.Name, value, MsbAnimation, (m, s) => m.Name = s);
        }

        public MsbAnimationViewModel(MsbAnimation msbAnimation, IEnumerable<MsbNodeViewModel> nodes, IEnumerable<MsbMeshViewModel> meshes, IEnumerable<MsbBoneViewModel> bones, IEnumerable<MsbAnimationViewModel> animations)
        {
            MsbAnimation = msbAnimation;
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
            var instance = (MsbAnimationViewModel)context.ObjectInstance;
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
