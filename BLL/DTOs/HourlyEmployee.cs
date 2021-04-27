using BLL.Enums;

namespace BLL.DTOs
{
    public class HourlyEmployee : BaseEmployee
    {
        public HourlyEmployee(int id, string name, decimal salary, ContractTypeEnum contractType, Role role) : base(id, name, salary, contractType, role)
        {
        }

        public override decimal AnnualSalary => 120 * Salary * 12;
    }
}
