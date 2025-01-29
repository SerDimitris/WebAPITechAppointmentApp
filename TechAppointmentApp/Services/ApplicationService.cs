using AutoMapper;
using TechAppointmentApp.Repositories;

namespace TechAppointmentApp.Services
{
    public class ApplicationService : IApplicationService
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService>? _logger;

        public ApplicationService(IUnitOfWork unitOfWork, ILogger<UserService>? logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }


        public UserService UserService => new(_unitOfWork,  _mapper, _logger);

        public CustomerService CustomerService => new(_unitOfWork, _mapper, _logger);

        public TechnicianService TechnicianService => new(_unitOfWork,  _mapper, _logger);
    }
}
