using TPToolkitLib.Enums;
using TPToolkitLib.WorldObject.Definitions.CollisionFactories;

namespace TPToolkitUI.ViewModels.WorldObject.CollisionFactories
{
    public class PointViewModel : CollisionDefinitionViewModel<Point>
    {
        public DetectionType DetectionType
        {
            get => Model.DetectionType;
            set => SetAndValidateProperty(Model.DetectionType, value, Model, (m, dt) => m.DetectionType = dt);
        }

        public ResponseType ResponseType
        {
            get => Model.ResponseType;
            set => SetAndValidateProperty(Model.ResponseType, value, Model, (m, rt) => m.ResponseType = rt);
        }

        public PointViewModel(Point model) : base(model)
        {
        }
    }
}
