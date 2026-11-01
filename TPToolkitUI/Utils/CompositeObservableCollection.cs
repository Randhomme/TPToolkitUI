using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace TPToolkitUI.Utils
{
    public class CompositeObservableCollection<T> : ObservableCollection<T>, IDisposable
    {
        private readonly List<IReadOnlyCollection<T>> sources = [];

        public CompositeObservableCollection(params IReadOnlyCollection<T>[] collections)
        {
            if (collections == null)
                throw new ArgumentNullException(nameof(collections));

            foreach (var collection in collections)
            {
                if (collection == null)
                    throw new ArgumentException("A source collection cannot be null.");
                if (sources.Contains(collection))
                    throw new ArgumentException("A source collection cannot be added twice.");
                sources.Add(collection);
                foreach (var item in collection)
                    Add(item);
                if (collection is INotifyCollectionChanged notifyCollectionChanged)
                    notifyCollectionChanged.CollectionChanged += OnSourceCollectionChanged;
            }
        }

        private void OnSourceCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is not IReadOnlyCollection<T> source)
                return;
            int sourceIndex = sources.IndexOf(source);
            if (sourceIndex < 0)
                return;
            int globalIndex = GetGlobalIndex(sourceIndex);
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems == null)
                        return;
                    for (int i = 0; i < e.NewItems.Count; i++)
                        Insert(globalIndex + e.NewStartingIndex + i, (T)e.NewItems[i]);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems == null)
                        return;
                    for (int i = 0; i < e.OldItems.Count; i++)
                        RemoveAt(globalIndex + e.OldStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if (e.NewItems == null)
                        return;
                    for (int i = 0; i < e.NewItems.Count; i++)
                        this[globalIndex + e.NewStartingIndex + i] = (T)e.NewItems[i];
                    break;
                case NotifyCollectionChangedAction.Move:
                    if (e.OldItems == null)
                        return;
                    int oldIndex = globalIndex + e.OldStartingIndex;
                    int newIndex = globalIndex + e.NewStartingIndex;
                    for (int i = 0; i < e.OldItems.Count; i++)
                        Move(oldIndex + i, newIndex + i);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Refresh();
                    break;
            }
        }

        private int GetGlobalIndex(int sourceIndex)
        {
            int index = 0;
            for (int i = 0; i < sourceIndex; i++)
                index += sources[i].Count;
            return index;
        }

        private void Refresh()
        {
            Clear();
            foreach (var source in sources)
                foreach (var item in source)
                    Add(item);
        }

        public void Dispose()
        {
            foreach (var source in sources)
                if (source is INotifyCollectionChanged notifyCollectionChanged)
                    notifyCollectionChanged.CollectionChanged -= OnSourceCollectionChanged;
            sources.Clear();
            Clear();
        }
    }
}
