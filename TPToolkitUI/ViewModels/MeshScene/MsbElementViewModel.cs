using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitUI.CustomAttributes;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public interface IMsbNamedElement
    {
        public string Name { get; set; }
    }

    public abstract class MsbNamedElementViewModel : CustomObservableValidator, IMsbNamedElement
    {
        private readonly IEnumerable<MsbNodeViewModel> nodes;
        private readonly IEnumerable<MsbMeshViewModel> meshes;
        private readonly IEnumerable<MsbBoneViewModel> bones;
        private readonly IEnumerable<MsbAnimationViewModel> animations;

        public abstract string Name { get; set; }

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

        public override string ToString()
        {
            return Name;
        }
    }

    public class MsbNamedElementViewModel<T> : MsbNamedElementViewModel where T : MsbNamedElement
    {
        public T Model { get; }

        [CustomValidation(typeof(MsbNamedElementViewModel), nameof(ValidateName))]
        public override string Name
        {
            get => Model.Name;
            set => SetAndValidateProperty(Model.Name, value, Model, (m, s) => m.Name = s);
        }

        public MsbNamedElementViewModel(T model, IEnumerable<MsbNodeViewModel> nodes, IEnumerable<MsbMeshViewModel> meshes, IEnumerable<MsbBoneViewModel> bones, IEnumerable<MsbAnimationViewModel> animations) : base(nodes, meshes, bones, animations)
        {
            Model = model;
        }
    }

    public abstract partial class MsbElementViewModel : MsbNamedElementViewModel
    {
        public MsbElement Model { get; }
        public CompositeObservableCollection<MsbElementViewModel> ParentCollection { get; }

        [ObservableProperty]
        public partial MsbElementViewModel? ParentElement { get; set; }

        [Float]
        public string PivotX
        {
            get => Model.Pivot.X.ToString("F6");
            set => SetAndValidateProperty(Model.Pivot.X.ToString(), value, Model, (m, s) => m.Pivot = new(float.Parse(s), m.Pivot.Y, m.Pivot.Z));
        }

        [Float]
        public string PivotY
        {
            get => Model.Pivot.Y.ToString("F6");
            set => SetAndValidateProperty(Model.Pivot.Y.ToString(), value, Model, (m, s) => m.Pivot = new(m.Pivot.X, float.Parse(s), m.Pivot.Z));
        }

        [Float]
        public string PivotZ
        {
            get => Model.Pivot.Z.ToString("F6");
            set => SetAndValidateProperty(Model.Pivot.Z.ToString(), value, Model, (m, s) => m.Pivot = new(m.Pivot.X, m.Pivot.Y, float.Parse(s)));
        }

        [Float]
        public string PositionX
        {
            get => Model.Position.X.ToString("F6");
            set => SetAndValidateProperty(Model.Position.X.ToString(), value, Model, (m, s) => m.Position = new(float.Parse(s), m.Position.Y, m.Position.Z));
        }

        [Float]
        public string PositionY
        {
            get => Model.Position.Y.ToString("F6");
            set => SetAndValidateProperty(Model.Position.Y.ToString(), value, Model, (m, s) => m.Position = new(m.Position.X, float.Parse(s), m.Position.Z));
        }

        [Float]
        public string PositionZ
        {
            get => Model.Position.Z.ToString("F6");
            set => SetAndValidateProperty(Model.Position.Z.ToString(), value, Model, (m, s) => m.Position = new(m.Position.X, m.Position.Y, float.Parse(s)));
        }

        [Float]
        public string RotationYaw
        {
            get => Model.Rotation.X.ToString("F6");
            set => SetAndValidateProperty(Model.Rotation.X.ToString(), value, Model, (m, s) => m.Rotation = new(float.Parse(s), m.Rotation.Y, m.Rotation.Z));
        }

        [Float]
        public string RotationPitch
        {
            get => Model.Rotation.Y.ToString("F6");
            set => SetAndValidateProperty(Model.Rotation.Y.ToString(), value, Model, (m, s) => m.Rotation = new(m.Rotation.X, float.Parse(s), m.Rotation.Z));
        }

        [Float]
        public string RotationRoll
        {
            get => Model.Rotation.Z.ToString("F6");
            set => SetAndValidateProperty(Model.Rotation.Z.ToString(), value, Model, (m, s) => m.Rotation = new(m.Rotation.X, m.Rotation.Y, float.Parse(s)));
        }

        public ObservableCollection<MsbAttributeViewModel> MsbAttributes { get; } = [];

        public MsbElementViewModel(MsbElement model, IEnumerable<MsbNodeViewModel> nodes, IEnumerable<MsbMeshViewModel> meshes, IEnumerable<MsbBoneViewModel> bones, IEnumerable<MsbAnimationViewModel> animations, CompositeObservableCollection<MsbElementViewModel> parentCollection) : base(nodes, meshes, bones, animations)
        {
            Model = model;
            ParentCollection = parentCollection;
            PopulateMsbAttributes(model);
            MsbAttributes.CollectionChanged += MsbAttributes_CollectionChanged;
        }

        [RelayCommand]
        private void OnAddMsbAttribute()
        {
            MsbAttributes.Add(new(new()));
        }

        private void PopulateMsbAttributes(MsbElement model)
        {
            for(int i = 0; i < model.MsbAttirbutes.Count; i++)
            {
                MsbAttributes.Add(new(model.MsbAttirbutes[i]));
            }
        }

        private void MsbAttributes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        var newItem = (MsbAttributeViewModel)e.NewItems[i];
                        Model.MsbAttirbutes.Insert(e.NewStartingIndex + i, newItem.Model);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; i++)
                        Model.MsbAttirbutes.RemoveAt(e.OldStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        var item = (MsbAttributeViewModel)e.NewItems[i];
                        Model.MsbAttirbutes[e.NewStartingIndex + i] = item.Model;
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    var item1 = Model.MsbAttirbutes[e.OldStartingIndex];

                    Model.MsbAttirbutes.RemoveAt(e.OldStartingIndex);
                    Model.MsbAttirbutes.Insert(e.NewStartingIndex, item1);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    Model.MsbAttirbutes.Clear();
                    break;
            }
        }

        partial void OnParentElementChanged(MsbElementViewModel? value)
        {
            Model.Parent = value?.Model;
        }
    }


    public partial class MsbElementViewModel<T> : MsbElementViewModel where T : MsbElement
    {
        public new T Model { get; }

        [CustomValidation(typeof(MsbNamedElementViewModel), nameof(ValidateName))]
        public override string Name
        {
            get => Model.Name;
            set => SetAndValidateProperty(Model.Name, value, Model, (m, s) => m.Name = s);
        }

        public MsbElementViewModel(T model, IEnumerable<MsbNodeViewModel> nodes, IEnumerable<MsbMeshViewModel> meshes, IEnumerable<MsbBoneViewModel> bones, IEnumerable<MsbAnimationViewModel> animations, CompositeObservableCollection<MsbElementViewModel> parentCollection) : base(model, nodes, meshes, bones, animations, parentCollection)
        {
            Model = model;
        }
    }
}
