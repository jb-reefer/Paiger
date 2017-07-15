using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Paiger.Models
{
    public class PublisherDTO
    {
        public string Name { get; set; }
        public IFormFile Icon { get; set; }
    }

    public class GenreDTO
    {
        public string Name { get; set; }
    }
}
