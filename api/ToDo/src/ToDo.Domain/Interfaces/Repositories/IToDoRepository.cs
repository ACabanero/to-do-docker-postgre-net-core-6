using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface IToDoRepository
    {
        Task<ToDoEntity?> GetToDoByIdAsync(int id);
        Task<IEnumerable<ToDoEntity>> GetToDoSearchAsync(string search);
        Task AddToDoAsync(ToDoEntity dto);
        Task UpdateToDoAsync(ToDoEntity dto);
    }
}
