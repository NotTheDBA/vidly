using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    [DisplayName("Vidly Customer")]
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes;
        public Customer Customer { get; set; }
    }
}