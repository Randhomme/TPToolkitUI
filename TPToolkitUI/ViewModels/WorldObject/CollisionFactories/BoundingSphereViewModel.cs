using TPToolkitLib.Enums;
using TPToolkitLib.WorldObject.Definitions.CollisionFactories;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CollisionFactories
{
    public class BoundingSphereViewModel : CollisionDefinitionViewModel<BoundingSphere>
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

        public bool UserDefinedSphereSize
        {
            get => Model.UserDefinedSphereSize;
            set => SetAndValidateProperty(Model.UserDefinedSphereSize, value, Model, (m, b) => m.UserDefinedSphereSize = b);
        }

        [Float]
        public string LocalPositionX
        {
            get => Model.LocalPosition.X.ToString("F6");
            set => SetAndValidateProperty(Model.LocalPosition.X.ToString(), value, Model, (m, s) => m.LocalPosition = new(float.Parse(s), m.LocalPosition.Y, m.LocalPosition.Z));
        }

        [Float]
        public string LocalPositionY
        {
            get => Model.LocalPosition.Y.ToString("F6");
            set => SetAndValidateProperty(Model.LocalPosition.Y.ToString(), value, Model, (m, s) => m.LocalPosition = new(m.LocalPosition.X, float.Parse(s), m.LocalPosition.Z));
        }

        [Float]
        public string LocalPositionZ
        {
            get => Model.LocalPosition.Z.ToString("F6");
            set => SetAndValidateProperty(Model.LocalPosition.Z.ToString(), value, Model, (m, s) => m.LocalPosition = new(m.LocalPosition.X, m.LocalPosition.Y, float.Parse(s)));
        }

        [Float]
        public string Radius
        {
            get => Model.Radius.ToString("F6");
            set => SetAndValidateProperty(Model.Radius.ToString(), value, Model, (m, s) => m.Radius = float.Parse(s));
        }

        public BoundingSphereViewModel(BoundingSphere model) : base(model)
        {
        }
    }
}
