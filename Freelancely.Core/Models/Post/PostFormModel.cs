using System.ComponentModel.DataAnnotations;
using static Freelancely.Core.Constants.MessageConstants;
using static Freelancely.Infrastructure.Constants.DataConstants;

namespace Freelancely.Core.Models.Post
{
    public class PostFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PostTitleMaxLength, MinimumLength = PostTitleMinLength, ErrorMessage = LenghtMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PostDescriptionMaxLength, ErrorMessage = DescriptionLenghtMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), PostPriceMinValue, PostPriceMaxValue, ConvertValueInInvariantCulture = true, ErrorMessage = PriceErrorMessage)]
        public decimal? Price { get; set; }
    }
}
