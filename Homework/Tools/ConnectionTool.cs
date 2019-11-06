using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Homework.Tool
{
    public class ConnectionTool
    {
        public static IDbConnection CreateConnection()
        {
            string connectionString;
#if DEBUG
            connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
#endif
            return new SqlConnection(connectionString);

        }
    }
}