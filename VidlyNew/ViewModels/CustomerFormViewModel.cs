using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyNew.Models;
using VidlyNew.Dtos;

namespace VidlyNew.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
       
        ///note:
        ///saat ini memnggunakan class yg ada pada entity, tetapi bisa di define lagi, karena hanya untuk keperluan view
        ///karena ada situasi dimana kita haru memisahkan keperluan view dengan entity karena bisa merusak class entiti/domain
        ///hanya untuk keprluan view (saat ini tidak ada dalam skenariio itu maka tidak apa-apa menggunakan domain clss) 
        ///contoh menggunakan clas view model sendiri ada pada view model movienya
    }
}