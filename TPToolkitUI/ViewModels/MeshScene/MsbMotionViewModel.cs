using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public partial class MsbMotionViewModel : CustomObservableValidator
    {
        public MsbMotion Model { get; }

        [ObservableProperty]
        public partial MsbElementViewModel? MsbElement { get; set; }

        public ObservableCollection<MsbKeyframeViewModel> Channel1 { get; } = [];
        public ObservableCollection<MsbKeyframeViewModel> Channel2 { get; } = [];
        public ObservableCollection<MsbKeyframeViewModel> Channel3 { get; } = [];
        public ObservableCollection<MsbKeyframeViewModel> Channel4 { get; } = [];
        public ObservableCollection<MsbKeyframeViewModel> Channel5 { get; } = [];
        public ObservableCollection<MsbKeyframeViewModel> Channel6 { get; } = [];

        public CompositeObservableCollection<MsbElementViewModel> AvailableElements { get; }

        public MsbMotionViewModel(MsbMotion model, CompositeObservableCollection<MsbElementViewModel> availableElements)
        {
            Model = model;
            AvailableElements = availableElements;
            PopulateChannels(model);
            Channel1.CollectionChanged += (s, e) => Keyframes_CollectionChanged(e, model.MsbChannel1);
            Channel2.CollectionChanged += (s, e) => Keyframes_CollectionChanged(e, model.MsbChannel2);
            Channel3.CollectionChanged += (s, e) => Keyframes_CollectionChanged(e, model.MsbChannel3);
            Channel4.CollectionChanged += (s, e) => Keyframes_CollectionChanged(e, model.MsbChannel4);
            Channel5.CollectionChanged += (s, e) => Keyframes_CollectionChanged(e, model.MsbChannel5);
            Channel6.CollectionChanged += (s, e) => Keyframes_CollectionChanged(e, model.MsbChannel6);
        }

        [RelayCommand]
        private void OnAddChannel1Keyframe()
        {
            Channel1.Add(new(new()));
        }

        [RelayCommand]
        private void OnAddChannel2Keyframe()
        {
            Channel2.Add(new(new()));
        }

        [RelayCommand]
        private void OnAddChannel3Keyframe()
        {
            Channel3.Add(new(new()));
        }

        [RelayCommand]
        private void OnAddChannel4Keyframe()
        {
            Channel4.Add(new(new()));
        }

        [RelayCommand]
        private void OnAddChannel5Keyframe()
        {
            Channel5.Add(new(new()));
        }

        [RelayCommand]
        private void OnAddChannel6Keyframe()
        {
            Channel6.Add(new(new()));
        }

        private void PopulateChannels(MsbMotion model)
        {
            for (int i = 0; i < model.MsbChannel1.Count; i++)
                Channel1.Add(new(model.MsbChannel1[i]));
            for (int i = 0; i < model.MsbChannel2.Count; i++)
                Channel2.Add(new(model.MsbChannel2[i]));
            for (int i = 0; i < model.MsbChannel3.Count; i++)
                Channel3.Add(new(model.MsbChannel3[i]));
            for (int i = 0; i < model.MsbChannel4.Count; i++)
                Channel4.Add(new(model.MsbChannel4[i]));
            for (int i = 0; i < model.MsbChannel5.Count; i++)
                Channel5.Add(new(model.MsbChannel5[i]));
            for (int i = 0; i < model.MsbChannel6.Count; i++)
                Channel6.Add(new(model.MsbChannel6[i]));
        }

        private void Keyframes_CollectionChanged(NotifyCollectionChangedEventArgs e, IList<MsbKeyframe> modelChannel)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        var newItem = (MsbKeyframeViewModel)e.NewItems[i];
                        modelChannel.Insert(e.NewStartingIndex + i, newItem.Model);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; i++)
                        modelChannel.RemoveAt(e.OldStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        var item = (MsbKeyframeViewModel)e.NewItems[i];
                        modelChannel[e.NewStartingIndex + i] = item.Model;
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    var item1 = modelChannel[e.OldStartingIndex];

                    modelChannel.RemoveAt(e.OldStartingIndex);
                    modelChannel.Insert(e.NewStartingIndex, item1);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    modelChannel.Clear();
                    break;
            }
        }

        public override string ToString()
        {
            return MsbElement?.Name ?? "None";
        }
    }
}
