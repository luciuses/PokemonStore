using System.Data.Entity;
using System.Reflection;
using PokemonStore.Web.Components;
using Autofac;
using Autofac.Integration.WebApi;
using rg.GenericRepository.Core;
using rg.GenericRepository.Impl.EF;

namespace PokemonStore.Web
{
    public class WireupModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            containerBuilder.RegisterType<ApplicationContext>().As<DbContext>().AsSelf().InstancePerRequest();

            containerBuilder.RegisterGeneric(typeof(SqlRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();
        }
    }
}