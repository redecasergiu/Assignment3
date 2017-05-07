using BankCredit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsApi.Controllers
{
    public class PatientController : XController
    {
        // GET: api/Patient
        public IEnumerable<Patient> Get()
        {
            //return new string[] { "value1", "value2" };
            return null;
        }

        // GET: api/Patient/5
        public IEnumerable<Patient> Get(int id)
        {
            //return da.getConsultations(id.ToString());
            return null;
        }

        // POST: api/Patient
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Patient/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Patient/5
        public void Delete(int id)
        {
        }
    }
}
