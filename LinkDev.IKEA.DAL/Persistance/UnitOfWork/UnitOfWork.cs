using LinkDev.IKEA.DAL.Contacts.Repositories;
using LinkDev.IKEA.DAL.Contracts;
using LinkDev.IKEA.DAL.Persistance.Data;
using LinkDev.IKEA.DAL.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Persistance.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        public IDepartmentRepository? DepartmentRepository { get ; set; }

       public UnitOfWork(ApplicationDbContext context)
        {
            DepartmentRepository departmentRepository = new DepartmentRepository(context);
            dbContext = context;
        }

        public int Complete()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
             dbContext.Dispose();
        }
    }
}
