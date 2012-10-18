using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg.Commands
{
    public class UpdateCustomerCommand:ICommand
    {
        public void Run(HttpContext context)
        {
            if (context.Session["UpdatingCustomer"] != null && context.Session["UpdatingCustomer"] is Customer &&
                context.Session["UpdatedCustomer"] != null && context.Session["UpdatedCustomer"] is Customer)
            {
                ((Customer)context.Session["UpdatingCustomer"]).markDirty(((Customer)context.Session["UpdatedCustomer"]));
                context.Session["UpdatingCustomer"] = null;
                context.Session["UpdatedCustomer"] = null;
            }
        }
    }
}