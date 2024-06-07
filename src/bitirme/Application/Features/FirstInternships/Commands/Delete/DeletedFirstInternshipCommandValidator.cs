using FluentValidation;

namespace Application.Features.FirstInternships.Commands.Delete;

public class DeleteFirstInternshipCommandValidator : AbstractValidator<DeleteFirstInternshipCommand>
{
    public DeleteFirstInternshipCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}