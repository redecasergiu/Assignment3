using BankCredit.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsApi.Controllers
{
    public class SalaDeAsteptareController : XController
    {
        public static Dictionary<String, List<String>> msg = new Dictionary<String, List<String>>();

        // GET: api/SalaDeAsteptare
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SalaDeAsteptare/5
        public List<String> Get(String id)
        {
            if (da.isDToken(id.Substring(0, 90)))
                if (msg.ContainsKey(id.Substring(90)))
                {
                    System.Diagnostics.Debug.WriteLine("SSSSSSSSSSS");
                    List < String > l = msg[id.Substring(90)];
                    msg.Remove(id.Substring(90));
                    return l;
                }
            return null;
        }

        // POST: api/SalaDeAsteptare
        public void Post([FromBody]CC id)
        {
            String k = id.param[0];
            String m = id.param[1];
            if (da.isSToken(id.token))
            {
                if (msg.ContainsKey(k)) {
                    msg[k].Add(m);
                }
                else
                {
                    msg.Add(k,new List<String>() {m});
                }
            }
        }

        // PUT: api/SalaDeAsteptare/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SalaDeAsteptare/5
        public void Delete(int id)
        {
        }
    }
}
