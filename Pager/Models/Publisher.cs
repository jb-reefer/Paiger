using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Pager.Models
{
    public class Publisher
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Uri Homepage { get; set; }

        [Required]
        public IFormFile Icon { get; set; }
    }
}
