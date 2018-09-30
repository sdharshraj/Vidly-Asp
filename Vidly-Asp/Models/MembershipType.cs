using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly_Asp.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
    }
}