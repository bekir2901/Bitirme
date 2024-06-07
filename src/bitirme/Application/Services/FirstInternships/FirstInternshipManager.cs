using Application.Features.FirstInternships.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FirstInternships;

public class FirstInternshipManager : IFirstInternshipService
{
    private readonly IFirstInternshipRepository _firstInternshipRepository;
    private readonly FirstInternshipBusinessRules _firstInternshipBusinessRules;

    public FirstInternshipManager(IFirstInternshipRepository firstInternshipRepository, FirstInternshipBusinessRules firstInternshipBusinessRules)
    {
        _firstInternshipRepository = firstInternshipRepository;
        _firstInternshipBusinessRules = firstInternshipBusinessRules;
    }

    public async Task<FirstInternship?> GetAsync(
        Expression<Func<FirstInternship, bool>> predicate,
        Func<IQueryable<FirstInternship>, IIncludableQueryable<FirstInternship, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        FirstInternship? firstInternship = await _firstInternshipRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return firstInternship;
    }

    public async Task<IPaginate<FirstInternship>?> GetListAsync(
        Expression<Func<FirstInternship, bool>>? predicate = null,
        Func<IQueryable<FirstInternship>, IOrderedQueryable<FirstInternship>>? orderBy = null,
        Func<IQueryable<FirstInternship>, IIncludableQueryable<FirstInternship, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<FirstInternship> firstInternshipList = await _firstInternshipRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return firstInternshipList;
    }

    public async Task<FirstInternship> AddAsync(FirstInternship firstInternship)
    {
        FirstInternship addedFirstInternship = await _firstInternshipRepository.AddAsync(firstInternship);

        return addedFirstInternship;
    }

    public async Task<FirstInternship> UpdateAsync(FirstInternship firstInternship)
    {
        FirstInternship updatedFirstInternship = await _firstInternshipRepository.UpdateAsync(firstInternship);

        return updatedFirstInternship;
    }

    public async Task<FirstInternship> DeleteAsync(FirstInternship firstInternship, bool permanent = false)
    {
        FirstInternship deletedFirstInternship = await _firstInternshipRepository.DeleteAsync(firstInternship);

        return deletedFirstInternship;
    }
}
