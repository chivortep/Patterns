using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg.Filters
{
    public class CopyrightsFilter: Filter
    {
        public CopyrightsFilter(IFilter nextFilter)
        {
            this.nextFilter = nextFilter;
        }

        public override void activateFilter(HttpContext context)
        {
            context.Response.Write("This page is protected by a copyright law... I guess...");
            
            if (nextFilter != null)
            {
                nextFilter.activateFilter(context);
            }
        }
    }    
}