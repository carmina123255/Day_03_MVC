using LinkDev.IKEA.BLL.Services.Employees;
using LinkDev.IKEA.DAL.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.IKEA.PL.Controllers
{
    public class EmployeeControllers:Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeControllers> _logger;

        public EmployeeControllers(IEmployeeService employeeService, ILogger<EmployeeControllers> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }
    }
}
