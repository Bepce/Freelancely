using Freelancely.Core.Models.Post;

namespace Freelancely.Core.Contracts.Post
{
    public interface IPostService 
    {
        Task<IEnumerable<PostIndexServiceModel>> GetPostsAsync(int count);

        Task<PostIndexServiceModel?> PostById(int id);

        Task<int> CreatePostAsync(PostFormModel model, string userId);

        Task<bool> IsCurrentUserPostOwnerAsync(int postId, string  userId);

        Task UpdatePostAsync(PostFormModel model, int id);

        Task DeletePostAsync(int postId);
    }
}
