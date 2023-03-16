using FluentValidation;
using Yan.Demo.Request;

namespace Yan.Demo.Validation;

public class MessageValidator : AbstractValidator<MessageRequest>
{
    public MessageValidator()
    {
        _ = RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
        _ = RuleFor(x => x.Message).NotNull().NotEmpty().WithErrorCode("400");
    }
}
