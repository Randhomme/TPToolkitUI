using System.Windows;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitUI.Dialogs;
using TPToolkitUI.ViewModels;

namespace TPToolkitUI.Services.Implementations
{
    public class DialogService : IDialogService
    {
        private readonly Window owner;

        public DialogService()
        {
            this.owner = Application.Current.MainWindow;
        }

        public DialogService(Window owner)
        {
            this.owner = owner;
        }

        public string? PromptMsbElementName(params IEnumerable<MsbNamedElement>[] existingElementsCollection)
        {
            var vm = new MsbElementNamePickerViewModel(existingElementsCollection);
            var dialog = new MsbElementNamePicker(owner) { DataContext = vm };
            if (dialog.ShowDialog() == true)
                return vm.MsbElementName;
            return null;
        }
    }
}
