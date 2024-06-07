using NArchitecture.Core.Application.Responses;

namespace Application.Features.SecondInternships.Commands.Update;

public class UpdatedSecondInternshipResponse : IResponse
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int LecturerId { get; set; }
    public string Message { get; set; }
    public bool Progress { get; set; }
}