using InscalePracticalFirst.Domain.Models;
using InscalePracticalFirst.Domain.Models.HttpReponseModels;
using InscalePracticalFirst.Domain.Repositories.Contract;
using InscalePracticalFirst.Domain.Services.Contract;
using InscalePraticalFirst.Infrastructure.Services.Contract;

namespace InscalePraticalFirst.Infrastructure.Services.Implementation
{
    public class DummyApiService : IDummyApiService
    {
        private readonly IInscalePracticalRepo _inscalePracticalRepo;
        private readonly IDummyPostApiDomainService _dummyPostApiDomainService;
        private readonly IDummyUserApiDomainService _dummyUserDomainService;

        public DummyApiService(IInscalePracticalRepo inscalePracticalRepo, IDummyPostApiDomainService dummyPostApiDomainService, IDummyUserApiDomainService dummyPostUserDomainService)
        {
            _inscalePracticalRepo = inscalePracticalRepo;
            _dummyPostApiDomainService = dummyPostApiDomainService;
            _dummyUserDomainService = dummyPostUserDomainService;
        }

        public async Task GetAndProcessUserDataFromPosts()
        {
            var posts = (await _dummyPostApiDomainService.GetAllPostsFromAPIAsync()).Where(x => x.Reactions > 0 && x.Tags.Contains("history")).ToList();

            List<UserData> userData = new List<UserData>();

            foreach (Post p in posts)
            {
                if (userData.FirstOrDefault(x => x.UserId == p.UserId) != null)
                    userData.Add(new UserData
                    {
                        UserId = p.UserId,
                        NumberOfPosts = posts.Where(x => x.UserId == p.UserId).Count(),
                        NumberOfTodos = (await _dummyUserDomainService.GetTodosForUserAsync(p.UserId)).Todos.Count()
                    });
            }

            await _inscalePracticalRepo.BulkInsertUserDataAsync(userData);
        }

        public async Task<List<UserTodoObject>> GetUserTodosWithMoreThanTwoPosts()
        {
            var ids = await _inscalePracticalRepo.RetrieveIdsOfUserWithMoreThanTwoPosts();

            List<UserTodoObject> userTodos = new List<UserTodoObject>();
            foreach (int id in ids)
            {
                var todos = await _dummyUserDomainService.GetTodosForUserAsync(id);
                userTodos.AddRange(todos.Todos);
            }

            return userTodos;
        }

        public async Task<List<Post>> GetPostsFromUsersThatUseMasterCard()
        {
            var users = await _dummyUserDomainService.GetUsersThatUseMastercard();

            List<Post> posts = new List<Post>();

            foreach (UserAPIObject user in users)
            {
                var userPosts = await _dummyUserDomainService.GetPostsForUserAsync(user.Id);
                posts.AddRange(posts);
            }

            return posts;
        }
    }
}
