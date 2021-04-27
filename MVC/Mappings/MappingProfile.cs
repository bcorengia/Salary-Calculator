using BLL.DTOs;
using Mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mvc.Mappings
{
    public static class MappingProfile
    {
        public static EmployeeViewModel MapToModel(this BaseEmployee employee)
        {
            return new EmployeeViewModel(employee.Id,
                                         employee.Name,
                                         employee.Salary,
                                         employee.ContractType.ToString(),
                                         employee.Role,
                                         employee.AnnualSalary);
        }

        public static IEnumerable<EmployeeViewModel> MapToModel(this IEnumerable<BaseEmployee> employees) 
        {
            return employees.Select(e => e.MapToModel());
        }

        public static EmployeesTableViewModel MapToModel(this PaginatedEmployees employees)
        {
            return new EmployeesTableViewModel(employees.Employees.MapToModel(),
                                               employees.Page,
                                               employees.PageSize,
                                               employees.TotalCount);
        }
    }
}
