using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFirstInternshipRepository : IAsyncRepository<FirstInternship, int>, IRepository<FirstInternship, int>
{
}