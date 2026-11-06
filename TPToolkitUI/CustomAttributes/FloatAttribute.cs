using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Linq;

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
                return new(FormatErrorMessage(validationContext.DisplayName));

            if (float.TryParse(value.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var result) && !float.IsInfinity(result))
            {
                if ((result < MinValue) || (result > MaxValue))
                    return new(FormatRangeErrorMessage());
                else
                    return ValidationResult.Success;
            }
            else
                return new(FormatErrorMessage(validationContext.DisplayName));
        }

        private string FormatRangeErrorMessage()
        {
            return string.Format(CultureInfo.CurrentCulture, RangeErrorMessage, MinValue, MaxValue);
        }

        public FloatAttribute()
        {
            ErrorMessage = "The given number is not a valid float.";
            RangeErrorMessage = "The given number is out of the valid range.\nMinimum: {0}\nMaximum: {1}";
        }
    }
}
