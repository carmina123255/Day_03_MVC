using LinkDev.IKEA.BLL.Models.Department;
using LinkDev.IKEA.DAL.Common.Entities.Departments;
using LinkDev.IKEA.DAL.Contracts;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            _UnitOfWork.DepartmentRepository.Add(departmentToCreate);
            return _UnitOfWork.Complete();

        }

        public IEnumerable<DepartmentDto> GetDepartment()
        {
            var departments = _UnitOfWork.DepartmentRepository.GetAll();

            foreach(var department in departments)
            {
                yield return new DepartmentDto(department.Id,department.Code,department.Name,department.CreationDate);
            }
        }

        public DepartmentDetailsDto GetDepartmentById(int id)
        {
            var department = _UnitOfWork.DepartmentRepository.Get(id);
            if (department is null) return null;
            return new DepartmentDetailsDto(department.Id, department.Name, department.Code, department.Description,department.CreationDate,department.CreatedBy,department.CreatedOn,department.LastModifiedBy,department.LastModifiedOn);
        }

        public bool RemoveDepartment(int id)
        {
            _UnitOfWork.DepartmentRepository.Delete(id);
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

            _UnitOfWork.DepartmentRepository.Update(dept);
            return _UnitOfWork.Complete();
        }
    }
}
