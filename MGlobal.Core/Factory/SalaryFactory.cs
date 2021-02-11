using MGlobal.Core.Domain.Contracts;
using MGlobal.Core.Utils.Constant;
using System;

namespace MGlobal.Core.Factory
{
    public class SalaryFactory : ISalaryFactory
    {
        public IContract Create(string contractType)
        {

            switch (contractType)
            {
                case ContractTypeConst.HourlySalaryEmployee:
                    return new HourSalaryContract();
                case ContractTypeConst.MonthlySalaryEmployee:
                    return new MonthSalaryContract();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
