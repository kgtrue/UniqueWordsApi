using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniqueWordsApi.Dtos;
using UniqueWordsApi.Services;
namespace UniqueWordsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TextController : ControllerBase
    {
        private IWordStoreService _wordStoreService;
        public TextController(IWordStoreService wordStoreService)
        {
            this._wordStoreService = wordStoreService;
        }

        // POST: api/Text
        /// <summary>
        /// Takes a json object containing a text an searches the text for unique words and matches in a whitelist.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>
        /// Returns a result containing the number of unique words in the sentance, and a list of matching watchlistWords
        /// </returns>
        [HttpPost]
        public async Task<Result> Post(Request request)
        {
            try
            {
                return await _wordStoreService.GetTextResultAsync(request);
            }
            catch (WordStoreException ex)
            {
                return new Result();
            }
        }

    }
}
