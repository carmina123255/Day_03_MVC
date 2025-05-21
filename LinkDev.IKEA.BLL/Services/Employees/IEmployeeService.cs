using LinkDev.IKEA.BLL.Models.Employee;
using LinkDev.IKEA.DAL.Persistance.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Services.Employees
{
    public interface IEmployeeService
    {
        EmployeeDto? GetEmployeeById(int id);

        EmployeeDetailsDto? GetEmployeeDetails(int id);

        PaginatedResult<EmployeeDto> GetPaginatedEmployees(QueryParameters? queryParameters);

        void CreateEmployee(EmployeeCreateDto employee);
        void UpdateEmployee(EmployeeUpdateDto employee);
        void DeleteEmployee(int id);
    }
}
