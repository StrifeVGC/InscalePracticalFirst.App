using InscalePracticalFirst.Domain.Models.HttpReponseModels;

namespace InscalePracticalFirst.Domain.Services.Contract
{
    public interface IDummyUserApiDomainService
    {
        Task<IEnumerable<Post>> GetPostsForUserAsync(int userId);
        Task<UserTodos> GetTodosForUserAsync(int userId);
        Task<IEnumerable<UserAPIObject>> GetUsersThatUseMastercard();
    }
}