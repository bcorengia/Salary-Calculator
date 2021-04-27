using Newtonsoft.Json;

namespace DAL.Entities
{
    public class Employee
    {
        public Employee()
        {
        }

        public Employee(int id, string name, string contractTypeName, int roleId, string roleName, string roleDescription, decimal hourlySalary, decimal monthlySalary)
        {
            Id = id;
            Name = name;
            ContractTypeName = contractTypeName;
            RoleId = roleId;
            RoleName = roleName;
            RoleDescription = roleDescription;
            HourlySalary = hourlySalary;
            MonthlySalary = monthlySalary;
        }

        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string ContractTypeName { get; set; }
        [JsonProperty]
        public int RoleId { get; set; }
        [JsonProperty]
        public string RoleName { get; set; }
        [JsonProperty]
        public string RoleDescription { get; set; }
        [JsonProperty]
        public decimal HourlySalary { get; set; }
        [JsonProperty]
        public decimal MonthlySalary { get; set; }
    }
}
