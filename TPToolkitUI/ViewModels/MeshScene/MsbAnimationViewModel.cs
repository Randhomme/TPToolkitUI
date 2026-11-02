using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitUI.CustomAttributes;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public partial class MsbAnimationViewModel : MsbNamedElementViewModel<MsbAnimation>
    {
        private readonly CompositeObservableCollection<MsbElementViewModel> availableElements;

        [Float]
        public string Duration
        {
            get => Model.Duration.ToString("F6");
            set => SetAndValidateProperty(Model.Duration.ToString(), value, Model, (m, s) => m.Duration = float.Parse(s));
        }

        public ObservableCollection<MsbMotionViewModel> MsbMotions { get; } = [];

        public MsbAnimationViewModel(MsbAnimation model, IEnumerable<MsbNodeViewModel> nodes, IEnumerable<MsbMeshViewModel> meshes, IEnumerable<MsbBoneViewModel> bones, IEnumerable<MsbAnimationViewModel> animations, CompositeObservableCollection<MsbElementViewModel> availableElements) : base(model, nodes, meshes, bones, animations)
        {
            this.availableElements = availableElements;
            PopulateMsbMotions(model);
            MsbMotions.CollectionChanged += MsbMotions_CollectionChanged;
        }

        [RelayCommand]
        private void OnAddMsbMotion()
        {
            MsbMotions.Add(new(new(), availableElements));
        }

        private void PopulateMsbMotions(MsbAnimation model)
        {
            for (int i = 0; i < model.MsbMotions.Count; i++)
            {
                MsbMotions.Add(new(model.MsbMotions[i], availableElements));
            }
        }

        private void MsbMotions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        var newItem = (MsbMotionViewModel)e.NewItems[i];
                        Model.MsbMotions.Insert(e.NewStartingIndex + i, newItem.Model);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; i++)
                        Model.MsbMotions.RemoveAt(e.OldStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        var item = (MsbMotionViewModel)e.NewItems[i];
                        Model.MsbMotions[e.NewStartingIndex + i] = item.Model;
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    var item1 = Model.MsbMotions[e.OldStartingIndex];

                    Model.MsbMotions.RemoveAt(e.OldStartingIndex);
                    Model.MsbMotions.Insert(e.NewStartingIndex, item1);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    Model.MsbMotions.Clear();
                    break;
            }
        }
    }
}
