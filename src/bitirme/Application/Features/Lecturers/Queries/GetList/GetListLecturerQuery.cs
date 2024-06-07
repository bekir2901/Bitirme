using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Lecturers.Queries.GetList;

public class GetListLecturerQuery : IRequest<GetListResponse<GetListLecturerListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListLecturerQueryHandler : IRequestHandler<GetListLecturerQuery, GetListResponse<GetListLecturerListItemDto>>
    {
        private readonly ILecturerRepository _lecturerRepository;
        private readonly IMapper _mapper;

        public GetListLecturerQueryHandler(ILecturerRepository lecturerRepository, IMapper mapper)
        {
            _lecturerRepository = lecturerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLecturerListItemDto>> Handle(GetListLecturerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Lecturer> lecturers = await _lecturerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLecturerListItemDto> response = _mapper.Map<GetListResponse<GetListLecturerListItemDto>>(lecturers);
            return response;
        }
    }
}