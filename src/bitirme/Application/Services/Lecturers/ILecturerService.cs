using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Lecturers;

public interface ILecturerService
{
    Task<Lecturer?> GetAsync(
        Expression<Func<Lecturer, bool>> predicate,
        Func<IQueryable<Lecturer>, IIncludableQueryable<Lecturer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Lecturer>?> GetListAsync(
        Expression<Func<Lecturer, bool>>? predicate = null,
        Func<IQueryable<Lecturer>, IOrderedQueryable<Lecturer>>? orderBy = null,
        Func<IQueryable<Lecturer>, IIncludableQueryable<Lecturer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Lecturer> AddAsync(Lecturer lecturer);
    Task<Lecturer> UpdateAsync(Lecturer lecturer);
    Task<Lecturer> DeleteAsync(Lecturer lecturer, bool permanent = false);
}
