using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MovieCustomerWithAuthMVC_app.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Customer Name is Mandatory")]
        [StringLength(40,ErrorMessage="Character cannot excced 40 Character" )]
        public string Name { get; set; }
        public bool ISSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name=" Membership Type")]
        public int MembershipTypeId { get; set; }

        [Display(Name = " Date of Birth")]
        [Min18YrsIfMember]
        public DateTime DOB { get; set; }

    }
}