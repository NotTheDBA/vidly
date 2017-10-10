using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    [DisplayName("Vidly Customer")]
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [DisplayName("Subscribe")]
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        //[DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime? BirthDate { get; set; }
    }
}