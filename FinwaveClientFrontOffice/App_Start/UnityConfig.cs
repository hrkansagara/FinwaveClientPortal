using FinwaveClientFrontOffice.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FinwaveClientFrontOffice
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IDashboardService, DashboardService>();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IPortfolioService, PortfolioService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}