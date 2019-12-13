using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;

namespace AnimalCrossing.Models
{
    public class Cat
    {
        
        public int CatId { get; set; }

        
        [Required(ErrorMessage = "All cats must have a name to be a pet")]
        public string Name { get; set; }

        public Gender? Gender { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Birth Date")]
        public DateTime? BirthDate { get; set; }

        public string ProfilePicture { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Description { get; set; }

        public int SpeciesId { get; set; }
        public Species Species { get; set; }

        public List<Review> Reviews { get; set; }

        public Cat()
        {
        }


    }

    public enum Gender { Male, Female, Other };
}
