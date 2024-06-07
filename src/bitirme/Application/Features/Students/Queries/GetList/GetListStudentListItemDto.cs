using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Students.Queries.GetList;

public class GetListStudentListItemDto : IDto
{
    public int Id { get; set; }
    public int No { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int FormalType { get; set; }
    public int EntryYear { get; set; }
}