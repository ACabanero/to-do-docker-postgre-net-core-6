using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Infrastructure.Mapper
{
    public static class ConvertDataItemToObjectDynamic
    {
        public static Func<IDataReader, T> MapEntity<T>()
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            return reader =>
            {
                var entity = Activator.CreateInstance<T>();

                foreach (var property in properties)
                {
                    if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                    {
                        var value = reader[property.Name];
                        property.SetValue(entity, value);
                    }
                }

                return entity;
            };
        }
    }
}
