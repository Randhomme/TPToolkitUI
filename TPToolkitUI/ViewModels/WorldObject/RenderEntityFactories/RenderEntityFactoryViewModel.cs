using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitLib.WorldObject.Definitions.RenderEntityFactories;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories
{
    public partial class RenderEntityFactoryViewModel : RenderEntityDefinitionViewModel<RenderEntityFactory>
    {
        public bool Distant
        {
            get => Model.Distant;
            set => SetAndValidateProperty(Model.Distant, value, Model, (m, b) => m.Distant = b);
        }

        public bool Visible
        {
            get => Model.Visible;
            set => SetAndValidateProperty(Model.Visible, value, Model, (m, b) => m.Visible = b);
        }

        public MsbScene MeshScene
        {
            get => Model.MeshScene ?? MsbScene.None;
            set
            {
                SetAndValidateProperty(Model.MeshScene, value, Model, (m, ms) => m.MeshScene = ms);
                for (int i = 0; i < MeshAttributes.Count; i++)
                {
                    MeshAttributes[i].RefreshMeshScene(value);
                }
            }
        }

        public ObservableCollection<MeshAttributeViewModel> MeshAttributes { get; }

        [Float]
        public string RotationSpeed
        {
            get => Model.RotationSpeed.ToString("F6");
            set => SetAndValidateProperty(Model.RotationSpeed.ToString(), value, Model, (m, s) => m.RotationSpeed = float.Parse(s));
        }

        

        public RenderEntityFactoryViewModel(RenderEntityFactory model) : base(model)
        {
            MeshAttributes = new(model.MeshAttributes.Select((meshAttribute) => new MeshAttributeViewModel(meshAttribute, MeshScene)));
            MeshAttributes.CollectionChanged += MeshAttributes_CollectionChanged;
        }

        [RelayCommand]
        private void OnAddMeshAttribute()
        {
            MeshAttributes.Add(new(new(string.Empty), MeshScene));
        }

        private void MeshAttributes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        var newItem = (MeshAttributeViewModel)e.NewItems[i];
                        Model.MeshAttributes.Insert(e.NewStartingIndex + i, newItem.Model);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; i++)
                        Model.MeshAttributes.RemoveAt(e.OldStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        var item = (MeshAttributeViewModel)e.NewItems[i];
                        Model.MeshAttributes[e.NewStartingIndex + i] = item.Model;
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    var item1 = Model.MeshAttributes[e.OldStartingIndex];

                    Model.MeshAttributes.RemoveAt(e.OldStartingIndex);
                    Model.MeshAttributes.Insert(e.NewStartingIndex, item1);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    Model.MeshAttributes.Clear();
                    break;
            }
        }
    }
}
