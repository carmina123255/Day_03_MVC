using LinkDev.IKEA.BLL.Services.Departments;
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
            return View();
        }
    }
}
