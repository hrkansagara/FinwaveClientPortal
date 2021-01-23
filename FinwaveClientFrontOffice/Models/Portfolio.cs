using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinwaveClientFrontOffice.Models
{
    public class HoldingDetails
    {
        public string CLIENTCODE { get; set; }
        public string ISIN { get; set; }
        public string BRBENQTY { get; set; }
        public string COLQTY { get; set; }
        public string FreeQTY { get; set; }
        public string SOHQTY { get; set; }
        public string PLedgeQTY { get; set; }
        public string LockinQty { get; set; }
        public string NET { get; set; }
        public string NET1 { get; set; }
        public string AMOUNT { get; set; }
        public string AMOUNT1 { get; set; }
        public string PLEDGE_QTY { get; set; }
        public string INSHORT { get; set; }
        public string OUTSHORT { get; set; }
        public string TOT_AMT { get; set; }
        public string PERCENT_HOLD { get; set; }
        public string BRANCHCODE { get; set; }
        public string FAMILYCODE { get; set; }
        public string CLIENTNAME { get; set; }
        public string BRANCHNAME { get; set; }
        public string FAMILYNAME { get; set; }
        public string BRANCHCODE_MAIL { get; set; }
        public string CLIENTCODE_MAIL { get; set; }
        public string LEDGERBAL { get; set; }
        public string HOLDDATETIME { get; set; }
        public string DP_ID { get; set; }
        public string BO_ID { get; set; }
        public string DEF_ACC { get; set; }
        public string POA { get; set; }
        public string PRICEDATE { get; set; }
        public string MOBILE_NO { get; set; }
        public string SCRIP_NAME { get; set; }
        public string SCRIPTYPE { get; set; }
        public string SCRIP_CODE { get; set; }
        public string SCRIP_VALUE { get; set; }
        public string SCRIP_SYMBOL { get; set; }
        public string HOLDINGDATETIME111 { get; set; }
        public string BENQTY { get; set; }
    }

    public class ClientLegerDetails
    {
        public string COCD { get; set; }
        public string CONAME { get; set; }
        public string KINDOFACCOUNT { get; set; }
        public string ACCOUNTCODE { get; set; }
        public string ACCOUNTNAME { get; set; }
        public string TELNO { get; set; }
        public string FAX { get; set; }
        public string ADDR { get; set; }
        public string OPENINGBALANCE { get; set; }
        public string DR_AMT { get; set; }
        public string CR_AMT { get; set; }
        public string VOUCHERDATE { get; set; }
        public string SETTLEMENT_NO { get; set; }
        public string CTRCODE { get; set; }
        public string CTRNAME { get; set; }
        public string TRANS_TYPE { get; set; }
        public string VOUCHERNO { get; set; }
        public string NARRATION { get; set; }
        public string BILLNO { get; set; }
        public string CHQNO { get; set; }
        public string EXPECTED_DATE { get; set; }
        public string TRADING_COCD { get; set; }
        public string PANNO { get; set; }
        public string EMAIL { get; set; }
        public string MANUALVNO { get; set; }
        public string BOOKTYPECODE { get; set; }
        public DateTime? BILL_DATE { get; set; }
        public string strBillDate => BILL_DATE .HasValue ? this.BILL_DATE.Value.ToShortDateString() 
            : string.Empty;
        public string MKT_TYPE { get; set; }
        public string GROUPCODE { get; set; }
        public string BRSFLAG { get; set; }
        public string SETL_PAYINDATE { get; set; }
        public string LAST2SETL { get; set; }
        public string GATEWAYID { get; set; }
        public string PUNCH_TIME { get; set; }
        public string voctype { get; set; }
        public string CHQIMAGEPATH { get; set; }
        public string TRANS_TYPE1 { get; set; }

        private decimal bal;

        public decimal Balance
        {
            get 
            {
                return string.IsNullOrEmpty(OPENINGBALANCE) ? 0 : Convert.ToDecimal(OPENINGBALANCE) + (string.IsNullOrEmpty(CR_AMT) ? 0 : Convert.ToDecimal(CR_AMT)) - (string.IsNullOrEmpty(DR_AMT) ? 0 : Convert.ToDecimal(DR_AMT)); 
            }
            set { bal = value; }
        }

    }

    public class MultipleDateOfPosition
    {
        public string CLIENT_ID { get; set; }
        public string SCRIP_SYMBOL { get; set; }
        public string FULL_SCRIP_SYMBOL { get; set; }
        public string SCRIP_NAME { get; set; }
        public string EXPIRY_DATE { get; set; }
        public string OPQTY { get; set; }
        public string OPRATE { get; set; }
        public string OPAMT { get; set; }
        public string BUYQTY { get; set; }
        public string BUYRATE { get; set; }
        public string BUYAMT { get; set; }
        public string SALEQTY { get; set; }
        public string SALERATE { get; set; }
        public string SALEAMT { get; set; }
        public string NETQTY { get; set; }
        public string SHORTQTY { get; set; }
        public string LONGQTY { get; set; }
        public string NETRATE { get; set; }
        public string NETAMT { get; set; }
        public string NET_PLAMT { get; set; }
        public string FIFORATE { get; set; }
        public string PL_AMT { get; set; }
        public string CL_PRICE { get; set; }
        public string CL_AMT { get; set; }
        public string NOTIONAL { get; set; }
        public string NOTIONAL1 { get; set; }
        public string NOTIONAL_NET { get; set; }
        public string NOTIONAL_NET1 { get; set; }
        public string GROSSEXP { get; set; }
        public string BRANCH_CODE { get; set; }
        public string BRANCH_NAME { get; set; }
        public string BRANCH_CODE_MAIL { get; set; }
        public string CLIENT_NAME { get; set; }
        public string CLIENT_ID_MAIL { get; set; }
        public string SR { get; set; }
        public string FAMILY_GROUP { get; set; }
        public string FAMILY_GROUP_MAIL { get; set; }
        public string FROM_DATE { get; set; }
        public string TO_DATE { get; set; }
        public string FACTOR { get; set; }
        public string MAIN_BRANCH_CODE { get; set; }
        public string MAIN_BRANCH_NAME { get; set; }
        public string MAIN_BRANCH_CODE_MAIL { get; set; }
        public string INSTRUMENT_TYPE { get; set; }
        public string CL_PRICE_ACT { get; set; }
    }
}