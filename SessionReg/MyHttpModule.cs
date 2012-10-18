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
            // context.Response.Write("Postfilters!!!");

            var postFilterChain = new CopyrightsFilter(null);
            postFilterChain.activateFilter(context);
        }

        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            var preFilterChain = new WelcomeFilter(new AddDateFilter(new PageIdCheckFilter(null)));
            preFilterChain.activateFilter(context);
        }

        //private void context_EndRequest(object sender, EventArgs e)
        //{
        //    HttpContext context = ((HttpApplication)sender).Context;
        //    if (context!=null)
        //    {
        //        HttpRequest request = context.Request;
        //        HttpResponse response = context.Response;
        //        HttpSessionState session = context.Session; 

        //        // основная обработка
        //        if (session != null && session["ThisPageID"] != null && session["NextPageID"] != null)
        //        {
        //            int thisId = Int32.Parse(session["ThisPageID"].ToString());
        //            int nextId = Int32.Parse(session["NextPageID"].ToString());
        //            if (nextId != thisId + 1)
        //            {
        //                response.Write("Нарушен порядок страниц! Измения не сохраняться!");
        //                response.Redirect("form" + (nextId - 1) + ".aspx", true);
        //            }
        //        }

        //        response.Write("Проверка!");
        //    }
        //}

        public void Dispose()
        {
            
        }
    }
}