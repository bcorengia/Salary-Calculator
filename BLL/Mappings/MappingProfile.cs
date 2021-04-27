using BLL.DTOs;
using BLL.Enums;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Mappings
{
    public static class MappingProfile
    {
        public static BaseEmployee MapToDto(this Employee employee)
        {
            var role = new Role(employee.RoleId, employee.RoleName, employee.RoleDescription);
            Enum.TryParse(employee.ContractTypeName, out ContractTypeEnum contractType);

            return contractType switch
            {
                // Hourly Contract
                ContractTypeEnum.HourlySalaryEmployee => new HourlyEmployee(employee.Id,
                                                                            employee.Name,
                                                                            employee.HourlySalary,
                                                                            ContractTypeEnum.HourlySalaryEmployee,
                                                                            role),
                // Monthly Contract
                ContractTypeEnum.MonthlySalaryEmployee => new MonthlyEmployee(employee.Id,
                                                                              employee.Name,
                                                                              employee.MonthlySalary,
                                                                              ContractTypeEnum.MonthlySalaryEmployee,
                                                                              role),

                _ => throw new Exception($"Cannot map Employee, '{employee.ContractTypeName}' is not a valid Contract Type"),
            };
        }

        public static IEnumerable<BaseEmployee> MapToDto(this IEnumerable<Employee> employees)
        {
            return employees.Select(e => e.MapToDto());
        }
    }
}
