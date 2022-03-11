using TodoAPI.Domain.Exceptions;
using ValueOf;

namespace TodoAPI.Domain.ValueObjects
{
    public class Description : ValueOf<string, Description>
    {
        protected const uint MaxDescriptionLength = 512;
        protected override void Validate() 
        {
            if (Value?.Length > MaxDescriptionLength) 
            {
                throw new DescriptionInvalidLengthException((uint)Value.Length, MaxDescriptionLength);
            }
        }
    }
}
