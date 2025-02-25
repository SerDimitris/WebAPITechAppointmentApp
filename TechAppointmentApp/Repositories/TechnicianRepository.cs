﻿using Microsoft.EntityFrameworkCore;
using TechAppointmentApp.Core.Enums;
using TechAppointmentApp.Data;
using TechAppointmentApp.Models;

namespace TechAppointmentApp.Repositories
{
    public class TechnicianRepository : BaseRepository<Technician>, ITechnicianRepository
    {
        public TechnicianRepository(TechAppointmentAppDbContext context) : base(context)
        {
        }

        public async Task<Technician?> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Technicians
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.User.PhoneNumber == phoneNumber);
        }

        public async Task<Technician?> GetTechnicianByUsernameAsync(string username)
        {
            return await _context.Technicians
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.User.Username == username);
        }

        public async Task<List<Appointment>> GetTechnicianAppointmensAsync(int id)
        {
            List<Appointment> appointments;

            appointments = await _context.Technicians
                .Where(t => t.Id == id)
                .SelectMany(t =>  t.Appointments)
                .ToListAsync();

            return appointments;
        }
        public async Task<List<User>> GetAllUsersTechniciansAsync()
        {
            var usersWithTechnicianRole = await _context.Users
                .Where (u => u.UserRole == UserRole.Technician)
                .Include(u => u.Technician)
                .ToListAsync ();

            return usersWithTechnicianRole;
        }


        public async Task<PaginatedResult<User>> GetPaginatedUsersTechniciansAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _context.Users
                .Where(u => u.UserRole == UserRole.Technician)
                .CountAsync();

            int skip = (pageNumber - 1) * pageSize;
            var usersWithTechnicianRole = await _context.Users
                .Where(u => u.UserRole == UserRole.Technician)
                .Include(u => u.Technician)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<User>
            {
                Data = usersWithTechnicianRole,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<PaginatedResult<User>> GetPaginatedUsersTechniciansFilteredAsync(int pageNumber, int pageSize,
            List<Func<User, bool>> predicates)
        {
            var totalRecords = await _context.Users
                .Where(u => u.UserRole == UserRole.Technician)
                .CountAsync();

            int skip = (pageNumber - 1) * pageSize;

            IQueryable<User> query = _context.Users
                .Where(u => u.UserRole == UserRole.Technician)
                .Skip(skip)
                .Take(pageSize);

            if (predicates != null && predicates.Any())
            {
                query = query.Where(u => predicates.All(predicate => predicate(u)));
            }

            var userTechnicians = await query.ToListAsync();

            return new PaginatedResult<User>
            {
                Data = userTechnicians,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<List<Appointment>> GetTechnicianAppointmensByStatusAsync(int id, string status)
        {
            return await _context.Technicians
                .Where(t => t.Id == id)
                .SelectMany(t => t.Appointments)
                .Where(t => t.Status.ToString() == status)
                .ToListAsync();
        }
    }
}
