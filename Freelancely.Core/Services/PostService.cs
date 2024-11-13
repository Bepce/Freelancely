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

        public async Task<IEnumerable<PostIndexServiceModel>> LastThreePosts()
        {
            return await repository
                .AllReadOnly<Post>()
                .OrderByDescending(p => p.Id)
                .Take(3)
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
                    PostUserName = p.User.UserName
                })
                .FirstOrDefaultAsync();
        }
    }
}
