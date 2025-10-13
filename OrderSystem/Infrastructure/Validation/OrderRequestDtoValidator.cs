using FluentValidation;
using OrderSystem.Domain.DTO;
using System.Net;

namespace OrderSystem.Infrastructure.Validation
{
    public class OrderRequestDtoValidator : AbstractValidator<OrderRequestDto>
    {
        public OrderRequestDtoValidator() 
        { 
            RuleFor(request => request.Amount).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(request => request.Count).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(request => request.CustomerName).NotEmpty();
        }
    }
}
