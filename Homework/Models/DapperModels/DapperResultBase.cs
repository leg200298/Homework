using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Homework.Models.DapperModels
{
    /// <summary>
    /// SQL執行結果的基底類別
    /// </summary>
    public class DapperResultBase
    {
        public DapperResultBase() { }

        public DapperResultBase(ConnectionState state)
        {
            DBState = state.ToString();
        }

        /// <summary>
        /// 資料庫連線狀態
        /// </summary>
        public string DBState { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; } = false;

        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string ErrorMessage { get; set; }

    }
}