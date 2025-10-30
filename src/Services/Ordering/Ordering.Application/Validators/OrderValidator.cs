using FluentValidation;
using Ordering.Application.Models;

namespace Ordering.Application.Validators;

public class OrderValidator
{
    public class OrderCreateValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateValidator()
        {
            RuleFor(x => x.Number).NotEmpty().MaximumLength(30);
            RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(200);
            RuleFor(x => x.TotalAmount).GreaterThanOrEqualTo(0).WithMessage("Must be a natural!");
            
        }
    }

    public class OrderUpdateValidator : AbstractValidator<OrderUpdateDto>
    {
        public OrderUpdateValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(200);
            RuleFor(x => x.TotalAmount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}