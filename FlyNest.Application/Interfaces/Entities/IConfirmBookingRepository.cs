using FlyNest.Infrastructure.Interfaces.BaseRepo;
using FlyNest.SharedKernel.Entities;

namespace FlyNest.Application.Interfaces.Entities;

public interface IConfirmBookingRepository : IBaseRepository<ConfirmBooking>
{
    Task<long> GetIdByTranIdAsync(string tranId);
}
