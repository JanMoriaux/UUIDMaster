using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace UUIDMaster.Validation
{
    [AttributeUsage(AttributeTargets.Property |
  AttributeTargets.Field, AllowMultiple = false)]
    public sealed class GUIDValidationAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessage, name);
        }

        public override bool IsValid(object value)
        {
            var result = false;
            if (value != null)
            {
                var stringValue = value.ToString();
                Guid guid;
                result = Guid.TryParse(stringValue, out guid);
            }
            return result;
        }
    }
}
