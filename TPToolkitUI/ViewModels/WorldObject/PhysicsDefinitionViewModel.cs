using TPToolkitLib.WorldObject.Definitions;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.WorldObject
{
    public class PhysicsDefinitionViewModel : CustomObservableValidator
    {
    }

    public class PhysicsDefinitionViewModel<T> : PhysicsDefinitionViewModel where T : PhysicsDefinition
    {
        public T Model { get; }
        public PhysicsDefinitionViewModel(T model)
        {
            Model = model;
        }
    }
}
