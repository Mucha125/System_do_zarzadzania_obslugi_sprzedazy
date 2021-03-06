﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarzadzania_obslugi_sprzedazy
{
    class Seller
    {
        private int idSeller;

        private string name;

        private string surname;

        private string city;

        private string street;

        private string numberPhone;

        private string nip;

        private string regon;


        [DisplayName("ID Sprzedawcy")]
        public int IdSeller
        {
            get
            {
                return idSeller;
            }
            set
            {
                idSeller = value;
            }
        }

        [DisplayName("Imię")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        [DisplayName("Nazwisko")]
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }

        [DisplayName("Miasto")]
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

        [DisplayName("Ulica")]
        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
            }
        }

        [DisplayName("Numer telefonu")]
        public string NumberPhone
        {
            get
            {
                return numberPhone;
            }
            set
            {
                numberPhone = value;
            }
        }
        [DisplayName("NIP")]
        public string Nip
        {
            get
            {
                return nip;
            }
            set
            {
                nip = value;
            }
        }

        [DisplayName("REGON")]
        public string Regon
        {
            get { return regon; }
            set { regon = value; }
        }



        public Seller()
        {

        }

        public Seller(int idSeller, string name, string surname, string city, string street, string numberPhone, string nip, string regon) : this(name, surname, city, street, numberPhone, nip, regon)
        {                      
            IdSeller = idSeller;            
        }

        public Seller(string name, string surname, string city, string street, string numberPhone, string nip, string regon)
        {
            Name = name;
            Surname = surname;
            City = city;
            Street = street;
            NumberPhone = numberPhone;
            Nip = nip;
            Regon = regon;
        }
    }
}
