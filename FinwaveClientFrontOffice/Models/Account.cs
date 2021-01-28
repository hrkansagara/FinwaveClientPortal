using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinwaveClientFrontOffice.Models
{

    public class ApiResponse
    {
        public IEnumerable<string> COLUMNS { get; set; }
        public IEnumerable<List<object>> DATA { get; set; }
    }

    public class Account
    {
        public string COMPANY_CODE { get; set; }
        public string CLIENT_ID { get; set; }
        public string CLIENT_NAME { get; set; }
        public string CL_RESI_ADD1 { get; set; }
        public string CL_RESI_ADD2 { get; set; }
        public string CL_RESI_ADD3 { get; set; }
        public string MOBILE_NO { get; set; }
        public string PAN_NO { get; set; }
        public string MICR_CODE { get; set; }
        public string BANK_ACNO { get; set; }
        public string CLIENT_BANK_NAME { get; set; }
        public string CLIENT_DP_CODE { get; set; }
        public string DP_ID { get; set; }
        public string DP_NAME { get; set; }
        public string REMESHIRE_GROUP { get; set; }
        public string REMESHIRE_NAME { get; set; }
        public string CLIENT_ID_MAIL { get; set; }
        public string SEX { get; set; }
        public string BIRTH_DATE { get; set; }
        public string NOMINEE_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string PIN_CODE { get; set; }
        public string DEPOSITORY { get; set; }
        public BankAccountDetails objBankAccountDetails { get; set; }
        public List<BankAccountDetails> lstBankAccountDetails { get; set; }
    }

    public class AccountModel
    {
        public string COMPANY_CODE { get; set; }
        public string CLIENT_ID { get; set; }
        public string CLIENT_NAME { get; set; }
        public string CL_RESI_ADD1 { get; set; }
        public string CL_RESI_ADD2 { get; set; }
        public string CL_RESI_ADD3 { get; set; }
        public string MOBILE_NO { get; set; }
        public string PAN_NO { get; set; }
        public string MICR_CODE { get; set; }
        public string BANK_ACNO { get; set; }
        public string CLIENT_BANK_NAME { get; set; }
        public string CLIENT_DP_CODE { get; set; }
        public string DP_ID { get; set; }
        public string DP_NAME { get; set; }
        public string REMESHIRE_GROUP { get; set; }
        public string REMESHIRE_NAME { get; set; }
        public string CLIENT_ID_MAIL { get; set; }
        public string SEX { get; set; }
        public string BIRTH_DATE { get; set; }
        public string NOMINEE_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string PIN_CODE { get; set; }
        public string DEPOSITORY { get; set; }
        public string BANK_NAME { get; set; }
        public string MobileOtp { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserFullName { get; set; }
        public string UserTypeId { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
        public string IsChangePassword { get; set; }
        public bool IsActive { get; set; }
        public int EmployeeId { get; set; }
        public int BranchId { get; set; }
        public DateTime? DateAdded { get; set; }
        public string AddedBy { get; set; }
        public string ConformPassward { get; set; }
    }

    public class BankAccountDetails
    {
        public string ACCOUNT_CODE { get; set; }
        public string BANK_FAX_NO { get; set; }
        public string EFT_FLAG { get; set; }
        public string PROOF_REC { get; set; }
        public string IFSC_CODE { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string COUNTRY { get; set; }
        public string CHQPRINTNAME { get; set; }
        public string NACHFLAG { get; set; }

        public string NACHUMRNO { get; set; }
        public string CLIENT_NAME { get; set; }
        public string BANK_ACNO { get; set; }
        public string BANKACTIVE { get; set; }
        public string FT_ATOM_CODE { get; set; }
        public string BANKMODIFYDATE { get; set; }
        public string BANK_NAME { get; set; }
        public string BANK_ADDRESS { get; set; }
        public string DEFAULT_AC { get; set; }
        public string MICR_CODE { get; set; }

        public string MOBILE_NO { get; set; }
        public string IFSC_CODE_ACT { get; set; }
        public string BANK_ACCTYPE { get; set; }
        public string ACC_OPEN_DATE { get; set; }
        public string BANK_TEL_NO { get; set; }
    }

    public class ClientBankDetailMultipleAccounts
    {
        public string Account_Code { get; set; }
        public string Bank_AcNo { get; set; }
        public string CLIENT_NAME { get; set; }
        public string Bank_Name { get; set; }
        public string Bank_Address { get; set; }
        public string Default_Ac { get; set; }
        public string Micr_Code { get; set; }
        public string MOBILE_NO { get; set; }
        public string IFSC_CODE_ACT { get; set; }
        public string BANK_ACCTYPE { get; set; }
        public string ACC_OPEN_DATE { get; set; }
        public string BANK_TEL_NO { get; set; }
        public string BANK_FAX_NO { get; set; }
        public string EFT_FLAG { get; set; }
        public string PROOF_REC { get; set; }
        public string IFSC_Code { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string ChqPrintName { get; set; }
        public string NACHFLAG { get; set; }
        public string NACHUMRNO { get; set; }
        public string BankActive { get; set; }
        public string FT_ATOM_CODE { get; set; }
        public string BankModifyDate { get; set; }
    }
}

