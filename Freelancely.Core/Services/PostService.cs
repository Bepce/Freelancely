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
    }
}
