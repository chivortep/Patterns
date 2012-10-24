using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg.Filters
{
    public abstract class FilterBase : IFilter
    {
        public IFilter nextFilter;

        public abstract void ActivateFilter(HttpContext context);
    }
}