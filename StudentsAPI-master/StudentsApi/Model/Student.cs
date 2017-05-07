using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsApi.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime RegisteredDate { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}