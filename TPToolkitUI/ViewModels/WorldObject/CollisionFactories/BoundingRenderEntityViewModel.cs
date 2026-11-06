using TPToolkitLib.Enums;
using TPToolkitLib.WorldObject.Definitions.CollisionFactories;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CollisionFactories
{
    public class BoundingRenderEntityViewModel : CollisionDefinitionViewModel<BoundingRenderEntity>
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
            set => SetAndValidateProperty(Model.UserDefinedSphereSize, value, Model, (m, b) =>  m.UserDefinedSphereSize = b);
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

        public bool UserDefinedBoundingBoxExtents
        {
            get => Model.UserDefinedBoundingBoxExtents;
            set => SetAndValidateProperty(Model.UserDefinedBoundingBoxExtents, value, Model, (m, b) => m.UserDefinedBoundingBoxExtents = b);
        }

        [Float]
        public string MinExtentsX
        {
            get => Model.MinExtents.X.ToString("F6");
            set => SetAndValidateProperty(Model.MinExtents.X.ToString(), value, Model, (m, s) => m.MinExtents = new(float.Parse(s), m.MinExtents.Y, m.MinExtents.Z));
        }

        [Float]
        public string MinExtentsY
        {
            get => Model.MinExtents.Y.ToString("F6");
            set => SetAndValidateProperty(Model.MinExtents.Y.ToString(), value, Model, (m, s) => m.MinExtents = new(m.MinExtents.X, float.Parse(s), m.MinExtents.Z));
        }

        [Float]
        public string MinExtentsZ
        {
            get => Model.MinExtents.Z.ToString("F6");
            set => SetAndValidateProperty(Model.MinExtents.Z.ToString(), value, Model, (m, s) => m.MinExtents = new(m.MinExtents.X, m.MinExtents.Y, float.Parse(s)));
        }

        [Float]
        public string MaxExtentsX
        {
            get => Model.MaxExtents.X.ToString("F6");
            set => SetAndValidateProperty(Model.MaxExtents.X.ToString(), value, Model, (m, s) => m.MaxExtents = new(float.Parse(s), m.MaxExtents.Y, m.MaxExtents.Z));
        }

        [Float]
        public string MaxExtentsY
        {
            get => Model.MaxExtents.Y.ToString("F6");
            set => SetAndValidateProperty(Model.MaxExtents.Y.ToString(), value, Model, (m, s) => m.MaxExtents = new(m.MaxExtents.X, float.Parse(s), m.MaxExtents.Z));
        }

        [Float]
        public string MaxExtentsZ
        {
            get => Model.MaxExtents.Z.ToString("F6");
            set => SetAndValidateProperty(Model.MaxExtents.Z.ToString(), value, Model, (m, s) => m.MaxExtents = new(m.MaxExtents.X, m.MaxExtents.Y, float.Parse(s)));
        }

        public BoundingRenderEntityViewModel(BoundingRenderEntity model) : base(model)
        {
        }
    }
}
