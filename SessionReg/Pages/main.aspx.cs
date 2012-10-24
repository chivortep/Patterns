using System;
using System.Web;

namespace SessionReg.Pages
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CommitButtonClick(object sender, EventArgs e)
        {
            ICommand commitCommand = new CommitCommand();
            commitCommand.Run(HttpContext.Current);
        }
    }
}