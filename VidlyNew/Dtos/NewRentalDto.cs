using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidlyNew.Dtos
{
    public class NewRentalDto
    {
        public int CustomersId { get; set; }
        public DateTime DateReturned { get; set; }
        public CustomerDto Customer { get; set; }
        public List<int> MoviesId { get; set; }
    }
}