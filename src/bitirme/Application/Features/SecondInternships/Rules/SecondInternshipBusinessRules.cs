using Application.Features.SecondInternships.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.FirstInternships.Constants;

namespace Application.Features.SecondInternships.Rules;

public class SecondInternshipBusinessRules : BaseBusinessRules
{
    private readonly ISecondInternshipRepository _secondInternshipRepository;
    private readonly ILocalizationService _localizationService;

    public SecondInternshipBusinessRules(ISecondInternshipRepository secondInternshipRepository, ILocalizationService localizationService)
    {
        _secondInternshipRepository = secondInternshipRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SecondInternshipsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SecondInternshipShouldExistWhenSelected(SecondInternship? secondInternship)
    {
        if (secondInternship == null)
            await throwBusinessException(SecondInternshipsBusinessMessages.SecondInternshipNotExists);
    }
    public async Task StudentIdShouldNotExistsWhenInsert(int id)
    {
        bool doesExists = await _secondInternshipRepository.AnyAsync(predicate: u => u.StudentId == id);
        if (doesExists)
            await throwBusinessException(SecondInternshipsBusinessMessages.SecondInternshipStudentIdExist);
    }

    public async Task SecondInternshipIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SecondInternship? secondInternship = await _secondInternshipRepository.GetAsync(
            predicate: si => si.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SecondInternshipShouldExistWhenSelected(secondInternship);
    }
}