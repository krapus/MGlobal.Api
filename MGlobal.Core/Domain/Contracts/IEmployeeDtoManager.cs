using MGlobal.Core.Domain.Dto;
using MGlobal.Core.Domain.Entities;

namespace MGlobal.Core.Domain.Contracts
{
    public interface IEmployeeDtoManager
    {
        EmployeeDTO CreateEmployeeDTO(Employee employee);
    }
}
