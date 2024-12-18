using Freelancely.Core.Contracts.WorkIndustry;
using Freelancely.Core.Models.Post;
using Freelancely.Core.Models.WorkIndustry;
using Freelancely.Infrastructure.Common;
using Freelancely.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Freelancely.Core.Services
{
    public class WorkIndustryService : IWorkIdustryService
    {
        private readonly IRepository _repository;

        public WorkIndustryService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateWorkIndustryAsync(WorkIndustryFormModel model)
        {
            WorkIndustry workIndustry = new WorkIndustry
            {
                Name = model.Name,
                Description = model.Description,
            };
            
            await _repository.AddAsync(workIndustry);
            await _repository.SaveChagnesAsync();
        }

        public async Task<IEnumerable<PostWorkIndustriesServiceModel>> GetWorkIndustries()
        {
            return await _repository
                .All<WorkIndustry>()
                .Select(c => new PostWorkIndustriesServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public Task UpdateWorkIndustry(WorkIndustryFormModel model, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> WorkIndustryExists(string name)
        {
            return await _repository
                .AllReadOnly<WorkIndustry>()
                .AnyAsync(x  => x.Name == name);
        }
    }
}
