using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Homework.Models.DapperModels
{
    public class DapperQueryFirstResult<T> : DapperResultBase
    {
        public DapperQueryFirstResult(ConnectionState state):base(state)
        {

        }

        /// <summary>
        /// 查詢回傳的資料
        /// </summary>
        public T Data { get; set; }
    }
}