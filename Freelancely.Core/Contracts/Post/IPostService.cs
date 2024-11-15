using Freelancely.Core.Models.Post;

namespace Freelancely.Core.Contracts.Post
{
    public interface IPostService 
    {
        Task<IEnumerable<PostIndexServiceModel>> LastThreePosts();

        Task<PostIndexServiceModel?> PostById(int id);

        Task<int> CreatePostAsync(PostFormModel model, string userId);

        Task<bool> IsPoster(int postId, string  userId);

        Task UpdatePost(PostFormModel model, int id);
    }
}
