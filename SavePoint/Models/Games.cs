// Import necessary libraries

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SavePoint.Models
{
    public class Games
    {
        public int ID { get; set; }

        [Required]
        [StringLength(60)]
        public string Title { get; set; }

        [Required]
        public string Console { get; set; }

        [Required]
        public string Type { get; set; }

        [Display(Name = "Release Year")]
        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [StringLength(300, MinimumLength = 2)]
        public string Comment { get; set; }
    }
}
