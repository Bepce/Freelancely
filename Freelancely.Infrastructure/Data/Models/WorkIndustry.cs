using System.ComponentModel.DataAnnotations;
using static Freelancely.Infrastructure.Constants.DataConstants;

namespace Freelancely.Infrastructure.Data.Models
{
    public class WorkIndustry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(WorkIndustryNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(WorkIndustryDescriptionMaxLength)]
        public string Description { get; set; }

    }
}
