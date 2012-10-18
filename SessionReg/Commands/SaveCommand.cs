using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg.Commands
{
    public class SaveCommand: ICommand
    {
        #region ICommand Members

        public void Run(HttpContext context)
        {
            //DAO
            Customer customer = new Customer(
                (string)context.Session["Name"],
                (string)context.Session["Surname"],
                int.Parse((string)context.Session["Age"]));

            DAO.SaveStudent(customer);
        }

        #endregion
    }
}