﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace System_do_zarzadzania_obslugi_sprzedazy
{
    class SQLiteDataAccess
    {
        public static List<Company>LoadUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Company>("select * from Firma", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void SaveUser(Company company)
        {
            using(IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Firma(CompanyID,Nip,City,Street,PhoneNumber,Email) values(@CompanyName,@Nip,@City,@Street,@PhoneNumber,@Email)",company);
            }
        }

        public static void DeleteUsers(Company company)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                String str = "delete from Firma where Nazwa_Firmy=" + company.CompanyName;
                var output = cnn.Query<Company>(str);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
