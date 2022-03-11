namespace TodoAPI.Domain.Exceptions
{
    public class DescriptionInvalidLengthException : DomainException
    {
        internal DescriptionInvalidLengthException(uint currentLength, uint maxLength)
           : base($"Description length cannot exceed maximum value of {maxLength} characters. Current length {currentLength}") { }
    }
}
