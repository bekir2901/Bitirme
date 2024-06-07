using FluentValidation;

namespace Application.Features.Lecturers.Commands.Update;

public class UpdateLecturerCommandValidator : AbstractValidator<UpdateLecturerCommand>
{
    public UpdateLecturerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
    }
}