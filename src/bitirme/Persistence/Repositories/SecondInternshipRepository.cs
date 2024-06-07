using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SecondInternshipRepository : EfRepositoryBase<SecondInternship, int, BaseDbContext>, ISecondInternshipRepository
{
    public SecondInternshipRepository(BaseDbContext context) : base(context)
    {
    }
}