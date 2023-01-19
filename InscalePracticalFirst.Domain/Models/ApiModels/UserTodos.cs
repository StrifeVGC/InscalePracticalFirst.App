using InscalePracticalFirst.Domain.Models.ApiModels;

namespace InscalePracticalFirst.Domain.Models.HttpReponseModels
{
    public class UserTodos
    {
        public IEnumerable<UserTodoObject> Todos { get; set; }
    }
}
