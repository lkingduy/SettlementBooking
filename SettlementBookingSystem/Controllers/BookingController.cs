using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SettlementBookingSystem.Application.Bookings.Commands;
using SettlementBookingSystem.Application.Bookings.Dtos;
using SettlementBookingSystem.Decorators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SettlementBookingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookingDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [LimitRequests(MaxRequests = 4, TimeWindow = 1)]
        public async Task<ActionResult<BookingDto>> Create([FromBody] CreateBookingCommand command)
        {
            var result =  await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        // this api just only for code testing
        public async Task<ActionResult<BookingDto>> GetData()
        {
            return Ok(DB.bookings);
        }
    }
}
