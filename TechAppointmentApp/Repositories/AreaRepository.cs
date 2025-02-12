using Microsoft.EntityFrameworkCore;
using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(TechAppointmentAppDbContext context) : base(context)
        {
        }

        public async Task<Area?> GetAreaByName(string name)
        {
            return await _context.Areas
                .FirstOrDefaultAsync(a => a.AreaName == name);
        }
    }
}
