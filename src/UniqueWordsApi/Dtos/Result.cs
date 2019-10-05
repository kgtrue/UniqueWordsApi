using System.Collections.Generic;

namespace UniqueWordsApi.Dtos
{
    /// <summary>
    /// This DTO describes a result for the Text API endpoint.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// A list of destinct word found in a text.
        /// </summary>
        public int distinctUniqueWords { get; set; }
        /// <summary>
        /// A list of watchlistwords that matches destinct words in the sentance.
        /// </summary>
        public IEnumerable<string> watchlistWords { get; set; }
    }
}
