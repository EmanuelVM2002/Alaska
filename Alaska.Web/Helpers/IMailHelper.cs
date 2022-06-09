using Alaska.Web.Common;

namespace Alaska.Web.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string toName, string toEmail, string subject, string body);
    }

}
