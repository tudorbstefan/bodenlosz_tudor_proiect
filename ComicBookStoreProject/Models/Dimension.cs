using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookStoreProject.Models
{
    public class Dimension
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Size is a Required field.")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Unit is a Required field.")]
        public string Unit { get; set; }
        public ICollection<Comicbook> Comicbooks { get; set; }
    }
}
