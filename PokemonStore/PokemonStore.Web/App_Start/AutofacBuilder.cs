using Autofac;

namespace PokemonStore.Web
{
    public static class AutofacBuilder
    {
        public static IContainer Build()
        {
            var container = new ContainerBuilder();
            
            container.RegisterModule<WireupModule>();

            return container.Build();
        }
    }
}