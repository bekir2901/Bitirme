using NArchitecture.Core.Application.Responses;

namespace Application.Features.Notifications.Queries.GetById;

public class GetByIdNotificationResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public int LecturerId { get; set; }
}