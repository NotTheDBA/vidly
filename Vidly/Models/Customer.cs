using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Subscribe")]
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Please select a Membership.")]
        public byte MembershipTypeId { get; set; }
 
        [Display(Name = "Date of Birth")]
        [NotFutureDate]
        [Min18YearsIfAMemberAttribute]
        public DateTime? BirthDate { get; set; }
    }
}