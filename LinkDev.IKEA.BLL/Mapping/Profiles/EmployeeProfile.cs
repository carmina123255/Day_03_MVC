using AutoMapper;
using LinkDev.IKEA.BLL.Models.Department;
using LinkDev.IKEA.BLL.Models.Employee;
using LinkDev.IKEA.DAL.Entities.Departments;
using LinkDev.IKEA.DAL.Entities.Employees;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Mapping.Profiles
{
    class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.FirstName, options => options.MapFrom(src => $"Sir .{src.FirstName}"))
                .ForMember(dest => dest.DepartmentName, options => options.MapFrom(sc => sc.Department.Name))
               /// .ForMember(dest => dest.DepartmentName, options =>
               /// {
               ///     options.Condition(src => src.Department is null);
               ///     options.MapFrom(src => src.Department!.Name);
               /// }
               ///
               /// )
                .ForMember(dest => dest.FormattedHireDate, opt => opt.MapFrom(src => src.HireDate.ToString("MMMM d,yyyy")))

                .ReverseMap();
            //.ForMember(dest => dest.FirstName, options => options.MapFrom(sc => sc.FirstName));

            CreateMap<EmployeeCreateDto, Employee>();

            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.Manager, options =>
                {
                    options.Condition(scr => scr.Manager is not null);
                    options.MapFrom(src => $"{src.Manager!.FirstName} {src.Manager!.LastName}");
                }
                )
                .ReverseMap();
        }
    }
}
