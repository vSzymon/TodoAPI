namespace TodoAPI.Domain.Exceptions
{
    public class TitleInvalidLengthException : DomainException
    {
        internal TitleInvalidLengthException(uint currentLength, uint maxLength)
            : base($"Title length cannot exceed maximum value of {maxLength} characters. Current length {currentLength}") { }
        
    }
}
