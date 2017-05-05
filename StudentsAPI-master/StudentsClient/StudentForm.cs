using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace StudentsClient
{
    public partial class formStudents : Form
    {
        public formStudents()
        {
            InitializeComponent();
            gridStudents.AutoGenerateColumns = true;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:27445/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/student").Result;

            if (response.IsSuccessStatusCode)
            {
                var students = response.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                gridStudents.DataSource = students;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            std.Name = tbName.Text;
            std.RegisteredDate = dateRegistered.Value;
            std.Age = Convert.ToInt32(tbAge.Text);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:27445/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("api/student",std).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Operation succeded");
            }
            else
            {
                MessageBox.Show("Operation failed");
            }
        }
    }
}
