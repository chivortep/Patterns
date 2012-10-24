using System.Web;

namespace SessionReg
{
    public interface ICommand
    {
        void Run(HttpContext context);
    }
}