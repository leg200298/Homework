using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Homework.Tool
{
    public class ConnectionFactory
    {
        public IDbConnection CreateConnection()
        {
#if DEBUG
           var ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
#endif
            return new SqlConnection(ConnectionString);

        }
    }
}