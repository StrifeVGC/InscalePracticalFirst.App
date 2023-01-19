using InscalePracticalFirst.Domain.Models.HttpReponseModels;
using InscalePracticalFirst.Domain.Repositories.Contract;
using InscalePracticalFirst.Domain.Services.Contract;
using InscalePraticalFirst.Infrastructure.Services.Implementation;
using Moq;
using Xunit;

namespace InscalePraticalFirst.Tests
{
    public class DummyApiServiceTests
    {
        [Fact]
        public async Task GetAndProcessUserDataFromPostsShouldSucceed()
        {
            var postApiService = new Mock<IDummyPostApiDomainService>();
            var userApiService = new Mock<IDummyUserApiDomainService>();
            var repo = new Mock<IInscalePracticalRepo>();
            postApiService.Setup(x => x.GetAllPostsFromAPIAsync()).ReturnsAsync(new List<Post>() { new Post { UserId = 1 }, new Post { UserId = 2 }, new Post { UserId = 3 } });
            userApiService.Setup(x => x.GetTodosForUserAsync(It.IsAny<int>())).ReturnsAsync(new UserTodos());

            var dummyApiService = new DummyApiService(repo.Object, postApiService.Object, userApiService.Object);

            var exception = Record.ExceptionAsync(async () => await dummyApiService.GetAndProcessUserDataFromPosts());

            //Assert
            Assert.True(exception.Status.Equals(TaskStatus.RanToCompletion));
        }

        [Fact]
        public async Task GetAndProcessUserDataFromPostsThrowsException()
        {
            var postApiService = new Mock<IDummyPostApiDomainService>();
            var userApiService = new Mock<IDummyUserApiDomainService>();
            var repo = new Mock<IInscalePracticalRepo>();
            postApiService.Setup(x => x.GetAllPostsFromAPIAsync()).Throws<Exception>();

            var dummyApiService = new DummyApiService(repo.Object, postApiService.Object, userApiService.Object);

            await Assert.ThrowsAsync<Exception>(async () => await dummyApiService.GetAndProcessUserDataFromPosts());
        }

        //Tempo apertou e não consegui fazer mais unit tests. peço desculpa.
    }
}