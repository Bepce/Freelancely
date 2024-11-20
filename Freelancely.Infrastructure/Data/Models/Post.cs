using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Freelancely.Infrastructure.Constants.DataConstants;

namespace Freelancely.Infrastructure.Data.Models
{
    public class Post
    {
        [Key]
        public  int Id { get; set; }

        [Required]
        [MaxLength(PostTitleMaxLength)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(PostDescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = PostPricePerHour)]
        [Range(0.01, 999.99)]
        public decimal? PricePerHour { get; set; }

        [Required]
        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
