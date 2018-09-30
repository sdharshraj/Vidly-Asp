using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Asp.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}