namespace InscalePracticalFirst.Domain.Models.HttpReponseModels
{
    public class UserTodoObject
    {
        public int Id { get; set; }
        public string Todo { get; set; }
        public bool Completed { get; set; }
        public int UserId { get; set; }
    }
}
