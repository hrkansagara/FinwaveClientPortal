using FinwaveClientFrontOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinwaveClientFrontOffice.Services
{
    public interface IPortfolioService
    {
        HttpResponseMessage GetHoldingDetails(CommonSearch oCommonSearch);
        HttpResponseMessage GetClientLedgerDetails(CommonSearch oCommonSearch);
        HttpResponseMessage GetClientPositionDetails(CommonSearch oCommonSearch);
    }
}
