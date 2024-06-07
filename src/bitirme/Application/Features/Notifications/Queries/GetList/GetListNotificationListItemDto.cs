using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Notifications.Queries.GetList;

public class GetListNotificationListItemDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public int LecturerId { get; set; }
}