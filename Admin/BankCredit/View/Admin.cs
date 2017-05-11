using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BankCredit.Models;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

using BankCredit.View;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BankCredit
{
    public partial class Admin : Vieww
    {
        public String myuser;
        public Admin(String user)
        {
            myuser = user;
            InitializeComponent();
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.name = txtUserName.Text;
            user.parola = txtPassword.Text;
            user.tip = aradio.Checked ? 0 : dradio.Checked ? 1 : 2;


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:27445/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            CC c = new View.CC();
            c.tip = 3;
            c.token = token;
            c.param = new String[] { user.name, user.parola, user.tip.ToString() };
            HttpResponseMessage response = client.PostAsJsonAsync("api/Admin", c).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Operation succeded");
            }
            else
            {
                MessageBox.Show("Operation failed");
            }

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:27445/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            CC c = new View.CC();
            c.tip = 2;
            c.token = token;
            c.param = new String[] { txtUserName.Text };
            HttpResponseMessage response = client.PostAsJsonAsync("api/Admin", c).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Operation succeded");
            }
            else
            {
                MessageBox.Show("Operation failed");
            }
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
           try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:27445/");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/Admin/"+token ).Result;

                if (response.IsSuccessStatusCode)
                {
                    var students = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
                    dataGridView1.DataSource = students;
                                    }
                else
                    MessageBox.Show(response.Content.ToString(), "Eroare",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception q)
            {
                MessageBox.Show(q.Message, "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
