using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models.Department
{
    record CreateDepartmentDto(string Name, string Code, string? Description, DateOnly CreationDate);
}
