using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(Constants.DataConstants.User.FirstNameMaxLength)]
        [Comment("First name of the user")]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(Constants.DataConstants.User.LastNameMaxLength)]
        [Comment("Last name of the user")]
        public string LastName { get; set; } = null!;
    }
}
