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

        [Required(ErrorMessage = "Please enter customer's name")] // This is how we can overwrite the default error message
        [StringLength(255)] // This is how we limit the string length
        public string Name { get; set; }

        [Display(Name = "Date of birth")]
        [Min18YearsIfAMember]
        public DateTime Birthday { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypes MembershipType { get; set; }

        [Required] // This way we mark a fild that must be used by dataBase
        [Display(Name = "Membership Type")] // This display name overwrite the  name of the property
        public byte MenbershipTypeId { get; set; }
    }
}