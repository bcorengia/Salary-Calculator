using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<PaginatedEmployees> GetEmployees(int page, int pageSize, string employeeFilter);
    }
}
