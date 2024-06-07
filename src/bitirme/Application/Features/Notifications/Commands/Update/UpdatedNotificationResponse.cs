using NArchitecture.Core.Application.Responses;

namespace Application.Features.Notifications.Commands.Update;

public class UpdatedNotificationResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public int LecturerId { get; set; }
}