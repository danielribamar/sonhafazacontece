using System.Web;

namespace SFA.Core.Helpers
{
    public static class HttpHelper
    {
        public static void AddCookie(string name, string value)
        {
            HttpCookie mycookie = new HttpCookie(name);
            mycookie.Value = value;
            HttpContext.Current.Response.Cookies.Add(mycookie);
        }
    }
}
