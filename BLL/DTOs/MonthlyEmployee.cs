using BLL.Enums;

namespace BLL.DTOs
{
    public class MonthlyEmployee : BaseEmployee
    {
        public MonthlyEmployee(int id, string name, decimal salary, ContractTypeEnum contractType, Role role) : base(id, name, salary, contractType, role)
        {
        }

        public override decimal AnnualSalary => Salary * 12;
    }
}
