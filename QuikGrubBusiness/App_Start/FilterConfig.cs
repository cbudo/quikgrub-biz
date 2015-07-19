using System.Web;
using System.Web.Mvc;

namespace QuikGrubBusiness
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
