using NArchitecture.Core.Application.Responses;

namespace Application.Features.Lecturers.Commands.Create;

public class CreatedLecturerResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}