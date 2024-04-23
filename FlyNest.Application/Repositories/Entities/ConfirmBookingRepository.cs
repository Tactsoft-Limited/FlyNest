using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.BaseRepo;
using FlyNest.Infrastructure.Persistence;
using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlyNest.Application.Repositories.Entities;

public class ConfirmBookingRepository(FlyNestDbContext context) : BaseRepository<ConfirmBooking>(context), IConfirmBookingRepository
{
    public async Task<long> GetIdByTranIdAsync(string tranId)
    {
        var booking = await GetAll().FirstOrDefaultAsync(x => x.TransactionId == tranId);
        return booking.Id;
    }
}
