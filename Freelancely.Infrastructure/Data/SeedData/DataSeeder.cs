using Freelancely.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancely.Infrastructure.Data.SeedData
{
    internal class DataSeeder
    {
        public ApplicationUser FirstUser { get; set; }

        public Post FirstPost { get; set; }

        public Post SecoundPost { get; set; }

        public Post ThirdPost { get; set; }

        public DataSeeder()
        {
            SeedUser();
            SeedPost();
        }

        private void SeedUser()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            FirstUser = new ApplicationUser()
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
            var firstPostDate = new DateTime(2024, 9, 20, 8, 10, 2);
            var secondPostDate = new DateTime(2024, 10, 5, 16, 32, 8);
            var thirdPostDate = new DateTime(2024, 1, 8, 13, 3, 43);

            FirstPost = new Post()
            {
                Id = 1,
                Title = "Test",
                Description = "This is a test",
                PricePerHour = 20,
                PostCreationDate = firstPostDate.ToString(),
                WorkIndustryId = 1,
                UserId = FirstUser.Id
            };

            SecoundPost = new Post()
            {
                Id = 2,
                Title = "Test2",
                Description = "This is 2nd a test",
                PricePerHour = 30,
                PostCreationDate = secondPostDate.ToString(),
                WorkIndustryId = 1,
                UserId = FirstUser.Id
            };

            ThirdPost = new Post()
            {
                Id = 3,
                Title = "Photographer",
                Description = "Photographer looking for work in Sofia, Bulgaria",
                PricePerHour = 50,
                PostCreationDate = thirdPostDate.ToString(),
                WorkIndustryId = 1,
                UserId = FirstUser.Id
            };
        }
    }
}
