using Application.Features.SecondInternships.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SecondInternships.Queries.GetById;

public class GetByIdSecondInternshipQuery : IRequest<GetByIdSecondInternshipResponse>
{
    public int Id { get; set; }

    public class GetByIdSecondInternshipQueryHandler : IRequestHandler<GetByIdSecondInternshipQuery, GetByIdSecondInternshipResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISecondInternshipRepository _secondInternshipRepository;
        private readonly SecondInternshipBusinessRules _secondInternshipBusinessRules;

        public GetByIdSecondInternshipQueryHandler(IMapper mapper, ISecondInternshipRepository secondInternshipRepository, SecondInternshipBusinessRules secondInternshipBusinessRules)
        {
            _mapper = mapper;
            _secondInternshipRepository = secondInternshipRepository;
            _secondInternshipBusinessRules = secondInternshipBusinessRules;
        }

        public async Task<GetByIdSecondInternshipResponse> Handle(GetByIdSecondInternshipQuery request, CancellationToken cancellationToken)
        {
            SecondInternship? secondInternship = await _secondInternshipRepository.GetAsync(predicate: si => si.Id == request.Id, cancellationToken: cancellationToken);
            await _secondInternshipBusinessRules.SecondInternshipShouldExistWhenSelected(secondInternship);

            GetByIdSecondInternshipResponse response = _mapper.Map<GetByIdSecondInternshipResponse>(secondInternship);
            return response;
        }
    }
}