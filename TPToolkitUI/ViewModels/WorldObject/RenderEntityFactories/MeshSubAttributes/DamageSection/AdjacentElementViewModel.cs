using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitLib.WorldObject.Enums;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.WorldObject.RenderEntityFactories.MeshSubAttributes.DamageSection
{
    public partial class AdjacentElementViewModel(MsbMesh adjacentElement, IList<string> adjacents, IList<MsbMesh> adjacentElements) : CustomObservableValidator
    {
        private readonly MsbMesh adjacentElement = adjacentElement;
        private readonly IList<string> adjacents = adjacents;
        private readonly IList<MsbMesh> adjacentElements = adjacentElements;

        [ObservableProperty]
        public partial bool IsSelected { get; set; } = adjacentElements.Contains(adjacentElement);

        partial void OnIsSelectedChanged(bool value)
        {
            if (value)
            {
                adjacents.Add(adjacentElement.Name);
                adjacentElements.Add(adjacentElement);
            }
            else
            {
                for (int i = adjacents.Count - 1; i >= 0; i--)
                {
                    if (adjacents[i] == adjacentElement.Name)
                        adjacents.RemoveAt(i);
                }
                for (int i = adjacentElements.Count - 1; i >= 0; i--)
                {
                    if (adjacentElements[i] == adjacentElement)
                        adjacentElements.RemoveAt(i);
                }
            }
        }

        public override string ToString()
        {
            return adjacentElement.Name;
        }
    }
}
