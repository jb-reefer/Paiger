using System.ComponentModel.DataAnnotations;

namespace Paiger.Models
{
    public class Genre
    {
        [Required]
        public string Name { get; set; }
    }
}