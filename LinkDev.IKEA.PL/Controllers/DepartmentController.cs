using LinkDev.IKEA.BLL.Services.Departments;
using LinkDev.IKEA.DAL.Common.Entities.Departments;
using LinkDev.IKEA.PL.Models.Department;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.IKEA.PL.Controllers
{
    public class DepartmentController : Controller/* IDepartmentService departmentServcide*/
    {
      /// [FromServices]
      /// public IDepartmentService departmentService { get; set; }
      /// 
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentServic)
        {
            _departmentService = departmentServic;
        }
        public IActionResult Index([FromServices]IDepartmentService departmentServcide)
        {
            var departments = _departmentService.GetDepartment();
            var departmentViewMode = departments.Select(d => new DepartmentViewModel()
            {
                Id = d.Id,
                Code=d.Code,
                Name=d.Name,
                CreationDate=d.CreationDate
            });


            return View(departmentViewMode);
        }
    }
}
