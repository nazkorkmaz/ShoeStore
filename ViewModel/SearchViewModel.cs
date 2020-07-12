using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStore.ViewModel
{
    public class SearchViewModel
    {
        [Display(Name ="Arama Metni")]
        public string SearchText { get; set; }
        [Display(Name ="Açıklamalarda Ara")]
        public bool SearchInDescription { get; set; }
        [Display(Name = "Kategoriler")]
        public int? CategoryId { get; set; }
        [Display(Name = "Markalar")]
        public int? BrandId { get; set; }
        [Display(Name = "En Düşük")]
        public Decimal? MinPrice { get; set; }
        [Display(Name = "En Yüksek")]
        public Decimal? MaxPrice { get; set; }
        public List<Models.Shoe> Results { get; set; }
    }
}
