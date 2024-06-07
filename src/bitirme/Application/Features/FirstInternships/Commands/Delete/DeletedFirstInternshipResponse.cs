using NArchitecture.Core.Application.Responses;

namespace Application.Features.FirstInternships.Commands.Delete;

public class DeletedFirstInternshipResponse : IResponse
{
    public int Id { get; set; }
}