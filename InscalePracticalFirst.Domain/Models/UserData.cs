using System.ComponentModel.DataAnnotations;

namespace InscalePracticalFirst.Domain.Models
{
    public class UserData
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int NumberOfPosts { get; set; }
        public int NumberOfTodos { get; set; }
    }
}
