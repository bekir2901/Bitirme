using Application.Features.SecondInternships.Constants;
using Application.Features.SecondInternships.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SecondInternships.Commands.Delete;

public class DeleteSecondInternshipCommand : IRequest<DeletedSecondInternshipResponse>
{
    public int Id { get; set; }

    public class DeleteSecondInternshipCommandHandler : IRequestHandler<DeleteSecondInternshipCommand, DeletedSecondInternshipResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISecondInternshipRepository _secondInternshipRepository;
        private readonly SecondInternshipBusinessRules _secondInternshipBusinessRules;

        public DeleteSecondInternshipCommandHandler(IMapper mapper, ISecondInternshipRepository secondInternshipRepository,
                                         SecondInternshipBusinessRules secondInternshipBusinessRules)
        {
            _mapper = mapper;
            _secondInternshipRepository = secondInternshipRepository;
            _secondInternshipBusinessRules = secondInternshipBusinessRules;
        }

        public async Task<DeletedSecondInternshipResponse> Handle(DeleteSecondInternshipCommand request, CancellationToken cancellationToken)
        {
            SecondInternship? secondInternship = await _secondInternshipRepository.GetAsync(predicate: si => si.Id == request.Id, cancellationToken: cancellationToken);
            await _secondInternshipBusinessRules.SecondInternshipShouldExistWhenSelected(secondInternship);

            await _secondInternshipRepository.DeleteAsync(secondInternship!);

            DeletedSecondInternshipResponse response = _mapper.Map<DeletedSecondInternshipResponse>(secondInternship);
            return response;
        }
    }
}