using TPToolkitLib.WorldObject.Definitions;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.WorldObject
{
    public class AiEntityDefinitionViewModel : CustomObservableValidator
    {
    }

    public class AiEntityDefinitionViewModel<T> : AiEntityDefinitionViewModel where T : AiEntityDefinition
    {
        public T Model { get; }
        public AiEntityDefinitionViewModel(T model)
        {
            Model = model;
        }
    }
}
