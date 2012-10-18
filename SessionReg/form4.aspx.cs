﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using SessionReg.Commands;

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

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            HttpSessionState session = HttpContext.Current.Session;
            if (session["Name"] != null &&
                session["Surname"] != null &&
                session["Age"] != null)
            {
                ICommand command = new CreateCustomerCommand();
                command.Run(HttpContext.Current);
            }
            Response.Redirect("~/main.aspx?saved=ok");
        }
    }
}