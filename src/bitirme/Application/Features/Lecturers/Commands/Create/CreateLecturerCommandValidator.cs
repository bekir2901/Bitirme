using FluentValidation;

namespace Application.Features.Lecturers.Commands.Create;

public class CreateLecturerCommandValidator : AbstractValidator<CreateLecturerCommand>
{
    public CreateLecturerCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
    }
}