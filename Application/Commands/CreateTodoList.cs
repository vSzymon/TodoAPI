using MediatR;
using TodoAPI.Application.Interfaces;
using TodoAPI.Domain.Aggregates;

namespace TodoAPI.Application.Commands
{
    public record CreateTodoList : IRequest<Guid>
    {
        public string Title { get; init; }
        public string? Description { get; init; }
        public class Handler : IRequestHandler<CreateTodoList, Guid>
        {
            private readonly IUnitOfWork unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<Guid> Handle(CreateTodoList request, CancellationToken cancellationToken)
            {
               var itemList = new TodoItemsList(request.Title, request.Description, Guid.NewGuid(), null);

                await unitOfWork.TodoItemsListRepository.AddAsync(itemList, cancellationToken);

                return itemList.Id;

            }


        }
    }
}
