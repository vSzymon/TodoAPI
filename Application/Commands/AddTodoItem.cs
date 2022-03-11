using FluentValidation;
using MediatR;
using TodoAPI.Application.Common;
using TodoAPI.Application.DTO;
using TodoAPI.Application.Exceptions;
using TodoAPI.Application.Interfaces;

namespace TodoAPI.Application.Commands
{
    public record AddTodoItem: IRequest<Guid>
    {
        public Guid ListId { get; init; }
        public string Title { get; init; }
        public string? Description { get; init; }
        public DateTime ExpirationDate { get; init; }
        public class Handler : IRequestHandler<AddTodoItem, Guid>
        {
            private readonly IUnitOfWork unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<Guid> Handle(AddTodoItem request, CancellationToken cancellationToken)
            {
                new Validator().ValidateRequest(request);

                var itemList = await unitOfWork.TodoItemsListRepository.FindByIdAsync(request.ListId, cancellationToken);
                if (itemList is null)
                {
                    throw new ItemListNotFoundException(request.ListId);
                }

                var item = itemList.AddItem(request.Title,
                    request.Description!,
                    request.ExpirationDate);


                await unitOfWork.TodoItemRepository.AddAsync(item, cancellationToken);

                await unitOfWork.TodoItemsListRepository.UpdateAsync(itemList, cancellationToken);

                await unitOfWork.CommitAsync();

                return item.Id;

            }

            private class Validator : RequestValidator<AddTodoItem> 
            {
                internal Validator()
                {
                    RuleFor(x => x.ExpirationDate)
                        .Must(x => x.ToUniversalTime() > DateTime.UtcNow)
                        .WithMessage("Expiration date cannot be in the past");
                }
                
            }

         
        }
    }
}
