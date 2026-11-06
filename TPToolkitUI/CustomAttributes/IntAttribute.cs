using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TPToolkitUI.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IntAttribute : ValidationAttribute
    {
        public string RangeErrorMessage { get; set; }
        public int MinValue { get; set; } = int.MinValue;
        public int MaxValue { get; set; } = int.MaxValue;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return new(FormatErrorMessage(validationContext.DisplayName));

            if (int.TryParse(value.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture, out var result))
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

        public IntAttribute()
        {
            ErrorMessage = "The given number is not a valid integer.";
            RangeErrorMessage = "The given number is out of the valid range.\nMinimum: {0}\nMaximum: {1}";
        }
    }
}
