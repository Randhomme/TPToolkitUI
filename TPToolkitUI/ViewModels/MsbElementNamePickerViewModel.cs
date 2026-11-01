using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPToolkitLib.MeshScene.Classes;

namespace TPToolkitUI.ViewModels
{
    public partial class MsbElementNamePickerViewModel : ObservableObject
    {
        private readonly IEnumerable<MsbNamedElement>[] existingElementsCollection;
        public string? MsbElementName { get; private set; }
        public MsbElementNamePickerViewModel(IEnumerable<MsbNamedElement>[] existingElementsCollection)
        {
            this.existingElementsCollection = existingElementsCollection;
        }

        public bool IsMsbElementNameValid(string name)
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
            MsbElementName = name;
            return false;
        }
    }
}
