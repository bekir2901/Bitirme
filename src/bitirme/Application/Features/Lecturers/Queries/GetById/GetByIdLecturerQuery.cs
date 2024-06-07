using Application.Features.Lecturers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Lecturers.Queries.GetById;

public class GetByIdLecturerQuery : IRequest<GetByIdLecturerResponse>
{
    public int Id { get; set; }

    public class GetByIdLecturerQueryHandler : IRequestHandler<GetByIdLecturerQuery, GetByIdLecturerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILecturerRepository _lecturerRepository;
        private readonly LecturerBusinessRules _lecturerBusinessRules;

        public GetByIdLecturerQueryHandler(IMapper mapper, ILecturerRepository lecturerRepository, LecturerBusinessRules lecturerBusinessRules)
        {
            _mapper = mapper;
            _lecturerRepository = lecturerRepository;
            _lecturerBusinessRules = lecturerBusinessRules;
        }

        public async Task<GetByIdLecturerResponse> Handle(GetByIdLecturerQuery request, CancellationToken cancellationToken)
        {
            Lecturer? lecturer = await _lecturerRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _lecturerBusinessRules.LecturerShouldExistWhenSelected(lecturer);

            GetByIdLecturerResponse response = _mapper.Map<GetByIdLecturerResponse>(lecturer);
            return response;
        }
    }
}