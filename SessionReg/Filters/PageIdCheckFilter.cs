using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg.Filters
{
    public class PageIdCheckFilter: Filter
    {
        public PageIdCheckFilter(IFilter nextFilter)
        {
            this.nextFilter = nextFilter;
        }

        public override void activateFilter(HttpContext context)
        {
            if (context.Request.QueryString["PageId"] == null)
            {
                //context.Response.Redirect("~/Error.aspx?Errcode=1");
            }
            else if (context.Session == null)
                context.Response.Redirect("~/Error.aspx?Errcode=2");
            else if (context.Handler.ToString() == context.Session["LastHandler"].ToString()) //  Заплатка против повторного вызова
                return;
            else if (context.Session["PageId"] != null)
            {
                int pageId = int.Parse(context.Request.QueryString["PageId"]);
                int sessionId = int.Parse(context.Session["PageId"].ToString());

                if (sessionId != pageId + 1)
                {
                    context.Response.Redirect("~/Error.aspx?Errcode=4");
                }
                else
                {

                    sessionId++;
                    context.Session["PageId"] = sessionId;

                    context.Session["LastHandler"] = context.Handler.ToString(); //  Заплатка против повторного вызова
                }
            }
            //else
            //{
            //    // обработка обычной страницы, не входящей в процесс регистрации
            //}


            if (nextFilter != null)
            {
                nextFilter.activateFilter(context);
            }
        }
    }
}