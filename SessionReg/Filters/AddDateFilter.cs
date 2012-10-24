using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg.Filters
{
    public sealed class AddDateFilter : FilterBase
    {
        public AddDateFilter(IFilter nextFilter)
        {
            this.nextFilter = nextFilter;
        }

        public override void ActivateFilter(HttpContext context)
        {
            context.Response.Write( DateTime.Now.ToShortDateString() + "<br />");

            if (nextFilter != null)
            {
                nextFilter.ActivateFilter(context);
            }
        }    
    }
}