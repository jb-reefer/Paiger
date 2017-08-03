using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Pager.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Uri Homepage { get; set; }

        // Right now, holding them in blob storage. Alternative is
        //  to create an endpoint and return them from the db as raw bits
        //  This is a lot easier, if a few cents a month more expensive.
        [Required]
        public Uri IconUrl { get; set; }
    }

    public class PublisherDTO : Publisher
    {
        public IFormFile Icon { get; set; }
    }
}
