using System;
using FluentValidation;
using SettlementBookingSystem.Application.Bookings.Dtos;
namespace SettlementBookingSystem.Application.Bookings.Commands
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingCommand>
    {
        private TimeSpan TIME_START = new TimeSpan(9, 0, 0); // time is "09:00"
        private TimeSpan TIME_END = new TimeSpan(16, 0, 0); // time is "16:00"

        public CreateBookingValidator()
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.BookingTime).Matches("[0-9]{1,2}:[0-9][0-9]");
            RuleFor(x => x.BookingTime)
            .Must((model, time) => DB.GetTimeSpan(time) >= TIME_START && DB.GetTimeSpan(time) <= TIME_END)
            .WithMessage("Booking time must be from 09:00am to 04:00pm");
        }


    }
}
