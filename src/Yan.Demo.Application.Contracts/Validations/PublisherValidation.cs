using FluentValidation;
using Yan.Demo.Requests;

namespace Yan.Demo.Validations;

public class MessageValidator : AbstractValidator<MessageRequest>
{
    public MessageValidator()
    {
        _ = RuleFor(m => m.Id).GreaterThanOrEqualTo(0).WithMessage("Id không hợp lệ!");
        _ = RuleFor(m => m.Message).NotNull().NotEmpty().WithMessage("Message không hợp lệ!");
    }
}
