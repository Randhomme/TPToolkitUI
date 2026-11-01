using TPToolkitUI.ViewModels.MeshScene;

namespace TPToolkitUI.Services
{
    public interface IDialogService
    {
        /// <summary>
        /// Asks the user to pick a name for an MsbElement, and verifies if the name is already taken in the IEnumerables params.
        /// </summary>
        /// <param name="existingElements">The IEnumerables to verify if the picked name is already taken</param>
        /// <returns>The name picked by the user, or null if the name is already taken.</returns>
        public string? PromptMsbElementName(params IEnumerable<IMsbNamedElement>[] existingElements);
    }
}
