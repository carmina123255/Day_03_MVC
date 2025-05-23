using LinkDev.IKEA.DAL.Contacts.Repositories;
using LinkDev.IKEA.DAL.Contracts;
using LinkDev.IKEA.DAL.Contracts.Repositories;
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

        private readonly Lazy<EmployeeRepository> _employeeRepository;
        private readonly Lazy<DepartmentRepository> _departmentRepository;

       public UnitOfWork(ApplicationDbContext context)
        {
            dbContext = context;
            _employeeRepository = new Lazy<EmployeeRepository>(() => new EmployeeRepository(context));
            _departmentRepository = new Lazy<DepartmentRepository>(() => new DepartmentRepository(context));
        }

        public IDepartmentRepository Departments => _departmentRepository.Value;
        public IEmployeeRepository Employees => _employeeRepository.Value;

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
