using System;
using PokemonStore.Web.Models;
using rg.GenericRepository.Core;

namespace PokemonStore.Web.Controllers.Api
{
    public class OrderController : BaseApiController<Order>
    {
        public OrderController(IRepository<Order> repository)
            : base(repository)
        {
        }

        public override Order Post(Order item)
        {
            item.Date = DateTime.Now;
            return base.Post(item);
        }
    }
}
