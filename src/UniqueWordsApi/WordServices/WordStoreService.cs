using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueWordsApi.Dtos;
using UniqueWordsApi.Extensions;
namespace UniqueWordsApi.WordServices
{
    public class WordStoreService : IWordStoreService
    {
        private WordStoreDBContext _context;
        //A list of chars used to clean words
        private const string charIgnoreList = "*.,!\\/¤$€%()={}+?';:|´`";
        private string[] split = { " ", "\r\n", "\r", "\n" };
        private readonly ILogger<WordStoreService> _logger;

        public WordStoreService(ILogger<WordStoreService> logger, WordStoreDBContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task<Result> GetTextResultAsync(Request request)
        {

            try
            {
                //Creates a destinct list of words from the from the string from the request object instance. 
                var words = request.text.GetUniqueWords(split, charIgnoreList);

                //contains all the words from the table RecordedWords filterd by the distinct words in the words list. 
                //The reson for this select is to ensure that no duplicate words are added to the table RecordedWords.
                //This would not be necessary if EF could handle IGNORE_DUP_KEY.
                var existingRecordedWords = _context.RecordedWords.Where(x => words.Contains(x.Word));

                //Adds all destinct words to RecordedWords that are not already present in the RecordedWords table.
                _context.RecordedWords.AddRange(words.Where(w => !existingRecordedWords.Select(ew => ew.Word).Contains(w)).Select(w => new Models.RecordedWord() { Word = w }));

                //Saves the added words and pushes changes to database.
                await _context.SaveChangesAsync();
                                
                //A combined list af words created by joining distinctUniqueWords with WatchlistWords.
                //Total count is the number of rows in the resulting join.
                //If there a match in WatchlistWords the the word i selected. if there i no match then an empty string i set. 
                var res = from recordedWords in existingRecordedWords
                          join watchlistWords in _context.WatchlistWords on recordedWords.Word equals watchlistWords.Word into jointable
                          from rwww in jointable.DefaultIfEmpty()
                          select new
                          {
                              rw = recordedWords.Word,
                              ww = rwww == null ? "" : rwww.Word
                          };


                // Return a result containing the count of distinctUniqueWords in the text and a list of words from the Watchlist.
                return new Result() { distinctUniqueWords = res.Count(), watchlistWords = res.Where(w=> !string.IsNullOrEmpty(w.ww)).Select(w => w.ww) };
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new WordStoreException("Lookup failed");
            }
        }
    }
}
