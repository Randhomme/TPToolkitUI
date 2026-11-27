using TPToolkitLib.WorldObject.Definitions;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.WorldObject
{
    public class RenderEntityDefinitionViewModel : CustomObservableValidator
    {
    }

    public class RenderEntityDefinitionViewModel<T> : RenderEntityDefinitionViewModel where T : RenderEntityDefinition
    {
        public T Model { get; }
        public RenderEntityDefinitionViewModel(T model)
        {
            Model = model;
        }
    }
}
