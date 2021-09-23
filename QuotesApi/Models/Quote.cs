using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QuotesApi.Models
{
    public class Quote
    {
        public int id { get; set; }

        [Required]
        [StringLength(25)]
        public string title { get; set; }

        [Required]
        [StringLength(20)]
        public string author { get; set; }

        [Required]
        [StringLength(500)]
        public string description { get; set; }

        [Required]
        [StringLength(50)]
        public string type { get; set; }

        [Required]
        public DateTime created_at { get; set; }
    }
}
