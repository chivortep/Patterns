using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg.Commands
{
    public interface ICommand
    {
        void Run(HttpContext context);
    }
}