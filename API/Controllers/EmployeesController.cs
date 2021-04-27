using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Mappings;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        /// <summary>
        /// Gets paginated employees.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="employeeFilter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Models.PaginatedEmployees> GetEmployees(int page, int pageSize, string employeeFilter)
        {
            var employees = await _employeeService.GetEmployees(page, pageSize, employeeFilter);

            return employees.MapToModel();
        }
    }
}
