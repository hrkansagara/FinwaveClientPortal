using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinwavePortal.Models
{
    public class SearchParamModel
    {
        public string TradingCode { get; set; }
        public string ClientName { get; set; }
        public string AccountNo { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string SortExp { get; set; }
            
    }
}