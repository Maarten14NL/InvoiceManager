using Microsoft.Owin;
using Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(InvoiceManager.Startup))]
namespace InvoiceManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.Use((context, next) =>
            {
                if (context.Request.Headers.Any(k => k.Key.Contains("Origin")) && context.Request.Method == "OPTIONS")
                {
                    context.Response.StatusCode = 200;
                    return context.Response.WriteAsync("handled");
                }

                return next.Invoke();
            });
        }
    }

    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();

            filterContext.RequestContext.HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            string rqstMethod = HttpContext.Current.Request.Headers["Access-Control-Request-Method"];
            if (rqstMethod == "OPTIONS" || rqstMethod == "POST")
            {
                filterContext.RequestContext.HttpContext.Response.AppendHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
                filterContext.RequestContext.HttpContext.Response.AppendHeader("Access-Control-Allow-Headers", "X-Requested-With, Accept, Access-Control-Allow-Origin, Content-Type");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
