namespace ToDo.Api.DTOs
{
    public interface IDto
    {
        int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
