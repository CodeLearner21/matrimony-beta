using Autofac;
using AutoMapper;
using Matrimony.Database;
using Matrimony.Database.Repository;
using Matrimony.Database.Repository.Interfaces;
using Matrimony.Services;
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

            // Register Repositories
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();

            // Register Services
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
        }
    }
}
