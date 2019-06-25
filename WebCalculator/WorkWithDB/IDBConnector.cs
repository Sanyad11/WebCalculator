using System;
using System.Collections.Generic;

namespace WebCalculator.WorkWithDB
{
    public interface IDBConnector : IDisposable
    {
        void SQLConnect(string baseName, out bool haveExept);
        bool ExecuteQuery(string query, string message, out bool haveExept);
        bool CreateTableOperation(out bool haveExept);
        bool AddDataToTableOperation(int firstNum, int secondNum, string operationType, int result, out bool haveExept);
        List<OperationModel> ShowTableOperation(out bool haveExept);
        int? ShowOperationByParamethers(int firstNum, int secondNum, string operationType, out bool haveExept);
        bool DeleteOperation(int firstNum, int secondNum, string operationType, out bool haveExept);
    }
}
