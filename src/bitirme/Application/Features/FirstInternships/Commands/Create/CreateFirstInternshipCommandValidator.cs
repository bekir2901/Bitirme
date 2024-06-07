using FluentValidation;

namespace Application.Features.FirstInternships.Commands.Create;

public class CreateFirstInternshipCommandValidator : AbstractValidator<CreateFirstInternshipCommand>
{
    public CreateFirstInternshipCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.LecturerId).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.Progress).NotEmpty();
    }
}