using Application.Features.Lecturers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Lecturers.Commands.Update;

public class UpdateLecturerCommand : IRequest<UpdatedLecturerResponse>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }

    public class UpdateLecturerCommandHandler : IRequestHandler<UpdateLecturerCommand, UpdatedLecturerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILecturerRepository _lecturerRepository;
        private readonly LecturerBusinessRules _lecturerBusinessRules;

        public UpdateLecturerCommandHandler(IMapper mapper, ILecturerRepository lecturerRepository,
                                         LecturerBusinessRules lecturerBusinessRules)
        {
            _mapper = mapper;
            _lecturerRepository = lecturerRepository;
            _lecturerBusinessRules = lecturerBusinessRules;
        }

        public async Task<UpdatedLecturerResponse> Handle(UpdateLecturerCommand request, CancellationToken cancellationToken)
        {
            Lecturer? lecturer = await _lecturerRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _lecturerBusinessRules.LecturerShouldExistWhenSelected(lecturer);
            lecturer = _mapper.Map(request, lecturer);

            await _lecturerRepository.UpdateAsync(lecturer!);

            UpdatedLecturerResponse response = _mapper.Map<UpdatedLecturerResponse>(lecturer);
            return response;
        }
    }
}