using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly_Asp.Dtos
{
    public class ShowRentalDto
    {
        public int RentalId { get; set; }
        public string CustomerName { get; set; }
        public string MovieName { get; set; }
        public DateTime DateRented { get; set; }
    }
}