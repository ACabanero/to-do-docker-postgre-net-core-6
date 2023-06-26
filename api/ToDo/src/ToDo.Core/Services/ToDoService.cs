using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;

namespace ToDo.Core.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;
        public ToDoService(IToDoRepository toDoRepository)
        {
            _repository = toDoRepository ?? throw new ArgumentNullException(nameof(toDoRepository));
        }

        public Task AddToDoAsync(ToDoEntity dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof (dto));

            return _repository.AddToDoAsync(dto);
        }

        public Task<ToDoEntity?> GetToDoByIdAsync(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            return _repository.GetToDoByIdAsync(id);
        }

        public Task<IEnumerable<ToDoEntity>> GetToDoSearchAsync(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(nameof(title));

            return _repository.GetToDoSearchAsync(title);
        }

        public Task UpdateToDoAsync(ToDoEntity dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            if (dto.Id < 0) throw new ArgumentOutOfRangeException(nameof (dto));

            return _repository.UpdateToDoAsync(dto);
        }
    }
}
