using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using SessionReg.Commands;

namespace SessionReg
{
    public class ResultsFrontController : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            //HttpSessionState session = context.Session;
            //if (session["Name"] != null &&
            //    session["Surname"] != null &&
            //    session["Age"] != null)
            //{
            //    ICommand command = new CreateCustomerCommand();
            //    command.Run(HttpContext.Current);
            //}    

            // формируем список из xslt и записываем
            context.Response.Write(TransformView.GenerateView());
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
}