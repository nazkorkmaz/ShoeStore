using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStore.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        [StringLength(512)]
        [Display (Name="İsim")]
        public string Name { get; set; }
        [Display (Name ="Marka")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Ayakkabı Bedeni")]
        public string Size { get; set; }

        [Display(Name = "Fiyat")]
        public  Decimal Price { get; set; }

        [Display(Name = "Adet")]
        public int StockCount { get; set; }
        [Display (Name ="Kategori")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public virtual List<Comment> Comments { get; set; }
        public virtual List<ShoeImage> ShoeImages { get; set; }

    }
}
