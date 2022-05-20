using AutoMapper;
using CommandsAndQueries.Commands.HotelCommands.AddHotel;
using CommandsAndQueries.Commands.HotelCommands.RemoveHotel;
using CommandsAndQueries.Commands.HotelCommands.UpdateHotel;
using CommandsAndQueries.Queries.HotelQueries.GetHotel;
using CommandsAndQueries.Queries.HotelQueries.GetHotelList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UI.WebAPI.Models.Hotel;
using ViewModels;

namespace UI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public HotelController(IMediator mediator, IMapper mapper) =>
            (_mediator, _mapper) = (mediator, mapper);

        [HttpGet]
        public async Task<ActionResult<List<HotelVM>>> GetAll()
        {
            var query = new GetHotelListQuery { };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelVM>> Get(Guid id)
        {
            var query = new GetHotelQuery { Id = id };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddHotelModel addHotelModel)
        {
            var command = _mapper.Map<AddHotelCommand>(addHotelModel);
            var hotelId = await _mediator.Send(command);
            return Created($"{hotelId}", hotelId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateHotelModel updateHotelModel)
        {
            var command = _mapper.Map<UpdateHotelCommand>(updateHotelModel);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var command = new RemoveHotelCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
