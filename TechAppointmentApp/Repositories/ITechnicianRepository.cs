﻿using TechAppointmentApp.Data;
using TechAppointmentApp.Models;

namespace TechAppointmentApp.Repositories
{
    public interface ITechnicianRepository
    {
        Task<List<Appointment>> GetTechnicianAppointmensAsync(int id);
        Task<List<Appointment>> GetTechnicianAppointmensByStatusAsync (int id, string status);
        Task<Technician?> GetByPhoneNumberAsync (string phoneNumber);
        Task<Technician?> GetTechnicianByUsernameAsync (string username);
        Task<List<User>> GetAllUsersTechniciansAsync();
        Task<PaginatedResult<User>> GetPaginatedUsersTechniciansAsync(int pageNumber, int pageSize);
        Task<PaginatedResult<User>> GetPaginatedUsersTechniciansFilteredAsync(int pageNumber, int pageSize, List<Func<User, bool>> predicates);
    }
}
