using System.ComponentModel.DataAnnotations;
using static Freelancely.Core.Constants.MessageConstants;
using static Freelancely.Infrastructure.Constants.DataConstants;

namespace Freelancely.Core.Models.Post
{
    public class PostFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PostTitleMaxLength, MinimumLength = PostTitleMinLength, ErrorMessage = LenghtInRangeMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PostDescriptionMaxLength, ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public int WorkIndustryId { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), PostPriceMinValue, PostPriceMaxValue, ConvertValueInInvariantCulture = true, ErrorMessage = PriceErrorMessage)]
        public decimal Price { get; set; }

        public IEnumerable<PostWorkIndustriesServiceModel> WorkIndustries { get; set; } = new List<PostWorkIndustriesServiceModel>();
    }
}
