using TodoAPI.Domain.Exceptions;
using ValueOf;

namespace TodoAPI.Domain.ValueObjects
{
    public class Title : ValueOf<string, Title>
    {
        protected const uint MaxTitleLength = 256;
        protected override void Validate() 
        {
            if (string.IsNullOrWhiteSpace(Value)) 
            {
                throw new EmptyTitleException();
            }

            if (Value.Length > MaxTitleLength) 
            {
                throw new TitleInvalidLengthException((uint)Value.Length, MaxTitleLength);
            }
        }
    }
}
