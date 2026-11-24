using TPToolkitLib.WorldObject.Definitions;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.WorldObject
{
    public class CustomInfoDefinitionViewModel : CustomObservableValidator
    {
    }

    public class CustomInfoDefinitionViewModel<T> : CustomInfoDefinitionViewModel where T : CustomInfoDefinition
    {
        public T Model { get; }
        public CustomInfoDefinitionViewModel(T model)
        {
            Model = model;
        }
    }
}
