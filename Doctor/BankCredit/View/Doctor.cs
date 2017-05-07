using BankCredit.Models;
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
using BankCredit.Model;
using BankCredit.Models;
using BankCredit.View;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Threading;

namespace BankCredit.View
{
    public partial class Doctor : Vieww
    {
        public String nume;
        Thread t1;
        public Doctor()
        {
            
            InitializeComponent();
             t1 = new Thread(thread);
            t1.Start();
        }

        void thread()
        {
            while (true)
            {
                System.Diagnostics.Debug.WriteLine("SSSSSSSSSSS");
                try
                {
                    Thread.Sleep(10 * 1000);
                    //dataGridView1.RowCount = 1;
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:27445/");

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("api/SalaDeAsteptare/" + token + nume).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var students = response.Content.ReadAsAsync<List<String>>().Result;
                        if (students != null)
                        {
                            string msg = String.Join(" ", students.ToArray());

                            MessageBox.Show(msg, "Mesaje noi",
                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                //dataGridView1.RowCount = 1;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:27445/");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/Consultation/" + cnpb.Text).Result;

                if (response.IsSuccessStatusCode)
                {
                    var students = response.Content.ReadAsAsync<IEnumerable<Consultation>>().Result;
                    dataGridView1.DataSource = students;

                   
                }else
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

        private void button1_Click(object sender, EventArgs e)
        {

            String cnp = cnpb.Text;
            String desc = richTextBox1.Text;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:27445/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            CC c = new View.CC();
            c.tip = 1;
            c.token = token;
            c.param = new String []{ cnp, desc };
            HttpResponseMessage response = client.PostAsJsonAsync("api/Consultation",c).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Operation succeded");
            }
            else
            {
                MessageBox.Show("Operation failed");
            }
     
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String cnp = cnpb.Text;
            String desc = richTextBox1.Text;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:27445/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            CC c = new View.CC();
            c.tip = 0;
            c.token = token;
            c.param = new String[] { cnp, desc };
            HttpResponseMessage response = client.PostAsJsonAsync("api/Consultation", c).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Operation succeded");
            }
            else
            {
                MessageBox.Show("Operation failed");
            }
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
    }
}
