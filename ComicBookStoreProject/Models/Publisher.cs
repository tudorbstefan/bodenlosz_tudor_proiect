using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComicBookStoreProject.Models
{
    public class Publisher
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is a Required field.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is a Required field.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Founded is a Required field.")]
        public int Founded { get; set; }
        public ICollection<Comicbook> Comicbooks { get; set; }
    }
}
