using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SessionReg.Commands;

namespace SessionReg
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void commitButton_Click(object sender, EventArgs e)
        {
            ICommand commitCommand = new CommitCommand();
            commitCommand.Run(HttpContext.Current);
        }
    }
}