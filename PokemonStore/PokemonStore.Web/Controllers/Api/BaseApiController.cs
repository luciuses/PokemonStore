
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using rg.GenericRepository.Core;

namespace PokemonStore.Web.Controllers.Api
{
    public abstract class BaseApiController<T> : ApiController
        where T : class, IEntity, new()
    {
        private readonly IRepository<T> _repository;

        protected BaseApiController(IRepository<T> repository)
        {
            this._repository = repository;
        }

        public virtual IEnumerable<T> Get()
        {
            return this._repository.GetAll();
        }

        public virtual T Get(int id)
        {
            var item = this._repository.GetSingle(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return item;
        }

        [HttpPost]
        public virtual T Post([FromBody] T item)
        {
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            this._repository.Insert(item);
            this._repository.SaveChanges();

            return item;
        }

        public virtual void Put(int id, [FromBody] T item)
        {
            if (item == null || item.Id != id)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var find = this._repository.GetSingle(id);

            if (find == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            this._repository.Update(item);
            this._repository.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var foo = new T { Id = id };

            this._repository.Delete(foo);
            this._repository.SaveChanges();
        }
    }
}