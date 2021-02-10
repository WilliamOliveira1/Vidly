using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MenbershipTypeId { get; set; }
    }
}