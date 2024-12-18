using System.ComponentModel.DataAnnotations;

namespace Freelancely.Core.Models.Post
{
    public class PostIndexServiceModel
    {
        
        public int Id { get; set; }

        public string PostTitle { get; set; } = string.Empty;

        public string PostBody { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string PostUserName = string.Empty;

        public string postUserId { get; set; } = string.Empty;
    }
}
