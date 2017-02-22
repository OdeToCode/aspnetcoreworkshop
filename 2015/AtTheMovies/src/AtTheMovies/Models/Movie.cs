using System;
using System.ComponentModel.DataAnnotations;

namespace AtTheMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Title { get; set; }
        public int Length { get; set; }

        [Display(Name="Date of Release")]
        public DateTime ReleaseOn { get; set; }
    }
}