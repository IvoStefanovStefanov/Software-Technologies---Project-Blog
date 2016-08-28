using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biliana_Georgieva_Blog.Models
{
    public class H2HComment
    {
        public H2HComment()
        {
            this.Date = DateTime.Now;
        }
        public int Id { get; set; }

        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public ApplicationUser Author { get; set; }

        public H2HPost H2HPost { get; set; }
    }
}