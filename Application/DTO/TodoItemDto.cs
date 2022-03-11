using TodoAPI.Domain.Aggregates;

namespace TodoAPI.Application.DTO
{
    public class TodoItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get;  set; }
        public DateTime ExpirationDate { get; set; }
        public ItemStatus Status { get; set; }
        public DateTime Created { get; set; }
    }
}
