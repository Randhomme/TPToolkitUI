using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitUI.ViewModels.MeshScene;

namespace TPToolkitUI.ViewModels
{
    public partial class MsbElementNamePickerViewModel : ObservableObject
    {
        private readonly IEnumerable<IMsbNamedElement>[] existingElementsCollection;
        public string MsbElementName { get; private set; } = string.Empty;
        public MsbElementNamePickerViewModel(IEnumerable<IMsbNamedElement>[] existingElementsCollection)
        {
            this.existingElementsCollection = existingElementsCollection;
        }

        public void SetElementName(string name)
        {
            if (IsMsbElementNameValid(name))
                MsbElementName = name;
        }

        private bool IsMsbElementNameValid(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new("The name should not be empty.");
            else if (IsMsbElementNameAlreadyTaken(name))
                throw new("The name is already used by another element, choose a different name.");
            return true;
        }

        private bool IsMsbElementNameAlreadyTaken(string name)
        {
            for (int i = 0; i < existingElementsCollection.Length; i++)
            {
                var existingElements = existingElementsCollection[i];
                foreach (var item in existingElements)
                {
                    if (string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase))
                        return true;
                }
            }
            return false;
        }
    }
}
