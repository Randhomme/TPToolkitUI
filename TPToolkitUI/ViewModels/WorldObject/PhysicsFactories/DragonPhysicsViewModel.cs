using TPToolkitLib.WorldObject.Definitions.PhysicsFactories;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.PhysicsFactories
{
    public class DragonPhysicsViewModel : PhysicsDefinitionViewModel<DragonPhysics>
    {
        [Float]
        public string CenterOfMassX
        {
            get => Model.CenterOfMass.X.ToString("F6");
            set => SetAndValidateProperty(Model.CenterOfMass.X.ToString(), value, Model, (m, s) => m.CenterOfMass = new(float.Parse(s), m.CenterOfMass.Y, m.CenterOfMass.Z));
        }

        [Float]
        public string CenterOfMassY
        {
            get => Model.CenterOfMass.Y.ToString("F6");
            set => SetAndValidateProperty(Model.CenterOfMass.Y.ToString(), value, Model, (m, s) => m.CenterOfMass = new(m.CenterOfMass.X, float.Parse(s), m.CenterOfMass.Z));
        }

        [Float]
        public string CenterOfMassZ
        {
            get => Model.CenterOfMass.Z.ToString("F6");
            set => SetAndValidateProperty(Model.CenterOfMass.Z.ToString(), value, Model, (m, s) => m.CenterOfMass = new(m.CenterOfMass.X, m.CenterOfMass.Y, float.Parse(s)));
        }

        [Float(MinValue = 0)]
        public string Mass
        {
            get => Model.Mass.ToString("F6");
            set => SetAndValidateProperty(Model.Mass.ToString(), value, Model, (m, s) => m.Mass = float.Parse(s));
        }

        [Float]
        public string MaxThrust
        {
            get => Model.MaxThrust.ToString("F6");
            set => SetAndValidateProperty(Model.MaxThrust.ToString(), value, Model, (m, s) => m.MaxThrust = float.Parse(s));
        }

        [Float]
        public string MaxSpeed
        {
            get => Model.MaxSpeed.ToString("F6");
            set => SetAndValidateProperty(Model.MaxSpeed.ToString(), value, Model, (m, s) => m.MaxSpeed = float.Parse(s));
        }

        [Float]
        public string RotationalFriction
        {
            get => Model.RotationalFriction.ToString("F6");
            set => SetAndValidateProperty(Model.RotationalFriction.ToString(), value, Model, (m, s) => m.RotationalFriction = float.Parse(s));
        }

        [Float]
        public string MaxAngularAcceleration
        {
            get => Model.MaxAngularAcceleration.ToString("F6");
            set => SetAndValidateProperty(Model.MaxAngularAcceleration.ToString(), value, Model, (m, s) => m.MaxAngularAcceleration = float.Parse(s));
        }

        public DragonPhysicsViewModel(DragonPhysics model) : base(model)
        {
        }
    }
}
