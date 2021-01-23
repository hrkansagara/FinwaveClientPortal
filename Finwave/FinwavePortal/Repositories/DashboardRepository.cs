using Dapper;
using FinwavePortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FinwavePortal.Repositories
{
    /// <summary>
    /// DashboardRepository
    /// </summary>
    public class DashboardRepository : BaseRepository, IDashboardRepository
    {
        /// <summary>
        /// GetAllIntradayTransactions
        /// </summary>
        /// <param name="SearchParam"></param>
        /// <returns></returns>
        public List<IntradayTransactionModel> GetAllIntradayTransactions(SearchParamModel SearchParam)
        {
            try
            {
                using (IDbConnection connection = OpenConnection())
                {
                    var o = new DynamicParameters();
                    o.Add("@TradingCode", SearchParam.TradingCode, dbType: DbType.String);
                    o.Add("@ClientName", SearchParam.ClientName, dbType: DbType.String);
                    o.Add("@AccountNo", SearchParam.AccountNo, dbType: DbType.String);
                    o.Add("@FromDate", SearchParam.FromDate, dbType: DbType.String);
                    o.Add("@ToDate", SearchParam.ToDate, dbType: DbType.String);
                    o.Add("@PageSize", SearchParam.PageSize, dbType: DbType.Int32);
                    o.Add("@PageNo", SearchParam.PageIndex, dbType: DbType.Int32);
                    o.Add("@SortExpr", SearchParam.SortExp, dbType: DbType.String);
                    return connection.Query<IntradayTransactionModel>("usp_GetAllIntradayTransactions", o, commandType: CommandType.StoredProcedure, commandTimeout: 900).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<IntradayTransactionModel>();
            }
        }
    }
}