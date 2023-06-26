using Npgsql;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Infrastructure.Data;
using ToDo.Infrastructure.Mapper;

namespace ToDo.Infrastructure.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly PostgreSQLAdapter _adapter;

        public ToDoRepository(PostgreSQLAdapter adapter)
        {
            _adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));
        }

        public Task AddToDoAsync(ToDoEntity dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ToDoEntity?> GetToDoByIdAsync(int id)
        {
            string query = @$"
                SELECT  *
                FROM    ToDo
                WHERE   id = {id}";

            ToDoEntity? entity = await _adapter.GetFirstResultAsync<ToDoEntity?>(ConvertDataItemToObjectDynamic.MapEntity<ToDoEntity>(), query);

            return entity;
        }

        public async Task<IEnumerable<ToDoEntity>> GetToDoSearchAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search)) throw new ArgumentNullException(nameof(search));

            string query = @$"
                SELECT  *
                FROM    ToDo
                WHERE   filter LIKE '%{search.ToLowerInvariant()}%'";


            IEnumerable<ToDoEntity> entities = await _adapter.GetAllAsync<ToDoEntity>(ConvertDataItemToObjectDynamic.MapEntity<ToDoEntity>(), query);

            return entities;
        }

        public Task UpdateToDoAsync(ToDoEntity dto)
        {
            throw new NotImplementedException();
        }
    }
}
