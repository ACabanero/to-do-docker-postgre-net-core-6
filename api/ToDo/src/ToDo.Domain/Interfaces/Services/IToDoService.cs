using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IToDoService
    {
        Task<ToDoEntity?> GetToDoByIdAsync(int id);
        Task<IEnumerable<ToDoEntity>> GetToDoSearchAsync(string title);
        Task AddToDoAsync(ToDoEntity dto);
        Task UpdateToDoAsync(ToDoEntity dto);
    }
}