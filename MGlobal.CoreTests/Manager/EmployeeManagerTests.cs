using MGlobal.Core.Domain.Contracts;
using MGlobal.Core.Domain.Entities;
using MGlobal.Core.Factory;
using MGlobal.Core.Manager;
using MGlobal.Core.Utils.Constant;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MGlobal.Core.Tests.Manager
{
    [TestClass()]
    public class EmployeeManagerTests
    {
        private IEmployeeClientService _employeeClientService;
        private IEmployeeDtoManager _employeeDtoManager;
        private IEmployeeManager _employeeManager;
        private ISalaryFactory _salaryFactory;


        [TestInitialize()]
        public void Init()
        {
            //Arrange
            _salaryFactory = new SalaryFactory();
            _employeeClientService = Substitute.For<IEmployeeClientService>();
            _employeeDtoManager = new EmployeeDtoManager(_salaryFactory);
            _employeeManager = new EmployeeManager(_employeeClientService, _employeeDtoManager);
        }


        [TestMethod()]
        public async Task GetEmployeesTestAsync()
        {
            int id = 1;
            // Mock Data
            _employeeClientService.GetEmployees().ReturnsForAnyArgs(new List<Employee>()
            {
                new Employee()
                {   ContractTypeName = ContractTypeConst.HourlySalaryEmployee,
                    Id = 1,
                    HourlySalary = 1000,
                    MonthlySalary = 2000,
                    Name= "Dario" ,
                    RoleDescription = "",
                    RoleId = 1,
                    RoleName =  "Administrator"
                },
                new Employee()
                {
                    ContractTypeName = ContractTypeConst.MonthlySalaryEmployee,
                    Id = 2,
                    HourlySalary = 1000,
                    MonthlySalary = 2000,
                    Name= "Andrea" ,
                    RoleDescription = "",
                    RoleId = 2,
                    RoleName =  "Contractor"
                }
            });

            // Act
            var result = await _employeeManager.GetEmployees();

            // Asserts
            Assert.IsTrue(result.Any());
            Assert.AreEqual(id, result.FirstOrDefault().Id);


        }

        [TestMethod()]
        public async Task GetEmployeeByIdTestAsync()
        {
            int id = 1;
            int expected = 1;
            
            // Mock Data
            _employeeClientService.GetEmployee(id)
                .Returns(new Employee()
                {
                    ContractTypeName = ContractTypeConst.HourlySalaryEmployee,
                    Id = 1,
                    HourlySalary = 1000,
                    MonthlySalary = 2000,
                    Name = "Dario",
                    RoleDescription = "",
                    RoleId = 1,
                    RoleName = "Administrator"
                });

            // Act
            var result = await _employeeManager.GetEmployeeById(1);

            // Asserts
            Assert.AreEqual(expected, result.Id);
            Assert.IsNotNull(result);
        }
    }
}