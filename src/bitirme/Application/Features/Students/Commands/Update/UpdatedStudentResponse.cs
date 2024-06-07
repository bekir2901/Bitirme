using NArchitecture.Core.Application.Responses;

namespace Application.Features.Students.Commands.Update;

public class UpdatedStudentResponse : IResponse
{
    public int Id { get; set; }
    public int No { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int FormalType { get; set; }
    public int EntryYear { get; set; }
}