using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Order> Get(DateTime? date)
        {
            var startDate = date ?? DateTime.Today;
            var endDate = startDate.AddDays(1);
            return base.Get().Where(w => w.Date >= startDate && w.Date < endDate);
        }
    }
}
