using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Aggregates
{
    public interface IDatabaseAdapter
    {
        Task ExecuteQueryAsync(string sqlQuery);
        Task CreateAsync(string sqlQuery);
        Task<T?> GetFirstResultAsync<T>(Func<IDataReader, T> mapFunction, string sqlQuery);
        Task<IEnumerable<T>> GetAllAsync<T>(Func<IDataReader, T> mapFunction, string sqlQuery);
        Task UpdateAsync(string sqlQuery);
        Task DeleteAsync(string sqlQuery);
    }
}
