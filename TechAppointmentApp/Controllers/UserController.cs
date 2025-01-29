using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechAppointmentApp.Data;
using TechAppointmentApp.DTO;
using TechAppointmentApp.Services;

namespace TechAppointmentApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        protected UserController(IApplicationService applicationService, IConfiguration configuration, IMapper mapper) : base(applicationService)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ActionResult<CustomerReadOnlyDTO>> SignupCustomerAsync(CustomerSignupDTO customerSignupDTO)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, build a custom response
                var errors = ModelState
                    .Where(e => e.Value!.Errors.Any())
                    .Select(e => new
                    {
                        Field = e.Key,
                        Errors = e.Value!.Errors.Select(error => error.ErrorMessage).ToArray()
                    });

                // instead of return BadRequest(new { Errors = errors });
                throw new InvalidRegistrationException("ErrorsInRegistation: " + errors);
            }
            if (_applicationService == null)
            {
                throw new ServerGenericException("ApplicationServiceNull");
            }

            User? user = await _applicationService.UserService.GetUserByUsernameAsync(customerSignupDTO!.Username!);
            if (user is not null)
            {
                throw new UserAlreadyExistsException("UserExists: " + user.Username);
            }

            User? returnedUser = await _applicationService.CustomerService.SignUpUserAsync(customerSignupDTO);
        }
}
