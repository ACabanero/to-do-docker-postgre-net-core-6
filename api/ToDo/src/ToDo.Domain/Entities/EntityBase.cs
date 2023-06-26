using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Entities
{
    public abstract class EntityBase : IEntity
    {
        private string? _title;
        public int Id { get; set; }
        public string Title
        {
            get => !string.IsNullOrWhiteSpace(_title) ? _title : string.Empty;
            set => _title = value;
        }
        public bool IsCompleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
