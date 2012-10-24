using System;

namespace SessionReg.Pages
{
    public partial class Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerValueListHandler vlHandler = new CustomerValueListHandler();
        }
    }
}