using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Paiger.Models
{
    public class Article
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public Uri Link { get; set; }

        [Required]
        [MaxLength(100)]
        public List<string> Genre { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Publisher { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }
    }


}
