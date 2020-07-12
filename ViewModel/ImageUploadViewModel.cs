using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStore.ViewModel
{
    public class ImageUploadViewModel
    {
        public int ShoeId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
