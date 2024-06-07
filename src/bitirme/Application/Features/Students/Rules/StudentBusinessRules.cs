using Application.Features.Students.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Application.Features.Lecturers.Constants;

namespace Application.Features.Students.Rules;

public class StudentBusinessRules : BaseBusinessRules
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILocalizationService _localizationService;

    public StudentBusinessRules(IStudentRepository studentRepository, ILocalizationService localizationService)
    {
        _studentRepository = studentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, StudentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task StudentShouldExistWhenSelected(Student? student)
    {
        if (student == null)
            await throwBusinessException(StudentsBusinessMessages.StudentNotExists);
    }
    public async Task StudentEmailShouldNotExistsWhenInsert(string email)
    {
        bool doesExists = await _studentRepository.AnyAsync(predicate: u => u.Email == email);
        if (doesExists)
            await throwBusinessException(StudentsBusinessMessages.StudentEmailAlreadyExists);
    }
    public async Task StudentNoShouldNotExistsWhenInsert(int no)
    {
        bool doesExists = await _studentRepository.AnyAsync(predicate: u => u.No == no);
        if (doesExists)
            await throwBusinessException(StudentsBusinessMessages.StudentNoAlreadyExists);
    }

    public async Task StudentIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Student? student = await _studentRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentShouldExistWhenSelected(student);
    }
}