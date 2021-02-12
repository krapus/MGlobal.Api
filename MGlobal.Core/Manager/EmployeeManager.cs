using MGlobal.Core.Domain.Contracts;
using MGlobal.Core.Domain.Dto;
using MGlobal.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGlobal.Core.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeClientService _employeeClientService;
        private readonly IEmployeeDtoManager _employeeDtoManager;

        public EmployeeManager(IEmployeeClientService employeeClientService, IEmployeeDtoManager employeeDtoManager)
        {
            _employeeClientService = employeeClientService;
            _employeeDtoManager = employeeDtoManager;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            ICollection<Employee> employees = await _employeeClientService.GetEmployees();

            return employees.Select(employee => _employeeDtoManager.CreateEmployeeDTO(employee));
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {            
            return _employeeDtoManager.CreateEmployeeDTO(await _employeeClientService.GetEmployee(id));            
        }
    }
}
