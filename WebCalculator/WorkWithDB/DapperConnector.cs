using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;


namespace WebCalculator.WorkWithDB
{

    public class DapperConnector : IDBConnector
    {
        private static SQLiteConnection _dbConnection;

        public void SQLConnect(string baseName, out bool haveExept)
        {
            try
            {
                var dbFilePath = baseName;
                if (!File.Exists(dbFilePath))
                {
                    SQLiteConnection.CreateFile(dbFilePath);
                }
                _dbConnection = new SQLiteConnection(string.Format(
                    "Data Source={0};Version=3;", dbFilePath));
                _dbConnection.Open();
                haveExept = false;
            }
            catch(Exception ex)
            {
                haveExept = true;
                throw ex;                            
            }
        }

        public bool ExecuteQuery(string query, string message, out bool haveExept)
        {
            try
            {
                _dbConnection.Execute(query);

                haveExept = false;
                return true;
            }
            catch (Exception ex)
            {
                haveExept = true;
                return false;
            }
        }

        public bool CreateTableOperation(out bool haveExept)
        {
            return this.ExecuteQuery(@"CREATE TABLE [Operation] (
                    [firstNum] int NOT NULL,
                    [secondNum] int NOT NULL,
                    [operationType] char(100) NOT NULL,
                    [result] int NOT NULL
                    );",
                   "Table Operation was created",
                   out haveExept
                   );
        }

        public bool AddDataToTableOperation(int firstNum, int secondNum, string operationType, int result, out bool haveExept)
        {
            return this.ExecuteQuery(@"INSERT INTO Operation(firstNum, secondNum, operationType, result) 
                        VALUES (" + firstNum + "," + secondNum + ",'" + operationType + "'," + result + "); ",
                       "The data was added",
                       out haveExept
                       );
        }

        public List<OperationModel> ShowTableOperation(out bool exept)
        {
            try
            {
                var operation = _dbConnection.Query<OperationModel>(
                                            "SELECT * FROM Operation"
                                            );
                exept = false;
                return operation.ToList<OperationModel>();
            }
            catch (Exception ex)
            {
                exept = true;
                return new List<OperationModel>();
            }
        }

        public int? ShowOperationByParamethers(int firstNum, int secondNum, string operationType, out bool haveExept)
        {

            try
            {
                var operation = _dbConnection.Query<OperationModel>(
                                            "SELECT * FROM Operation " +
                                            " WHERE firstNum = " + firstNum + " AND secondNum = " + secondNum + " AND operationType = '" + operationType + "' "
                                            );
                haveExept = false;
                return operation.ToList<OperationModel>()[0].Result;
            }
            catch (Exception ex)
            {
                haveExept = true;
                return null;
            }
        }

        public bool DeleteOperation(int firstNum, int secondNum, string operationType, out bool haveExept)
        {
            return this.ExecuteQuery(@"DELETE FROM Operation WHERE firstNum = " + firstNum + " AND secondNum = " + secondNum + " AND operationType = '" + operationType + "'",
                      "The data was deleted",
                      out haveExept
                      );
        }

        public void Dispose()
        {
            _dbConnection.Close();
        }      
    }
}

