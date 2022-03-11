using TodoAPI.Domain.Interfaces;
using TodoAPI.Domain.ValueObjects;

namespace TodoAPI.Domain.Aggregates
{
    public class TodoItem : IEntity
    {
        public Guid Id { get; set; }
        public Title Title { get; set; }
        public Description Description { get; set; }
        public DateTime ExpirationDate { get; private set; }
        public ItemStatus Status { get; private set; }
        public DateTime Created { get; set; }
        internal TodoItem(string title, string? description, DateTime expirationDate)
        {
            Title = Title.From(title);
            Description = Description.From(description ?? string.Empty);
            ExpirationDate = expirationDate;
            Status = ItemStatus.New;
            Created = DateTime.Now;
        }

        public void MoveExpirationDate(DateTime dateTime) 
        {
            if (DateTime.UtcNow <= dateTime) 
            {
                throw new InvalidOperationException("Expiration date cannot be in the past");
            }
            ExpirationDate = dateTime; 
        }


        internal void Complete() 
        {
            if (Status == ItemStatus.Completed) 
            {
                throw new InvalidOperationException("Task has been already completed");
            }
            if (Status == ItemStatus.Canceled) 
            {
                throw new InvalidOperationException("Task has been canceled");
            }

            Status = ItemStatus.Completed;
        }
        internal void Cancel()
        {
            if (Status == ItemStatus.Completed)
            {
                throw new InvalidOperationException("Task has been completed");
            }
            if (Status == ItemStatus.Canceled)
            {
                throw new InvalidOperationException("Task has been already canceled");
            }

            Status = ItemStatus.Canceled;
        }

        internal void StartWorkOnItem() 
        {
            if (Status == ItemStatus.Completed)
            {
                throw new InvalidOperationException("Task has been already completed");
            }
            if (Status == ItemStatus.Canceled)
            {
                throw new InvalidOperationException("Task has been already canceled");
            }

            Status = ItemStatus.InProgress;
        }


    }
    public enum ItemStatus 
    {
        New,
        InProgress,
        Completed,
        Canceled
    }
}
