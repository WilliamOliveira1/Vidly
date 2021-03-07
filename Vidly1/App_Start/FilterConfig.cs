using System.Web;
using System.Web.Mvc;

namespace Vidly1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); //This redirect to an error page when an exception is throw 
            //This make a change in the way taht we acess our application
            //Will need login to use the application
            filters.Add(new AuthorizeAttribute());

            //This is needed to run our application only in HTTPS 
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
