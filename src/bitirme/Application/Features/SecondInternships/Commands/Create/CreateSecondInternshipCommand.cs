using Application.Features.FirstInternships.Rules;
using Application.Features.SecondInternships.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SecondInternships.Commands.Create;

public class CreateSecondInternshipCommand : IRequest<CreatedSecondInternshipResponse>
{
    public required int StudentId { get; set; }
    public required int LecturerId { get; set; }
    public required string Message { get; set; }
    public required bool Progress { get; set; }

    public class CreateSecondInternshipCommandHandler : IRequestHandler<CreateSecondInternshipCommand, CreatedSecondInternshipResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISecondInternshipRepository _secondInternshipRepository;
        private readonly SecondInternshipBusinessRules _secondInternshipBusinessRules;

        public CreateSecondInternshipCommandHandler(IMapper mapper, ISecondInternshipRepository secondInternshipRepository,
                                         SecondInternshipBusinessRules secondInternshipBusinessRules)
        {
            _mapper = mapper;
            _secondInternshipRepository = secondInternshipRepository;
            _secondInternshipBusinessRules = secondInternshipBusinessRules;
        }

        public async Task<CreatedSecondInternshipResponse> Handle(CreateSecondInternshipCommand request, CancellationToken cancellationToken)
        {
            await _secondInternshipBusinessRules.StudentIdShouldNotExistsWhenInsert(request.StudentId);

            SecondInternship secondInternship = _mapper.Map<SecondInternship>(request);

            await _secondInternshipRepository.AddAsync(secondInternship);

            CreatedSecondInternshipResponse response = _mapper.Map<CreatedSecondInternshipResponse>(secondInternship);
            return response;
        }
    }
}