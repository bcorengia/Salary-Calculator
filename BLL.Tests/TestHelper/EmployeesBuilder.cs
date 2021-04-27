using DAL.Entities;
using Faker;
using FizzWare.NBuilder;
using System.Collections.Generic;

namespace BLL.Tests.TestHelper
{
    public static class EmployeesBuilder
    {
        public static IEnumerable<Employee> GenerateEmployees(int amount)
        {
            return Builder<Employee>.CreateListOfSize(amount)
            .All()
            .With(e => e.Id = RandomNumber.Next(max: 10000))
            .With(e => e.Name = Name.First())
            .With(e => e.RoleId = RandomNumber.Next(max: 10))
            .With(e => e.RoleName = Lorem.GetFirstWord())
            .With(e => e.RoleDescription = Name.First())
            .With(e => e.HourlySalary = Finance.Coupon())
            .With(e => e.MonthlySalary = Finance.Coupon())
            .With(e => e.ContractTypeName = GetContractTypeName(RandomNumber.Next(max: 2)))
            .Build();
        }

        private static string GetContractTypeName(int contractTypeId)
        {
            return contractTypeId switch
            {
                1 => "HourlySalaryEmployee",
                2 => "MonthlySalaryEmployee",
                _ => ""
            };
        }
    }
}
