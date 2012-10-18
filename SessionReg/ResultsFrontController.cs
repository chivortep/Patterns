using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using SessionReg.Commands;

namespace SessionReg
{
    public class ResultsFrontController : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpSessionState session = context.Session;
            if (session["Name"] != null &&
                session["Surname"] != null &&
                session["Age"] != null)
            {
                ICommand command = new SaveCommand();
                command.Run(HttpContext.Current);
            }     

            context.Response.Write(TransformView.GenerateView());

        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
}