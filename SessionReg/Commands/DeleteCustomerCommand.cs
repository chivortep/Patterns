using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg.Commands
{
    public class DeleteCustomerCommand:ICommand
    {
        public void Run(HttpContext context)
        {
            if (context.Session["DeleteCustomer"]!=null && context.Session["DeleteCustomer"] is Customer)
            {
                ((Customer)context.Session["DeleteCustomer"]).markRemoved();
                context.Session["DeleteCustomer"] = null;
            }
        }
    }
}