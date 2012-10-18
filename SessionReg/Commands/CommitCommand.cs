using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionReg.Commands
{
    public class CommitCommand:ICommand
    {
        public void Run(HttpContext context)
        {
            UnitOfWork.getCurrent().Commit();
        }
    }
}