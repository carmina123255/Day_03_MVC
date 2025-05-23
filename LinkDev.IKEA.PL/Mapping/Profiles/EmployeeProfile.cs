using AutoMapper;
using LinkDev.IKEA.BLL.Models.Department;
using LinkDev.IKEA.BLL.Models.Employee;
using LinkDev.IKEA.DAL.Entities.Departments;
using LinkDev.IKEA.PL.Models.Employee;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinkDev.IKEA.PL.Mapping.Profiles
{
    public class EmployeeProfile: Profile
    {
       public EmployeeProfile()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<EmployeeDto, EmployeeViewModel>()
                .ForMember(dest => dest.Department, options => options.MapFrom(src => src.DepartmentName));

              CreateMap<EmployeeDetailsDto, EmployeeDetailsViewModel>()

            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Employee.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Employee.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Employee.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Employee.Email))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Employee.PhoneNumber))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Employee.Gender))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Employee.Address))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Employee.Age))
            .ForMember(dest => dest.ForamttedHireDate, opt => opt.MapFrom(src => src.Employee.HireDate.ToString("MMM dd, yyyy"))) 
            .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Employee.Salary))
            .ForMember(dest => dest.EmployeeType, opt => opt.MapFrom(src => src.Employee.EmployeeType))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Employee.IsActive))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.Employee.CreatedBy))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.Employee.CreatedOn))
            .ForMember(dest => dest.LastModifiedBy, opt => opt.MapFrom(src => src.Employee.LastModifiedBy))
            .ForMember(dest => dest.LastModifiedOn, opt => opt.MapFrom(src => src.Employee.LastModifiedOn))

            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Department.Id))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
            .ForMember(dest => dest.DepartmentCode, opt => opt.MapFrom(src => src.Department.Code))
            .ForMember(dest => dest.DepartmentDescription, opt => opt.MapFrom(src => src.Department.Description))

            .ForMember(dest => dest.YearsOfServic, opt => opt.MapFrom(src => src.YearsOfExperience))

           
            ;
            CreateMap<EmployeeCreateViewModel, EmployeeCreateDto>();
            CreateMap<EmployeeDto, EmployeeEditViewModel>();
            CreateMap<EmployeeEditViewModel, EmployeeCreateDto>();


        }
    }
}
