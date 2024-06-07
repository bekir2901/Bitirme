using FluentValidation;

namespace Application.Features.SecondInternships.Commands.Delete;

public class DeleteSecondInternshipCommandValidator : AbstractValidator<DeleteSecondInternshipCommand>
{
    public DeleteSecondInternshipCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}