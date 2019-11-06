using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Homework.Models.DapperModels
{
    public class DapperQueryResult<T> : DapperResultBase
    {
        public DapperQueryResult(ConnectionState state) : base(state)
        {
        }

        /// <summary>
        /// 查詢回傳的資料
        /// </summary>
        public IEnumerable<T> Data { get; set; }
    }
}