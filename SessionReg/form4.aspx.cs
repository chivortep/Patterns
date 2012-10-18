using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionReg
{
    public partial class form4 : System.Web.UI.Page
    {
        private const int PageId = 4;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<br /><b>Имя:</b> " + Session["Name"]);
            Response.Write("<br /><b>Фамилия:</b> " + Session["Surname"]);
            Response.Write("<br /><b>Возраст:</b> " + Session["Age"]);
        }
    }
}