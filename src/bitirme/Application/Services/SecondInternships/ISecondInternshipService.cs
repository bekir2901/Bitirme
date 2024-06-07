using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SecondInternships;

public interface ISecondInternshipService
{
    Task<SecondInternship?> GetAsync(
        Expression<Func<SecondInternship, bool>> predicate,
        Func<IQueryable<SecondInternship>, IIncludableQueryable<SecondInternship, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SecondInternship>?> GetListAsync(
        Expression<Func<SecondInternship, bool>>? predicate = null,
        Func<IQueryable<SecondInternship>, IOrderedQueryable<SecondInternship>>? orderBy = null,
        Func<IQueryable<SecondInternship>, IIncludableQueryable<SecondInternship, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SecondInternship> AddAsync(SecondInternship secondInternship);
    Task<SecondInternship> UpdateAsync(SecondInternship secondInternship);
    Task<SecondInternship> DeleteAsync(SecondInternship secondInternship, bool permanent = false);
}
