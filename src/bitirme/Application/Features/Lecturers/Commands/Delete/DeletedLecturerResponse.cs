using NArchitecture.Core.Application.Responses;

namespace Application.Features.Lecturers.Commands.Delete;

public class DeletedLecturerResponse : IResponse
{
    public int Id { get; set; }
}