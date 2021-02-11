using MGlobal.Core.Domain.Contracts;
using MGlobal.Core.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MGlobal.Core.Data.Services
{
    public class EmployeeClientService : IEmployeeClientService
    {
        private readonly IHttpService httpService;

        public EmployeeClientService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            ICollection<Employee> employees = await GetEmployees();
            return employees.FirstOrDefault(employee => employee.Id.Equals(id));
        }

        public async Task<ICollection<Employee>> GetEmployees()
        {
            HttpResponseMessage result = await httpService.ExecuteRequest(httpService.CreateHttpRequestMessage("https://masglobaltestapi.azurewebsites.net/api/Employees", HttpMethod.Get, null));
            string data = await result.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(data) ? default(List<Employee>) : JsonConvert.DeserializeObject<List<Employee>>(data);
        }
    }
}
