using InscalePracticalFirst.Domain.Models.HttpReponseModels;

namespace InscalePraticalFirst.Infrastructure.Services.Contract
{
    public interface IDummyApiService
    {
        Task GetAndProcessUserDataFromPosts();
        Task<List<Post>> GetPostsFromUsersThatUseMasterCard();
        Task<List<UserTodoObject>> GetUserTodosWithMoreThanTwoPosts();
    }
}