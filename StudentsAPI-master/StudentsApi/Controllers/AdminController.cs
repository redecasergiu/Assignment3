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
    public class AdminController : XController
    {
        // GET: api/Admin
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Admin/5
        public IEnumerable<User> Get(String id) //token admin
        {
            if (da.isAdminToken(id))
            return da.getUsers();
            return null;
        }

        // POST: api/Admin
        public void Post([FromBody]CC c)
        {
            User u; ;
            if (da.isAdminToken(c.token))
            switch (c.tip)
            {
                
                case 1:
                    u = new BankCredit.Models.User();
                    u.name = c.param[0];
                    u.parola = c.param[1];
                    u.tip = Int32.Parse(c.param[2]);
                    da.AddUser(u);
                    break;
                case 2:
                        da.deleteUser(c.param[0]);
                    break;
                case 3:
                    u = new BankCredit.Models.User();
                    u.name = c.param[0];
                    u.parola = c.param[1];
                    u.tip = Int32.Parse(c.param[2]);
                    da.AddUser(u);
                    break;
            }
        }

        // PUT: api/Admin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
        }
    }
}
