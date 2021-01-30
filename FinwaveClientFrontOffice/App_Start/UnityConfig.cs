using FinwaveClientFrontOffice.Repositories;
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
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<ILoginRepository, LoginRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}