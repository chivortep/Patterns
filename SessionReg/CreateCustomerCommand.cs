using System.Web;

namespace SessionReg
{
    public sealed class CreateCustomerCommand : ICommand
    {
        #region ICommand Members

        public void Run(HttpContext context)
        {
            Customer customer = new Customer(
                (string)context.Session["Name"],
                (string)context.Session["Surname"],
                int.Parse((string)context.Session["Age"]), true);

            //DAO.SaveCustomer(customer);
        }

        #endregion
    }
}