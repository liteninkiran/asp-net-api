using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuotesApi.Models
{
    public class Quote
    {
        public int id { get; set; }

        public string title { get; set; }

        public string author { get; set; }

        public string description { get; set; }

        public string type { get; set; }

        public DateTime created_at { get; set; }
    }
}
