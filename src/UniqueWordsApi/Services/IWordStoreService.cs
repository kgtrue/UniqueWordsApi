using System.Threading.Tasks;
using UniqueWordsApi.Dtos;

namespace UniqueWordsApi.Services
{
    public interface IWordStoreService
    {
        Task<Result> GetTextResultAsync(Request request);
    }
}
