using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Commands;
using OrderManagement.Application.Queries;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateOrderCommand createOrderCommands)
        {
            await _mediator.Send(createOrderCommands);

            return Ok();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var query = new GetOrderQuery(id);
            var order = await _mediator.Send(query);
            return Ok(order);
        }
    
    }


}
