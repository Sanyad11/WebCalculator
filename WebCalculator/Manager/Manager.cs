using WebCalculator.WorkWithDB;

namespace WebCalculator.Manager
{
    public class Manager : IManager
    {
        private IDBConnector dbConnector;
        public  Manager()
        {
            bool str;
            dbConnector = new DapperConnector();
            dbConnector.SQLConnect("./WorkWithDB/DB.db", out str);
            dbConnector.CreateTableOperation(out str);
        }
        
        public int Add( int value1, int value2)
        {
            bool exept;
            dbConnector.AddDataToTableOperation(value1, value2, "add", value1 + value2, out exept);
            return (value1 + value2);
        }

        public int Sub( int value1, int value2)
        {
            bool exept;
            dbConnector.AddDataToTableOperation(value1, value2, "sub", value1 - value2, out exept);
            return value1 - value2;
        }

        public int Mul( WorkWithDB.OperationModel stringJson)
        {
            bool exept;            
            dbConnector.AddDataToTableOperation(stringJson.FirstNum, stringJson.FirstNum, "mul", stringJson.FirstNum * stringJson.SecondNum, out exept);
            return stringJson.FirstNum * stringJson.SecondNum;
        }

        public int Div( WorkWithDB.OperationModel stringXml)
        {
            bool exept;
            dbConnector.AddDataToTableOperation(stringXml.FirstNum, stringXml.FirstNum, "div", stringXml.FirstNum * stringXml.SecondNum, out exept);
            return stringXml.FirstNum * stringXml.SecondNum;
        }
    }
}
