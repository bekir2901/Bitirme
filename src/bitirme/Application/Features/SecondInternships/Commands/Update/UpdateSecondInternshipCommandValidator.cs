using FluentValidation;

namespace Application.Features.SecondInternships.Commands.Update;

public class UpdateSecondInternshipCommandValidator : AbstractValidator<UpdateSecondInternshipCommand>
{
    public UpdateSecondInternshipCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.LecturerId).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.Progress).NotEmpty();
    }
}