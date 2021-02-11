using MGlobal.Core.Domain.Contracts;
using MGlobal.Core.Domain.Dto;
using MGlobal.Core.Domain.Entities;
using MGlobal.Core.Utils.Constant;

namespace MGlobal.Core.Manager
{
    public class EmployeeDtoManager : IEmployeeDtoManager
    {
        private readonly ISalaryFactory _salaryFactory;
        public EmployeeDtoManager(ISalaryFactory salaryFactory)
        {
            this._salaryFactory = salaryFactory;
        }
        public EmployeeDTO CreateEmployeeDTO(Employee employee)
        {
            EmployeeDTO result = null;

            if (employee != null)
            {
                var responseFactory = _salaryFactory.Create(employee.ContractTypeName);
                switch (employee.ContractTypeName)
                {
                    case ContractTypeConst.HourlySalaryEmployee:
                        result = EmployeeDTO.NewHourlyEmployee(employee.Id, employee.Name, employee.ContractTypeName, employee.RoleName, responseFactory.Calculate(employee.HourlySalary));
                        break;

                    case ContractTypeConst.MonthlySalaryEmployee:
                        result = EmployeeDTO.NewMonthlyEmployee(employee.Id, employee.Name, employee.ContractTypeName, employee.RoleName, responseFactory.Calculate(employee.MonthlySalary));
                        break;
                }
            }

            return result;
        }
    }
}
