using Freelancely.Core.Models.Post;

namespace Freelancely.Core.Contracts.Post
{
    public interface IPostService 
    {
        Task<IEnumerable<PostIndexServiceModel>> LastThreePosts();
    }
}
