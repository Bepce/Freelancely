using System.ComponentModel.DataAnnotations;
using static Freelancely.Core.Constants.MessageConstants;
using static Freelancely.Infrastructure.Constants.DataConstants;


namespace Freelancely.Core.Models.WorkIndustry
{
    public class WorkIndustryFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(WorkIndustryNameMaxLength, MinimumLength = WorkIndustryNameMinLength, ErrorMessage = LenghtInRangeMessage)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(WorkIndustryDescriptionMaxLength, ErrorMessage = LengthMessage)]
        public string Description { get; set; }
    }
}
