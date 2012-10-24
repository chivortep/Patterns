using System.Web;

namespace SessionReg
{
    public sealed class DeleteCustomerCommand : ICommand
    {
        public void Run(HttpContext context)
        {
            if (context.Session["DeleteCustomer"]!=null && context.Session["DeleteCustomer"] is Customer)
            {
                ((Customer)context.Session["DeleteCustomer"]).MarkRemoved();
                context.Session["DeleteCustomer"] = null;
            }
        }
    }
}