using Ecommerce_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_App.Areas.Identity.Data
{
    public class User : ApplicationUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
    }
}
