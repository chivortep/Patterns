using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg.Filters
{
    public class AddDateFilter: Filter
    {
        public AddDateFilter(IFilter nextFilter)
        {
            this.nextFilter = nextFilter;
        }

        public override void activateFilter(HttpContext context)
        {
            context.Response.Write( DateTime.Now.ToShortDateString() + "<br />");

            if (nextFilter != null)
            {
                nextFilter.activateFilter(context);
            }
        }    
    }
}