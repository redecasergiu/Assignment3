using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BankCredit.Models;
using BankCredit.View;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BankCredit
{
    public partial class Secretara : Vieww
    {
        public Secretara()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd hh:mm:ss";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy/MM/dd hh:mm:ss";
        }

        private void OrdinaryUser_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }



        private void add_Click(object sender, EventArgs e)
        {
            
        }



        private void id2b_TextChanged(object sender, EventArgs e)
        {

        }


        private void add_clickc(object sender, EventArgs e)
        {

                String descriere = richTextBox1.Text;
                String numeDoc = name2b.Text;
                String cnp = cnpcb.Text;
                String start = dateTimePicker1.Value.ToString("yyyy/MM/dd hh:mm:ss");
                String end = dateTimePicker2.Value.ToString("yyyy/MM/dd hh:mm:ss");


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:27445/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            CC c = new View.CC();
            c.tip = 3;
            c.token = token;
            c.param = new String[] { cnp, numeDoc,  descriere, start, end };
            HttpResponseMessage response = client.PostAsJsonAsync("api/Secretara", c).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Operation succeded");
            }
            else
            {
                MessageBox.Show("Operation failed");
            }
        }

        private void update_Click(object sender, EventArgs e)
        {

                String cnp = cnpb.Text;
                String addr = addressb.Text;
                String nume = numeb.Text;
                String da = birthdateb.Value.ToString("yyyy-MM-dd");


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:27445/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            CC c = new View.CC();
            c.tip = 2;
            c.token = token;
            c.param = new String[] { cnp, addr, da ,nume };
            HttpResponseMessage response = client.PostAsJsonAsync("api/Secretara", c).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Operation succeded");
            }
            else
            {
                MessageBox.Show("Operation failed");
            }
        }

        private void addd_Click(object sender, EventArgs e)
        {
                
                String cnp = cnpb.Text;
                String addr = addressb.Text;
                String nume = numeb.Text;
                String da = birthdateb.Value.ToString("yyyy-MM-dd");

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:27445/");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                CC c = new View.CC();
                c.tip = 1;
                c.token = token;
            c.param = new String[] { cnp, addr, da, nume };
            HttpResponseMessage response = client.PostAsJsonAsync("api/Secretara", c).Result;

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Operation succeded");
                }
                else
                {
                    MessageBox.Show("Operation failed");
                }
            }

        private void del_clickc(object sender, EventArgs e)
        {

                String cnp = cnpcb.Text;




            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:27445/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            CC c = new View.CC();
            c.tip = 4;
            c.token = token;
            c.param = new String[] { cnp};
            HttpResponseMessage response = client.PostAsJsonAsync("api/Secretara", c).Result;

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
                String descriere = richTextBox1.Text;
                String numeDoc = name2b.Text;
                String cnp = cnpcb.Text;
                String start = dateTimePicker1.Value.ToString("yyyy/MM/dd hh:mm:ss");
                String end = dateTimePicker2.Value.ToString("yyyy/MM/dd hh:mm:ss");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:27445/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            CC c = new View.CC();
            c.tip = 5;
            c.token = token;
            c.param = new String[] {  cnp, numeDoc, descriere, start, end };
            HttpResponseMessage response = client.PostAsJsonAsync("api/Secretara", c).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Operation succeded");
            }
            else
            {
                MessageBox.Show("Operation failed");
            }
        }

        private void view2_Click(object sender, EventArgs e)
        {

            try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:27445/");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/Secretara/" + token+cnpcb.Text).Result;

                if (response.IsSuccessStatusCode)
                {
                    var students = response.Content.ReadAsAsync<IEnumerable<Consultation>>().Result;
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


            String descriere = richTextBox2.Text;
            String doc = name2b.Text;


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:27445/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            CC c = new View.CC();
            //c.tip = 30000;
            c.token = token;
            c.param = new String[] { doc, descriere };
            HttpResponseMessage response = client.PostAsJsonAsync("api/SalaDeAsteptare", c).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Operation succeded");
            }
            else
            {
                MessageBox.Show("Operation failed");
            }
            
        }

        private void name2b_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
