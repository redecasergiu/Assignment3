
using BankCredit.Model;
using BankCredit.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BankCredit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new Login());
            }
            catch(Exception e) { MessageBox.Show(e.Message);
            }
        }
    }
}
