using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spootify.Context
{
    class Database
    {
        public static SqlConnection Connection
        {
            get
            {
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                return connection;
            }
        }

        private static string connectionstring =
            @"Data Source=PC-YANNICK\MSSQLSERVERCORRE;Initial Catalog=Spootifie;Integrated Security=True";
    }
}
