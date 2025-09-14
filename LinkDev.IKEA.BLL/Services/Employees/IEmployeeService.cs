using LinkDev.IKEA.BLL.Models.Employee;
using LinkDev.IKEA.DAL.Persistance.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Services.Employees
{
    public interface IEmployeeService
    {
        EmployeeDto? GetEmployeeById(int id);

        EmployeeDetailsDto? GetEmployeeDetails(int id);

        PaginatedResult<EmployeeDto> GetPaginatedEmployees(QueryParameters? queryParameters);

        int CreateEmployee(EmployeeCreateDto employee);
        bool changeEmployeeStatus(int id, bool isActive);
        int UpdateEmployee(EmployeeUpdateDto employee);
        void DeleteEmployee(int id);
    }
}
