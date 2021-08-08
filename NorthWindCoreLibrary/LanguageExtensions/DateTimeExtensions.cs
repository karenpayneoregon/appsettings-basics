using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindCoreLibrary.LanguageExtensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns passed datetime with zero padding using current culture separators
        /// </summary>
        /// <param name="sender"><seealso cref="DateTime"/></param>
        /// <returns>month zero padded/day zero padded/year zero padded</returns>
        /// <remarks>
        /// order of date parts year, month, day which can be changed to say month, day, year
        /// </remarks>
        public static string ZeroPad(this DateTime sender)
        {
            string dateSeparator = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;
            string timeSeparator = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator;

            return $"{sender.Year:D2}{dateSeparator}{sender.Month:D2}{dateSeparator}{sender.Day:D2} {sender.Hour:D2}{timeSeparator}{sender.Minute:D2}{timeSeparator}{sender.Second:D2}";
        }
    }
}
