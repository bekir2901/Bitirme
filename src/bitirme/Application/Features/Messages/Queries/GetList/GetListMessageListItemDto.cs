using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Messages.Queries.GetList;

public class GetListMessageListItemDto : IDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int LecturerId { get; set; }
    public string Text { get; set; }
    public string Title { get; set; }
}