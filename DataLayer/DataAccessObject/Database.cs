using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer.DataAccessObject
{
    public class Database
    {
        private SqlConnection Connection { get; }
        private SqlTransaction SqlTransaction { get; set; }
        public StringBuilder MessageString { get; }
        public string Language { get; set; }

        public Database()
        {
            Connection = new SqlConnection();
            MessageString = new StringBuilder();
            Connection.InfoMessage += myConnection_InfoMessage;
            Language = "en";
        }

        public void myConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            MessageString.Clear();
            MessageString.AppendLine(e.Message);
        }

        public bool Connect()
        {
            bool ret = true;
            if (Connection.State != ConnectionState.Open)
            {
                ret = Connect(@"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=pau0031;Persist Security Info=True;User ID=pau0031;Password=YQBcUovHkT");
            }
            return ret;
        }

        public bool Connect(string conString)
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.ConnectionString = conString;
                Connection.Open();
            }
            return true;
        }

        public void Close()
        {
            Connection.Close();
        }

        public void BeginTransaction()
        {
            SqlTransaction = Connection.BeginTransaction(IsolationLevel.Serializable);
        }

        public void EndTransaction()
        {
            SqlTransaction.Commit();
            Close();
        }

        public void Rollback()
        {
            SqlTransaction.Rollback();
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            var rownumber = command.ExecuteNonQuery();
            return rownumber;
        }

        public SqlCommand CreateCommand(string strCommand)
        {
            SqlCommand command = new SqlCommand(strCommand, Connection);
            if (SqlTransaction != null)
            {
                command.Transaction = SqlTransaction;
            }
            return command;
        }

        public SqlDataReader Select(SqlCommand command)
        {
            SqlDataReader sqlReader = command.ExecuteReader();
            return sqlReader;
        }

        public int GetIdentity(string tableName)
        {
            SqlCommand command = CreateCommand("SELECT IDENT_CURRENT(@tableName)");
            command.Parameters.AddWithValue("@tableName", tableName);
            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
