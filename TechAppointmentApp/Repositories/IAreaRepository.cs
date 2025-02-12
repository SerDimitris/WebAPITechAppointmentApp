using TechAppointmentApp.Data;

namespace TechAppointmentApp.Repositories
{
    public interface IAreaRepository
    {
        Task<Area?> GetAreaByName(string name);
    }
}
