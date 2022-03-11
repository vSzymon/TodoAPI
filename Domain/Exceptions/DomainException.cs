namespace TodoAPI.Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        internal DomainException() : base() { }
        internal DomainException(string message) : base(message) { }
    }
}
