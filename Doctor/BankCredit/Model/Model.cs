using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using BankCredit.Models;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Collections.Specialized;


    namespace BankCredit.Models
    {
  


















    //modfels
    public class Account
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public double Value { get; set; }

        public double previousValue;

        public User Customer { get; set; }

        public Account() { }
        public Account(int id, string number, double value)
        {
            ID = id;
            Number = number;
            Value = value;

            this.previousValue = value;
        }

        public void Withdraw(double amount, double fee)
        {
            double totalAmount = amount;

            if (totalAmount > Value)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            if (totalAmount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            previousValue = Value;
            Value -= totalAmount;
        }
    }



    public class Order
    {
        public int id { get; set; }
        public int idcustomer { get; set; }
        public string address { get; set; }
        public string deliverydate { get; set; }
        public string status { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public double size { get; set; }
        public double price { get; set; }
        public int stock { get; set; }


        public bool isOk()
        {
            if (name == "")
                return false;
            if (price <= 0.0)
                return false;
            if (stock <= 0)
                return false;
            return true;
        }
    }



    public class ProductOrder
    {
        public int id { get; set; }
        public int idproduct { get; set; }
        public int idcommand { get; set; }
        public int cantitate { get; set; }
    }


    //raport
    public class Rap
    {
        public String user { get; set; }
        public String action { get; set; }
        public DateTime time { get; set; }
    }



    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string parola { get; set; }
        public int tip { get; set; }


    }


    /// <summary>
    /// ////////////////////////////
    /// </summary>
    public class Patient
    {
        public int id { get; set; }
        public string name { get; set; }
        public string cnp { get; set; }
        public string birthdate { get; set; }
        public string address { get; set; }



        public IList<Consultation> Consultations { get; set; }


    }



    public class Consultation
    {
        public int id { get; set; }
        public int patientid { get; set; }
        public int doctorid { get; set; }
        public DateTime starttime { get; set; }
        public DateTime endtime { get; set; }
        public string description { get; set; }
     

    }


    


}



