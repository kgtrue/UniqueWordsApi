using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniqueWordsApi.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Splits string and filters each word using the suplied filter.
        /// </summary>
        /// <param name="value">The string to be split and filterd</param>
        /// <param name="spliton">A list of strings used in split.</param>
        /// <param name="filter">A filter that trims each split string</param>
        /// <returns>Returns a list containing destinct strings that have been cleaned.</returns>
        public static IEnumerable<string> GetUniqueWords(this string value, string[] spliton, string filter)
        {
            if (spliton.Length == 0)
            {
                throw new StringExtensionsException("The parameter spliton is missing a value.");
            }

            if (string.IsNullOrEmpty(filter))
            {
                throw new StringExtensionsException("The parameter filter is missing a value.");
            }
          
            return value.Split(spliton, StringSplitOptions.RemoveEmptyEntries).Select(textValue => textValue.Trim(filter.ToArray<char>()).ToLower()).Where(s => !string.IsNullOrEmpty(s)).Distinct();
        }
    }

    public class StringExtensionsException : Exception
    {
        public StringExtensionsException(string msg) : base(msg)
        {

        }
    }
}
