namespace MGlobal.Core.Domain.Dto
{
    public class EmployeeDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ContractType { get; private set; }
        public string RoleName { get; private set; }
        public decimal AnnualSalary { get; private set; }

        public EmployeeDTO(int id, string name, string contractType, string roleName, decimal annualSalary)
        {
            Id = id;
            Name = name;
            ContractType = contractType;
            RoleName = roleName;
            AnnualSalary = annualSalary;
        }

        public static EmployeeDTO NewHourlyEmployee(int id, string name, string contractType, string roleName, decimal annualSalary)
        {
            return new EmployeeDTO(id, name, contractType, roleName, annualSalary);
        }

        public static EmployeeDTO NewMonthlyEmployee(int id, string name, string contractType, string roleName, decimal annualSalary)
        {
            return new EmployeeDTO(id, name, contractType, roleName, annualSalary);
        }
    }
}
