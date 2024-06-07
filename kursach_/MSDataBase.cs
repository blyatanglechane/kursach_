using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace kursach_
{
    // Класс для работы с БД
    class MSDatabase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=.; Initial Catalog=ClientUserDatabase; Integrated Security=True");/*WIN-ESTKKU0VUON\SQLEXPRESS*/
        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
