using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace TPToolkitUI.Utils
{
    public static class ObservableCollectionExtensions
    {
        public static void SynchronizeTo<T>(this ObservableCollection<T> target, IList<T> source)
        {
            target.CollectionChanged += (s, e) => CollectionChangedHandler(source, e);
        }

        private static void CollectionChangedHandler<T>(IList<T> source, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var index1 = e.NewStartingIndex;
                    foreach (T item in e.NewItems)
                    {
                        source.Insert(index1, item);
                        index1++;
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (T item in e.OldItems)
                        source.Remove(item);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    foreach (T item in e.OldItems)
                        source.Remove(item);
                    var index2 = e.NewStartingIndex;
                    foreach (T item in e.NewItems)
                    {
                        source.Insert(index2, item);
                        index2++;
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    source.Clear();
                    break;
            }
        }
    }
}
