using Microsoft.Practices.Unity;
using prmToolkit.NotificationPattern;
using System.Data.Entity;
using XProjeto.Domain.Interfaces.Repositories;
using XProjeto.Domain.Interfaces.Repositories.Base;
using XProjeto.Domain.Interfaces.Services;
using XProjeto.Domain.Services;
using XProjeto.Infra.Persistence;
using XProjeto.Infra.Persistence.Repositories;
using XProjeto.Infra.Persistence.Repositories.Base;
using XProjeto.Infra.Transactions;

namespace XProjeto.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {

            container.RegisterType<DbContext, XGameContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            //container.RegisterType(typeof(IServiceBase<,>), typeof(ServiceBase<,>));

            container.RegisterType<IServiceJogador, ServiceJogador>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceJogo, ServiceJogo>(new HierarchicalLifetimeManager());

            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            container.RegisterType<IRepositoryJogador, RepositoryJogador>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryJogo, RepositoryJogo>(new HierarchicalLifetimeManager());

        }
    }
}
