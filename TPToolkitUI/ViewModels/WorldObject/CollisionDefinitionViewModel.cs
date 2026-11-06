using TPToolkitLib.WorldObject.Definitions;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.WorldObject
{
    public class CollisionDefinitionViewModel : CustomObservableValidator
    {
    }

    public class CollisionDefinitionViewModel<T> : CollisionDefinitionViewModel where T : CollisionDefinition
    {
        public T Model { get; }
        public CollisionDefinitionViewModel(T model)
        {
            Model = model;
        }
    }
}
