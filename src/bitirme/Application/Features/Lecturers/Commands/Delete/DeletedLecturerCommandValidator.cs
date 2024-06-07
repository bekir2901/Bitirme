using FluentValidation;

namespace Application.Features.Lecturers.Commands.Delete;

public class DeleteLecturerCommandValidator : AbstractValidator<DeleteLecturerCommand>
{
    public DeleteLecturerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}