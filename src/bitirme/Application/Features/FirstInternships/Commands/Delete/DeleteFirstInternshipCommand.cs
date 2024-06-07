using Application.Features.FirstInternships.Constants;
using Application.Features.FirstInternships.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FirstInternships.Commands.Delete;

public class DeleteFirstInternshipCommand : IRequest<DeletedFirstInternshipResponse>
{
    public int Id { get; set; }

    public class DeleteFirstInternshipCommandHandler : IRequestHandler<DeleteFirstInternshipCommand, DeletedFirstInternshipResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFirstInternshipRepository _firstInternshipRepository;
        private readonly FirstInternshipBusinessRules _firstInternshipBusinessRules;

        public DeleteFirstInternshipCommandHandler(IMapper mapper, IFirstInternshipRepository firstInternshipRepository,
                                         FirstInternshipBusinessRules firstInternshipBusinessRules)
        {
            _mapper = mapper;
            _firstInternshipRepository = firstInternshipRepository;
            _firstInternshipBusinessRules = firstInternshipBusinessRules;
        }

        public async Task<DeletedFirstInternshipResponse> Handle(DeleteFirstInternshipCommand request, CancellationToken cancellationToken)
        {
            FirstInternship? firstInternship = await _firstInternshipRepository.GetAsync(predicate: fi => fi.Id == request.Id, cancellationToken: cancellationToken);
            await _firstInternshipBusinessRules.FirstInternshipShouldExistWhenSelected(firstInternship);

            await _firstInternshipRepository.DeleteAsync(firstInternship!);

            DeletedFirstInternshipResponse response = _mapper.Map<DeletedFirstInternshipResponse>(firstInternship);
            return response;
        }
    }
}