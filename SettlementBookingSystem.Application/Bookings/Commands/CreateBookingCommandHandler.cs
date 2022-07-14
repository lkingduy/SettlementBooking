using MediatR;
using SettlementBookingSystem.Application.Bookings.Dtos;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SettlementBookingSystem.Application.Bookings.Commands
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingDto>
    {
        public CreateBookingCommandHandler()
        {
        }

        public Task<BookingDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var isConflictTime = Bookings.Dtos.DB.bookings.Any(x => DB.GetTimeSpan(request.BookingTime) >= DB.GetTimeSpan(x.BookingTime)
            && DB.GetTimeSpan(request.BookingTime) <= DB.GetTimeSpan(x.BookingTime) + TimeSpan.FromMinutes(59));
            if(isConflictTime)
                throw new SettlementBookingSystem.Application.Exceptions.ConflictException("Time is conflict");

            var bookingDto = new BookingDto();
            Bookings.Dtos.DB.bookings.Add(new BookingDb() {
                Id = bookingDto.BookingId,
                Name = request.Name,
                BookingTime = request.BookingTime
            });
            // TODO Implement CreateBookingCommandHandler.Handle() and confirm tests are passing. See InfoTrack Global Team - Tech Test.pdf for business rules.
            //throw new NotImplementedException();
            return Task.FromResult(bookingDto);
        }
    }
}
