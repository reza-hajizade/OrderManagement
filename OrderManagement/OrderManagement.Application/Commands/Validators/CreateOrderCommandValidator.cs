using FluentValidation;

namespace OrderManagement.Application.Commands.Validators
{
    public class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name can not be Empty");
            RuleFor(p => p).Must(QuantityOrderValidator).WithMessage("The order number range is not valid for the prize.");

        }


        private bool QuantityOrderValidator(CreateOrderCommand command)
        {
            if(command == null|| command.Quantity>100 || command.Quantity<0)
                return false;

            return true;
        }
    }
}
