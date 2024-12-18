using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancely.Infrastructure.Data.Models
{

    public class ApplicationUser : IdentityUser
    {

        public IEnumerable<Education> Education { get; set; }

        public IEnumerable<Review> WittenReviews { get; set; } 

        public IEnumerable<Review> RecievedReviews { get; set; }
    }
}
