using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

[assembly: CLSCompliant(true)]
namespace SessionReg
{
    public class Global : System.Web.HttpApplication
    {
        //private void Application_Start(object sender, EventArgs e)
        //{

        //}

        private void Session_Start(object sender, EventArgs e)
        {
            UnitOfWork.NewCurrent();
        }

        //private void Application_BeginRequest(object sender, EventArgs e)
        //{

        //}

        //private void Application_AuthenticateRequest(object sender, EventArgs e)
        //{

        //}

        //private void Application_Error(object sender, EventArgs e)
        //{

        //}

        //private void Session_End(object sender, EventArgs e)
        //{

        //}

        //private void Application_End(object sender, EventArgs e)
        //{

        //}
    }
}