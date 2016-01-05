using System.Web;
using System.Web.Mvc;

namespace NAME_REPLACE.WebMvcApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}