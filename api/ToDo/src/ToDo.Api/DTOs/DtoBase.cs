using System.Runtime.Serialization;

namespace ToDo.Api.DTOs
{
    public abstract class DtoBase : IDto
    {
        private string? _title;
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title
        {
            get => !string.IsNullOrWhiteSpace(_title) ? _title : string.Empty;
            set => _title = value;
        }
        [DataMember]
        public bool IsCompleted { get; set; }
        [DataMember]
        public DateTime DateUpdated { get; set; }
    }
}
