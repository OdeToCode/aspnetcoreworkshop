using System;

namespace AtTheMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public DateTime ReleaseOn { get; set; }
    }
}