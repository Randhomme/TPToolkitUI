namespace TPToolkitUI.Services
{
    public interface IDialogService
    {
        public bool? ShowSettings(AppSettings settings, bool showInTaskBar = false);
    }
}
