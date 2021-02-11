using MGlobal.Core.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MGlobal.Core.Domain.Contracts
{
    public interface IEmployeeClientService
    {
        Task<Employee> GetEmployee(int id);
        Task<ICollection<Employee>> GetEmployees();
    }
}
