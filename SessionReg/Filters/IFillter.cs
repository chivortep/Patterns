using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SessionReg.Filters
{
    public interface IFilter
    {
        void ActivateFilter(HttpContext context);
    }
}
