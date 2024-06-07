using NArchitecture.Core.Application.Responses;

namespace Application.Features.FirstInternships.Queries.GetById;

public class GetByIdFirstInternshipResponse : IResponse
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int LecturerId { get; set; }
    public string Message { get; set; }
    public bool Progress { get; set; }
}