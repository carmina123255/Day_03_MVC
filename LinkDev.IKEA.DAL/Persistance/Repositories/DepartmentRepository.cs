using LinkDev.IKEA.DAL.Contacts.Repositories;
using LinkDev.IKEA.DAL.Entities.Departments;
using LinkDev.IKEA.DAL.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Persistance.Repositories
{
    public class DepartmentRepository : BaseRepository<Department,int>
    {
          public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    
    }
}
