using MGlobal.Core.Domain.Contracts;

namespace MGlobal.Core.Factory
{
    public class HourSalaryContract : IContract
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 120 * 12;
        }
    }
}
