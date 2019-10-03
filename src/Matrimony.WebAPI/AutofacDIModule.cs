using Autofac;
using AutoMapper;
using Matrimony.Database;
using Matrimony.Database.Repository;
using Matrimony.Database.Repository.Interfaces;
using Matrimony.Services;
using Matrimony.Services.Auth;
using Matrimony.Services.Interfaces;

namespace Matrimony.WebAPI
{
    public class AutofacDIModule : Module
    {
        public AutofacDIModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            // Automapper Profile
            builder.RegisterType<MappingProfile>().As<Profile>();

            // Register JWTFactory
            builder.RegisterType<JwtFactory>().As<IJwtFactory>();

            // Register Repositories
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ResourceRepository>().As<IResourceRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PortfolioRepository>().As<IPortfolioRepository>().InstancePerLifetimeScope();

            // Register Services
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
            builder.RegisterType<ResourceService>().As<IResourceService>().InstancePerLifetimeScope();
            builder.RegisterType<PortfolioService>().As<IPortfolioService>().InstancePerLifetimeScope();
        }
    }
}
