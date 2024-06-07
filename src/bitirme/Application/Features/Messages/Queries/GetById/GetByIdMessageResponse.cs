using NArchitecture.Core.Application.Responses;

namespace Application.Features.Messages.Queries.GetById;

public class GetByIdMessageResponse : IResponse
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int LecturerId { get; set; }
    public string Text { get; set; }
    public string Title { get; set; }
}