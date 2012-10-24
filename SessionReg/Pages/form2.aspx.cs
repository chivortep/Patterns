using System;

namespace SessionReg.Pages
{
    public partial class Form2 : System.Web.UI.Page
    {
        private const int PageId = 2;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Surname"] = SurnameTextBox1.Text;
            Response.Redirect("form3.aspx?Surname=" + SurnameTextBox1.Text + "&PageId=" + PageId.ToString());
        }
    }
}