using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStore.Models
{
    public class ShoeStoreUser : IdentityUser<int>
    {
        public DateTime BirthDate { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }

        public string AvatarFileName { get; set; }

    }

    public class ShoeStoreRole : IdentityRole<int>
    {
        public bool CanEnterComment { get; set; }
        public bool CanDeleteComment { get; set; }

    }
}