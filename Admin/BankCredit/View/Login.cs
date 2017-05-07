
using BankCredit.Models;
using BankCredit.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;



namespace BankCredit
{
    

    public partial class Login : Vieww
    {

        public Login()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }



        Random rand = new Random();

        public const string Alphabet =
        "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string GenerateString(int size)
        {
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[rand.Next(Alphabet.Length)];
            }
            return new string(chars);
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:27445/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            CC c = new View.CC();
            //c.tip = 1;
            c.token = GenerateString(90);
            c.param = new String[] { txtUser.Text, txtPassword.Text };
            HttpResponseMessage response = client.PostAsJsonAsync("api/User", c).Result;

            if (response.IsSuccessStatusCode)
            {


                //dataGridView1.RowCount = 1;
                HttpClient clientt = new HttpClient();
                clientt.BaseAddress = new Uri("http://localhost:27445/");

                clientt.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responsee = clientt.GetAsync("api/User/" + c.token+"admin").Result;

                if (responsee.IsSuccessStatusCode)
                {
                    var students = responsee.Content.ReadAsAsync<bool>().Result;
                    


                    //User user = p.Login(txtUser.Text, txtPassword.Text);
                    if ( students)

                        {
                            Vieww adminForm = new Admin(txtUser.Text);
                            //adminForm.p = p;
                            adminForm.token = c.token;
                            adminForm.Show();

                        }
                    else
                    {
                        MessageBox.Show("Operation failed");
                    }

                }

            }
            else
            {
                MessageBox.Show("Operation failed");
            }




            
            
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
