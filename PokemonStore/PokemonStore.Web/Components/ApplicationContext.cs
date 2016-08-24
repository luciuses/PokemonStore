using System.Data.Entity;
using PokemonStore.Web.Models;

namespace PokemonStore.Web.Components
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("PokemonStoreDataBase")
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}