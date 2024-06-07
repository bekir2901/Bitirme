using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FirstInternships;

public interface IFirstInternshipService
{
    Task<FirstInternship?> GetAsync(
        Expression<Func<FirstInternship, bool>> predicate,
        Func<IQueryable<FirstInternship>, IIncludableQueryable<FirstInternship, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<FirstInternship>?> GetListAsync(
        Expression<Func<FirstInternship, bool>>? predicate = null,
        Func<IQueryable<FirstInternship>, IOrderedQueryable<FirstInternship>>? orderBy = null,
        Func<IQueryable<FirstInternship>, IIncludableQueryable<FirstInternship, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<FirstInternship> AddAsync(FirstInternship firstInternship);
    Task<FirstInternship> UpdateAsync(FirstInternship firstInternship);
    Task<FirstInternship> DeleteAsync(FirstInternship firstInternship, bool permanent = false);
}
