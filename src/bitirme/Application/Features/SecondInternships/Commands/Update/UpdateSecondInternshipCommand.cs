using Application.Features.SecondInternships.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SecondInternships.Commands.Update;

public class UpdateSecondInternshipCommand : IRequest<UpdatedSecondInternshipResponse>
{
    public int Id { get; set; }
    public required int StudentId { get; set; }
    public required int LecturerId { get; set; }
    public required string Message { get; set; }
    public required bool Progress { get; set; }

    public class UpdateSecondInternshipCommandHandler : IRequestHandler<UpdateSecondInternshipCommand, UpdatedSecondInternshipResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISecondInternshipRepository _secondInternshipRepository;
        private readonly SecondInternshipBusinessRules _secondInternshipBusinessRules;

        public UpdateSecondInternshipCommandHandler(IMapper mapper, ISecondInternshipRepository secondInternshipRepository,
                                         SecondInternshipBusinessRules secondInternshipBusinessRules)
        {
            _mapper = mapper;
            _secondInternshipRepository = secondInternshipRepository;
            _secondInternshipBusinessRules = secondInternshipBusinessRules;
        }

        public async Task<UpdatedSecondInternshipResponse> Handle(UpdateSecondInternshipCommand request, CancellationToken cancellationToken)
        {
            SecondInternship? secondInternship = await _secondInternshipRepository.GetAsync(predicate: si => si.Id == request.Id, cancellationToken: cancellationToken);
            await _secondInternshipBusinessRules.SecondInternshipShouldExistWhenSelected(secondInternship);
            secondInternship = _mapper.Map(request, secondInternship);

            await _secondInternshipRepository.UpdateAsync(secondInternship!);

            UpdatedSecondInternshipResponse response = _mapper.Map<UpdatedSecondInternshipResponse>(secondInternship);
            return response;
        }
    }
}