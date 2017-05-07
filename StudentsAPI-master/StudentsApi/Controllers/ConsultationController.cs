using BankCredit.Models;
using BankCredit.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsApi.Controllers
{
    public class ConsultationController : XController
    {
        // GET: api/Consultation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Consultation/5
        public IEnumerable<Consultation> Get(String id)
        {
              return da.getConsultations(id);
        }

        // POST: api/Consultation
        public void Post([FromBody]CC c)
        {
            if (da.getTokens().Contains(c.token))
                if (c.tip == 0)
                    da.udc(c.param[0], c.param[1]);
                else
                    da.adc(c.param[0], c.param[1]);
        }

        // PUT: api/Consultation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Consultation/5
        public void Delete(int id)
        {
        }
    }
}
