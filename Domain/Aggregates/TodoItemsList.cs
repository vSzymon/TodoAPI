using TodoAPI.Domain.Interfaces;
using TodoAPI.Domain.ValueObjects;

namespace TodoAPI.Domain.Aggregates
{
    public class TodoItemsList : IEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public Title Title { get; set; }
        public Description Description { get; set; }
        public Guid Owner { get; private set; }
        public IReadOnlyCollection<TodoItem> TodoItems => _todoItems.AsReadOnly(); 

        private List<TodoItem> _todoItems = new();

        public TodoItemsList(string title, string? description, Guid owner, IEnumerable<TodoItem>? todoItems)
        {
            Title = Title.From(title);
            Description = Description.From(description ?? string.Empty);
            Owner = owner;
            Created = DateTime.Now; 

            if (todoItems is not null) 
            {
                _todoItems.AddRange(todoItems);
            }
        }

        public TodoItem AddItem(string title, string? description, DateTime expirationDate) 
        {
            var item = new TodoItem(title, description, expirationDate);

            _todoItems.Add(item);

            return item;
        }
        
        public void RemoveItem(Guid itemId) 
        {
            var itemToRemove = _todoItems.FirstOrDefault(item => item.Id == itemId);
            
            if (itemToRemove is not null) 
            {
                _todoItems.Remove(itemToRemove);
            }
            
        }
        public void ClearItems() 
        {
            _todoItems.Clear();
        }
        public void ChangeItemTitle(Guid itemId, string title)
        {
            var itemToUpdate = _todoItems.FirstOrDefault(item => item.Id == itemId);

            if (itemToUpdate is not null)
            {
                itemToUpdate.Title = Title.From(title);
            }
        }
        public void UpdateItemDescription(Guid itemId, string description)
        {
            var itemToUpdate = _todoItems.FirstOrDefault(item => item.Id == itemId);

            if (itemToUpdate is not null)
            {
                itemToUpdate.Description = Description.From(description);
            }
        }
        public void MoveItemExpriationDate(Guid itemId, DateTime expriationDate)
        {
            var itemToUpdate = _todoItems.FirstOrDefault(item => item.Id == itemId);

            if (itemToUpdate is not null)
            {
                itemToUpdate.MoveExpirationDate(expriationDate);
            }
        }
        public void CompleteTodo(Guid itemId) 
        {
            var itemToUpdate = _todoItems.FirstOrDefault(item => item.Id == itemId);

            if (itemToUpdate is not null)
            {
                itemToUpdate.Complete();
            }
        }

        public void CancelTodo(Guid itemId)
        {
            var itemToUpdate = _todoItems.FirstOrDefault(item => item.Id == itemId);

            if (itemToUpdate is not null)
            {
                itemToUpdate.Cancel();
            }

        }
        public void MoveToInProgress(Guid itemId)
        {
            var itemToUpdate = _todoItems.FirstOrDefault(item => item.Id == itemId);

            if (itemToUpdate is not null)
            {
                itemToUpdate.StartWorkOnItem();
            }

        }

    }
}
