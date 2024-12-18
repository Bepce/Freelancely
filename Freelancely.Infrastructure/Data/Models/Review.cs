using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Freelancely.Infrastructure.Constants.DataConstants;

namespace Freelancely.Infrastructure.Data.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(ReviewMaxValue,ReviewMaxValue)]
        public int Rating { get; set; }

        [Required]
        [MaxLength(ReviewMaxValue)]
        public string Comment { get; set; }

        [Required]
        public string WriterId { get; set; }

        [ForeignKey(nameof(WriterId))]
        public ApplicationUser Writer { get; set; } = null!;

        [Required]
        public string RecipientId { get; set; }

        [ForeignKey(nameof(RecipientId))]
        public ApplicationUser Recipient { get; set; } = null!;
    }
}