using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Homework.Models.DapperModels
{
    public class DapperExecuteResult : DapperResultBase
    {
        public DapperExecuteResult(ConnectionState state) : base(state)
        {
        }

        /// <summary>
        /// 影響資料數
        /// </summary>
        public int AffectedRows { get; set; }
    }
}