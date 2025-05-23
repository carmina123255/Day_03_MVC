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
    public class EmployeeRepository : BaseRepository<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public PaginatedResult<Employee> GetAll(QueryParameters Parameters)
        {
            Expression<Func<Employee, bool>>? filter = null;
            if (!string.IsNullOrEmpty(Parameters.Searchterm))
            {
                filter = e => e.FirstName.Contains(Parameters.Searchterm) || e.LastName.Contains(Parameters.Searchterm);
            }

            Func<IQueryable<Employee>, IQueryable<Employee>>? includes = null;
            includes = query => query.Include(e => e.Department);

            // Remove nullable annotation and provide default ordering
            Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? OrderBy = null;
            OrderBy=Parameters.SortBy?.ToLower() switch
            {
                "name" => Parameters.SortAsc ?
                      query => query.OrderBy(E => E.FirstName).ThenBy(E => E.LastName)
                    : query => query.OrderByDescending(E => E.FirstName).ThenByDescending(E => E.LastName),
                "hiredate" => Parameters.SortAsc ?
                      query => query.OrderBy(E => E.HireDate)
                    : query => query.OrderByDescending(E => E.HireDate),
                "address" => Parameters.SortAsc ?
                      query => query.OrderBy(E => E.Address)
                    : query => query.OrderByDescending(E => E.Address),
                "departmentid" => Parameters.SortAsc ?
                      query => query.OrderBy(E => E.DepartmentId)
                    : query => query.OrderByDescending(E => E.DepartmentId),
                _ => Parameters.SortAsc ?
                      query => query.OrderBy(E => E.FirstName).ThenBy(E => E.LastName)
                    : query => query.OrderByDescending(E => E.FirstName).ThenByDescending(E => E.LastName)
            };

          

            return base.GetAll(Parameters, filter, OrderBy, includes);
        }
         
    
    }
}
