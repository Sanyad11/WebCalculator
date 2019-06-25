using WebCalculator.WorkWithDB;

namespace WebCalculator.Manager
{
    public interface IManager
    {
        int Add(int value1, int value2);
        int Div(OperationModel stringXml);
        int Mul(OperationModel stringJson);
        int Sub(int value1, int value2);
    }
}