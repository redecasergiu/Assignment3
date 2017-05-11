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
        public class DataAccess
        {
            private string connString;

            public DataAccess()
            {
                //connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                connString = "Server=localhost;Port=3306;Database=as3;Uid=root;Pwd=root;";
            }

            public User GetUser(string userName)
            {

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string statement = "SELECT * FROM us where name=\"" + userName + "\";";

                    MySqlCommand cmd = new MySqlCommand(statement, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        {
                            User user = new User();
                            user.id = reader.GetInt32("id");
                            user.name = reader.GetString("name");
                            user.parola = reader.GetString("parola");
                            user.tip = reader.GetInt32("tip");

                        return user;
                        }
                    }
                }

                return null;
            }

            public void AddUser(User user)
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "call updateUser(@name, @parola, @tip);";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@name", user.name);
                    cmd.Parameters.AddWithValue("@parola", user.parola);
                    cmd.Parameters.AddWithValue("@tip", user.tip);

                    cmd.ExecuteNonQuery();
                }
            }


        public IList<String> getTokens()
        {
            IList<String> productList = new List<String>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "select * from tk;";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productList.Add(reader.GetString("token"));
                    }
                }
            }
            return productList;
        }


        public int getPermission(String token)
        {
            IList<String> productList = new List<String>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "select * from tk;";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return reader.GetInt32("tip");
                    }
                }
            }
            return -1000;
        }


        public void updateUser(User user)
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                cmd.CommandText = "call updateUser(@name, @parola, @tip);";
                cmd.Prepare();

                    cmd.Parameters.AddWithValue("@name", user.name);
                    cmd.Parameters.AddWithValue("@parola", user.parola);
                    cmd.Parameters.AddWithValue("@tip", user.tip);

                cmd.ExecuteNonQuery();
                }
            }


        public void addToken(String t, String un)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "call addToken(@t,@username)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@t", t);
                cmd.Parameters.AddWithValue("@username", un);

                cmd.ExecuteNonQuery();
            }
        }

        /*
        public void addRaport(String user, String action)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "call addRaport(@user, @action)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@action", action);


                cmd.ExecuteNonQuery();
            }
        }
        */



        public void deleteUser(String username)
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "call deluser(@username);";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@username", username);

                    cmd.ExecuteNonQuery();
                }
            }

         

   

        public void addPatient(Patient o)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "call addPatient(@a, @b, @c, @d);";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@a", o.name);
                cmd.Parameters.AddWithValue("@b", o.cnp);
                cmd.Parameters.AddWithValue("@c", o.birthdate);
                cmd.Parameters.AddWithValue("@d", o.address);

                cmd.ExecuteNonQuery();
            }
        }

        public void updatePatient(Patient o)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "call updatePatient(@a, @b, @c, @d);";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@a", o.name);
                cmd.Parameters.AddWithValue("@b", o.cnp);
                cmd.Parameters.AddWithValue("@c", o.birthdate);
                cmd.Parameters.AddWithValue("@d", o.address);

                cmd.ExecuteNonQuery();
            }

        }


        public void addConsultation(String cnp, String numeDoc, String descriere, String start, String end)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "call addConsultation(@a, @b, @c, @d, @e);";
                cmd.Prepare();

                System.Diagnostics.Debug.WriteLine(cnp);
                System.Diagnostics.Debug.WriteLine(numeDoc);
                System.Diagnostics.Debug.WriteLine(descriere);
                System.Diagnostics.Debug.WriteLine(start);
                System.Diagnostics.Debug.WriteLine(end);

                cmd.Parameters.AddWithValue("@a", descriere);
                cmd.Parameters.AddWithValue("@b", numeDoc);
                cmd.Parameters.AddWithValue("@c", cnp);
                cmd.Parameters.AddWithValue("@d", start.Replace("/","-"));
                cmd.Parameters.AddWithValue("@e", end.Replace("/", "-"));

                cmd.ExecuteNonQuery();
            }

        }


        public void adc(String cnp ,String descriere)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "call adc(@a, @b);";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@a", descriere);
                cmd.Parameters.AddWithValue("@b", cnp);

                cmd.ExecuteNonQuery();
            }
        }

        public void udc(String cnp, String descriere)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "call udc(@a, @b);";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@a", descriere);
                cmd.Parameters.AddWithValue("@b", cnp);

                cmd.ExecuteNonQuery();
            }
        }


        public void updateConsultation(String cnp, String numeDoc, String descriere, String start, String end)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "call updateConsultation(@a, @b, @c, @d, @e);";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@a", descriere);
                cmd.Parameters.AddWithValue("@b", numeDoc);
                cmd.Parameters.AddWithValue("@c", cnp);
                cmd.Parameters.AddWithValue("@d", start);
                cmd.Parameters.AddWithValue("@e", end);

                cmd.ExecuteNonQuery();
            }

        }


        public void deleteConsultation(String cnp)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "call deleteConsultation(@a);";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@a", cnp);
 

                cmd.ExecuteNonQuery();
            }

        }

        //ignore this
        public IList<Account> GetAccountsForUser(int userID)
            {
                IList<Account> creditList = new List<Account>();

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string statement = "SELECT * FROM Accounts where userid=" + userID + "; ";

                    MySqlCommand cmd = new MySqlCommand(statement, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Account credit = new Account();
                            credit.ID = reader.GetInt32("Id");
                            credit.Number = reader.GetString("Number");
                            credit.Value = reader.GetDouble("Value");
                            creditList.Add(credit);
                        }
                    }
                }

                return creditList;
            }


            public IList<Product> getProducts()
            {
                IList<Product> productList = new List<Product>();
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string statement = "select * from products";

                    MySqlCommand cmd = new MySqlCommand(statement, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Product products = new Product();
                            products.id = reader.GetInt32("id");
                            products.name = reader.GetString("name");
                            products.description = reader.GetString("description");
                            products.color = reader.GetString("color");
                            products.size = reader.GetInt32("size");
                            products.price = reader.GetInt32("price");
                            products.stock = reader.GetInt32("stock");
                            productList.Add(products);
                        }
                    }
                }
                return productList;
            }

            public IList<User> getUsers()
            {
                IList<User> productList = new List<User>();
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    string statement = "select * from us";

                    MySqlCommand cmd = new MySqlCommand(statement, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            User users = new User();
                            users.id = reader.GetInt32("id");
                            users.name = reader.GetString("name");
                            //users.parola = reader.GetString("parola");
                            users.tip = reader.GetInt32("tip");
                            productList.Add(users);
                        }
                    }
                }
                return productList;
            }
        

        public IList<Rap> getRaports()
        {
            IList<Rap> productList = new List<Rap>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "select * from raports";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Rap r = new Rap();
                        r.user = reader.GetString("user");
                        r.action = reader.GetString("action");
                        r.time = reader.GetDateTime("time");
                        productList.Add(r);
                    }
                }
            }
            return productList;
        }


        //folosite de doctor
        public IList<Consultation> getConsultations(String cnp)
        {
            IList<Consultation> consultationsList = new List<Consultation>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "select * from consultations where consultations.patientid = (select id from patients where patients.cnp='"+cnp+"');";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Consultation consultation = new Consultation();
                        consultation.patientid = reader.GetInt32("patientid");
                        consultation.doctorid = reader.GetInt32("doctorid");
                        consultation.starttime = reader.GetDateTime("starttime");
                        consultation.endtime = reader.GetDateTime("endtime");
                        consultation.description = reader.GetString("description");
                        consultationsList.Add(consultation);
                    }
                }
            }
            return consultationsList;
        }



        public bool isToken(String token)
        {
            IList<Consultation> consultationsList = new List<Consultation>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "select * from tk where token='"+token+"';";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool isAdminToken(String token)
        {
            IList<Consultation> consultationsList = new List<Consultation>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "select * from tk where token='" + token + "';";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32("tip") == 0)
                            return true;
                        return false;
                    }
                }
            }
            return false;
        }

        public bool isSToken(String token)
        {
            IList<Consultation> consultationsList = new List<Consultation>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "select * from tk where token='" + token + "';";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32("tip") == 2)
                            return true;
                        return false;
                    }
                }
            }
            return false;
        }


        public bool isDToken(String token)
        {
            IList<Consultation> consultationsList = new List<Consultation>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "select * from tk where token='" + token + "';";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32("tip") == 1)
                            return true;
                        return false;
                    }
                }
            }
            return false;
        }


    }



















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



