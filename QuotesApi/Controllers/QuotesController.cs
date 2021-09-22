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
        public Quote Get(int id)
        {
            return quotesDbContext.Quotes.Find(id);
        }

        // POST: api/Quotes
        public Quote Post([FromBody]Quote quote)
        {
            var newQuote = quotesDbContext.Quotes.Add(quote);
            quotesDbContext.SaveChanges();
            return newQuote;
        }

        // PUT: api/Quotes/5
        public Quote Put(int id, [FromBody]Quote quote)
        {
            var updateQuote = quotesDbContext.Quotes.FirstOrDefault(q => q.id == id);

            if (updateQuote == null)
            {
                return null;
            }

            updateQuote.title = quote.title;
            updateQuote.author = quote.author;
            updateQuote.description = quote.description;

            quotesDbContext.SaveChanges();

            return updateQuote;
        }

        // DELETE: api/Quotes/5
        public string Delete(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);

            if (quote == null)
            {
                return "Quote not found";
            }

            quotesDbContext.Quotes.Remove(quote);
            quotesDbContext.SaveChanges();

            return "Quote successfully deleted";
        }
    }
}
