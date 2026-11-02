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
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        source.Insert(e.NewStartingIndex + i, (T)e.NewItems[i]);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; i++)
                        source.RemoveAt(e.OldStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        source[e.NewStartingIndex + i] =
                            (T)e.NewItems[i];
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    var item1 = source[e.OldStartingIndex];

                    source.RemoveAt(e.OldStartingIndex);
                    source.Insert(e.NewStartingIndex, item1);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    source.Clear();
                    break;
            }
        }
    }
}
