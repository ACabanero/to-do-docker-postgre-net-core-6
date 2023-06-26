using Npgsql;
using System.Data;
using System.Reflection.PortableExecutable;
using ToDo.Domain.Aggregates;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.Data
{
    public class PostgreSQLAdapter : IDatabaseAdapter
    {
        private readonly string _connectionString;

        public PostgreSQLAdapter(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            _connectionString = connectionString;
        }

        public async Task CreateAsync(string sqlQuery)
        {
            await ExecuteQueryAsync(sqlQuery);
        }

        public async Task UpdateAsync(string sqlQuery)
        {
            await ExecuteQueryAsync(sqlQuery);
        }

        public async Task DeleteAsync(string sqlQuery)
        {
            await ExecuteQueryAsync(sqlQuery);
        }

        public async Task<T?> GetFirstResultAsync<T>(Func<IDataReader, T> mapFunction, string sqlQuery)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sqlQuery, connection))
                {
                    var result = await command.ExecuteReaderAsync();
                    if (await result.ReadAsync()) {
                        return mapFunction(result);
                    }
                    return default;
                }
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(Func<IDataReader, T> mapFunction, string sqlQuery)
        {
            var collection = new List<T>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new NpgsqlCommand(sqlQuery, connection))
                {
                    using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        var entity = mapFunction(reader);
                        collection.Add(entity);
                    }
                }
            }
            return collection;
        }

        public async Task ExecuteQueryAsync(string sqlQuery)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();

            using (var command = new NpgsqlCommand(sqlQuery, connection))
            {
                await command.ExecuteNonQueryAsync();
            }

            connection.Close();
        }
    }
}
