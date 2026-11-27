using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.Enums;
using TPToolkitLib.WorldObject.Enums;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories.MeshSubAttributes.DamageSection
{
    public partial class CriticalViewModel(Critical critical, IList<Critical> criticals) : CustomObservableValidator
    {
        private readonly IList<Critical> criticals = criticals;

        private readonly Critical critical = critical;

        [ObservableProperty]
        public partial bool IsSelected { get; set; } = criticals.Contains(critical);

        partial void OnIsSelectedChanged(bool value)
        {
            if (value)
                criticals.Add(critical);
            else
                RemoveCriticalFromList(critical);
        }

        private void RemoveCriticalFromList(Critical critical)
        {
            for (int i = criticals.Count - 1; i >= 0; i--)
            {
                if (criticals[i] == critical)
                    criticals.RemoveAt(i);
            }
        }

        public override string ToString()
        {
            return critical.GetName();
        }
    }
}
