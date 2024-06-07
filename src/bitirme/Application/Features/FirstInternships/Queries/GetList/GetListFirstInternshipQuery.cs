using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.FirstInternships.Queries.GetList;

public class GetListFirstInternshipQuery : IRequest<GetListResponse<GetListFirstInternshipListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListFirstInternshipQueryHandler : IRequestHandler<GetListFirstInternshipQuery, GetListResponse<GetListFirstInternshipListItemDto>>
    {
        private readonly IFirstInternshipRepository _firstInternshipRepository;
        private readonly IMapper _mapper;

        public GetListFirstInternshipQueryHandler(IFirstInternshipRepository firstInternshipRepository, IMapper mapper)
        {
            _firstInternshipRepository = firstInternshipRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFirstInternshipListItemDto>> Handle(GetListFirstInternshipQuery request, CancellationToken cancellationToken)
        {
            IPaginate<FirstInternship> firstInternships = await _firstInternshipRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFirstInternshipListItemDto> response = _mapper.Map<GetListResponse<GetListFirstInternshipListItemDto>>(firstInternships);
            return response;
        }
    }
}