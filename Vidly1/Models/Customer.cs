using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypes MembershipType { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte MenbershipTypeId { get; set; }
    }
}