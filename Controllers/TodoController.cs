using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Application.Commands;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ISender sender;

        public TodoController(ISender sender) 
        {
            this.sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoList createTodoList)
        
            => Ok(await sender.Send(createTodoList));

        [HttpPut]
        public async Task<IActionResult> AddItem(AddTodoItem addTodoItem)

            => Ok(await sender.Send(addTodoItem));

    }
}