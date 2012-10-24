using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg.Filters
{
    public sealed class CopyrightsFilter : FilterBase
    {
        public CopyrightsFilter(IFilter nextFilter)
        {
            this.nextFilter = nextFilter;
        }

        public override void ActivateFilter(HttpContext context)
        {
            context.Response.Write("This page is protected by a copyright law... I guess...");
            
            if (nextFilter != null)
            {
                nextFilter.ActivateFilter(context);
            }
        }
    }    
}