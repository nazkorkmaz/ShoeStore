using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStore.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Display (Name ="Başlık")]
        public string Title { get; set; }
        [Display (Name ="Yorum")]
        public string Detail { get; set; }
        [Display (Name ="Değerlendirme")]
        public int? Rating { get; set; }
        [Display(Name = "Oluşturma Tarihi")]
        public DateTime CreatedDate { get; set; }
        public int ShoeId { get; set; }
        public Shoe Shoe { get; set; }
    }
}
