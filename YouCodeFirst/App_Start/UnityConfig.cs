using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebSite.Repositories;

namespace WebSite
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IDocumentRepository, DocumentRepository>();
            container.RegisterType<IOperationRepository, OperationRepository>();
            container.RegisterType<IClientRepository, ClientRepository>();
            container.RegisterType<IApplicationRepository, ApplicationRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}