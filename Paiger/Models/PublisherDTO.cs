using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Paiger.Models
{
    public class PublisherDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public IFormFile Icon { get; set; }
    }

    public class GenreDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
