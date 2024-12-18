using Freelancely.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancely.Infrastructure.Data.SeedData
{
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .HasOne(r => r.Writer)
                .WithMany(w => w.WittenReviews)
                .HasForeignKey(r => r.WriterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(r => r.Recipient)
                .WithMany(re => re.RecievedReviews)
                .HasForeignKey(r => r.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
