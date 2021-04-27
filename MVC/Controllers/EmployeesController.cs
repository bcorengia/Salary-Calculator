using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc.Mappings;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class EmployeesController : Controller
    {


        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeesController(ILogger<HomeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }


        public IActionResult OnGetPartialEmployees(string filter, int page, int pageSize)
        {
            var paginatedEmployees = _employeeService.GetEmployees(page, pageSize, filter).Result;

            var employeesTableModel = new EmployeesTableViewModel(paginatedEmployees.Employees.MapToModel(), 
                                                                  paginatedEmployees.Page, 
                                                                  paginatedEmployees.PageSize,
                                                                  paginatedEmployees.TotalCount);

            return PartialView("_EmployeesTable", employeesTableModel);
        }
    }
}
