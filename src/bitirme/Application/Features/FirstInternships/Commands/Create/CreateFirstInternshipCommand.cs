using Application.Features.FirstInternships.Rules;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FirstInternships.Commands.Create;

public class CreateFirstInternshipCommand : IRequest<CreatedFirstInternshipResponse>
{
    public required int StudentId { get; set; }
    public required int LecturerId { get; set; }
    public required string Message { get; set; }
    public required bool Progress { get; set; }

    public class CreateFirstInternshipCommandHandler : IRequestHandler<CreateFirstInternshipCommand, CreatedFirstInternshipResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFirstInternshipRepository _firstInternshipRepository;
        private readonly FirstInternshipBusinessRules _firstInternshipBusinessRules;

        public CreateFirstInternshipCommandHandler(IMapper mapper, IFirstInternshipRepository firstInternshipRepository,
                                         FirstInternshipBusinessRules firstInternshipBusinessRules)
        {
            _mapper = mapper;
            _firstInternshipRepository = firstInternshipRepository;
            _firstInternshipBusinessRules = firstInternshipBusinessRules;
        }

        public async Task<CreatedFirstInternshipResponse> Handle(CreateFirstInternshipCommand request, CancellationToken cancellationToken)
        {

            await _firstInternshipBusinessRules.StudentIdShouldNotExistsWhenInsert(request.StudentId);

            FirstInternship firstInternship = _mapper.Map<FirstInternship>(request);

            await _firstInternshipRepository.AddAsync(firstInternship);

            CreatedFirstInternshipResponse response = _mapper.Map<CreatedFirstInternshipResponse>(firstInternship);
            return response;
        }
    }
}