using FluentValidation;

namespace Application.Features.FirstInternships.Commands.Update;

public class UpdateFirstInternshipCommandValidator : AbstractValidator<UpdateFirstInternshipCommand>
{
    public UpdateFirstInternshipCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.LecturerId).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.Progress).NotEmpty();
    }
}