namespace TodoAPI.Domain.Exceptions
{
    public class EmptyTitleException : DomainException
    {
        internal EmptyTitleException() : base("Title cannot be empty") { } 
          
    }
}
