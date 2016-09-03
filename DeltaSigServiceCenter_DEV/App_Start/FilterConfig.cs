using System.Web;
using System.Web.Mvc;

namespace DeltaSigServiceCenter_DEV
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
