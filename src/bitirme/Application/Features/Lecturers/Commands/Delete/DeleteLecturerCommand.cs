using Application.Features.Lecturers.Constants;
using Application.Features.Lecturers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Lecturers.Commands.Delete;

public class DeleteLecturerCommand : IRequest<DeletedLecturerResponse>
{
    public int Id { get; set; }

    public class DeleteLecturerCommandHandler : IRequestHandler<DeleteLecturerCommand, DeletedLecturerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILecturerRepository _lecturerRepository;
        private readonly LecturerBusinessRules _lecturerBusinessRules;

        public DeleteLecturerCommandHandler(IMapper mapper, ILecturerRepository lecturerRepository,
                                         LecturerBusinessRules lecturerBusinessRules)
        {
            _mapper = mapper;
            _lecturerRepository = lecturerRepository;
            _lecturerBusinessRules = lecturerBusinessRules;
        }

        public async Task<DeletedLecturerResponse> Handle(DeleteLecturerCommand request, CancellationToken cancellationToken)
        {
            Lecturer? lecturer = await _lecturerRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _lecturerBusinessRules.LecturerShouldExistWhenSelected(lecturer);

            await _lecturerRepository.DeleteAsync(lecturer!);

            DeletedLecturerResponse response = _mapper.Map<DeletedLecturerResponse>(lecturer);
            return response;
        }
    }
}