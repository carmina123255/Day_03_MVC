using AutoMapper;
using LinkDev.IKEA.BLL.Models.Employee;
using LinkDev.IKEA.BLL.Services.Departments;
using LinkDev.IKEA.BLL.Services.Employees;
using LinkDev.IKEA.DAL.Contacts.Repositories;
using LinkDev.IKEA.DAL.Contracts.Repositories;
using LinkDev.IKEA.DAL.Entities.Departments;
using LinkDev.IKEA.DAL.Persistance.Common;
using LinkDev.IKEA.PL.Models.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Extensions.Hosting;

namespace LinkDev.IKEA.PL.Controllers
{
    [Authorize(Roles ="Admin,Manager")]
    public class EmployeeController:Controller
    {
        #region Services
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment hostEnvironment;

        #endregion
        public EmployeeController(IEmployeeService employeeService,
            IDepartmentService departmentSrvice, ILogger<EmployeeController> logger,
            IMapper mapper,IWebHostEnvironment hostEnvironment)
        {
            
            _logger = logger;
            _mapper = mapper;
            this.hostEnvironment = hostEnvironment;
            _employeeService = employeeService;
            _departmentService = departmentSrvice;
        }

        #region Index 
        [HttpGet] //Get:/Employee/Index
        public IActionResult Index(string SearchTerm="",
            string SortBy="name",bool SortAsc=true,
            int pageIndex = 1, int PageSize = 10)
        {


            var queryParameters = new QueryParameters
            {
                PageSize = PageSize,
                PageIndex = pageIndex,
                Searchterm=SearchTerm,
                SortBy=SortBy,
                SortAsc=SortAsc
                
            };
            var employee = _employeeService.GetPaginatedEmployees(queryParameters);
            var employeeViewModel = _mapper.Map<IEnumerable<EmployeeViewModel>>(employee.Data);

            
            var model = new EmployeeListViewModel()
          {
         
              Employees = employeeViewModel,
             ///employee.Data.Select(e => new EmployeeViewModel()
             ///{
             ///    Id = e.Id,
             ///    FullName = $"{e.FirstName} {e.LastName}",
             ///    Age = e.Age,
             ///    Address = e.Address,
             ///    Salary = e.Salary,
             ///    Email = e.Email,
             ///    PhoneNumber = e.PhoneNumber,
             ///    IsActive = e.IsActive,
             ///    EmployeeType = e.EmployeeType,
             ///    Gender = e.Gender,
             ///    CreatedBy = e.CreatedBy,
             ///    LastModifiedBy = e.LastModifiedBy,
             ///    CreatedOn = e.CreatedOn,
             ///    LastModifiedOn = e.LastModifiedOn,
             ///    Department = e.DepartmentName
             ///}),
              Page = employee.PageIndex,
              PageSize = employee.PageSize,
              TotalCount = employee.TotalCount,
              SortedBy=SortBy,
              SortedAscending=SortAsc,
              SearchTerm=SearchTerm
         
          };

            return View(model);
        }
        #endregion

        #region Details 

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var employeeDetails = _employeeService.GetEmployeeDetails(id.Value);
            if (employeeDetails is null) return NotFound();

            var ViewModel = _mapper.Map<EmployeeDetailsViewModel>(employeeDetails);
           
          /// var model = new EmployeeDetailsViewModel
          /// {
          ///
          ///     Id = employeeDetails.Employee.Id,
          ///     FirstName = employeeDetails.Employee.FirstName,
          ///     LastName = employeeDetails.Employee.LastName,
          ///     Email = employeeDetails.Employee.Email,
          ///     PhoneNumber = employeeDetails.Employee.phoneNumber,
          ///     Gender = employeeDetails.Employee.Gender,
          ///     Address = employeeDetails.Employee.Address,
          ///     EmployeeType = employeeDetails.Employee.EmployeeType,
          ///     IsActive = employeeDetails.Employee.IsActive,
          ///     Age = employeeDetails.Employee.Age,
          ///
          ///     // Department Information
          ///     DepartmentId = employeeDetails.Department.Id,
          ///     DepartmentName = employeeDetails.Department.Name,
          ///     DepartmentCode = employeeDetails.Department.Code,
          ///     DepartmentDescription = employeeDetails.Department.Description,
          ///
          ///     // Audit Information
          ///     CreatedBy = employeeDetails.Employee.CreatedBy,
          ///     CreatedOn = employeeDetails.Employee.CreatedOn,
          ///     LastModifiedBy = employeeDetails.Employee.LastModifiedBy,
          ///     LastModifiedOn = employeeDetails.Employee.LastModifiedOn
          /// };
          
