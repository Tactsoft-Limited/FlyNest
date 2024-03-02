using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;

namespace FlyNest.Application.Repositories.Entities;


public class VisaRequirementRepository(FlyNestDbContext context) : BaseRepository<VisaRequirement>(context), IVisaRequirementRepository
{
}