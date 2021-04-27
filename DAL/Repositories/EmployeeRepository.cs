using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly IConfiguration _config;

        public EmployeeRepository(IConfiguration configuration)
        {
            _config = configuration;
        }
        public async Task<IEnumerable<Employee>> GetEmployees(string employeeFilter)
        {
            var apiUrl = _config["MasGlobalApiUrl"];

            var response = await client.GetAsync(apiUrl);

            int.TryParse(employeeFilter, out int possibleId);

            string apiResponse = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);

            var filteredEmployees = (employeeFilter == null) ? employees 
                : employees.Where(e => e.Id == possibleId || e.Name.Contains(employeeFilter, StringComparison.CurrentCultureIgnoreCase));

            return filteredEmployees;
        }
    }
}
