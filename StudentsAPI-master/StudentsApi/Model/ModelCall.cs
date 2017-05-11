
using BankCredit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BankCredit.Model
{
    public class ModelCall
    {


        public bool addPatient(String numeb, String cnpb, String addressb, String bd)
        {
            Patient o = new Patient();
            o.cnp = cnpb;
            o.address = addressb;
            o.birthdate = bd;
            o.name = numeb;

            DataAccess dal = new DataAccess();
            dal.addPatient(o);
            return false;

        }


        public bool updatePatient(String numeb, String cnpb, String addressb, String bd)
        {
            Patient o = new Patient();
            o.cnp = cnpb;
            o.address = addressb;
            o.birthdate = bd;
            o.name = numeb;

            DataAccess dal = new DataAccess();
            dal.updatePatient(o);
            return false;

        }


        public bool addConsultation(String cnp, String numeDoc, String descriere, String start, String end)
        {
            DataAccess dal = new DataAccess();
            dal.addConsultation(cnp,  numeDoc, descriere,  start,  end);
            return false;
        }



        public bool udc(String cnp,String descriere)
        {
            DataAccess dal = new DataAccess();
            dal.udc(cnp, descriere);
            return false;
        }

        public bool adc(String cnp, String descriere)
        {
            DataAccess dal = new DataAccess();
            dal.adc(cnp, descriere);
            return false;
        }



        public bool updateConsultation(String cnp, String numeDoc, String descriere, String start, String end)
        {
            DataAccess dal = new DataAccess();
            dal.updateConsultation(cnp, numeDoc, descriere, start, end);
            return false;
        }

        public bool deleteConsultation(String cnp)
        {
            DataAccess dal = new DataAccess();
            dal.deleteConsultation(cnp);
            return false;
        }




        public IList<Product> getProducts()
        {
            DataAccess dal = new DataAccess();
            return dal.getProducts();
        }




        internal string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.UTF8.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        internal bool VerifyHash(string value, string hash)
        {
            if (value != null && hash != null && hash.Equals(HashSHA1(value)))
            {
                return true;
            }
            return false;
        }

        internal string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }


        public User Login(string userName, string password)
        {
            DataAccess dal = new DataAccess();
            User user = dal.GetUser(userName);
            if (user != null)
            {
                //String check = HashSHA1(password + user.salt);
               if (user.parola.Equals(password))
                {
                    return user;
                }
            }
            return null;
        }

        public void AddUser(User user)
        {
            //user.epass = HashSHA1(user.epass + user.salt);

            DataAccess dal = new DataAccess();
            dal.AddUser(user);
        }

        public void addRaport(String name, String action)
        {
            DataAccess dal = new DataAccess();
            //dal.addRaport(name, action);
        }


        public void updateUser(User user)
        {
            //user.epass = HashSHA1(user.epass + user.salt);

            DataAccess dal = new DataAccess();
            dal.updateUser(user);
        }

        public void DeleteUser(String username)
        {
            DataAccess dal = new DataAccess();
            dal.deleteUser(username);
        }


        public IList<Account> GetAccountsForUser(int userId)
        {
            DataAccess dal = new DataAccess();
            return dal.GetAccountsForUser(userId);
        }

        public IList<User> getUsers()
        {
            DataAccess dal = new DataAccess();
            return dal.getUsers();
        }

        public IList<Rap> getRaports()
        {
            DataAccess dal = new DataAccess();
            return dal.getRaports();
        }


            public IList<Consultation> getConsultations(String cnp)
        {
            DataAccess dal = new DataAccess();
            return dal.getConsultations(cnp);
        }
    }
}
