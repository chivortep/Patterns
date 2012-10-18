using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionReg
{
    public partial class form3 : System.Web.UI.Page
    {
        private const int PageId = 3;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Age"] = AgeTextBox1.Text;
            Response.Redirect("~/form4.aspx?Age=" + AgeTextBox1.Text + "&PageId=" + PageId.ToString());
        }
    }
}