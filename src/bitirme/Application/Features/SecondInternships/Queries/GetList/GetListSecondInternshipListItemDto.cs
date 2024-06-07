using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SecondInternships.Queries.GetList;

public class GetListSecondInternshipListItemDto : IDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int LecturerId { get; set; }
    public string Message { get; set; }
    public bool Progress { get; set; }
}