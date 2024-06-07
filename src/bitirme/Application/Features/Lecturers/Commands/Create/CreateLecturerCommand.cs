using Application.Features.Lecturers.Rules;
using Application.Features.SecondInternships.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Lecturers.Commands.Create;

public class CreateLecturerCommand : IRequest<CreatedLecturerResponse>
{
    public required string Name { get; set; }
    public required string Email { get; set; }

    public class CreateLecturerCommandHandler : IRequestHandler<CreateLecturerCommand, CreatedLecturerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILecturerRepository _lecturerRepository;
        private readonly LecturerBusinessRules _lecturerBusinessRules;

        public CreateLecturerCommandHandler(IMapper mapper, ILecturerRepository lecturerRepository,
                                         LecturerBusinessRules lecturerBusinessRules)
        {
            _mapper = mapper;
            _lecturerRepository = lecturerRepository;
            _lecturerBusinessRules = lecturerBusinessRules;
        }

        public async Task<CreatedLecturerResponse> Handle(CreateLecturerCommand request, CancellationToken cancellationToken)
        {
            await _lecturerBusinessRules.LecturerEmailShouldNotExistsWhenInsert(request.Email);

            Lecturer lecturer = _mapper.Map<Lecturer>(request);

            await _lecturerRepository.AddAsync(lecturer);

            CreatedLecturerResponse response = _mapper.Map<CreatedLecturerResponse>(lecturer);
            return response;
        }
    }
}