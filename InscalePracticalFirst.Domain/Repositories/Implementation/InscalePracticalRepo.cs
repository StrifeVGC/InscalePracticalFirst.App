using InscalePracticalFirst.Domain.Context;
using InscalePracticalFirst.Domain.Models;
using InscalePracticalFirst.Domain.Repositories.Contract;

namespace InscalePracticalFirst.Domain.Repositories.Implementation
{
    public class InscalePracticalRepo : IInscalePracticalRepo
    {
        private readonly InscalePracticalContext _context;
        public InscalePracticalRepo(InscalePracticalContext context)
        {
            _context = context;
        }

        public async Task BulkInsertUserDataAsync(List<UserData> userDatas)
        {
            await _context.AddRangeAsync(userDatas);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<int>> RetrieveIdsOfUserWithMoreThanTwoPosts()
        {
            return _context.UserData
                .Where(x => x.NumberOfPosts > 2)
                .Select(x => x.UserId);
        }
    }
}
