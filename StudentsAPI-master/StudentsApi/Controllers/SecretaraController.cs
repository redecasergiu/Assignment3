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
    public class SecretaraController : XController
    {
        // GET: api/Secretara
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Secretara/5
        public IEnumerable<Consultation> Get(String id)
        {
            if (da.isSToken(id.Substring(0,90)))
                return da.getConsultations(id.Substring(90));
            return null;
        }

        // POST: api/Secretara
        public void Post([FromBody]CC id)
        {
            Patient o = new Patient();
            if (da.isSToken(id.token))
            switch(id.tip){
                case 1: // adauga pacient    
                        o.cnp = id.param[0];
                        o.address = id.param[1];
                        o.birthdate = id.param[2];
                        o.name = id.param[3];
                        da.addPatient(o);
                break;
                case 2: // update pacient
                    o.cnp = id.param[0];
                    o.address = id.param[1];
                    o.birthdate = id.param[2];
                    o.name = id.param[3];
                    da.updatePatient(o);
                    break;

                case 3: // add consultation
                    da.addConsultation(id.param[0], id.param[1], id.param[2], id.param[3], id.param[4]);
                    break;
                case 4: // delete last consultation
                    da.deleteConsultation(id.param[0]);
                    break;

                case 5: // update consultation
                    da.updateConsultation(id.param[0], id.param[1], id.param[2], id.param[3], id.param[4]);
                    break;
                }
        }

        // PUT: api/Secretara/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Secretara/5
        public void Delete(int id)
        {
        }
    }
}