            return View(ViewModel);
        }

        #endregion

        #region Create
         
        [HttpGet] // GEt:/Employee/Create 

        public IActionResult Create()
        {
            var department = _departmentService.GetDepartment();
            var viewModel = new EmployeeCreateViewModel()
            {
                Departments = department.Select(d => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }),
                DateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-18))
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var message = "Createad Successfuly";
            try
            {
                // var employeeToCreate = new EmployeeCreateDto(model.FirstName, model.LastName, model.Address, model.Salary, model.Email, model.PhoneNumber, model.DateOfBirth, model.Gender, model.EmployeeType, model.DepartmentId);
                var employeeToCreate = _mapper.Map<EmployeeCreateDto>(model);
                var created = _employeeService.CreateEmployee(employeeToCreate) > 0;

                if (created)
                    return RedirectToAction(nameof(Index));
                message = "Employee Creation filed";
            }
            catch (Exception ex)
            {
                //1-Log Exception in Database or External File
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
                //2-Set Message 
                message = "An error Occurred,Please Try Later";
            }

            return RedirectToAction(nameof(Index));

        }
        #endregion


        #region Update 
        [HttpGet] //Get : /Employee/Edit/{id?}
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();

            var viewModel = new EmployeeEditViewModel()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address = employee.Address,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Gender = employee.Gender,
                IsActive = employee.IsActive,
                EmployeeType = employee.EmployeeType,
                DepartmentId = employee.DepartmentId

            };
            return View(viewModel);

        }

        [HttpPost]

        public IActionResult Edit([FromRoute] int id, EmployeeEditViewModel model)
        {
            if (((int?)TempData["Id"]) != id)
            {
                ModelState.AddModelError("Id", "Invalid Id");
                return View(model);
            }
            if (!ModelState.IsValid)
                return View(model);
            var message = "Department Updated Successfuly";

            try
            {
                /// var employeeToUpdate = new EmployeeUpdateDto(model.Id, model.FirstName, model.LastName, model.Address, model.Salary, model.Email, model.PhoneNumber, model.DateOfBirth, model.IsActive, model.Gender, model.EmployeeType, model.DepartmentId);
                var employeeToUpdate = _mapper.Map<EmployeeUpdateDto>(model);
                var updated = _employeeService.UpdateEmployee(employeeToUpdate) > 0;
                if (!updated) message = "An  error occure ";
            }
            catch (Exception ex)
            {
                //1-Log Exception in Database or External File
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
                //2-Set Message 
                message = "An error Occurred,Please Try Later";
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete 
        [HttpPost]
        public IActionResult Delete(int id)
        {

            var message = "Department Created Successfuly";
            try
            {
                _employeeService.DeleteEmployee(id);


            }
            catch (Exception ex)
            {//1-Log Exception in Database or External File
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
                //2-Set Message 
                if (hostEnvironment.IsDevelopment())
                    message = ex.Message;
                else
                    message = "There is Error Occur , Try Again";
            }
            TempData["Message"] = message;//Appear message in next Action
            return RedirectToAction(nameof(Index));//next Action 
        }

        #endregion


        #region Toggle Status 
        [HttpPost]
        public IActionResult ToggleStatus(int id, bool IsActive)
        {
            var message = "";
            try
            {
                var result = _employeeService.changeEmployeeStatus(id, IsActive);

                // Set message based on the intended action, not the result
                message = result ?
                    "Employee activated successfully" :
                    "Employee deactivated successfully";
            }
            catch (Exception ex)
            {
                // 1 - Log Exception in Database or External File
                _logger.LogError(ex, "Error changing employee status for ID {EmployeeId}: {ErrorMessage}", id, ex.Message);

                // 2 - Set Message 
                if (hostEnvironment.IsDevelopment())
                    message = ex.Message;
                else
                    message = "An error occurred. Please try again.";
            }

            TempData["Message"] = message; // Appear message in next Action
            return RedirectToAction(nameof(Index));
        }

        #endregion




    }


}
