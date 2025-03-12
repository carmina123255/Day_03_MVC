﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models.Department
{
    public record DepartmentDto(int Id, string Code, string Name, DateOnly CreationDate);
}
