using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Common.Entities.Departments
{
   public class Department:BaseAuditableEntity<int>
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }
        [JsonConverter(typeof(DataOnlyJsonConverter))]
        public DateOnly CreationDate { get; set; }
    }
}
