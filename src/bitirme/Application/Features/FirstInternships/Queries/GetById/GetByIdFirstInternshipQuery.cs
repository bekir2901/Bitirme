using Application.Features.FirstInternships.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FirstInternships.Queries.GetById;

public class GetByIdFirstInternshipQuery : IRequest<GetByIdFirstInternshipResponse>
{
    public int Id { get; set; }

    public class GetByIdFirstInternshipQueryHandler : IRequestHandler<GetByIdFirstInternshipQuery, GetByIdFirstInternshipResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFirstInternshipRepository _firstInternshipRepository;
        private readonly FirstInternshipBusinessRules _firstInternshipBusinessRules;

        public GetByIdFirstInternshipQueryHandler(IMapper mapper, IFirstInternshipRepository firstInternshipRepository, FirstInternshipBusinessRules firstInternshipBusinessRules)
        {
            _mapper = mapper;
            _firstInternshipRepository = firstInternshipRepository;
            _firstInternshipBusinessRules = firstInternshipBusinessRules;
        }

        public async Task<GetByIdFirstInternshipResponse> Handle(GetByIdFirstInternshipQuery request, CancellationToken cancellationToken)
        {
            FirstInternship? firstInternship = await _firstInternshipRepository.GetAsync(predicate: fi => fi.Id == request.Id, cancellationToken: cancellationToken);
            await _firstInternshipBusinessRules.FirstInternshipShouldExistWhenSelected(firstInternship);

            GetByIdFirstInternshipResponse response = _mapper.Map<GetByIdFirstInternshipResponse>(firstInternship);
            return response;
        }
    }
}