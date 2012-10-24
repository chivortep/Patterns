using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using SessionReg.Filters;

namespace SessionReg
{
    public sealed class MyHttpModule : IHttpModule, IRequiresSessionState
    {
        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(Context_PreRequestHandlerExecute);
            context.PostRequestHandlerExecute += new EventHandler(Context_PostRequestHandlerExecute);
        }

        void Context_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;

            var postFilterChain = new CopyrightsFilter(null);
            postFilterChain.ActivateFilter(context);
        }

        void Context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            var preFilterChain = new WelcomeFilter(new AddDateFilter(new PageIdCheckFilter(null)));
            preFilterChain.ActivateFilter(context);
        }

        public void Dispose() { }
    }
}