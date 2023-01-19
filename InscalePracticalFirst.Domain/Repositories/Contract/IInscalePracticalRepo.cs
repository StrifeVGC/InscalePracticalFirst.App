using InscalePracticalFirst.Domain.Models;

namespace InscalePracticalFirst.Domain.Repositories.Contract
{
    public interface IInscalePracticalRepo
    {
        Task BulkInsertUserDataAsync(List<UserData> userDatas);
        Task<IEnumerable<int>> RetrieveIdsOfUserWithMoreThanTwoPosts();
    }
}