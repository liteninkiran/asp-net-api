using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuotesApi.Models;

namespace QuotesApi.Controllers
{
    public class QuotesController : ApiController
    {
        static List<Quote> _quotes = new List<Quote>()
        {
            new Quote(){ id = 0, author = "Einstein", description = "Imagination is more important than knowledge", title = "Imagination" },
            new Quote(){ id = 1, author = "Einstein", description = "Imagination is more important than knowledge", title = "Imagination" },
        };

        public IEnumerable<Quote> Get()
        {
            return _quotes;
        }

        public void Post([FromBody]Quote quote)
        {
            _quotes.Add(quote);
        }

        public void Put(int id, [FromBody] Quote quote)
        {
            _quotes[id] = quote;
        }

        public void Delete(int id)
        {
            _quotes.RemoveAt(id);
        }
    }
}

