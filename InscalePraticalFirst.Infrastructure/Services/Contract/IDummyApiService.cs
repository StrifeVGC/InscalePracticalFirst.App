using InscalePracticalFirst.Domain.Models.ApiModels;

namespace InscalePraticalFirst.Infrastructure.Services.Contract
{
    public interface IDummyApiService
    {
        Task GetAndProcessUserDataFromPosts();
        Task<List<Post>> GetPostsFromUsersThatUseMasterCard();
        Task<List<UserTodoObject>> GetUserTodosWithMoreThanTwoPosts();
    }
}