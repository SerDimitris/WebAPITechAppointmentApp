using AutoMapper;
using TechAppointmentApp.Data;
using TechAppointmentApp.Repositories;

namespace TechAppointmentApp.Services
{
    public class TechnicianService : ITechnicianService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<TechnicianService> _logger;

        public TechnicianService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TechnicianService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> DeleteTechnicianAsync(int id)
        {
            bool technicianDeleted = false;

            try
            {
                technicianDeleted = await _unitOfWork.TechnicianRepository.DeleteAsync(id);
                _logger.LogInformation("{Message}", "Student with id: " + id + " deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return technicianDeleted;

        }

        public async Task<IEnumerable<User>> GetAllTechniciansAsync()
        {
            List<User> usersTechnicians = new List<User>();

            try
            {
                usersTechnicians = await _unitOfWork.TechnicianRepository.GetAllUsersTechniciansAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return usersTechnicians;
        }

        public async Task<Technician?> GetTechnicianByIdAsync(int id)
        {
            Technician? technician = null;

            try
            {
                technician = await _unitOfWork.TechnicianRepository.GetAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return technician;
        }

        public async Task<int> GetTechnicianCountAsync()
        {
            int count;

            try
            {
                count = await _unitOfWork.TechnicianRepository.GetCountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return count;
        }

        //public async Task<List<Service>> GetTechniciansServicesAsync(int id)
        //{
        //    List<Service> services = new();

        //    try
        //    {
        //        services = await _unitOfWork.TechnicianRepository.GetTechnician
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}
