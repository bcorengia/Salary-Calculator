using BLL.DTOs;
using BLL.Mappings;
using BLL.Services.Interfaces;
using DAL.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<PaginatedEmployees> GetEmployees(int page, int pageSize, string employeeFilter)
        {
            var employees = await _employeeRepository.GetEmployees(employeeFilter);

            var paginatedEmployees = (page == 0 || pageSize == 0) ? employees : employees.Skip((page - 1) * pageSize).Take(pageSize);

            return new PaginatedEmployees(paginatedEmployees.MapToDto(), page, pageSize, employees.Count());
        }
    }
}
