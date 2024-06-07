using FluentValidation;

namespace Application.Features.Messages.Commands.Create;

public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
{
    public CreateMessageCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.LecturerId).NotEmpty();
        RuleFor(c => c.Text).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
    }
}