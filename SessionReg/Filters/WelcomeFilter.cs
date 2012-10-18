using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg.Filters
{
    public class WelcomeFilter : Filter
    {
        public WelcomeFilter(IFilter nextFilter)
        {
            this.nextFilter = nextFilter;
        }

        public override void activateFilter(HttpContext context)
        {
            if (context.Request.QueryString["Name"] != null)
                context.Response.Write("Приветствуем тебя, " + context.Request.QueryString["Name"] + "<br />");

            if (nextFilter != null)
            {
                nextFilter.activateFilter(context);
            }
        }
    }
}