using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionReg
{
    public partial class form2 : System.Web.UI.Page
    {
        private const int PageId = 2;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Surname"] = SurnameTextBox1.Text;
            Response.Redirect("~/form3.aspx?Surname=" + SurnameTextBox1.Text + "&PageId=" + PageId.ToString());
        }
    }
}