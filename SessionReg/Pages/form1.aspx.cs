using System;

namespace SessionReg.Pages
{
    public partial class Form1 : System.Web.UI.Page
    {
        private const int PageId = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LastHandler"] = ""; //  Заплатка против повторного вызова

            if (!Session.IsNewSession)
            {
                //Response.Write("<b>Ошибка! Страница уже была загружена!</b>");               
                Session["LastHandler"] = ""; //  Заплатка против повторного вызова
            }
            else
            {
                Session.Add("PageId", 2);
                Session["LastHandler"] = ""; //  Заплатка против повторного вызова
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Name"] = NameTextBox1.Text;
            Response.Redirect("form2.aspx?Name=" + NameTextBox1.Text + "&PageId=" + PageId.ToString());
        }
    }
}