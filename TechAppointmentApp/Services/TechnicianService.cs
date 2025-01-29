using AutoMapper;
using TechAppointmentApp.Data;
using TechAppointmentApp.Repositories;

namespace TechAppointmentApp.Services
{
    public class TechnicianService : ITechnicianService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IMapper? _mapper;
        private readonly ILogger<UserService>? _logger;

        public TechnicianService(IUnitOfWork? unitOfWork, IMapper? mapper, ILogger<UserService>? logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<User?> GetTechnicianByIdAsync(int id)
        {
            User? user = null;

            try
            {
                user = await _unitOfWork.UserRepository.GetAsync(id);

                if ( user?.Technician != null)
                {
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
                throw;
            }
        }
    }
}