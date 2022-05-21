using AutoMapper;
using CommandsAndQueries.ResumeCommands.CreateResume;
using CommandsAndQueries.ResumeCommands.RemoveResume;
using CommandsAndQueries.ResumeCommands.UpdateResume;
using CommandsAndQueries.ResumeQueries.GetCustomer;
using CommandsAndQueries.ResumeQueries.GetCustomerList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UI.WebAPI.Models.Customer;
using ViewModels;

namespace UI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CustomerController(IMediator mediator, IMapper mapper) =>
            (_mediator, _mapper) = (mediator, mapper);

        [HttpGet]
        public async Task<ActionResult<List<CustomerVM>>> GetAll()
        {
            var query = new GetCustomerListQuery { };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerVM>> Get(Guid id)
        {
            var query = new GetCustomerQuery { Id = id };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddCustomerModel addCustomerModel)
        {
            var command = _mapper.Map<AddCustomerCommand>(addCustomerModel);
            var customerId = await _mediator.Send(command);
            return Created($"{customerId}", customerId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerModel updateCustomerModel)
        {
            var command = _mapper.Map<UpdateCustomerCommand>(updateCustomerModel);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var command = new RemoveCustomerCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
