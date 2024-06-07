using NArchitecture.Core.Application.Responses;

namespace Application.Features.SecondInternships.Commands.Delete;

public class DeletedSecondInternshipResponse : IResponse
{
    public int Id { get; set; }
}