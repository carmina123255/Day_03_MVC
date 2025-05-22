using LinkDev.IKEA.BLL.Models.Department;
using LinkDev.IKEA.DAL.Entities.Departments;
using LinkDev.IKEA.DAL.Contracts;
using LinkDev.IKEA.DAL.Persistance.Repositories;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.IKEA.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public int CreateDepartment(CreateDepartmentDto department)
        {
            var departmentToCreate = new Department()
            {
                Code = department.Code,
                Name=department.Name,
                Description=department.Description,
                CreationDate=department.CreationDate,
                CreatedBy="",
                LastModifiedBy=""

            };
            
            _UnitOfWork.Departments.Add(departmentToCreate);
            return _UnitOfWork.Complete();

        }

        public IEnumerable<DepartmentDto> GetDepartment()
            
        {
            if (_UnitOfWork is null) Console.WriteLine("Unit is null");
            if (_UnitOfWork.Departments is null) Console.WriteLine("UD is null");
         

            var departments = _UnitOfWork.Departments.GetAll();
           

                foreach (var department in departments)
                {
                    yield return new DepartmentDto(department.Id, department.Code, department.Name, department.CreationDate,department.Manager?.FirstName,department.Description);
                }
            
        }

        public DepartmentDetailsDto GetDepartmentById(int id)
        {
            var department = _UnitOfWork.Departments.Get(filter:D=>D.Id==id,includes:query=>query.Include(nameof(Department.Manager)));
            if (department is null) return null;
            return new DepartmentDetailsDto(department.Id, department.Name, department.Code, department.Description,department.CreationDate,department.CreatedBy,department.CreatedOn,department.LastModifiedBy,department.LastModifiedOn,$"{department.Manager?.FirstName} {department.Manager?.LastName}");
        }

        public bool RemoveDepartment(int id)
        {
            _UnitOfWork.Departments.Delete(id);
            var Deleted = _UnitOfWork.Complete() > 0;
            return Deleted;
        }

        public int UpdateDepartment(UpdateDepartmentDto department)
        {
            var dept = new Department()
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate,
                CreatedBy = "",
                LastModifiedBy = ""

            };

            _UnitOfWork.Departments.Update(dept);
            return _UnitOfWork.Complete();
        }
    }
}
