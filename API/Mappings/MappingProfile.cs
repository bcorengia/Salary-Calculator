using BLL.DTOs;
using Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Api.Mappings
{
    public static class MappingProfile
    {
        public static Employee MapToModel(this BaseEmployee employee)
        {
            return new Employee(employee.Id,
                                employee.Name,
                                employee.Salary,
                                employee.ContractType.ToString(),
                                employee.Role,
                                employee.AnnualSalary);
        }

        public static IEnumerable<Employee> MapToModel(this IEnumerable<BaseEmployee> employees) 
        {
            return employees.Select(e => e.MapToModel());
        }

        public static Models.PaginatedEmployees MapToModel(this BLL.DTOs.PaginatedEmployees employees)
        {
            return new Models.PaginatedEmployees(employees.Employees.MapToModel(),
                                                 employees.Page,
                                                 employees.PageSize,
                                                 employees.TotalCount);
        }
    }
}
