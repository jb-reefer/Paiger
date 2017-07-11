using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace Paiger.Models
{
    public class ArticleModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public Uri Link { get; set; }

        [Required]
        [MaxLength(100)]
        public string Genre { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Publisher { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }


    }
}
