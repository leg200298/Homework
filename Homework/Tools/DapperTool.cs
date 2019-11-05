using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Homework.Tools
{
    public class DapperTool
    {

        public DapperTool()
        {

        }
        public void Execute(IDbConnection dbConnection,string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var affectedRows = dbConnection.Execute(sql, param, transaction);
        }
    }
}