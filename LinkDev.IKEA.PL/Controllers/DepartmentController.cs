using LinkDev.IKEA.BLL.Models.Department;
using LinkDev.IKEA.BLL.Services.Departments;
using LinkDev.IKEA.DAL.Common.Entities.Departments;
using LinkDev.IKEA.PL.Models.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Identity.Client;

namespace LinkDev.IKEA.PL.Controllers
{
    public class DepartmentController : Controller/* IDepartmentService departmentServcide*/
    {
        #region Services 
        /// [FromServices]
        /// public IDepartmentService departmentService { get; set; }
        /// 
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> logger;

        public DepartmentController(ILogger<DepartmentController>Logger,IDepartmentService departmentServic)
        {
            logger = Logger;
            _departmentService = departmentServic;
        }
        #endregion

        #region Index
        public IActionResult Index(/*[FromServices]IDepartmentService departmentServcide*/)
        {
            var departments = _departmentService.GetDepartment();
            var departmentViewMode = departments.Select(d => new DepartmentViewModel()
            {
                Id = d.Id,
                Code = d.Code,
                Name = d.Name,
                CreationDate = d.CreationDate
            });


            return View(departmentViewMode);
        }
        #endregion

        #region Details
        [HttpGet] //Department/Details/Id

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();//400
            var department = _departmentService.GetDepartmentById(id.Value);

            if (department is null)
                return NotFound();//404

            var departmentToView = new DepartmentDetailsViewModels()
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description??" ",

                CreationDate = department.CreationDate,
                CreatedBy = department.CreatedBy,
                CreatedOn = department.CreatedOn,
                LastModifiedBy = department.LastModifiedBy,
                LastModifiedOn = department.LastModifiedOn


            };
            return View(departmentToView);

        }

        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //Post:/Department/Create
        public IActionResult Create(CreateDepartmentViewModel model)
        {
            var message = "Department Created Successfuly";
            try
            {
                if (!ModelState.IsValid)
                    return View(model);
                var departmentToCreate = new CreateDepartmentDto(model.Code, model.Name, model.Description, model.CreationDate);
                var Created = _departmentService.CreateDepartment(departmentToCreate) > 0;
                if (!Created)
                    message = "Failed To Create Department";

            }
            catch(Exception ex)
            {//1-Log Exception in Database or External File
                logger.LogError(ex.Message, ex.StackTrace!.ToString());
                //2-Set Message 
                message = "An error Occurred,Please Try Later";
            }
            TempData["Message"] = message;//Appear message in next Action
            return RedirectToAction(nameof(Index));//next Action 
        }
        #endregion
    }
}
