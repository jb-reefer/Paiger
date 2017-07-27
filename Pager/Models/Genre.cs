using System.ComponentModel.DataAnnotations;

namespace Pager.Models
{
    public class Genre
    {
        [Required]
        public string Name { get; set; }
    }
}