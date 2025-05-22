using LinkDev.IKEA.BLL.Models.Department;
using LinkDev.IKEA.BLL.Models.Employee;
using LinkDev.IKEA.DAL.Contracts;
using LinkDev.IKEA.DAL.Entities.Employees;
using LinkDev.IKEA.DAL.Persistance.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public EmployeeDto? GetEmployeeById(int id)
        {
            var employee = _unitOfWork.Employees.Get(id);
            if (employee is null)
                return null;
            var employeeDto = new EmployeeDto(employee.Id, employee.FirstName, employee.LastName,employee.Department.Name, employee.Age , employee.Email
                , employee.PhoneNumber, employee.Address, employee.Salary, employee.IsActive, employee.HireDate, employee.Gender, employee.
                EmployeeType, employee.DepartmentId, employee.CreatedBy, employee.CreatedOn, employee.LastModifiedBy, employee.LastModifiedOn);

            return employeeDto;
        }

        public EmployeeDetailsDto? GetEmployeeDetails(int id)
        {
            var employee = _unitOfWork.Employees.Get(
                filter: E => E.Id == id,
                includes: E => E.Include(E => E.Department));

            if (employee is null)
                return null;

            var employeeDto = new EmployeeDto(employee.Id, employee.FirstName, employee.LastName,employee.Department.Name, employee.Age, employee.Email
              , employee.PhoneNumber, employee.Address, employee.Salary, employee.IsActive, employee.HireDate, employee.Gender, employee.
           EmployeeType, employee.DepartmentId, employee.CreatedBy, employee.CreatedOn, employee.LastModifiedBy, employee.LastModifiedOn);

            DepartmentDto departmentDto = default!;
            if (employee.Department is not null)
                departmentDto = new DepartmentDto(employee.Department.Id, employee.Department.Code, employee.Department.Name, employee.Department.CreationDate,$"{employee.Department?.Manager?.FirstName} {employee.Department?.Manager?.LastName}",employee.Department?.Description);

            var YearsOfExperience = DateTime.Now.Year - employee.HireDate.Year;

            var employeeDetailsDto = new EmployeeDetailsDto(employeeDto, departmentDto, YearsOfExperience);
            return employeeDetailsDto;



        }

        public PaginatedResult<EmployeeDto> GetPaginatedEmployees(QueryParameters queryParameters)
        {
            if (queryParameters.PageIndex < 1)
                queryParameters.PageIndex = 1;

            if (queryParameters.PageSize < 1)
                queryParameters.PageSize = 10;

            if(queryParameters.PageSize>100)
                queryParameters.PageSize = 100;

            var employees = _unitOfWork.Employees.GetAll(
               Parameters:queryParameters,
                includes: E => E.Include(nameof(Employee.Department))
                //filter:E=>E.FirstName.contains(queryParamters.searchterm)
                //orderby:E=E.Age
                );

            var result = new PaginatedResult<EmployeeDto>()
            {
                Data = employees.Data.Select(employee => new EmployeeDto(employee.Id, employee.FirstName,employee.Department.Name, employee.LastName, employee.Age, employee.Email
              , employee.PhoneNumber, employee.Address, employee.Salary, employee.IsActive, employee.HireDate, employee.Gender, employee.
                EmployeeType, employee.DepartmentId, employee.CreatedBy, employee.CreatedOn, employee.LastModifiedBy, employee.LastModifiedOn)),
                PageIndex = queryParameters.PageIndex,
                PageSize = queryParameters.PageSize,
                TotalCount = queryParameters.TotalCount


            };

            return result;

        }

        public int CreateEmployee(EmployeeCreateDto employeeDto)
        {
            validateEmployeeCreateBussinessRules(employeeDto);
            var employee = new Employee()
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Age = DateTime.Now.Year - employeeDto.BirthOfDate.Year,
                Address = employeeDto.Address,
                DepartmentId = employeeDto.DepartmentId,
                PhoneNumber = employeeDto.PhoneNumber, 
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                Salary = employeeDto.Salary,
                CreatedBy="",
                LastModifiedBy=""
            };
            employee.HireDate = DateOnly.FromDateTime(DateTime.Now);
            employee.IsActive = true;

            _unitOfWork.Employees.Add(employee);
           return  _unitOfWork.Complete();
        }

     
        public void UpdateEmployee(EmployeeUpdateDto employeeDto)
        {
            var existingemp = _unitOfWork.Employees.Get(employeeDto.Id);
            if (existingemp is null) return;
            validateEmployeeUpdateBussinessRules(employeeDto, existingemp);
            existingemp.FirstName = employeeDto.FirstName;
            existingemp.LastName = employeeDto.LastName;
             existingemp.Address = employeeDto.Address;
            existingemp.DepartmentId = employeeDto.DepartmentId;
             existingemp.Email = employeeDto.Email;
            existingemp.PhoneNumber = employeeDto.PhoneNumber;
            existingemp.IsActive = employeeDto.IsActive;
            existingemp.Gender = employeeDto.Gender;
            existingemp.EmployeeType = employeeDto.EmployeeType;

            _unitOfWork.Employees.Update(existingemp);
            _unitOfWork.Complete();
        
        }



        public void DeleteEmployee(int id)
        {
            _unitOfWork.Employees.Delete(id);
            _unitOfWork.Complete();
        }

        #region HelperMethod 

        private void validateEmployeeCreateBussinessRules(EmployeeCreateDto employee)
        {
            if (employee.DepartmentId.HasValue)
            {
                var department = _unitOfWork.Departments.Get(employee.DepartmentId.Value);
                if (department is null)
                    throw new Exception($"Department with Id {employee.DepartmentId} does not exit .");

            }
            var minage = 18;
            var age = DateTime.Now.Year - employee.BirthOfDate.Year;
            if (age < minage)
                throw new Exception($"Employee must be at least{minage}");

            if (employee.Salary < 5000)
                throw new Exception($"Salary at least be 5000");
        
        }

        private void validateEmployeeUpdateBussinessRules(EmployeeUpdateDto employee,Employee  existingemp)
        {
            if (employee.DepartmentId.HasValue)
            {
                var department = _unitOfWork.Departments.Get(employee.DepartmentId.Value);
                if (department is null)
                    throw new Exception($"Department with Id {employee.DepartmentId} does not exit .");

            }
            
            var newsalary= existingemp.Salary * existingemp.Salary * 0.1m;
            if (employee.Salary<newsalary)
                throw new Exception($"salary must be larger than or equal{newsalary}");

        }
        #endregion
    }
}
