using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TPToolkitUI.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class FloatAttribute : ValidationAttribute
    {
        public string RangeErrorMessage { get; set; }
        public float MinValue { get; set; } = float.MinValue;
        public float MaxValue { get; set; } = float.MaxValue;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return new(ErrorMessage);

            if (float.TryParse(value.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var result) && !float.IsInfinity(result))
            {
                if ((result < MinValue) || (result > MaxValue))
                    return new(RangeErrorMessage);
                else
                    return ValidationResult.Success;
            }
            else
                return new(ErrorMessage);
        }

        public FloatAttribute()
        {
            ErrorMessage = "The given number is not a valid float.";
            RangeErrorMessage = "The given number is out of the valid range.";
        }
    }
}
