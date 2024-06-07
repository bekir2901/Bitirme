using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SecondInternships.Queries.GetList;

public class GetListSecondInternshipQuery : IRequest<GetListResponse<GetListSecondInternshipListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSecondInternshipQueryHandler : IRequestHandler<GetListSecondInternshipQuery, GetListResponse<GetListSecondInternshipListItemDto>>
    {
        private readonly ISecondInternshipRepository _secondInternshipRepository;
        private readonly IMapper _mapper;

        public GetListSecondInternshipQueryHandler(ISecondInternshipRepository secondInternshipRepository, IMapper mapper)
        {
            _secondInternshipRepository = secondInternshipRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSecondInternshipListItemDto>> Handle(GetListSecondInternshipQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SecondInternship> secondInternships = await _secondInternshipRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSecondInternshipListItemDto> response = _mapper.Map<GetListResponse<GetListSecondInternshipListItemDto>>(secondInternships);
            return response;
        }
    }
}