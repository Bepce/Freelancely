using Freelancely.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancely.Infrastructure.Data.SeedData
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasOne(p => p.WorkIndustry)
                .WithMany(wi => wi.Posts)
                .HasForeignKey(p => p.WorkIndustryId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new DataSeeder();

            builder.HasData(new Post[] { data.FirstPost, data.SecoundPost, data.ThirdPost });
        }
    }
}
