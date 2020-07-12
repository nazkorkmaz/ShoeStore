using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Bu alan zorunludur.")]
        [StringLength(100, MinimumLength =3, ErrorMessage="Bu alan 2 ile 100 karakter arasında olmalıdır.")]
        [Display (Name="Category İsmi")]
        public string Name { get; set; }
        public virtual List<Shoe> Shoes { get; set; }
    }
}
