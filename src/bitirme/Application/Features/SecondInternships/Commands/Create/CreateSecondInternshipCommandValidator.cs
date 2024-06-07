using FluentValidation;

namespace Application.Features.SecondInternships.Commands.Create;

public class CreateSecondInternshipCommandValidator : AbstractValidator<CreateSecondInternshipCommand>
{
    public CreateSecondInternshipCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.LecturerId).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.Progress).NotEmpty();
    }
}