using InscalePracticalFirst.Domain.Models.HttpReponseModels;

namespace InscalePracticalFirst.Domain.Services.Contract
{
    public interface IDummyPostApiDomainService
    {
        Task<IEnumerable<Post>> GetAllPostsFromAPIAsync();
    }
}