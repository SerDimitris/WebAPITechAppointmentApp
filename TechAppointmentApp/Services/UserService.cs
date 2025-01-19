using AutoMapper;
using TechAppointmentApp.Core.Filters;
using TechAppointmentApp.Data;
using TechAppointmentApp.DTO;
using TechAppointmentApp.Repositories;

namespace TechAppointmentApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<List<User>> GetAllUsersFiltered(int pagaNumber, int pageSize, UserFiltersDTO userFiltersDTO)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> VerifyAndGetUserAsync(UserLoginDTO credentials)
        {
            User? user;

            try
            {
                user = await _unitOfWork.UserRepository.GetUserAsync(credentials.Username!, credentials.Password!);
                _logger.LogInformation("{Message}", "User: " + user + "found and returned.");   // ToDo toString
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
                throw;
            }
            return user;
        }
    }
}
