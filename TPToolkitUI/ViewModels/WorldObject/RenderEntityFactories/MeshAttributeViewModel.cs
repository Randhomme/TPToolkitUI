using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitLib.WorldObject.Definitions.RenderEntityFactories.RenderEntityFactoryClasses;
using TPToolkitLib.WorldObject.Definitions.RenderEntityFactories.RenderEntityFactoryClasses.MeshAttributes;
using TPToolkitUI.Utils;
using TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories.MeshSubAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories
{
    public partial class MeshAttributeViewModel : CustomObservableValidator
    {
        private MsbScene meshScene;
        public MeshAttribute Model { get; }

        public MsbElement? Mesh
        {
            get => Model.Mesh;
            set => SetAndValidateProperty(Model.Mesh, value, Model, (m, mesh) => m.Mesh = mesh);
        }

        public ObservableCollection<MeshSubAttributeViewModel> MeshSubAttributes { get; }

        public IEnumerable<MsbElement> AvailableMsbElements { get => meshScene.MsbNodes.Concat<MsbElement>(meshScene.MsbMeshes); }

        public MeshAttributeViewModel(MeshAttribute model, MsbScene meshScene)
        {
            this.meshScene = meshScene;
            Model = model;
            Mesh ??= AvailableMsbElements.FirstOrDefault();
            MeshSubAttributes = new(Model.MeshSubAttributes.Select((msa) => new MeshSubAttributeViewModel(msa, meshScene)));
            MeshSubAttributes.CollectionChanged += MeshSubAttributes_CollectionChanged;
        }

        [RelayCommand]
        private void OnAddMeshSubAttribute()
        {
            MeshSubAttributes.Add(new(new BoardingEffectPoint(), meshScene));
        }

        private void MeshSubAttributes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        var newItem = (MeshSubAttributeViewModel)e.NewItems[i];
                        Model.MeshSubAttributes.Insert(e.NewStartingIndex + i, newItem.Model);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; i++)
                        Model.MeshSubAttributes.RemoveAt(e.OldStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        var item = (MeshSubAttributeViewModel)e.NewItems[i];
                        Model.MeshSubAttributes[e.NewStartingIndex + i] = item.Model;
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    var item1 = Model.MeshSubAttributes[e.OldStartingIndex];

                    Model.MeshSubAttributes.RemoveAt(e.OldStartingIndex);
                    Model.MeshSubAttributes.Insert(e.NewStartingIndex, item1);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    Model.MeshSubAttributes.Clear();
                    break;
            }
        }

        public void RefreshMeshScene(MsbScene newMeshScene)
        {
            RefreshAvailableMsbElements(newMeshScene);
            RefreshMeshSubAttributes(newMeshScene);
        }

        private void RefreshAvailableMsbElements(MsbScene newMeshScene)
        {
            this.meshScene = newMeshScene;
            var mesh = Model.Mesh;
            OnPropertyChanged(nameof(AvailableMsbElements));
            var newMesh = AvailableMsbElements.FirstOrDefault((m) => m.Name.Equals(mesh?.Name));
            Mesh = newMesh ?? AvailableMsbElements.FirstOrDefault(); // Try to get an element with the same name
        }
        
        
        private void RefreshMeshSubAttributes(MsbScene newMeshScene)
        {
            for (int i = 0; i < MeshSubAttributes.Count; i++)
            {
                var meshSubAttribute = MeshSubAttributes[i];
                // Refresh adjacent list for damage section attributes
                if (meshSubAttribute.ModelPropertiesViewModel is DamageSectionViewModel damageSectionViewModel)
                    damageSectionViewModel.RefreshAvailableAdjacentElements(newMeshScene, true);
                // Refresh animation list for dock point attributes
                else if (meshSubAttribute.ModelPropertiesViewModel is DockPointViewModel dockPointViewModel)
                    dockPointViewModel.RefreshAvailableAnimations(newMeshScene.MsbAnimations);
            }
        }

        public override string ToString()
        {
            return Model.MeshName;
        }
    }
}
