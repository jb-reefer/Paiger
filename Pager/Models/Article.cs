using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pager.Models
{
    public class Article
    {
        public int Id
        {
            get;
            set;
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public Uri Link { get; set; }

  //      [Required]
  //      [MaxLength(100)]
		//[ForeignKey("Id")]
		public List<Genre> Genres { get; set; }

  //      [Required]
  //      [MinLength(5)]
  //      [MaxLength(50)]
		//[ForeignKey("Id")]
		public string Publisher { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }
    }


}
