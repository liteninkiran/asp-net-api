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
        public IHttpActionResult Get()
        {
            var quotes = quotesDbContext.Quotes;
            return Ok(quotes);
        }

        // GET: api/Quotes/5
        public IHttpActionResult Get(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);

            if (quote == null)
            {
                return BadRequest("Record not found");
            }

            return Ok(quote);
        }

        // POST: api/Quotes
        public IHttpActionResult Post([FromBody]Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newQuote = quotesDbContext.Quotes.Add(quote);
            quotesDbContext.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Quotes/5
        public IHttpActionResult Put(int id, [FromBody]Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateQuote = quotesDbContext.Quotes.FirstOrDefault(q => q.id == id);

            if (updateQuote == null)
            {
                return BadRequest("Record not found");
            }

            updateQuote.title = quote.title;
            updateQuote.author = quote.author;
            updateQuote.description = quote.description;

            quotesDbContext.SaveChanges();

            return Ok(updateQuote);
        }

        // DELETE: api/Quotes/5
        public IHttpActionResult Delete(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);

            if (quote == null)
            {
                return BadRequest("Record not found");
            }

            quotesDbContext.Quotes.Remove(quote);
            quotesDbContext.SaveChanges();

            return Ok("Record deleted successfully");
        }
    }
}
