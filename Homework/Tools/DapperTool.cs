using Dapper;
using Homework.Models.DapperModels;
using Homework.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Homework.Tools
{
    public class DapperTool : IDisposable
    {
        private IDbConnection _dbConnection;

        public DapperTool()
        {

        }
        /// <summary>
        /// 連線設定與開啟
        /// </summary>
        /// <returns></returns>
        public async Task OpenConnection()
        {
            if (_dbConnection == null)
            {
                _dbConnection = ConnectionTool.CreateConnection();
            }
            await (_dbConnection as SqlConnection).OpenAsync();
        }

        /// <summary>
        /// 執行SQL語句(Insert、Update、Delete)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<DapperExecuteResult> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DapperExecuteResult result = new DapperExecuteResult(_dbConnection.State);

            if (_dbConnection.State == ConnectionState.Closed)
            {
                result.ErrorMessage = "Connection is closed.";
            }
            else
            {
                try
                {
                    result.AffectedRows = await _dbConnection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
                    result.Success = true;
                }
                catch (Exception error)
                {
                    result.ErrorMessage = error.Message;
                }

            }
            return result;
        }

        /// <summary>
        /// 執行SQL語句(Select)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<DapperQueryResult<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DapperQueryResult<T> result = new DapperQueryResult<T>(_dbConnection.State);
            if (_dbConnection.State == ConnectionState.Closed)
            {
                result.ErrorMessage = "Connection is closed.";
            }
            else
            {
                try
                {
                    result.Data = await _dbConnection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
                    result.Success = true;
                }
                catch (Exception error)
                {
                    result.ErrorMessage = error.Message;
                }
            }
            return result;
        }

        /// <summary>
        /// 執行SQL語句(Select)，回傳第一筆資料或預設值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<DapperQueryFirstResult<T>> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DapperQueryFirstResult<T> result = new DapperQueryFirstResult<T>(_dbConnection.State);

            if (_dbConnection.State == ConnectionState.Closed)
            {
                result.ErrorMessage = "Connection is closed.";
            }
            else
            {
                try
                {
                    result.Data = await _dbConnection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
                    result.Success = true;
                }
                catch (Exception error)
                {
                    result.ErrorMessage = error.Message;
                }
            }

            return result;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbConnection.Close();
                    _dbConnection.Dispose();
                    // TODO: 處置受控狀態 (受控物件)。
                }

                // TODO: 釋放非受控資源 (非受控物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。

                disposedValue = true;
            }
        }

        //TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放非受控資源的程式碼時，才覆寫完成項。
        ~DapperTool()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(false);
        }

        // 加入這個程式碼的目的在正確實作可處置的模式。
        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}