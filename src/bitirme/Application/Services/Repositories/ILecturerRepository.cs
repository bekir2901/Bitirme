using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILecturerRepository : IAsyncRepository<Lecturer, int>, IRepository<Lecturer, int>
{
}