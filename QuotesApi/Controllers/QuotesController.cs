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
        [HttpGet]
        public IHttpActionResult LoadQuotes(string sort)
        {
            IQueryable<Quote> quotes;

            switch (sort)
            {
                case "desc" : quotes = quotesDbContext.Quotes.OrderByDescending(q => q.created_at); break;
                case "asc"  : quotes = quotesDbContext.Quotes.OrderBy(q => q.created_at); break;
                default     : quotes = quotesDbContext.Quotes; break;
            }
            return Ok(quotes);
        }

        [HttpGet]
        [Route("api/Quotes/PagingQuote/{pageNumber=1}/{pageSize=2}")]
        public IHttpActionResult PagingQuote(int pageNumber, int pageSize)
        {
            var quotes = quotesDbContext.Quotes.OrderBy(q => q.id);

            return Ok(quotes.Skip((pageNumber - 1) * pageSize).Take(pageSize));
        }

        [HttpGet]
        [Route("api/Quotes/SearchQuote/{type=}")]
        public IHttpActionResult SearchQuote(string type)
        {
            var quotes = quotesDbContext.Quotes.Where(q => q.type.StartsWith(type));
            return Ok(quotes);
        }

        [HttpGet]
        [Route("api/Quotes/test/{id}")]
        public int test(int id)
        {
            return id;
        }

        // GET: api/Quotes/5
        [HttpGet]
        public IHttpActionResult LoadQuote(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);

            if (quote == null)
            {
                return BadRequest("Record not found");
            }

            return Ok(quote);
        }

        // POST: api/Quotes
        [HttpPost]
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
        [HttpPut]
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
        [HttpDelete]

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
