using InscalePracticalFirst.Domain.Models.HttpReponseModels;

namespace InscalePraticalFirst.Infrastructure.Services.Implementation
{
    public interface IDummyApiService
    {
        Task GetAndProcessUserDataFromPosts();
        Task<List<Post>> GetPostsFromUsersThatUseMasterCard();
        Task<List<UserTodoObject>> GetUserTodosWithMoreThanTwoPosts();
    }
}