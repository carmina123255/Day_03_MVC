using LinkDev.IKEA.DAL.Contracts.Repositories;
using LinkDev.IKEA.DAL.Entities.Employees;
using LinkDev.IKEA.DAL.Persistance.Common;
using LinkDev.IKEA.DAL.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Persistance.Repositories
{
    public class EmployeeRepository:BaseRepository<Employee,int>,IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public  PaginatedResult<Employee> GetAll(QueryParameters Parameters)
        {
            Expression<Func<Employee, bool>>? filter = null;
            if (!string.IsNullOrEmpty(Parameters.Searchterm))
            {
                filter=e=>e.FirstName.Contains(Parameters.Searchterm)|| e.LastName.Contains(Parameters.Searchterm);
            }
            Func<IQueryable<Employee>, IQueryable<Employee>>? includes = null;
            includes = query => query.Include(e => e.Department);

            return base.GetAll(Parameters, filter, null, includes);
        }
    }
}
