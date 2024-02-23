using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.WebApi;
using WebApplication1.Value;

namespace WebApplication1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterSingleton<IValueProcessor, ValueProcessor>();
           
          //  DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

    }
}