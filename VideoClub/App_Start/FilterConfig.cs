using System.Web;
using System.Web.Mvc;

namespace VideoClub
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());

            //para obligar a poder solo mirar nuestro sitio con htttps
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
