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
    public class UserController : XController
    {
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public bool Get(String id)
        {
            String token = id.Substring(0, 90);
            String tip = id.Substring(90);
            if (!da.isToken(token))
                return false;

            if (tip.Equals("admin"))
                return da.isAdminToken(token);

            if (tip.Equals("doctor"))
                return da.isDToken(token);

            if (tip.Equals("secretara"))
                return da.isSToken(token);

            return false;
        }

        // POST: api/User
        public void Post([FromBody]CC c)
        {
            try
            {
                if (da.GetUser(c.param[0]).parola.Equals(c.param[1]))
                    da.addToken(c.token, c.param[0]);
            }
            finally { }
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
