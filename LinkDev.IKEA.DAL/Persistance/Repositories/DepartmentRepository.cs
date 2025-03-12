using LinkDev.IKEA.DAL.Common.Entities.Departments;
using LinkDev.IKEA.DAL.Contacts.Repositories;
using LinkDev.IKEA.DAL.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Persistance.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DepartmentRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public Department? Get(int id)
        {
            var department = dbContext.Departments.Find(id);
            department = dbContext.Find<Department>(id);

          /// var dept = dbContext.Departments.Local.FirstOrDefault(D => D.Id == id);
          /// if(dept is null) dept = dbContext.Departments.FirstOrDefault(D => D.Id == id);
          ///
            return department;
        }

        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {
            if (!WithTracking) return dbContext.Departments.AsNoTracking();
            else return dbContext.Departments;
        }

        public void Add(Department Entity) => dbContext.Departments.Add(Entity);
       

        public void Delete(int id)
        {
            var department = dbContext.Departments.Find(id);
            if((!(department is null)))
            {
                dbContext.Departments.Remove(department);
               
            }
         
        }

       
        public void  Update(Department Entity)=>  dbContext.Departments.Update(Entity);
          
    
    }
}
