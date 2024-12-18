using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Freelancely.Infrastructure.Constants.DataConstants;

namespace Freelancely.Infrastructure.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PostTitleMaxLength)]
        public string Title { get; set; } 

        [Required]
        [MaxLength(PostDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = PostPricePerHour)]
        [Range(0.01, 999.99)]
        public decimal PricePerHour { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        [Required]
        public int WorkIndustryId { get; set; }

        [Required]
        public string PostCreationDate { get; set; } = DateTime.UtcNow.ToString();

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(WorkIndustryId))]
        public WorkIndustry WorkIndustry { get; set; } = null!;
        
    }
}
