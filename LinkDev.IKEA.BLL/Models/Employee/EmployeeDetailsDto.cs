using LinkDev.IKEA.BLL.Models.Department;
using LinkDev.IKEA.DAL.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models.Employee
{

    public record EmployeeDetailsDto(
        EmployeeDto Employee,
        DepartmentDto Department,
        int YearsOfExperience
        
        );



}
