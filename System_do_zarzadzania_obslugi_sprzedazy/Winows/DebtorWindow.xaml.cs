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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

using System_do_zarzadzania_obslugi_sprzedazy.Classes;

namespace System_do_zarzadzania_obslugi_sprzedazy.Winows
{
    /// <summary>
    /// Logika interakcji dla klasy DebtorWindow.xaml
    /// </summary>
    public partial class DebtorWindow : Window
    {
        private Debter debter;
        private Dictionary<string, int> debterDictionary = new Dictionary<string, int>();
        List<Debter> debters;


        public DebtorWindow(Debter Debter) 
        {
            InitializeComponent();
            debterDictionary = Debter.returnList();
            debter = Debter;
            DebtorInvoice.ItemsSource = debterDictionary;
        }

       

        private void ExportToPDF()
        {

        }
       

        private void ClientPDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.IO.FileStream fs = new FileStream("C:/projekcik" + "\\" +"Raport_dluznika"+ debter.FullName + ".pdf", FileMode.Create);
                var pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                pdfDoc.Open();

                var spacer = new iTextSharp.text.Paragraph("")
                {
                    SpacingBefore = 10f,
                    SpacingAfter = 10f,
                };

                var spacer2 = new iTextSharp.text.Paragraph("")
                {
                    SpacingBefore = 100f,
                    SpacingAfter = 70f,
                };

                var spacer3 = new iTextSharp.text.Paragraph("")
                {
                    SpacingBefore = 50f,
                    SpacingAfter = 30f,
                };

                var titleFont = FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1257, 28);
                var numberFont = FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1257, 22);
                var serviceFont = FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1257, 16);
                var dateFont = FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1257, 14);
                var smallFont = FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1257, 11);
                var tableFont = FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1257, 12);
                DateTime date1 = DateTime.Today;

                var docDate = new iTextSharp.text.Paragraph("Data wygenerowania :" + date1.ToString("d"));
                docDate.Alignment = Element.ALIGN_RIGHT;

                
                var docTitle = new iTextSharp.text.Paragraph("Podsumowanie niezapłaconych należności ",numberFont);
                docTitle.Alignment = Element.ALIGN_CENTER;
                var docName = new iTextSharp.text.Paragraph(debter.FullName,numberFont);
                docName.Alignment = Element.ALIGN_CENTER;

                pdfDoc.Add(docDate);
                pdfDoc.Add(spacer3);
                pdfDoc.Add(docTitle);
                pdfDoc.Add(docName);

                var columnCount = 2;
                var columnWidths = new[] { 2f,2f };

                var table = new PdfPTable(columnWidths)
                {
                    HorizontalAlignment = 0,
                    WidthPercentage = 100,
                    DefaultCell = { MinimumHeight = 22f }
                };

                var cell = new PdfPCell()
                {
                    Colspan = columnCount,
                    HorizontalAlignment = 1,  //0=Left, 1=Centre, 2=Right
                    MinimumHeight = 30f
                };

                var debtTable = new PdfPTable(new[] { .75f, .75f, .75f })
                {
                    HorizontalAlignment = 2,
                    WidthPercentage = 40,
                    DefaultCell = { MinimumHeight = 22f }
                };

                PdfPCell cell1 = new PdfPCell(new iTextSharp.text.Paragraph("Numer Faktury", tableFont)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                PdfPCell cell2 = new PdfPCell(new iTextSharp.text.Paragraph("Kwota", tableFont)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT };
                cell1.BackgroundColor = new iTextSharp.text.BaseColor(192, 192, 192);
                cell2.BackgroundColor = new iTextSharp.text.BaseColor(192, 192, 192);
                table.AddCell(cell1);
                table.AddCell(cell2);

              
                pdfDoc.Add(spacer3);
                pdfDoc.Add(table);
                pdfDoc.Close();
                writer.Close();
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nie udało się zapisać pliku pdf");
            }
        }

    }
}
