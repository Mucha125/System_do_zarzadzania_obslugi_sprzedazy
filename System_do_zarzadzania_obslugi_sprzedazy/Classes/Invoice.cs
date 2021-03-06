using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarzadzania_obslugi_sprzedazy.Classes
{
    public class Invoice : BaseInvoice
    {
        private int idSeller;
        private int idCompany;
        private string saleDate;
        private string paymentType;
        private string paymentDeadline;
        private string toPayInWords;
        private string toPay;
        private string dateOfIssue;
        private string nameOfService;
        private string accountNumber;
        private int isPrinted;

        public int IdSeller
        {
            get { return idSeller; }
            set { idSeller = value; }
        }

        public int IdCompany
        {
            get { return idCompany; }
            set { idCompany = value; }
        }

        public string SaleDate
        {
            get { return saleDate; }
            set { saleDate = value; }
        }

        public string PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }

        public string PaymentDeadline
        {
            get { return paymentDeadline; }
            set { paymentDeadline = value; }
        }

        public string ToPay
        {
            get { return toPay; }
            set { toPay = value; }
        }

        public string ToPayInWords
        {
            get { return toPayInWords; }
            set { toPayInWords = value; }
        }

        
        public string NameOfService
        {
            get { return nameOfService; }
            set { nameOfService = value; }
        }
       

        public string DateOfIssue
        {
            get { return dateOfIssue; }
            set { dateOfIssue = value; }
        }    

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public int IsPrinted
        {
            get { return isPrinted; }
            set { isPrinted = value; }
        }



        public Invoice()
        {

        }

        public Invoice(int idSeller, int idCompany, string number, string creationDate, string saleDate, string paymentType, string paymentDeadline, string toPay,
            string toPayInWords, string paid, string dateOfIssue, string nameOfService, string accountNumber)
        {
            IdSeller = idSeller;
            IdCompany = idCompany;
            Number = number;
            CreationDate = creationDate;
            SaleDate = saleDate;
            PaymentType = paymentType;
            PaymentDeadline = paymentDeadline;
            ToPay = toPay;
            ToPayInWords = toPayInWords;
            Paid = paid;
            DateOfIssue = dateOfIssue;
            NameOfService = nameOfService;
            AccountNumber = accountNumber;
           
            
        }
        public Invoice(int id, int idSeller,int idCompany, string number, string creationDate, string saleDate, string paymentType, string paymentDeadline, string toPay,
            string toPayInWords, string paid, string dateOfIssue, string nameOfService, string accountNumber)
        {
            Id = id;
            IdSeller = idSeller;
            IdCompany = idCompany;
            Number = number;
            CreationDate = creationDate;
            SaleDate = saleDate;
            PaymentType = paymentType;
            PaymentDeadline = paymentDeadline;
            ToPay = toPay;
            ToPayInWords = toPayInWords;
            Paid = paid;
            DateOfIssue = dateOfIssue;
            NameOfService = nameOfService;
            AccountNumber = accountNumber;
        }

        public Invoice(int id, int idSeller, int idCompany, string number, string creationDate, string saleDate, string paymentType, string paymentDeadline, string toPay,
                        string toPayInWords, string paid, string dateOfIssue, string nameOfService, string accountNumber, int isPrinted)
        {
            Id = id;
            IdSeller = idSeller;
            IdCompany = idCompany;
            Number = number;
            CreationDate = creationDate;
            SaleDate = saleDate;
            PaymentType = paymentType;
            PaymentDeadline = paymentDeadline;
            ToPay = toPay;
            ToPayInWords = toPayInWords;
            Paid = paid;
            DateOfIssue = dateOfIssue;
            NameOfService = nameOfService;
            AccountNumber = accountNumber;
            IsPrinted = isPrinted;
        }
    }

}