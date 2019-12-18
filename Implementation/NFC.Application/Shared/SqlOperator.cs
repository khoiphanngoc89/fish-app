using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace NFC.Application.Shared
{
    /// <summary>
    /// The sql operator.
    /// </summary>
    public enum SqlOperator
    {
        /// <summary>
        /// The equal.
        /// </summary>
        [Description("=")]
        Equal = 0,

        /// <summary>
        /// The less than.
        /// </summary>
        [Description("<")]
        LessThan,

        /// <summary>
        /// The greater than or equal.
        /// </summary>
        [Description("=<")]
        LessThanOrEqual,

        /// <summary>
        /// The greater than.
        /// </summary>
        [Description(">")]
        GeaterThan,

        /// <summary>
        /// The greater than or equal.
        /// </summary>
        [Description(">=")]
        GearterThanOrEqual
    }

    /// <summary>
    /// Provides sql operator extension methods for sql operator enum.
    /// </summary>
    public static class SqlOperatorExtension
    {
        /// <summary>
        /// Gets description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetDescription(this SqlOperator value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            if (fi.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
