using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyNew.Models;
using VidlyNew.Dtos;
using System.ComponentModel.DataAnnotations;

namespace VidlyNew.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        /// <summary>
        /// ini disebut pure view model
        /// </summary>
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Add In Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }

        [Display(Name="Rental Price")]
        [Required]
        public int? RentalPrice { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Movie";
                return "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie mov)
        {
            Id = mov.Id;
            Name = mov.Name;
            ReleaseDate = mov.ReleaseDate;
            RentalPrice = mov.RentalPrice;
            NumberInStock = mov.NumberInStock;
            GenreId = mov.GenreId;
        }
        
    }
}