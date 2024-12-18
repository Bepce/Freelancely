using Freelancely.Infrastructure.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Freelancely.Infrastructure.Constants.DataConstants;

namespace Freelancely.Infrastructure.Data.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public EducationType EducationType { get; set; }

        [Required]
        public string SchoolName { get; set; }

        [Required]
        [Range(GraduationMinYear, GraduationMaxYear)]
        public int GraduationYear { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
    }
}