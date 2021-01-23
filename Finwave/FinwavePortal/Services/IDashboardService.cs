using FinwavePortal.Models;
using System.Collections.Generic;

namespace FinwavePortal.Services
{
    /// <summary>
    /// IDashboardService
    /// </summary>
    public interface IDashboardService
    {
        /// <summary>
        /// GetTransactionList</summary>
        /// <param name="paramModel"></param>
        /// <returns></returns>
        List<IntradayTransactionModel> GetTransactionList(SearchParamModel paramModel);
    }
}