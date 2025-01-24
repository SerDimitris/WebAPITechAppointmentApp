using AutoMapper;
using TechAppointmentApp.Core.Enums;
using TechAppointmentApp.Data;
using TechAppointmentApp.DTO;
using TechAppointmentApp.Exceptions;
using TechAppointmentApp.Repositories;
using TechAppointmentApp.Security;

namespace TechAppointmentApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CustomerService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<User>> GetAllUsersCustomersAsync()
        {
            List<User> usersCustomers = new();
            try
            {
                usersCustomers = await _unitOfWork.CustomerRepository.GetAllUsersCustomersAsync();
                _logger.LogInformation("{Message}", "All customers returned.");
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
            }
            return usersCustomers;
        }

        public async Task<List<User>> GetAllUsersCustomersAsync(int pageNumber, int pageSize)
        {
            List<User> usersCustomers = new();
            try
            {
                usersCustomers = await _unitOfWork.CustomerRepository.GetAllUsersCustomersPaginatedAsync(pageNumber, pageSize);
                _logger.LogInformation("{Message}", "All customers returned.");
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
            }
            return usersCustomers;
        }

        public async Task<Customer?> GetCustomerByPhoneNumberAsync(string phoneNumber)
        {
            return await _unitOfWork.CustomerRepository.GetCustomerByPhoneNmumberAsync(phoneNumber);
        }

        public async Task<int> GetCustomerCountAsync()
        {
            return await _unitOfWork.CustomerRepository.GetCountAsync();
        }

        public async Task SignUpUserAsync(CustomerSignupDTO request)
        {
            Customer customer;
            User user;

            try
            {
                user = ExtractUser(request);
                User? existingUser = await _unitOfWork.UserRepository.GetByUserName(user.Username);

                if (existingUser != null)
                {
                    throw new EntityAlreadyExistsException("Customer", "Customer with username "
                        + existingUser.Username + "already exists");
                }
                user.Password = EncryptionUtil.Encrypt(user.Password);
                await _unitOfWork.UserRepository.AddAsync(user);

                customer = ExtractCustomer(request);
                if (await _unitOfWork.CustomerRepository
                    .GetCustomerByPhoneNmumberAsync(customer.PhoneNumber) is not null)
                {
                    throw new EntityAlreadyExistsException("Customer", "Customer with phonenumber "
                        + customer.PhoneNumber + "already exists");
                }

                await _unitOfWork.CustomerRepository.AddAsync(customer);
                user.Customer = customer;
                // customer.User = user; EF manages the other-end of the relationship sinceboth entities are attached.

                await _unitOfWork.SaveAsync();
                _logger.LogInformation("{Message}", "Teacher: " + customer + " singed up successfully"); // ToDo toString
            }
            catch (Exception ex)
            {
                _logger.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
            }
        }

        private User ExtractUser (CustomerSignupDTO signupDTO)
        {
            return new User()
            {
                Username = signupDTO.Username!,
                Password = signupDTO.Password!,
                Email = signupDTO.Email!,
                Firstname = signupDTO.Firstname!,
                Lastname = signupDTO.Lastname!,
                UserRole = (UserRole)signupDTO.UserRole!
            };
        }

        private Customer ExtractCustomer(CustomerSignupDTO signupDTO)
        {
            return new Customer()
            {
                PhoneNumber = signupDTO.PhoneNumber!,
                ServiceId = (int?)signupDTO.Service,
            };
        }
    }
}
