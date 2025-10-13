using FluentValidation;
using OrderSystem.Domain.DTO;

namespace OrderSystem.Infrastructure.Validation
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator() 
        {
            RuleFor(dto => dto.CustomerName).NotEmpty();
            RuleFor(dto => dto.TotalAmount).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
