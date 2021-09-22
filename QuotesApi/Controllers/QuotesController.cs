using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuotesApi.Data;
using QuotesApi.Models;

namespace QuotesApi.Controllers
{
    public class QuotesController : ApiController
    {
        QuotesDbContext quotesDbContext = new QuotesDbContext();

        // GET: api/Quotes
        public IEnumerable<Quote> Get()
        {
            return quotesDbContext.Quotes;
        }

        // GET: api/Quotes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Quotes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Quotes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Quotes/5
        public void Delete(int id)
        {
        }
    }
}
