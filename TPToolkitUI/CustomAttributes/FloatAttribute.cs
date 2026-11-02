using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TPToolkitUI.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class FloatAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return false;

            return float.TryParse(
                value.ToString(),
                NumberStyles.Float,
                CultureInfo.CurrentCulture,
                out var result
            ) && !float.IsInfinity(result);
        }

        public FloatAttribute()
        {
            ErrorMessage = "The given number is not a valid float number.";
        }
    }
}
