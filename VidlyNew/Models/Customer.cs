using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidlyNew.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }//// navigation prop, untuk assosiasikan antar porperty,type to type(many to many, etc)

        [Display(Name = "Birth Of Date")]
        [min18YearMember]
        public DateTime? BirthDay { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } /// foreign key untuk ke membership(jika tipenya byte dia secara implicit Required data annotation)

    }
}