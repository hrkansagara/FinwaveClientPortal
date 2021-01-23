using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinwaveClientFrontOffice.Services
{
    public interface IAccountService
    {
        HttpResponseMessage GetClientDetailByClientCode(string ClientCode);
        HttpResponseMessage GetClientBankDetailByClientCode(string AccountNumber);
        HttpResponseMessage GetClientBankDetailMultipleAccounts(string ClientCode);
    }
}
