using MGlobal.Core.Domain.Contracts;

namespace MGlobal.Core.Factory
{
    public class MonthSalaryContract : IContract
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 12;
        }
    }
}
