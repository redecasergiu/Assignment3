using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using StudentsApi.Controllers;
using BankCredit.Models;

[assembly: OwinStartup(typeof(StudentsApi.Startup))]

namespace StudentsApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            XController.da = new DataAccess();
            ConfigureAuth(app);
        }
    }
}
