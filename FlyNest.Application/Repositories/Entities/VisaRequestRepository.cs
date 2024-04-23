using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;

namespace FlyNest.Application.Repositories.Entities;

public class VisaRequestRepository(FlyNestDbContext context) : BaseRepository<VisaRequest>(context), IVisaRequestRepository
{
}
