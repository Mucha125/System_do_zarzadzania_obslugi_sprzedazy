﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System_do_zarzadzania_obslugi_sprzedazy.Classes;

namespace System_do_zarzadzania_obslugi_sprzedazy
{
    /// <summary>
    /// Interaction logic for NewInvoice.xaml
    /// </summary>
    public partial class NewInvoice : Window
    {
        public NewInvoice()
        {
            InitializeComponent();
        }

        private void AddInvoice_Click(object sender, RoutedEventArgs e)
        {
            int num = SQLiteDataAccess.LoadAiCompanyId("Database_for_invoices")[0]+1;
            int idSeller = Int32.Parse(IdSeller.Text);
            int idCompany = Int32.Parse(IdCompany.Text);
            string creationDate = CreationDate.Text;
            string saleDate = SaleDate.Text;
            string paymentType = PaymentTypeComboBox.Text;
            string paymentDeadline = PaymentDeadline.Text;
            string toPay = ToPay.Text;
            string toPayInWord = ToPayInWord.Text;
            string paid = Paid.Text;
            string dateOfIssue = DateOfIssue.Text;
            string nameOfService = NameOfService.Text;
            string[] date = creationDate.Split('.');
            string number = num.ToString()+"."+date[1]+"."+date[2];
            string accountNumber = AccountNumber.Text;
            Invoice invoice = new Invoice(idSeller, idCompany, number, creationDate, saleDate, paymentType, paymentDeadline, toPay,
            toPayInWord, paid, dateOfIssue, nameOfService, accountNumber);
            SQLiteDataAccess.SaveInvoice(invoice);
            this.Close();
        }

        private void PaymentTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(PaymentTypeComboBox.SelectedItem!=null)
            {
                if(PaymentTypeComboBox.SelectedItem == Gotowka)
                {
                    AccountNumber.Visibility = Visibility.Hidden;
                    AccountNumberLabel.Visibility = Visibility.Hidden;
                    AccountNumber.Clear();
                }
                else
                {
                    AccountNumber.Visibility = Visibility.Visible;
                    AccountNumberLabel.Visibility = Visibility.Visible;

                }
            }


        }
    }
}
