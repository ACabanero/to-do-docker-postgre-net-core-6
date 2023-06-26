using ToDo.Api.DTOs;
using ToDo.Domain.Entities;

namespace ToDo.Api.Mappers
{
    public static class ToDoEntityToDto
    {
        public static ToDoDto? ToDoDto(ToDoEntity? entity)
        {
            if (entity == null) return null;

            return new ToDoDto()
            {
                Id = entity.Id,
                Title = entity.Title,
                IsCompleted = entity.IsCompleted,
                DateUpdated = entity.DateUpdated
            };
        }

        public static IEnumerable<ToDoDto?> ToDoDtoCollection(IEnumerable<ToDoEntity> entities)
        {
            return entities.Select(entity => ToDoDto(entity));
        }
    }
}
