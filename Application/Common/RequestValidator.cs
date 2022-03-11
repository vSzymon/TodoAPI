using FluentValidation;
using MediatR;

namespace TodoAPI.Application.Common
{
    public abstract class RequestValidator<T> : AbstractValidator<T> where T : IBaseRequest
    {
        public virtual void ValidateRequest(T request) 
        {
            var result = Validate(request);
            if (!result.IsValid)
            {
                throw new ValidationException("Invalid request", result.Errors);
            }
        }
    }
}
