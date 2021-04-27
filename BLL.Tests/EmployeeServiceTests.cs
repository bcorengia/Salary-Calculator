using BLL.DTOs;
using BLL.Enums;
using BLL.Services.Interfaces;
using BLL.Tests.TestHelper;
using DAL.Interfaces;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
        private readonly IEmployeeService _employeeService;


        public EmployeeServiceTests()
           : base()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeService(_employeeRepositoryMock.Object);
        }

        [Theory]
        [InlineData(50)]
        public void GetEmployees_ShouldCalculateCorrectly(int employeeCount)
        {
            //Arrange
            _employeeRepositoryMock.Setup(e => e.GetEmployees(It.IsAny<string>())).Returns(Task.FromResult(EmployeesBuilder.GenerateEmployees(employeeCount)));

            //Act
            var paginatedEmployees = _employeeService.GetEmployees(1, employeeCount, "").Result;

            //Assert
            Assert.All(paginatedEmployees.Employees, e => Assert.Equal(e.AnnualSalary, CalculateAnnualSalary(e)));
        }

        [Theory]
        [InlineData(1, 50, 100)]
        [InlineData(7, 1, 100)]
        [InlineData(5, 10, 100)]
        public void GetEmployees_ShouldPaginateCorrectly(int page, int pageSize, int employeeCount)
        {
            //Arrange
            _employeeRepositoryMock.Setup(e => e.GetEmployees(It.IsAny<string>())).Returns(Task.FromResult(EmployeesBuilder.GenerateEmployees(employeeCount)));

            //Act
            var paginatedEmployees = _employeeService.GetEmployees(page, pageSize, "").Result;

            //Assert
            Assert.Equal(page, paginatedEmployees.Page);
            Assert.Equal(employeeCount, paginatedEmployees.TotalCount);
            Assert.Equal(pageSize, paginatedEmployees.Employees.Count());

        }

        private decimal CalculateAnnualSalary(BaseEmployee employee)
        {
            return employee.ContractType switch
            {
                ContractTypeEnum.HourlySalaryEmployee => 120 * employee.Salary * 12,
                ContractTypeEnum.MonthlySalaryEmployee => employee.Salary * 12,
                _ => 0
            };
        }
    }
}
