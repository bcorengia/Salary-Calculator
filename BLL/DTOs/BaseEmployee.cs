using BLL.Enums;

namespace BLL.DTOs
{
    public abstract class BaseEmployee
    {
        public BaseEmployee(int id, string name, decimal salary, ContractTypeEnum contractType, Role role)
        {
            Id = id; ;
            Name = name;
            Salary = salary;
            ContractType = contractType;
            Role = role;
        }

        public int Id { get; }
        public string Name { get; }
        public decimal Salary { get; }
        public ContractTypeEnum ContractType { get; }
        public Role Role { get; }
        public abstract decimal AnnualSalary { get; }
    }
}
