using Freelancely.Core.Models.Post;

namespace Freelancely.Core.Contracts.Post
{
    public interface IPostService 
    {
        Task<IEnumerable<PostIndexServiceModel>> LastThreePosts();

        Task<PostIndexServiceModel?> PostById(int id);

        Task<int> CreatePostAsync(CreatePostFormModel model, string userId);
    }
}
