using Application.Features.FirstInternships.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FirstInternships.Commands.Update;

public class UpdateFirstInternshipCommand : IRequest<UpdatedFirstInternshipResponse>
{
    public int Id { get; set; }
    public required int StudentId { get; set; }
    public required int LecturerId { get; set; }
    public required string Message { get; set; }
    public required bool Progress { get; set; }

    public class UpdateFirstInternshipCommandHandler : IRequestHandler<UpdateFirstInternshipCommand, UpdatedFirstInternshipResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFirstInternshipRepository _firstInternshipRepository;
        private readonly FirstInternshipBusinessRules _firstInternshipBusinessRules;

        public UpdateFirstInternshipCommandHandler(IMapper mapper, IFirstInternshipRepository firstInternshipRepository,
                                         FirstInternshipBusinessRules firstInternshipBusinessRules)
        {
            _mapper = mapper;
            _firstInternshipRepository = firstInternshipRepository;
            _firstInternshipBusinessRules = firstInternshipBusinessRules;
        }

        public async Task<UpdatedFirstInternshipResponse> Handle(UpdateFirstInternshipCommand request, CancellationToken cancellationToken)
        {
            FirstInternship? firstInternship = await _firstInternshipRepository.GetAsync(predicate: fi => fi.Id == request.Id, cancellationToken: cancellationToken);
            await _firstInternshipBusinessRules.FirstInternshipShouldExistWhenSelected(firstInternship);
            firstInternship = _mapper.Map(request, firstInternship);

            await _firstInternshipRepository.UpdateAsync(firstInternship!);

            UpdatedFirstInternshipResponse response = _mapper.Map<UpdatedFirstInternshipResponse>(firstInternship);
            return response;
        }
    }
}