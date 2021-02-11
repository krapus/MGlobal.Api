namespace MGlobal.Core.Domain.Contracts
{
    public interface ISalaryFactory
    {
        IContract Create(string contractType);
    }
}
