using AutoMapper;
using TechAppointmentApp.Core.Enums;
using TechAppointmentApp.Data;
using TechAppointmentApp.DTO;
using TechAppointmentApp.Repositories;
using TechAppointmentApp.Security;
using TechAppointmentApp.Services.Exceptions;

namespace TechAppointmentApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IMapper? _mapper;
        private readonly ILogger<UserService>? _logger;

        public CustomerService(IUnitOfWork? unitOfWork, IMapper? mapper, ILogger<UserService>? logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Customer?> SignUpCustomerAsync(CustomerSignupDTO request)
        {
            Customer customer;
            User user;

            try
            {
                user = ExtractUser(request);
                User? existingUser = await _unitOfWork!.UserRepository.GetByUsernameAsync(user.Username!);

                if (existingUser != null)
                {
                    throw new EntityAlreadyExistsException("Customer", "Customer with username "
                        + existingUser.Username + "already exists");
                }

                user.Password = EncryptionUtil.Encrypt(user.Password!);
                await _unitOfWork.UserRepository.AddAsync(user);

                customer = ExtractCustomer(request);
                if (await _unitOfWork.UserRepository
                    .GetByPhoneNumberAsync(user.PhoneNumber!) is not null)
                {
                    throw new EntityAlreadyExistsException("Customer", "Customer with phonenumber "
                        + user.PhoneNumber + "already exists");
                }

                //await _unitOfWork.UserRepository.AddAsync(user);
                user.Customer = customer;
                // customer.User = user; EF manages the other-end of the relationship since both entities are attached.

                await _unitOfWork.SaveAsync();
                _logger!.LogInformation("{Message}", "Teacher: " + customer + " singed up successfully"); // ToDo toString

                return customer;
            }
            catch (Exception ex)
            {
                _logger!.LogError("{Message}{Exception}", ex.Message, ex.StackTrace);
                return null;
            }
        }

        public Task<User?> UpdateCustomerAsync(int id, CustomerDTO customerDTO)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateCustomerPatchAsync(int id, CustomerPatchDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetCustomerByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllCustomersFiltered(int pageNumber, int pageSize, CustomerFiltersDTO customerFiltersDTO)
        {
            throw new NotImplementedException();
        }

        private User ExtractUser(CustomerSignupDTO signupDTO)
        {
            return new User()
            {
                Username = signupDTO.Username!,
                Password = signupDTO.Password!,
                Email = signupDTO.Email!,
                Firstname = signupDTO.Firstname!,
                Lastname = signupDTO.Lastname!,
                UserRole = (UserRole)signupDTO.UserRole!,
                PhoneNumber = signupDTO.PhoneNumber!,
            };
        }

        private Customer ExtractCustomer(CustomerSignupDTO signupDTO)
        {
            return new Customer()
            {
                ServiceId = (int?)signupDTO.Service,
            };
        }
    }
}
