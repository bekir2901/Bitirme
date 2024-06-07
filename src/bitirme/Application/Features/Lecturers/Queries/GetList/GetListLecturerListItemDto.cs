using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Lecturers.Queries.GetList;

public class GetListLecturerListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}