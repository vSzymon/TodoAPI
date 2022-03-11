namespace TodoAPI.Domain.Interfaces
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
    }
}
