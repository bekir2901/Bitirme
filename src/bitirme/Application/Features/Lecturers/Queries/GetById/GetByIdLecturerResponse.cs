using NArchitecture.Core.Application.Responses;

namespace Application.Features.Lecturers.Queries.GetById;

public class GetByIdLecturerResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}