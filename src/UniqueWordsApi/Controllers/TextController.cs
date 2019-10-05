using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UniqueWordsApi.Dtos;
using UniqueWordsApi.WordServices;
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
                if(request == null)
                {
                    HttpContext.Response.StatusCode = 204;
                    return new Result();
                }

                if (string.IsNullOrWhiteSpace(request.text))
                {
                    HttpContext.Response.StatusCode = 204;
                    return new Result();
                }

                HttpContext.Response.StatusCode = 200;
                return await _wordStoreService.GetTextResultAsync(request);
            }
            catch (WordStoreException)
            {
                //status code is set to 404 an argument could be made that 500 is more accurate.
                HttpContext.Response.StatusCode = 404;
                return new Result();
            }
            catch (Exception)
            {
                //status code is set to 404 an argument could be made that 500 is more accurate.
                HttpContext.Response.StatusCode = 500;
                return new Result();
            }
        }

    }
}
