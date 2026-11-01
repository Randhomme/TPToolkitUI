using System.ComponentModel.DataAnnotations;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public interface IMsbNamedElement
    {
        public string Name { get; set; }
    }

    public class MsbNamedElementViewModel : CustomObservableValidator
    {
        private readonly IEnumerable<MsbNodeViewModel> nodes;
        private readonly IEnumerable<MsbMeshViewModel> meshes;
        private readonly IEnumerable<MsbBoneViewModel> bones;
        private readonly IEnumerable<MsbAnimationViewModel> animations;

        public MsbNamedElementViewModel(IEnumerable<MsbNodeViewModel> nodes, IEnumerable<MsbMeshViewModel> meshes, IEnumerable<MsbBoneViewModel> bones, IEnumerable<MsbAnimationViewModel> animations)
        {
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
            var instance = (MsbNamedElementViewModel)context.ObjectInstance;
            var typedValue = (string)value;
            if (string.IsNullOrEmpty(typedValue))
                return new("The name cannot be empty.");
            if (instance.IsNameAlreadyUsed(typedValue))
                return new($"The name {typedValue} is already used.");
            return ValidationResult.Success;
        }
    }

    public class MsbNamedElementViewModel<T> : MsbNamedElementViewModel, IMsbNamedElement where T : MsbNamedElement
    {
        public T Model { get; }

        [CustomValidation(typeof(MsbNamedElementViewModel), nameof(ValidateName))]
        public string Name
        {
            get => Model.Name;
            set => SetAndValidateProperty(Model.Name, value, Model, (m, s) => m.Name = s);
        }

        public MsbNamedElementViewModel(T model, IEnumerable<MsbNodeViewModel> nodes, IEnumerable<MsbMeshViewModel> meshes, IEnumerable<MsbBoneViewModel> bones, IEnumerable<MsbAnimationViewModel> animations) : base(nodes, meshes, bones, animations)
        {
            Model = model;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class MsbElementViewModel : MsbNamedElementViewModel
    {
        public CompositeObservableCollection<MsbElementViewModel> ParentCollection { get; }
        public MsbElementViewModel(IEnumerable<MsbNodeViewModel> nodes, IEnumerable<MsbMeshViewModel> meshes, IEnumerable<MsbBoneViewModel> bones, IEnumerable<MsbAnimationViewModel> animations, CompositeObservableCollection<MsbElementViewModel> parentCollection) : base(nodes, meshes, bones, animations)
        {
            ParentCollection = parentCollection;
        }
    }


    public class MsbElementViewModel<T> : MsbElementViewModel, IMsbNamedElement where T : MsbElement
    {
        public T Model { get; }

        [CustomValidation(typeof(MsbNamedElementViewModel), nameof(ValidateName))]
        public string Name
        {
            get => Model.Name;
            set => SetAndValidateProperty(Model.Name, value, Model, (m, s) => m.Name = s);
        }

        public MsbElementViewModel(T model, IEnumerable<MsbNodeViewModel> nodes, IEnumerable<MsbMeshViewModel> meshes, IEnumerable<MsbBoneViewModel> bones, IEnumerable<MsbAnimationViewModel> animations, CompositeObservableCollection<MsbElementViewModel> parentCollection) : base(nodes, meshes, bones, animations, parentCollection)
        {
            Model = model;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
