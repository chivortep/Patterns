using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using SessionReg.Filters;

namespace SessionReg
{
    public class MyHttpModule: IHttpModule, IRequiresSessionState
    {
        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(context_PreRequestHandlerExecute);
            context.PostRequestHandlerExecute += new EventHandler(context_PostRequestHandlerExecute);
        }

        void context_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;

            var postFilterChain = new CopyrightsFilter(null);
            postFilterChain.activateFilter(context);
        }

        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            var preFilterChain = new WelcomeFilter(new AddDateFilter(new PageIdCheckFilter(null)));
            preFilterChain.activateFilter(context);

            // Command
        }

        public void Dispose() { }
    }
}