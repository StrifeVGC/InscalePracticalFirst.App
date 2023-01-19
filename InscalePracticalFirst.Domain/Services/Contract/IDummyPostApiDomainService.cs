using InscalePracticalFirst.Domain.Models.ApiModels;

namespace InscalePracticalFirst.Domain.Services.Contract
{
    public interface IDummyPostApiDomainService
    {
        Task<IEnumerable<Post>> GetAllPostsFromAPIAsync();
    }
}