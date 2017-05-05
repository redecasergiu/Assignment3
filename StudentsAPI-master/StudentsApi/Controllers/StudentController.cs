using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentsApi.Models;
using StudentsApi.Providers;

namespace StudentsApi.Controllers
{
    public class StudentController : ApiController
    {
        // GET: api/Student
        public IEnumerable<Student> Get()
        {
            return StudentProvider.GetList();
        }

        // GET: api/Student/5
        public Student Get(int id)
        {
            return StudentProvider.GetById(id);
        }

        // POST: api/Student
        public void Post([FromBody]Student value)
        {
            StudentProvider.AddStudent(value);
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
        }
    }
}
