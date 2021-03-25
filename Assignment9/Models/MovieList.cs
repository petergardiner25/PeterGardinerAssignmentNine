using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Allows use of validation constraints
using System.ComponentModel.DataAnnotations;

namespace Assignment9.Models
{
    public class MovieList
    {
        //Attribute for database key
        [Key]
        [Required]
        public int MovieId { get; set; }

        //Model attributes and their validation constraints
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }

        //Question mark makes it nullable
        public bool? Edited { get; set; }
        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
    }
}