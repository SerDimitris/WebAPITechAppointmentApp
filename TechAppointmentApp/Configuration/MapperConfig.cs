using AutoMapper;
using TechAppointmentApp.Data;
using TechAppointmentApp.DTO;

namespace TechAppointmentApp.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Customer, CustomerReadOnlyDTO>().ReverseMap();

            CreateMap<Appointment, CustomerAppointmentReadOnlyDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.AppointmentDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Customer.User.Firstname))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Customer.User.Lastname))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Customer.User.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Customer.Address))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Customer.Area != null ? src.Customer.Area.AreaName : string.Empty)).ReverseMap();

            CreateMap<Appointment, TechnicianAppointmentReadOnlyDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.AppointmentDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Technician.User.Firstname))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Technician.User.Lastname)).ReverseMap();

            CreateMap<User, CustomerSignupDTO>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Firstname))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Lastname))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Customer!.Address))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Customer!.Area != null ? src.Customer.Area.AreaName : string.Empty))
                .ForMember(dest => dest.Service, opt => opt.MapFrom(src => src.Customer!.Service!.UserService.ToString())).ReverseMap();

            CreateMap<User, TechnicianSignupDTO>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Firstname))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Lastname))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Technician!.Area != null ? src.Technician.Area.AreaName : string.Empty)).ReverseMap();

            CreateMap<User, UserLoginDTO>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password)).ReverseMap();
        }
    }
}
