using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinwaveClientFrontOffice.Models
{
    public class CommonSearch
    {
        public string ClientCode { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CompanyCode { get; set; }
        public string CocdList { get; set; }
        public string ShowMargin { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string SortExp { get; set; }
    }
}