using TPToolkitUI.Enums;
using TPToolkitUI.ViewModels.MeshScene;

namespace TPToolkitUI.Services
{
    public interface IDialogService
    {
        /// <summary>
        /// Start a work and report progress.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="autoClose">If the view automatically closes when the job is done, unless a warning / error is shown.</param>
        /// <param name="notifyOnFinish">If the view notifies the user when the job is done.</param>
        public void StartAsyncWorkWithProgress(Action<IProgress<string>, IProgress<string>> action, bool autoClose, bool notifyOnFinish);

        /// <summary>
        /// Asks the user to pick a name for an MsbElement, and verifies if the name is already taken in the IEnumerables params.
        /// </summary>
        /// <param name="existingElements">The IEnumerables to verify if the picked name is already taken</param>
        /// <returns>The name picked by the user. The default is string.Empty.</returns>
        public string PromptMsbElementName(params IEnumerable<IMsbNamedElement>[] existingElements);

        /// <summary>
        /// Asks the user to select one file, using different parameters, and return the selected file path.
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="filter">The filter used to select the file</param>
        /// <param name="defaultExt">The default extension</param>
        /// <param name="initialDirectory">The initial directory to look in</param>
        /// <returns>The selected file full path</returns>
        public string BrowseFileImport(string title, string filter, string defaultExt, string initialDirectory);

        /// <summary>
        /// Asks the user to select one or multiple file, using different parameters, and return the selected file path.
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="filter">The filter used to select the file</param>
        /// <param name="defaultExt">The default extension</param>
        /// <param name="initialDirectory">The initial directory to look in</param>
        /// <returns>An array containing the full path of each selected file</returns>
        public string[] BrowseFilesImport(string title, string filter, string defaultExt, string initialDirectory);

        /// <summary>
        /// Asks the user to select one file, using different parameters, and return the selected file path.
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="filter">The filter used to select the file</param>
        /// <param name="defaultExt">The default extension</param>
        /// <param name="initialDirectory">The initial directory to look in</param>
        /// <returns>The selected file full path</returns>
        public string BrowseFileExport(string title, string filter, string defaultExt, string initialDirectory);

        /// <summary>
        /// Asks the user to select a directory, with different parameters, and return the selected directory path.
        /// </summary>
        /// <param name="title">The title of the dialog.</param>
        /// <param name="initialDirectory">The initial directory to look in.</param>
        /// <returns></returns>
        public string BrowseDirectoryExport(string title, string initialDirectory);

        /// <summary>
        /// Asks the user to pick a 3D file format.
        /// </summary>
        /// <param name="defaultFormat">The format selected by default.</param>
        /// <returns>The format selected by the user.</returns>
        public File3DFormat? PromptFile3DFormat(File3DFormat defaultFormat);

        /// <summary>
        /// Open the specified settings for modification.
        /// </summary>
        /// <param name="settings">The settings to modify.</param>
        /// <returns>The dialog result.</returns>
        public bool OpenAppSettings(AppSettings settings);

        public void DisplayWarning(string title, string message);
    }
}
