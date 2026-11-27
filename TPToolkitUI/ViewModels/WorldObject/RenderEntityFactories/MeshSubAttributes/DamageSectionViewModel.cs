using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitLib.WorldObject.Enums;
using TPToolkitUI.CustomAttributes;
using TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories.MeshSubAttributes.DamageSection;

namespace TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories.MeshSubAttributes
{
    public partial class DamageSectionViewModel : MeshSubAttributePropertiesBaseViewModel<TPToolkitLib.WorldObject.Definitions.RenderEntityFactories.RenderEntityFactoryClasses.MeshAttributes.DamageSection>
    {
        public bool VitalToShip
        {
            get => Model.VitalToShip;
            set => SetAndValidateProperty(Model.VitalToShip, value, Model, (m, b) => m.VitalToShip = b);
        }

        public bool VitalToMaxVelocity
        {
            get => Model.VitalToMaxVelocity;
            set => SetAndValidateProperty(Model.VitalToMaxVelocity, value, Model, (m, b) => m.VitalToMaxVelocity = b);
        }

        public bool VitalToManeuverability
        {
            get => Model.VitalToManeuverability;
            set => SetAndValidateProperty(Model.VitalToManeuverability, value, Model, (m, b) => m.VitalToManeuverability = b);
        }

        public bool VitalToMission
        {
            get => Model.VitalToMission;
            set => SetAndValidateProperty(Model.VitalToMission, value, Model, (m, b) => m.VitalToMission = b);
        }

        public bool Swappable
        {
            get => Model.Swappable;
            set => SetAndValidateProperty(Model.Swappable, value, Model, (m, b) => m.Swappable = b);
        }

        public Material Material
        {
            get => Model.Material;
            set => SetAndValidateProperty(Model.Material, value, Model, (m, mt) => m.Material = mt);
        }

        [Int]
        public string Hitpoints
        {
            get => Model.Hitpoints.ToString();
            set => SetAndValidateProperty(Model.Hitpoints.ToString(), value, Model, (m, s) => m.Hitpoints = int.Parse(s));
        }

        [Int(MinValue = 0)]
        public string VitalSectionCoreDamagePercent
        {
            get => Model.VitalSectionCoreDamagePercent.ToString();
            set => SetAndValidateProperty(Model.VitalSectionCoreDamagePercent.ToString(), value, Model, (m, s) => m.VitalSectionCoreDamagePercent = int.Parse(s));
        }

        [ObservableProperty]
        public partial bool HasDebrisMeshScene { get; set; }

        public MsbScene? DebrisMsbScene
        {
            get => Model.DebrisMsbScene;
            set => SetAndValidateProperty(Model.DebrisMsbScene, value, Model, (m, msbScene) => m.DebrisMsbScene = msbScene);
        }

        public string DebrisFx
        {
            get => Model.DebrisFx;
            set => SetAndValidateProperty(Model.DebrisFx, value, Model, (m, s) => m.DebrisFx = s);
        }

        public ObservableCollection<CriticalViewModel> Criticals { get; } = [];

        public ObservableCollection<AdjacentElementViewModel> AdjacentElements { get; } = [];

        public ObservableCollection<DestructFxViewModel> DestructFxs { get; }

        public DamageSectionViewModel(TPToolkitLib.WorldObject.Definitions.RenderEntityFactories.RenderEntityFactoryClasses.MeshAttributes.DamageSection model, MsbScene meshScene) : base(model)
        {
            foreach (Critical critical in (Critical[])Enum.GetValues(typeof(Critical)))
            {
                Criticals.Add(new(critical, model.Criticals));
            }
            RefreshAvailableAdjacentElements(meshScene, false);
            DestructFxs = new(model.DestructFxs.Select((dfx) => new DestructFxViewModel(dfx)));
            DestructFxs.CollectionChanged += DestructFxs_CollectionChanged;
        }

        [RelayCommand]
        private void OnAddDestructFx()
        {
            DestructFxs.Add(new(new()));
        }

        partial void OnHasDebrisMeshSceneChanged(bool value)
        {
            if (value)
            {
                if (DebrisMsbScene == null)
                    DebrisMsbScene = AppSettings.MeshScenes.FirstOrDefault();
                if (string.IsNullOrWhiteSpace(DebrisFx))
                    DebrisFx = AppSettings.Effects.FirstOrDefault();
            }
            else
            {
                DebrisMsbScene = null;
                DebrisFx = string.Empty;
            }
        }

        private void DestructFxs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        var newItem = (DestructFxViewModel)e.NewItems[i];
                        Model.DestructFxs.Insert(e.NewStartingIndex + i, newItem.Model);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; i++)
                        Model.DestructFxs.RemoveAt(e.OldStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        var item = (DestructFxViewModel)e.NewItems[i];
                        Model.DestructFxs[e.NewStartingIndex + i] = item.Model;
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    var item1 = Model.DestructFxs[e.OldStartingIndex];

                    Model.DestructFxs.RemoveAt(e.OldStartingIndex);
                    Model.DestructFxs.Insert(e.NewStartingIndex, item1);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    Model.DestructFxs.Clear();
                    break;
            }
        }

        public void RefreshAvailableAdjacentElements(MsbScene meshScene, bool clearExistingAdjacents)
        {
            AdjacentElements.Clear();
            if (clearExistingAdjacents)
            {
                Model.Adjacents.Clear();
                Model.AdjacentElements.Clear();
            }
            for (int i = 0; i < meshScene.MsbMeshes.Count; i++)
            {
                AdjacentElements.Add(new(meshScene.MsbMeshes[i], Model.Adjacents, Model.AdjacentElements));
            }
        }


    }
}
