using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookStoreProject.Models
{
    public class Comicbook
    {
        [Key]
        public int ISSN { get; set; }

        [Required(ErrorMessage = "Title is a Required field.")]
        [RegularExpression("^((?!^Title$)[a-zA-Z !#$%^&*()'])+$", ErrorMessage = "Title must be properly formatted.")]
        public string Title { get; set; }
        public int PublisherID { get; set; }
        [Display(Name = "Publisher")]
        public Publisher Publisher { get; set; }

        [Required(ErrorMessage = "Weight is a Required field.")]
        public decimal Weight { get; set; }
        public int DimensionID { get; set; }
        [Display(Name = "Dimension")]
        public Dimension Dimension { get; set; }

        [Required(ErrorMessage = "Decimal is a Required field.")]
        public int Pages { get; set; }

        [Required(ErrorMessage = "Age is a Required field.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Price is a Required field.")]
        public decimal Price { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublishingDate { get; set; }
    }
}
