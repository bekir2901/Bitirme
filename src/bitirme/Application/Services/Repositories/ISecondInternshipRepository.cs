using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISecondInternshipRepository : IAsyncRepository<SecondInternship, int>, IRepository<SecondInternship, int>
{
}