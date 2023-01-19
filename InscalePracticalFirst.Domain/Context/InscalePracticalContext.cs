using InscalePracticalFirst.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InscalePracticalFirst.Domain.Context
{
    public class InscalePracticalContext : DbContext
    {
        public InscalePracticalContext()
        {

        }

        public DbSet<UserData> UserData { get; set; }
    }
}
