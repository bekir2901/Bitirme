using FluentValidation;

namespace Application.Features.Messages.Commands.Update;

public class UpdateMessageCommandValidator : AbstractValidator<UpdateMessageCommand>
{
    public UpdateMessageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.LecturerId).NotEmpty();
        RuleFor(c => c.Text).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
    }
}