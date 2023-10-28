using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace BingoManager.SystemManager.Engine
{
  public  class ConnectionProvider:IDisposable
    {
    private const string dbPassword = "**********";
      public ConnectionProvider() { }
   // static   OleDbConnection _connection;

      public static OleDbConnection Connection()
      {
       //   if (_connection == null)
       //   {

              OleDbConnection _connection = new OleDbConnection();
           
        //  }
          ConnectionProvider _connProvider = new ConnectionProvider();
          _connection.ConnectionString = _connProvider.GetConnectionString();
          return _connection;

      }

       String GetConnectionString()
      {
          OleDbConnectionStringBuilder _connStringBuilder = new OleDbConnectionStringBuilder();
            _connStringBuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
             _connStringBuilder["Data Source"] = @"|DataDirectory|\bingo.accdb";
             _connStringBuilder["Persist Security Info"] = "True";
            _connStringBuilder.Add("Jet OLEDB:Database Password",dbPassword);
       // _connStringBuilder.Add("Asynchronous Processing", "True");
        //    _connStringBuilder.Add("providerName", "System.Data.OleDb");
          return _connStringBuilder.ConnectionString;
      }

       public void Dispose()
       {
         //  if (_connection.State == System.Data.ConnectionState.Open)
         //  {
         //      _connection.Close();
        //   }
           
       }
    }
}
