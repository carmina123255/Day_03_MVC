using LinkDev.IKEA.DAL.Common.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Contacts.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll(bool WithTracking = false);

        Department? Get(int id);
        void Add(Department Entity);
        void Update(Department Entity);
        void  Delete(int id);
    }
}
