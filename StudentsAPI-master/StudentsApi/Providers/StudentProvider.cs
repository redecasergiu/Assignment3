using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentsApi.Models;

namespace StudentsApi.Providers
{
    public class StudentProvider
    {
        private static List<Student> studentList = new List<Student>()
        {
            new Student() { ID=1, Name="Dan Pop", Age=21, RegisteredDate=new DateTime(2014,06,20), HomeTown="Bistrita"},
                new Student() { ID=2, Name="Ovidiu Ionescu", Age=21, RegisteredDate=new DateTime(2014,06,20), HomeTown="Brasov"},
                new Student() { ID=3, Name="Maria Sturza", Age=21, RegisteredDate=new DateTime(2014,06,20), HomeTown="Cluj-Napoca"}
        };

        public static IEnumerable<Student> GetList()
        {
            return studentList;
        }

        public static Student GetById(int id)
        {
            return studentList.FirstOrDefault(x=>x.ID == id);
        }

        public static void AddStudent(Student student)
        {
            studentList.Add(student);
        }
    }
}