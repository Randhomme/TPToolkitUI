using TPToolkitLib.MeshScene.Classes;
using TPToolkitUI.CustomAttributes;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.MeshScene
{
    public class MsbKeyframeViewModel : CustomObservableValidator
    {
        public MsbKeyframe Model { get; }

        [Float]
        public string Time
        {
            get => Model.Time.ToString("F6");
            set => SetAndValidateProperty(Model.Time.ToString(), value, Model, (m, s) => m.Time = float.Parse(s));
        }

        [Float]
        public string Value
        {
            get => Model.Value.ToString("F6");
            set => SetAndValidateProperty(Model.Value.ToString(), value, Model, (m, s) => m.Value = float.Parse(s));
        }

        [Int]
        public string Smoothing
        {
            get => Model.Smoothing.ToString("F6");
            set => SetAndValidateProperty(Model.Smoothing.ToString(), value, Model, (m, s) => m.Smoothing = int.Parse(s));
        }

        [Float]
        public string Tension
        {
            get => Model.Tension.ToString("F6");
            set => SetAndValidateProperty(Model.Tension.ToString(), value, Model, (m, s) => m.Tension = float.Parse(s));
        }

        [Float]
        public string Continuity
        {
            get => Model.Continuity.ToString("F6");
            set => SetAndValidateProperty(Model.Continuity.ToString(), value, Model, (m, s) => m.Continuity = float.Parse(s));
        }

        [Float]
        public string Bias
        {
            get => Model.Bias.ToString("F6");
            set => SetAndValidateProperty(Model.Bias.ToString(), value, Model, (m, s) => m.Bias = float.Parse(s));
        }

        [Float]
        public string IncomingTangent
        {
            get => Model.IncomingTangent.ToString("F6");
            set => SetAndValidateProperty(Model.IncomingTangent.ToString(), value, Model, (m, s) => m.IncomingTangent = float.Parse(s));
        }

        [Float]
        public string OutgoingTangent
        {
            get => Model.OutgoingTangent.ToString("F6");
            set => SetAndValidateProperty(Model.OutgoingTangent.ToString(), value, Model, (m, s) => m.OutgoingTangent = float.Parse(s));
        }

        public MsbKeyframeViewModel(MsbKeyframe model)
        {
            Model = model;
        }

        public override string ToString()
        {
            return "Keyframe";
        }
    }
}
