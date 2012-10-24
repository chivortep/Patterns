using System.Web;

namespace SessionReg
{
    public sealed class CommitCommand : ICommand
    {
        public void Run(HttpContext context)
        {
            UnitOfWork.GetCurrent().Commit();
        }
    }
}