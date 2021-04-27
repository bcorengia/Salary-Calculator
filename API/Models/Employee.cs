using BLL.DTOs;

namespace Api.Models
{
    public class Employee
    {
        public Employee(int id, string name, decimal salary, string contractType, Role role, decimal annualSalary)
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
        public Role Role { get; }
        public decimal AnnualSalary { get; }
    }
}
