using MGlobal.Core.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MGlobal.Core.Domain.Contracts
{
    public interface IEmployeeManager
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployees();
        Task<EmployeeDTO> GetEmployeeById(int id);
    }
}
