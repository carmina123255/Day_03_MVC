using LinkDev.IKEA.BLL.Services.Employees;
using LinkDev.IKEA.DAL.Contracts.Repositories;
using LinkDev.IKEA.DAL.Persistance.Common;
using LinkDev.IKEA.PL.Models.Employee;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.IKEA.PL.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet] //Get:/Employee/Index
        public IActionResult Index(int pageIndex=1,int PageSize = 10)
        {


            var queryParameters = new QueryParameters
            {
                PageSize = PageSize,
                PageIndex = pageIndex
            };
            var employee = _employeeService.GetPaginatedEmployees(queryParameters);
            var model = new EmployeeListViewModel()
            {

                Employees = employee.Data.Select(e => new EmployeeViewModel()
                {
                    Id = e.Id,
                    FullName = $"{e.FirstName} {e.LastName}",
                    Age = e.Age,
                    Address = e.Address,
                    Salary = e.Salary,
                    Email = e.Email,
                    PhoneNumber = e.phoneNumber,
                    IsActive = e.IsActive,
                    EmployeeType = e.EmployeeType,
                    Gender = e.Gender,
                    CreatedBy = e.CreatedBy,
                    LastModifiedBy = e.LastModifiedBy,
                    CreatedOn = e.CreatedOn,
                    LastModifiedOn = e.LastModifiedOn,
                    Department=e.DepartmentName
                }),
                Page=employee.PageIndex,
                PageSize=employee.PageSize,
                TotalCount=employee.TotalCount,
 
            };

            return View(model);
        }
    }
}
