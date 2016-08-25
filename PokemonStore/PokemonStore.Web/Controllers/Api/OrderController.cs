using System;
using System.Collections.Generic;
using System.Linq;
using PokemonStore.Web.Components;
using PokemonStore.Web.Models;
using rg.GenericRepository.Core;

namespace PokemonStore.Web.Controllers.Api
{
    public class OrderController : BaseApiController<Order>
    {
        private readonly ISendMailProvider _sendMailProvider;

        public OrderController(IRepository<Order> repository, ISendMailProvider sendMailProvider)
            : base(repository)
        {
            this._sendMailProvider = sendMailProvider;
        }

        public override Order Post(Order item)
        {
            item.Date = DateTime.Now;
            var result = base.Post(item);
            _sendMailProvider.Send(result.Email, $"Dear {result.Name}, You ordered pokemon with this Email.");
            return result;
        }

        public IEnumerable<Order> Get(DateTime? date)
        {
            var startDate = date ?? DateTime.Today;
            var endDate = startDate.AddDays(1);
            return base.Get().Where(w => w.Date >= startDate && w.Date < endDate);
        }
    }
}
