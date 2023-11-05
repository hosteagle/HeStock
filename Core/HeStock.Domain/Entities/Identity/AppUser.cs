using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeStock.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        /*  
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
      */
        public string NameSurname { get; set; }
        public List<AppRole>? Roles { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
