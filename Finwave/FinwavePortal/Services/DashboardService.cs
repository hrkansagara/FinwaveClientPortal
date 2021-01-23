using FinwavePortal.Models;
using FinwavePortal.Repositories;
using System.Collections.Generic;

namespace FinwavePortal.Services
{
    /// <summary>
    /// Dashboard Service
    /// </summary>
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        /// <summary>
        /// DashboardService
        /// </summary>
        /// <param name="dashboardRepository"></param>
        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        /// <summary>
        /// GetTransactionList
        /// </summary>
        /// <param name="oSearchParamModel"></param>
        /// <returns></returns>
        public List<IntradayTransactionModel> GetTransactionList(SearchParamModel oSearchParamModel)
        {
            return _dashboardRepository.GetAllIntradayTransactions(oSearchParamModel);
        }
    }
}