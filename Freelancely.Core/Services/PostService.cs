using Freelancely.Core.Contracts.Post;
using Freelancely.Core.Models.Post;
using Freelancely.Infrastructure.Common;
using Freelancely.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Freelancely.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository _repository;

        public PostService(IRepository repository)
        {
            _repository = repository;
        }

        //TODO: Rename the methods to give more context.
        public async Task<int> CreatePostAsync(PostFormModel model, string userId)
        {
            Post post = new Post
            {
                Title = model.Title,
                Description = model.Description,
                PricePerHour = model.Price,
                UserId = userId
            };

            await _repository.AddAsync(post);
            await _repository.SaveChagnesAsync();

            return post.Id;
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = await _repository.GetByIdAsync<Post>(postId);

            if (post != null && post.IsDeleted != true)
            {
                post.IsDeleted = true;

                await _repository.SaveChagnesAsync();
            }
        }

        public async Task<bool> IsPoster(int postId, string userId)
        {
            return await _repository
                .AllReadOnly<Post>()
                .AnyAsync(post => post.Id == postId && post.UserId == userId);

        }

        public async Task<IEnumerable<PostIndexServiceModel>> LastNinePosts()
        {
            return await _repository
                .AllReadOnly<Post>()
                .Where(p => p.IsDeleted == false)
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
            return await _repository
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

        public async Task UpdatePostAsync(PostFormModel model, int id)
        {
            var post = await _repository.GetByIdAsync<Post>(id);

            if (post != null)
            {
                post.Title = model.Title;
                post.Description = model.Description;
                post.PricePerHour = model.Price;

                await _repository.SaveChagnesAsync();
            }
        }

    }
}
