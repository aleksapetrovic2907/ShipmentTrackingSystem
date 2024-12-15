using FluentValidation;
using Domain.Models;

namespace Application.Validators
{
    public class ShipmentValidator : AbstractValidator<Shipment>
    {
        public ShipmentValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Shipment name cannot be empty");

            RuleFor(s => s.DeliveredAt)
                .GreaterThanOrEqualTo(DateTime.UtcNow)
                .When(s => s.DeliveredAt.HasValue)
                .WithMessage("Delivery date must be in the future");

            RuleFor(s => s.Status)
                .IsInEnum().WithMessage("Invalid shipment status");
        }
    }
}
