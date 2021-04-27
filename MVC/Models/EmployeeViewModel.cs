using BLL.DTOs;
using System.Text.RegularExpressions;

namespace Mvc.Models
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel(int id, string name, decimal salary, string contractType, Role role, decimal annualSalary)
        {
            Id = id;
            Name = name;
            Salary = salary;
            ContractType = contractType;
            Role = role;
            AnnualSalary = annualSalary;
        }

        public int Id { get; }
        public string Name { get; }
        public decimal Salary { get; }
        public string ContractType { get; }
        public string ContractTypeFormatted => Regex.Split(ContractType, @"(?<!^)(?=[A-Z])")[0];
        public Role Role { get; }
        public decimal AnnualSalary { get; }
    }
}

