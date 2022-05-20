using AutoMapper;
using CommandsAndQueries.Commands.RoomCommands.AddRoom;
using CommandsAndQueries.Commands.RoomCommands.RemoveRoom;
using CommandsAndQueries.Commands.RoomCommands.UpdateRoom;
using CommandsAndQueries.Queries.RoomQueries.GetRoom;
using CommandsAndQueries.Queries.RoomQueries.GetRoomList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UI.WebAPI.Models.Room;
using ViewModels;

namespace UI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public RoomController(IMediator mediator, IMapper mapper) =>
            (_mediator, _mapper) = (mediator, mapper);

        [HttpGet]
        public async Task<ActionResult<List<RoomVM>>> GetAll(Guid hotelId)
        {
            var query = new GetRoomListQuery { HotelId = hotelId };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomVM>> Get(Guid id)
        {
            var query = new GetRoomQuery { Id = id };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddRoomModel addRoomModel)
        {
            var command = _mapper.Map<AddRoomCommand>(addRoomModel);
            var hotelId = await _mediator.Send(command);
            return Created($"{hotelId}", hotelId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRoomModel updateRoomModel)
        {
            var command = _mapper.Map<UpdateRoomCommand>(updateRoomModel);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var command = new RemoveRoomCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
