using Application.Features.Lecturers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Lecturers;

public class LecturerManager : ILecturerService
{
    private readonly ILecturerRepository _lecturerRepository;
    private readonly LecturerBusinessRules _lecturerBusinessRules;

    public LecturerManager(ILecturerRepository lecturerRepository, LecturerBusinessRules lecturerBusinessRules)
    {
        _lecturerRepository = lecturerRepository;
        _lecturerBusinessRules = lecturerBusinessRules;
    }

    public async Task<Lecturer?> GetAsync(
        Expression<Func<Lecturer, bool>> predicate,
        Func<IQueryable<Lecturer>, IIncludableQueryable<Lecturer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Lecturer? lecturer = await _lecturerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return lecturer;
    }

    public async Task<IPaginate<Lecturer>?> GetListAsync(
        Expression<Func<Lecturer, bool>>? predicate = null,
        Func<IQueryable<Lecturer>, IOrderedQueryable<Lecturer>>? orderBy = null,
        Func<IQueryable<Lecturer>, IIncludableQueryable<Lecturer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Lecturer> lecturerList = await _lecturerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return lecturerList;
    }

    public async Task<Lecturer> AddAsync(Lecturer lecturer)
    {
        Lecturer addedLecturer = await _lecturerRepository.AddAsync(lecturer);

        return addedLecturer;
    }

    public async Task<Lecturer> UpdateAsync(Lecturer lecturer)
    {
        Lecturer updatedLecturer = await _lecturerRepository.UpdateAsync(lecturer);

        return updatedLecturer;
    }

    public async Task<Lecturer> DeleteAsync(Lecturer lecturer, bool permanent = false)
    {
        Lecturer deletedLecturer = await _lecturerRepository.DeleteAsync(lecturer);

        return deletedLecturer;
    }
}
