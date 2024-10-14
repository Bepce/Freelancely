using Freelancely.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancely.Infrastructure.Data.SeedData
{
    internal class SeedData
    {
        public IdentityUser FirstUser { get; set; }

        public Post FirstPost { get; set; }

        public Post SecoundPost { get; set; }

        public SeedData()
        {
            SeedUser();
            SeedPost();
        }

        private void SeedUser()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            FirstUser = new IdentityUser()
            {
                Id = "2680690b-1683-45cb-8a99-cf0f9a9258aa",
                UserName = "first@free.com",
                NormalizedUserName = "first@free.com",
                Email = "first@free.com",
                NormalizedEmail = "first@free.com"
            };

            FirstUser.PasswordHash = 
                hasher.HashPassword(FirstUser, "first");
        }

        private void SeedPost()
        {
            FirstPost = new Post()
            {
                Id = 1,
                Title = "Test",
                Description = "This is a test",
                PricePerHour = 20,
                UserId = FirstUser.Id,
            };

            SecoundPost = new Post()
            {
                Id = 2,
                Title = "Test2",
                Description = "This is 2nd a test",
                PricePerHour = 30,
                UserId = FirstUser.Id,
            };
        }
    }
}
