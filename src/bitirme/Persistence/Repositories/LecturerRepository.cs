using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LecturerRepository : EfRepositoryBase<Lecturer, int, BaseDbContext>, ILecturerRepository
{
    public LecturerRepository(BaseDbContext context) : base(context)
    {
    }
}