using Application.Features.SecondInternships.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SecondInternships;

public class SecondInternshipManager : ISecondInternshipService
{
    private readonly ISecondInternshipRepository _secondInternshipRepository;
    private readonly SecondInternshipBusinessRules _secondInternshipBusinessRules;

    public SecondInternshipManager(ISecondInternshipRepository secondInternshipRepository, SecondInternshipBusinessRules secondInternshipBusinessRules)
    {
        _secondInternshipRepository = secondInternshipRepository;
        _secondInternshipBusinessRules = secondInternshipBusinessRules;
    }

    public async Task<SecondInternship?> GetAsync(
        Expression<Func<SecondInternship, bool>> predicate,
        Func<IQueryable<SecondInternship>, IIncludableQueryable<SecondInternship, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SecondInternship? secondInternship = await _secondInternshipRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return secondInternship;
    }

    public async Task<IPaginate<SecondInternship>?> GetListAsync(
        Expression<Func<SecondInternship, bool>>? predicate = null,
        Func<IQueryable<SecondInternship>, IOrderedQueryable<SecondInternship>>? orderBy = null,
        Func<IQueryable<SecondInternship>, IIncludableQueryable<SecondInternship, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SecondInternship> secondInternshipList = await _secondInternshipRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return secondInternshipList;
    }

    public async Task<SecondInternship> AddAsync(SecondInternship secondInternship)
    {
        SecondInternship addedSecondInternship = await _secondInternshipRepository.AddAsync(secondInternship);

        return addedSecondInternship;
    }

    public async Task<SecondInternship> UpdateAsync(SecondInternship secondInternship)
    {
        SecondInternship updatedSecondInternship = await _secondInternshipRepository.UpdateAsync(secondInternship);

        return updatedSecondInternship;
    }

    public async Task<SecondInternship> DeleteAsync(SecondInternship secondInternship, bool permanent = false)
    {
        SecondInternship deletedSecondInternship = await _secondInternshipRepository.DeleteAsync(secondInternship);

        return deletedSecondInternship;
    }
}
