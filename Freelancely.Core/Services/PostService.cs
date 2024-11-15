using Freelancely.Core.Contracts.Post;
using Freelancely.Core.Models.Post;
using Freelancely.Infrastructure.Common;
using Freelancely.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Freelancely.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository repository;

        public PostService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<int> CreatePostAsync(PostFormModel model, string userId)
        {
            Post post = new Post
            {
                Title = model.Title,
                Description = model.Description,
                PricePerHour = model.Price,
                UserId = userId
            };

            await repository.AddAsync(post);
            await repository.SaveChagnesAsync();

            return post.Id;
        }

        public async Task<bool> IsPoster(int postId, string userId)
        {
            return await repository
                .AllReadOnly<Post>()
                .Where(post => post.Id == postId)
                .Where(post => post.UserId == userId)
                .AnyAsync();
                                    
        }

        public async Task<IEnumerable<PostIndexServiceModel>> LastNinePosts()
        {
            return await repository
                .AllReadOnly<Post>()
                .OrderByDescending(p => p.Id)
                .Take(9)
                .Select(p => new PostIndexServiceModel
                {
                    Id = p.Id,
                    PostTitle = p.Title,
                    PostBody = p.Description,
                    Price = p.PricePerHour,
                    PostUserName = p.User.UserName
                })
                .ToListAsync();
        }

        public async Task<PostIndexServiceModel?> PostById(int id)
        {
            return await repository
                .AllReadOnly<Post>()
                .Where(p => p.Id == id)
                .Select(p => new PostIndexServiceModel
                {
                    Id = p.Id,
                    PostTitle = p.Title,
                    PostBody = p.Description,
                    Price = p.PricePerHour,
                    PostUserName = p.User.UserName,
                    postUserId = p.UserId
                })
                .FirstOrDefaultAsync();
        }

        public async Task UpdatePost(PostFormModel model, int id)
        {
            var post = await repository.GetByIdAsync<Post>(id);

            if (post != null)
            {
                post.Title = model.Title;
                post.Description = model.Description;
                post.PricePerHour = model.Price;

                await repository.SaveChagnesAsync();
            }
        }
    }
}
