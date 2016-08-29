﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biliana_Georgieva_Blog.Models
{
    public class H2HPost
    {
        public H2HPost()
        {
            this.Date = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength (200)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Required]
        public DateTime Date { get; set; }

       //[Required]
        public ApplicationUser Author { get; set; }

        public ICollection<H2HComment> H2HComments { get; set; }
    }
}