using System.Threading.Tasks;
using UniqueWordsApi.Dtos;

namespace UniqueWordsApi.WordServices
{
    public interface IWordStoreService
    {
        Task<Result> GetTextResultAsync(Request request);
    }
}
