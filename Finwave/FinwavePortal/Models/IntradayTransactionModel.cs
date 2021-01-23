using System;

namespace FinwavePortal.Models
{
    public class IntradayTransactionModel
    {
        public long RecordId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string DateTransactionStr => this.TransactionDate.ToShortDateString();
        public string MnemonicCode { get; set; }
        public string BenefDetails2 { get; set; }
        public decimal Amount { get; set; }
        public string TradingCode { get; set; }
        public string Status { get; set; }
        public string ClientName { get; set; }
        public string RemitterBank { get; set; }
        public string RemitterName { get; set; }
        public string RemitterAccount { get; set; }
        public string UserReferenceNumber { get; set; }
        public string AlertSequenceNo { get; set; }
        public string DebitorCredit { get; set; }
        public string RemitterIFSC { get; set; }
        public string ChequeNo { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}