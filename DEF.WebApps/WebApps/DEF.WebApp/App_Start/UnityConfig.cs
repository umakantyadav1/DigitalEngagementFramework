using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using DEF.Services.Business.Interfaces.BriefingSource;
using DEF.Services.Business.Modules.BriefingSource;
using DEF.Services.Data;
using DEF.Services.Common.Repository.Interfaces.UOW;
using DEF.Services.Common.Repository.Modules.UOW;
using DEF.Services.Repository.Interfaces.BriefingSources;
using DEF.Services.Repository.Modules.BriefingSource;

namespace DEF.WebApp
{
    public static class UnityConfig
    {
        /// <summary>
        /// Unity Container.
        /// </summary>
        private static IUnityContainer container;

        /// <summary>
        /// Gets Unity Container.
        /// </summary>
        /// <value>Container value.</value>
        public static IUnityContainer Container
        {
            get
            {
                return container;
            }
        }

        public static void RegisterComponents()
        {
			 container = new UnityContainer();
            RegisterTypes(container);          
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        /// <summary>
        /// Registers the types.
        /// </summary>
        /// <param name="container">The container.</param>
        private static void RegisterTypes(IUnityContainer container)
        {
            // Data Context
            container.RegisterType<EquusEntities>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            //// BriefingSource
            container.RegisterType<IBriefingSourceRequestBusiness, BriefingSourceRequestBusiness>();
            container.RegisterType<IBriefingSourceRequestRepository, BriefingSourceRequestRepository>();
            //container.RegisterType<IHttpClientService, HttpClientService>(new InjectionConstructor("httpClientWebAPI"));
            //container.RegisterType<ILogger, EnterpriseLogger>(new ContainerControlledLifetimeManager());
        }
    }
}