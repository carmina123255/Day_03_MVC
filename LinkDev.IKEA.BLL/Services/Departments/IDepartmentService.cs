using LinkDev.IKEA.BLL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Services.Departments
{
    interface IDepartmentService
    {
        IEnumerable<DepartmentDto> GetDepartment();
        DepartmentDetailsDto GetDepartmentById(int id);
        int CreateDepartment(CreateDepartmentDto department);
        int UpdateDepartment(UpdateDepartmentDto department);
        bool RemoveDepartment(int id);
    }


}
