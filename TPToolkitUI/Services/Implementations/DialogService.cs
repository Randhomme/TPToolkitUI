using System.Windows;
using TPToolkitUI.Dialogs;
using TPToolkitUI.ViewModels;

namespace TPToolkitUI.Services.Implementations
{
    public class DialogService : IDialogService
    {
        private readonly Window owner;

        public DialogService(Window owner)
        {
            this.owner = owner;
        }

        public bool? ShowSettings(AppSettings settings, bool showInTaskBar = false)
        {
            var vm = new AppSettingsViewModel(settings);
            return new AppSettingsDialog(owner, vm).ShowDialog(showInTaskBar);
        }
    }
}
