using FinwavePortal.Repositories;
using FinwavePortal.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FinwavePortal
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDashboardService, DashboardService>();
            container.RegisterType<IDashboardRepository, DashboardRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}