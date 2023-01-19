using InscalePracticalFirst.Domain.Models.HttpReponseModels;
using InscalePracticalFirst.Domain.Services.Contract;

namespace InscalePracticalFirst.Domain.Services.Implementation
{
    public class DummyUserApiDomainService : IDummyUserApiDomainService
    {
        private IHttpClientFactory _httpClientFactory;
        public HttpClient _httpClient;

        public DummyUserApiDomainService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("DummyApiClient");
        }

        public async Task<UserTodos> GetTodosForUserAsync(int userId)
            => await HttpUtils<UserTodos>.GetAsync($"users/{userId}/todos", _httpClient);

        public async Task<IEnumerable<Post>> GetPostsForUserAsync(int userId)
            => await HttpUtils<IEnumerable<Post>>.GetAsync($"users/{userId}/posts", _httpClient);
        public async Task<IEnumerable<UserAPIObject>> GetUsersThatUseMastercard()
            => await HttpUtils<IEnumerable<UserAPIObject>>.GetAsync($"users/filter?key=bank.cardType&value=mastercard", _httpClient);

    }
}
