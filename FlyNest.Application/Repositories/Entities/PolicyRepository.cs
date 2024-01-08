using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;

namespace FlyNest.Application.Repositories.Entities;

public class PolicyRepository(FlyNestDbContext context)
    : BaseRepository<Policy>(context), IPolicyRepository, IApplication;