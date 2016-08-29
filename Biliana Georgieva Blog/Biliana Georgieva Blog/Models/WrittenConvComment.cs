using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biliana_Georgieva_Blog.Models
{
    public class WrittenConvComment
    {
        public WrittenConvComment()
        {
            this.Date = DateTime.Now;
        }
        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public ApplicationUser Author { get; set; }

       public WrittenConv WrittenConv { get; set; }
    }
}