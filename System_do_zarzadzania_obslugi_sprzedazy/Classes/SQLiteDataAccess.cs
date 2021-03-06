﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System_do_zarzadzania_obslugi_sprzedazy.Classes;

namespace System_do_zarzadzania_obslugi_sprzedazy
{
    class SQLiteDataAccess
    {
        public static List<Company>LoadUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Company>("select * from Company", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void SaveUser(Company company)
        {
            using(IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Company(CompanyName,Nip,City,Street,PhoneNumber,Email) values(@companyName,@nip,@city,@street,@phoneNumber,@email)",company);
            }
        }

        public static void DeleteUsers(Company company)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                String str = "delete from Company where CompanyID=" + company.CompanyID;
                var output = cnn.Query<Company>(str);
            }
        }

        public static void DeleteInvoice(Invoice invoice)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                String str = "delete from Database_for_invoices where IdCompany=" + invoice.IdCompany;
                var output = cnn.Query<Company>(str);
            }
        }
        public static void DeleteProduct(Product product)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                String str = "delete from Product where Id=" + product.Id;
                var output = cnn.Query<Company>(str);
            }
        }

        public static void DeleteProductFromInvoice(InvoiceProduct invoiceProduct)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                String str = "delete from InvoicesProduct where IdProduct=" + invoiceProduct.IdProduct;
                var output = cnn.Query<Company>(str);
            }
        }
        public static List<Seller> LoadSellers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Seller>("select * from Seller", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void DeleteContractors(Seller seller)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                String str = "delete from Seller where IdSeller=" + seller.IdSeller;
                var output = cnn.Query<Seller>(str);
            }
        }
        public static void SaveSeller(Seller seller)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string s1 = "Name,Surname,City,Street,NumberPhone,Nip";
                cnn.Execute("insert into Seller(" + s1 + ")values(@Name,@Surname,@City,@Street,@NumberPhone,@Nip)", seller);
            }
        }

        public static List<Invoice> LoadInvoices()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Invoice>("select * from Database_for_invoices", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Invoice> LoadInvoice(int ID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Invoice>("select * from Database_for_invoices WHERE Database_for_invoices.Id=" +  ID.ToString(), new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveInvoice(Invoice invoice)
        {
            using(IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string s1 = "IdSeller,  IdCompany,  Number,  CreationDate,  SaleDate,  PaymentType,  PaymentDeadline,  ToPay, ToPayInWords,  Paid,  DateOfIssue, NameOfService, AccountNumber, IsPrinted";
                cnn.Execute("insert into Database_for_invoices(" + s1 + ")values(@idSeller, @idCompany, @number, @creationDate, @saleDate, @paymentType, @paymentDeadline, @toPay, @toPayInWords, @paid, @dateOfIssue, @nameOfService, @accountNumber, @isPrinted)", invoice);
            }
        }

        public static List<InvoiceProduct> LoadInvoicesProduct(int ID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //var DynamicParameter = new DynamicParameters();
                //DynamicParameter.Add("QuantityUnit")
                string str = "SELECT InvoicesProduct.IdInvoice,InvoicesProduct.IdProduct,InvoicesProduct.ProductName,InvoicesProduct.Quantity,QuantityUnit.QuantityUnitName,InvoicesProduct.NettoPrice,InvoicesProduct.BruttoPrice,InvoicesProduct.Vat FROM InvoicesProduct INNER JOIN QuantityUnit ON InvoicesProduct.QuantityUnits=QuantityUnit.QuantityUnitID WHERE IdInvoice=";
                var output = cnn.Query<InvoiceProduct>(str + ID.ToString(), new DynamicParameters());
                return output.ToList();
            }
        }
        
        public static List<Product> LoadInvoiceProduct(int CompanyID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Product>("SELECT Product.Id, Product.Name,Product.NetPrice,Product.VatPrice FROM CompanyWithPoroduct INNER JOIN Product ON CompanyWithPoroduct.IdProduct = Product.Id WHERE CompanyWithPoroduct.IdCompany=" + CompanyID.ToString(), new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveInvoiceProduct(InvoiceProduct invoiceProduct, int unitId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string s1 = "IdInvoice, IdProduct, ProductName, Quantity, QuantityUnits, NettoPrice, BruttoPrice, Vat";
                cnn.Execute("insert into InvoicesProduct("+s1+ ")values(@idInvoice, @idProduct, @productName, @quantity,"+unitId.ToString() +", @nettoPrice, @bruttoPrice, @vat)", invoiceProduct);
            }
        }
        
        //Wczytuje id z autoincrementa
        public static List<int> LoadAiCompanyId(string name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<int>("SELECT seq FROM sqlite_sequence WHERE name =\""+name+"\"", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<Product> LoadProducts(int CompanyID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Product>("select Product.Id, Product.Name,Product.Quantity,Product.NetPrice,Product.Vat,Product.VatValue,Product.GrossValue FROM CompanyWithPoroduct INNER JOIN Product ON CompanyWithPoroduct.IdProduct = Product.Id WHERE CompanyWithPoroduct.IdCompany=" + CompanyID.ToString(), new DynamicParameters());
                return output.ToList();
                
            }
        }
        public static void SaveProduct(Product product)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string s1 = "name,quantity,netPrice,vat,vatValue,grossValue";
                cnn.Execute("insert into Product(" + s1 + ")values(@name, @quantity, @netPrice, @vat, @vatValue, @grossValue)", product);
            }
        }

        public static List<Seller> LoadNameSeller(int idCompany) 
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) 
            {                       
                var output =cnn.Query<Seller>("SELECT Seller.Name, Seller.Surname, Seller.Street, Seller.City, Seller.NumberPhone, Seller.Nip, Seller.Regon FROM CompanyWithSellers INNER JOIN Seller ON CompanyWithSellers.IdSeller=Seller.IdSeller WHERE CompanyWithSellers.IdCompany=" + idCompany.ToString(), new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Company> LoadNameCompany(int idCompany) 
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output=cnn.Query<Company>("select * from Company where CompanyID="+ idCompany.ToString(), new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<string> LoadQuantityUnitName() 
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) 
            {
                var output =cnn.Query<string>("select QuantityUnitName FROM QuantityUnit", new DynamicParameters());
                return output.ToList();
            }

        }

        public static void SaveProductToCustomer(int productId, int companyId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string s1 = "IdCompany, IdProduct";
                cnn.Execute("insert into CompanyWithPoroduct(" + s1 + ")values("+companyId.ToString()+","+productId.ToString()+")");
            }
        }

        public static void SaveUnitName(int unitId, string unitName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string s1 = "QuantityUnitID, QuantityUnitName";
                cnn.Execute("insert into QuantityUnit(" + s1 + ")values(" + unitId.ToString() + "," + "\'" + unitName + "\'" + ")");
            }
        }

        public static List<StorageOperations> LoadOperations()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StorageOperations>("SELECT StorageInformation.InformationID,StorageOperations.OperationName,StorageInformation.Quantity,StorageInformation.Date,StorageInformation.Receiver,StorageInformation.Sender,StorageInformation.InvoiceID,StorageInformation.StorageProductID FROM((StorageInformation INNER JOIN StorageOperations ON StorageInformation.OperationID=StorageOperations.OperationID))", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<StorageProduct> LoadStorageProduct(int ID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StorageProduct>("SELECT * FROM StorageProduct WHERE StorageProduct.StorageProductID="+ID.ToString()+"", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveOperation(StorageOperations storageOperation, int operationID, int invoiceID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string s1 = "OperationID, Date, Receiver, Sender, InvoiceID";
                cnn.Execute("insert into StorageInformation(" + s1 + ")values(" + operationID.ToString() + "," + "\'" + storageOperation.Date + "\'" + "," + "\'" + storageOperation.Receiver + "\'" + "," + "\'" + storageOperation.Sender + "\'" + "," + invoiceID.ToString() + ")");
            }
        }

        public static void SaveOperation(Product product, int operationID, int StorageProductID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
            	//Moze byc blad trzeba date zrobic
                string s1 = "OperationID, Date, Receiver, Sender, StorageProductID";
                cnn.Execute("insert into StorageInformation(" + s1 + ")values(" + operationID.ToString() + "," + "\'" + DateTime.Now.ToString("d") + "\'" + "," + "\'" + "Operacja wewnetrzna" + "\'" + "," + "\'"+ "Operacja wewnetrzna" + "\'" + "," + StorageProductID.ToString() + ")");
            }
        }

        public static void SaveProductInformation(Product product, int quantity)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string s1 = "StorageProductName, StorageProductQuantity, StorageProductNettoPrice, StorageProductBruttoPrice";
                cnn.Execute("insert into StorageProduct(" + s1 + ")values(" + "\'" + product.Name + "\'" + ","  + quantity.ToString() + "," +  Int32.Parse(product.NetPrice) + "," + Int32.Parse(product.GrossValue)+ ")");
            }
        }

        public static void UpdateProductQuantity(Product product)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Product SET Quantity = "+product.Quantity+" WHERE ID = "+product.Id+"");
            }
        }

        public static void UpdateProductQuantity(int quantity, int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Product SET Quantity = " + quantity.ToString() + " WHERE ID = " + id.ToString() + "");
            }
        }

        public static List<InvoiceCorrection> LoadCorrection()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<InvoiceCorrection>("SELECT * FROM CorrectedPdf", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveCorrectedInvoice(InvoiceCorrection invoiceCorrection)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string s1 = "CorrectionID, CorrectionNumber, CorrectionDate, CorrectionReason, InvoiceConnection, CorrectionConnection";
                cnn.Execute("insert into CorrectedPdf(" + s1 + ")values(@correctionID,@correctionNumber,@correctionDate,@correctionReason,@invoiceConnection,@correctionConnection)", invoiceCorrection);
            }
        }

        public static void SaveCorrectedInvoiceProduct(EditedInvoiceProduct editedInvoiceProduct)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string s1 = "IdEditedInvoice, IdEditedProduct, EditedProductName, EditedQuantity, EditedQuantityUnit, EditedNettoPrice, EditedBruttoPrice, EditedVat";
                cnn.Execute("insert into EditedInvoiceProduct(" + s1 + ")values(@idEditedInvoice,@idEditedProduct,@editedProductName,@editedQuantity,@editedQuantityUnit,@editedNettoPrice,@editedBruttoPrice,@editedVat)", editedInvoiceProduct);
            }
        }

        public static List<EditedInvoiceProduct> LoadEditedInvoicesProduct(int ID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //var DynamicParameter = new DynamicParameters();
                //DynamicParameter.Add("QuantityUnit")
                string str = "SELECT *  FROM EditedInvoiceProduct WHERE IdEditedInvoice=";
                var output = cnn.Query<EditedInvoiceProduct>(str + ID.ToString(), new DynamicParameters());
                return output.ToList();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
