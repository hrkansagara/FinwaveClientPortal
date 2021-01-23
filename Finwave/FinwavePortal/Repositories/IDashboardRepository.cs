using FinwavePortal.Models;
using System.Collections.Generic;

namespace FinwavePortal.Repositories
{
    public interface IDashboardRepository
    {
        List<IntradayTransactionModel> GetAllIntradayTransactions(SearchParamModel SearchParam);
    }
}