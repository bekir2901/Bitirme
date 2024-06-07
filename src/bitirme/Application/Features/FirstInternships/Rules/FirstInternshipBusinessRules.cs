using Application.Features.FirstInternships.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.FirstInternships.Rules;

public class FirstInternshipBusinessRules : BaseBusinessRules
{
    private readonly IFirstInternshipRepository _firstInternshipRepository;
    private readonly ILocalizationService _localizationService;

    public FirstInternshipBusinessRules(IFirstInternshipRepository firstInternshipRepository, ILocalizationService localizationService)
    {
        _firstInternshipRepository = firstInternshipRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, FirstInternshipsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task FirstInternshipShouldExistWhenSelected(FirstInternship? firstInternship)
    {
        if (firstInternship == null)
            await throwBusinessException(FirstInternshipsBusinessMessages.FirstInternshipNotExists);
    }

    public async Task StudentIdShouldNotExistsWhenInsert(int id)
    {
        bool doesExists = await _firstInternshipRepository.AnyAsync(predicate: u => u.StudentId == id);
        if (doesExists)
            await throwBusinessException(FirstInternshipsBusinessMessages.FirstInternshipStudentIdExist);
    }

    public async Task FirstInternshipIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        FirstInternship? firstInternship = await _firstInternshipRepository.GetAsync(
            predicate: fi => fi.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FirstInternshipShouldExistWhenSelected(firstInternship);
    }
}