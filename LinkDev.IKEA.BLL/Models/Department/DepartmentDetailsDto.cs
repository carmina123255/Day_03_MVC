using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models.Department
{
    #region Auditable 
    #endregion
   public record DepartmentDetailsDto(int Id, string Name, string Code, string? Description, DateOnly CreationDate, string CreatedBy, DateTime CreatedOn, string LastModifiedBy, DateTime LastModifiedOn)
        ;
}
