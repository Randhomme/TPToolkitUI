using TPToolkitLib.WorldObject.Definitions.PhysicsFactories;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.PhysicsFactories
{
    public class SpaceObjectPhysicsViewModel : PhysicsDefinitionViewModel<SpaceObjectPhysics>
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
        public string Acceleration
        {
            get => Model.Acceleration.ToString("F6");
            set => SetAndValidateProperty(Model.Acceleration.ToString(), value, Model, (m, s) => m.Acceleration = float.Parse(s));
        }

        public SpaceObjectPhysicsViewModel(SpaceObjectPhysics model) : base(model)
        {
        }
    }
}
