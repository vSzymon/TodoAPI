namespace TodoAPI.Application.Exceptions
{
    public class ItemListNotFoundException : Exception
    {
        public ItemListNotFoundException(Guid id) : base($"Todo items list not found for given Id {id}") { }
        
    }
}
