using NArchitecture.Core.Application.Responses;

namespace Application.Features.FirstInternships.Commands.Update;

public class UpdatedFirstInternshipResponse : IResponse
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int LecturerId { get; set; }
    public string Message { get; set; }
    public bool Progress { get; set; }
}