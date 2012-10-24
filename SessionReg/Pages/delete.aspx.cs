using System;
using System.Collections.Generic;
using System.Web;

namespace SessionReg.Pages
{
    public partial class Delete : System.Web.UI.Page
    {
        private readonly List<object> _customers = DAO.GetCustomersList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListBox1.DataSource = _customers;
                ListBox1.DataTextField = "Surname";
                ListBox1.DataMember = "Customer";
                ListBox1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex >= 0)
            {
                var tst = ListBox1.SelectedItem.Value;
                foreach (object customer in _customers)
                {
                    if (((Customer)customer).Surname == tst)
                    {
                        HttpContext.Current.Session["DeleteCustomer"] = customer;
                        DeleteCustomerCommand command = new DeleteCustomerCommand();
                        command.Run(HttpContext.Current);
                        return;
                    }
                }
            } 
        }
    }
}