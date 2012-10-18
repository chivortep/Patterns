using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg.Filters
{
    public abstract class Filter: IFilter
    {
        public IFilter nextFilter;

        public abstract void activateFilter(HttpContext context);
    }
}