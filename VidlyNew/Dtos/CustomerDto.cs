using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VidlyNew.Models;

namespace VidlyNew.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        // [min18YearMember]
        public DateTime? BirthDay { get; set; }

        public byte MembershipTypeId { get; set; } /// foreign key untuk ke membership(jika tipenya byte dia secara implicit Required data annotation)

    }
}