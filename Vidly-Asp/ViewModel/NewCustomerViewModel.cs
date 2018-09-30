using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Asp.Models;

namespace Vidly_Asp.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}