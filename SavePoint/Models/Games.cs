// Import necessary libraries

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavePoint.Models
{
    public class Games
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Console { get; set; }
        public string Type { get; set; }
        public int ReleaseYear { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
