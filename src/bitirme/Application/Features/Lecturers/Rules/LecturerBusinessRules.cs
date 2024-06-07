using Application.Features.Lecturers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.SecondInternships.Constants;

namespace Application.Features.Lecturers.Rules;

public class LecturerBusinessRules : BaseBusinessRules
{
    private readonly ILecturerRepository _lecturerRepository;
    private readonly ILocalizationService _localizationService;

    public LecturerBusinessRules(ILecturerRepository lecturerRepository, ILocalizationService localizationService)
    {
        _lecturerRepository = lecturerRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, LecturersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task LecturerShouldExistWhenSelected(Lecturer? lecturer)
    {
        if (lecturer == null)
            await throwBusinessException(LecturersBusinessMessages.LecturerNotExists);
    }
    public async Task LecturerEmailShouldNotExistsWhenInsert(string email)
    {
        bool doesExists = await _lecturerRepository.AnyAsync(predicate: u => u.Email == email);
        if (doesExists)
            await throwBusinessException(LecturersBusinessMessages.LecturerEmailAlreadyExists);
    }

    public async Task LecturerIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Lecturer? lecturer = await _lecturerRepository.GetAsync(
            predicate: l => l.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LecturerShouldExistWhenSelected(lecturer);
    }
}