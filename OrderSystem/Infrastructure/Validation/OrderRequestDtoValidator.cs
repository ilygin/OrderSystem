using FluentValidation;
using OrderSystem.Domain.DTO;

namespace OrderSystem.Infrastructure.Validation
{
    public class OrderRequestDtoValidator : AbstractValidator<OrderRequestDto>
    {
        public OrderRequestDtoValidator() 
        { 
            RuleFor(request => request.Amount).GreaterThanOrEqualTo(0);
            RuleFor(request => request.Count).GreaterThanOrEqualTo(0);
            RuleFor(request => request.CustomerName).NotEmpty();
        }
    }
}
